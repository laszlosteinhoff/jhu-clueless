using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Grpc.Core;

public class DebugUtil : MonoBehaviour
{
    private NetworkService.NetworkServiceClient client;
    private TextMeshProUGUI heartbeatText;

    // Start is called before the first frame update
    void Start()
    {
        // Get the text field to update the heartbeat counter
        heartbeatText = GameObject.Find("Heartbeat Text").GetComponent<TextMeshProUGUI>();

        // Create the client connection to the grpc server
        List<ChannelOption> options = new List<ChannelOption>();
        options.Add(new ChannelOption("grpc.keepalive_time_ms", 1000));
        Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure, options);
        client = new NetworkService.NetworkServiceClient(channel);

        // Make the async call to the heartbeat streaming endpoing
        AsyncServerStreamingCall<HeartbeatResponse> replies = client.heartbeat(new HeartbeatRequest { PlayerID = 1 });
        HandleReplies(replies);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void HandleReplies(AsyncServerStreamingCall<HeartbeatResponse> replies)
    {
        // Wait for each response, then update the text field
        IAsyncStreamReader<HeartbeatResponse> stream = replies.ResponseStream;
        while (await stream.MoveNext())
        {
            heartbeatText.SetText(stream.Current.Message + ": " + stream.Current.Count);
        }
    }
}
