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
    private int count;

    public UIManager uiManager;

    private void Start()
    {
        count = 0;
        List<ChannelOption> options = new List<ChannelOption>();
        options.Add(new ChannelOption("grpc.keepalive_time_ms", 1000));
        channel = new Channel(host, ChannelCredentials.Insecure, options);
        client = new NetworkService.NetworkServiceClient(channel);
    }

    // Send request to create a game and subscribe to updates for that game
    public void CreateGame()
    {
        Debug.Log("Sending create game request");
        HandleUpdates(client.createGame(new CreateGameRequest { PlayerID = 1, Name = "Demo" }));

        // Switch the UI to wait for game start
        uiManager.WaitingForStart();
    }

    public void ConnectToGame()
    {
        Debug.Log("Sending connect to game request");
        HandleUpdates(client.createGame(new CreateGameRequest { PlayerID = 1, Name = "Demo" }));
    }

    public void StartGame()
    {
        Debug.Log("Sending start game request");
        Acknowledgement response = client.startGame(new StartGameRequest { PlayerID = 1, GameID = 1 });
        LogAcknowledgement(response);
    }

    public void SubmitMove()
    {
        Debug.Log("Submitting move");
        Acknowledgement response = client.submitMove(new Move { PlayerID = 1, Location = 4, Suspect = 12, Weapon = 18 });
        LogAcknowledgement(response);
    }

    public void Disprove()
    {
        Debug.Log("Disproving a suggestion");
        Acknowledgement response = client.disprove(new DisproveRequest { PlayerID = 1, GameID = 1, Card = 12 });
        LogAcknowledgement(response);
    }

    public void RequestHistory()
    {
        Debug.Log("Requesting full game history");
        GameHistory response = client.requestHistory(new HistoryRequest { PlayerID = 1, GameID = 1 });
    }

    private void LogAcknowledgement(Acknowledgement response)
    {
        count++;
    }

    // Example of an ongoing stream of replies from the demo heartbeat method
    async void HandleUpdates(AsyncServerStreamingCall<GameUpdate> updates)
    {
        // Wait for each response, then update the text field
        IAsyncStreamReader<GameUpdate> stream = updates.ResponseStream;
        while (await stream.MoveNext())
        {
            // Handle any incoming game updates here
            logText.SetText("Response (" + count + "): " + stream.Current.ToString());
        }
    }

    private void OnDisable()
    {
        channel.ShutdownAsync().Wait();
    }
}
        
