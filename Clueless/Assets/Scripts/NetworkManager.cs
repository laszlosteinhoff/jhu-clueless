using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grpc.Core;
using TMPro;

public class NetworkManager : MonoBehaviour
{
    public TextMeshProUGUI logText;
    // private string host = "clueless.ideologyhole.com:50051";
    private string host = "localhost:50051";
    private Channel channel;
    private NetworkService.NetworkServiceClient client;

    public TMP_InputField nameInput;
    public TMP_InputField gameIdInput;
    public Game game;

    private void Start()
    {
        List<ChannelOption> options = new List<ChannelOption>();
        options.Add(new ChannelOption("grpc.keepalive_time_ms", 1000));
        channel = new Channel(host, ChannelCredentials.Insecure, options);
        client = new NetworkService.NetworkServiceClient(channel);
    }

    // Send request to create a game and subscribe to updates for that game
    public void CreateGame()
    {
        Debug.Log("Sending create game request with username: " + nameInput.text);
        HandleUpdates(client.createGame(new CreateGameRequest 
        { 
            PlayerID = 1, 
            Name = nameInput.text 
        }));

        // Switch the UI to wait for game start
        game.WaitForStart();
    }

    public void ConnectToGame()
    {
        Debug.Log("Sending connect to game request with username: " + nameInput.text 
            + " and gameID: " + gameIdInput.text);
        HandleUpdates(client.createGame(new CreateGameRequest { PlayerID = 1, Name = "Demo" }));
        HandleUpdates(client.connectToGame(new ConnectRequest
        {
            GameID = int.Parse(gameIdInput.text),
            PlayerID = 1,
            Name = nameInput.text
        }));

        // Switch the UI to wait for game start
        game.WaitForStart();
    }

    public void StartGame()
    {
        Debug.Log("Sending start game request");
        Acknowledgement response = client.startGame(new StartGameRequest 
        { 
            PlayerID = 1, 
            GameID = game.gameID 
        });
        LogAcknowledgement(response);
    }

    public void SubmitMove()
    {
        Debug.Log("Submitting move");
        Acknowledgement response = client.submitMove(new Move 
        { 
            PlayerID = game.player.id, 
            Location = 4, 
            Suspect = 12, 
            Weapon = 18 
        });
        LogAcknowledgement(response);
    }

    public void Disprove(Card card)
    {
        Debug.Log("Disproving card: " + card.id);
        Acknowledgement response = client.disprove(new DisproveRequest { 
            PlayerID = game.player.id, 
            GameID = game.gameID, 
            Card = card.id });
        LogAcknowledgement(response);
    }

    public void RequestHistory()
    {
        Debug.Log("Requesting full game history");
        GameHistory response = client.requestHistory(new HistoryRequest { PlayerID = 1, GameID = 1 });
    }

    private void LogAcknowledgement(Acknowledgement response)
    {
        Debug.Log("Received request Acknowledgement: " + response);
    }

    // Example of an ongoing stream of replies from the demo heartbeat method
    async void HandleUpdates(AsyncServerStreamingCall<GameUpdate> updates)
    {
        IAsyncStreamReader<GameUpdate> stream = updates.ResponseStream;
        while (await stream.MoveNext())
        {
            Debug.Log("Received GameUpdate: " + stream.Current.ToString());
            game.HandleUpdate(stream.Current);
        }
    }

    private void OnDisable()
    {
        channel.ShutdownAsync().Wait();
    }
}
        
