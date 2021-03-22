using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grpc.Core;

public class NetworkManager : MonoBehaviour
{
    private string host = "ec2-34-220-213-135.us-west-2.compute.amazonaws.com:50051";
    private Channel channel;
    private NetworkService.NetworkServiceClient client;

    private void Start()
    {
        List<ChannelOption> options = new List<ChannelOption>();
        options.Add(new ChannelOption("grpc.keepalive_time_ms", 1000));
        channel = new Channel(host, ChannelCredentials.Insecure, options);
        client = new NetworkService.NetworkServiceClient(channel);
    }

    private void Update()
    {
        // The whole update method should be removed, this is just to show
        // how to make a call for the skeletal increment
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    // Send request to create a game and subscribe to updates for that game
    public void CreateGame()
    {
        Debug.Log("Sending create game request");
        HandleUpdates(client.createGame(new CreateGameRequest { PlayerID = 1, Name = "Demo" }));
    }

    public void StartGame()
    {
        Debug.Log("Sending start game request");
        Acknowledgement response = client.startGame(new StartGameRequest { PlayerID = 1, GameID = 1 });
        Debug.Log("Received response: " + response.Message);
    }

    // Example of an ongoing stream of replies from the demo heartbeat method
    async void HandleUpdates(AsyncServerStreamingCall<GameUpdate> updates)
    {
        // Wait for each response, then update the text field
        IAsyncStreamReader<GameUpdate> stream = updates.ResponseStream;
        while (await stream.MoveNext())
        {
            // Handle any incoming game updates here
        }
    }

    private void OnDisable()
    {
        channel.ShutdownAsync().Wait();
    }
}
        
