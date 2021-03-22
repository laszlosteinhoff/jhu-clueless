// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Network.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

public static partial class NetworkService
{
  static readonly string __ServiceName = "NetworkService";

  static readonly grpc::Marshaller<global::CreateGameRequest> __Marshaller_CreateGameRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CreateGameRequest.Parser.ParseFrom);
  static readonly grpc::Marshaller<global::GameUpdate> __Marshaller_GameUpdate = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GameUpdate.Parser.ParseFrom);
  static readonly grpc::Marshaller<global::ConnectRequest> __Marshaller_ConnectRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ConnectRequest.Parser.ParseFrom);
  static readonly grpc::Marshaller<global::StartGameRequest> __Marshaller_StartGameRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::StartGameRequest.Parser.ParseFrom);
  static readonly grpc::Marshaller<global::Acknowledgement> __Marshaller_Acknowledgement = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Acknowledgement.Parser.ParseFrom);
  static readonly grpc::Marshaller<global::Move> __Marshaller_Move = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Move.Parser.ParseFrom);
  static readonly grpc::Marshaller<global::DisproveRequest> __Marshaller_DisproveRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::DisproveRequest.Parser.ParseFrom);
  static readonly grpc::Marshaller<global::HistoryRequest> __Marshaller_HistoryRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::HistoryRequest.Parser.ParseFrom);
  static readonly grpc::Marshaller<global::GameHistory> __Marshaller_GameHistory = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GameHistory.Parser.ParseFrom);

  static readonly grpc::Method<global::CreateGameRequest, global::GameUpdate> __Method_createGame = new grpc::Method<global::CreateGameRequest, global::GameUpdate>(
      grpc::MethodType.ServerStreaming,
      __ServiceName,
      "createGame",
      __Marshaller_CreateGameRequest,
      __Marshaller_GameUpdate);

  static readonly grpc::Method<global::ConnectRequest, global::GameUpdate> __Method_connectToGame = new grpc::Method<global::ConnectRequest, global::GameUpdate>(
      grpc::MethodType.ServerStreaming,
      __ServiceName,
      "connectToGame",
      __Marshaller_ConnectRequest,
      __Marshaller_GameUpdate);

  static readonly grpc::Method<global::StartGameRequest, global::Acknowledgement> __Method_startGame = new grpc::Method<global::StartGameRequest, global::Acknowledgement>(
      grpc::MethodType.Unary,
      __ServiceName,
      "startGame",
      __Marshaller_StartGameRequest,
      __Marshaller_Acknowledgement);

  static readonly grpc::Method<global::Move, global::Acknowledgement> __Method_submitMove = new grpc::Method<global::Move, global::Acknowledgement>(
      grpc::MethodType.Unary,
      __ServiceName,
      "submitMove",
      __Marshaller_Move,
      __Marshaller_Acknowledgement);

  static readonly grpc::Method<global::DisproveRequest, global::Acknowledgement> __Method_disprove = new grpc::Method<global::DisproveRequest, global::Acknowledgement>(
      grpc::MethodType.Unary,
      __ServiceName,
      "disprove",
      __Marshaller_DisproveRequest,
      __Marshaller_Acknowledgement);

  static readonly grpc::Method<global::HistoryRequest, global::GameHistory> __Method_requestHistory = new grpc::Method<global::HistoryRequest, global::GameHistory>(
      grpc::MethodType.Unary,
      __ServiceName,
      "requestHistory",
      __Marshaller_HistoryRequest,
      __Marshaller_GameHistory);

  /// <summary>Service descriptor</summary>
  public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
  {
    get { return global::NetworkReflection.Descriptor.Services[0]; }
  }

  /// <summary>Base class for server-side implementations of NetworkService</summary>
  [grpc::BindServiceMethod(typeof(NetworkService), "BindService")]
  public abstract partial class NetworkServiceBase
  {
    public virtual global::System.Threading.Tasks.Task createGame(global::CreateGameRequest request, grpc::IServerStreamWriter<global::GameUpdate> responseStream, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

    public virtual global::System.Threading.Tasks.Task connectToGame(global::ConnectRequest request, grpc::IServerStreamWriter<global::GameUpdate> responseStream, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

    public virtual global::System.Threading.Tasks.Task<global::Acknowledgement> startGame(global::StartGameRequest request, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

    public virtual global::System.Threading.Tasks.Task<global::Acknowledgement> submitMove(global::Move request, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

    public virtual global::System.Threading.Tasks.Task<global::Acknowledgement> disprove(global::DisproveRequest request, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

    public virtual global::System.Threading.Tasks.Task<global::GameHistory> requestHistory(global::HistoryRequest request, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

  }

  /// <summary>Client for NetworkService</summary>
  public partial class NetworkServiceClient : grpc::ClientBase<NetworkServiceClient>
  {
    /// <summary>Creates a new client for NetworkService</summary>
    /// <param name="channel">The channel to use to make remote calls.</param>
    public NetworkServiceClient(grpc::ChannelBase channel) : base(channel)
    {
    }
    /// <summary>Creates a new client for NetworkService that uses a custom <c>CallInvoker</c>.</summary>
    /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
    public NetworkServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
    {
    }
    /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
    protected NetworkServiceClient() : base()
    {
    }
    /// <summary>Protected constructor to allow creation of configured clients.</summary>
    /// <param name="configuration">The client configuration.</param>
    protected NetworkServiceClient(ClientBaseConfiguration configuration) : base(configuration)
    {
    }

    public virtual grpc::AsyncServerStreamingCall<global::GameUpdate> createGame(global::CreateGameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return createGame(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual grpc::AsyncServerStreamingCall<global::GameUpdate> createGame(global::CreateGameRequest request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncServerStreamingCall(__Method_createGame, null, options, request);
    }
    public virtual grpc::AsyncServerStreamingCall<global::GameUpdate> connectToGame(global::ConnectRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return connectToGame(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual grpc::AsyncServerStreamingCall<global::GameUpdate> connectToGame(global::ConnectRequest request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncServerStreamingCall(__Method_connectToGame, null, options, request);
    }
    public virtual global::Acknowledgement startGame(global::StartGameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return startGame(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual global::Acknowledgement startGame(global::StartGameRequest request, grpc::CallOptions options)
    {
      return CallInvoker.BlockingUnaryCall(__Method_startGame, null, options, request);
    }
    public virtual grpc::AsyncUnaryCall<global::Acknowledgement> startGameAsync(global::StartGameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return startGameAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual grpc::AsyncUnaryCall<global::Acknowledgement> startGameAsync(global::StartGameRequest request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncUnaryCall(__Method_startGame, null, options, request);
    }
    public virtual global::Acknowledgement submitMove(global::Move request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return submitMove(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual global::Acknowledgement submitMove(global::Move request, grpc::CallOptions options)
    {
      return CallInvoker.BlockingUnaryCall(__Method_submitMove, null, options, request);
    }
    public virtual grpc::AsyncUnaryCall<global::Acknowledgement> submitMoveAsync(global::Move request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return submitMoveAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual grpc::AsyncUnaryCall<global::Acknowledgement> submitMoveAsync(global::Move request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncUnaryCall(__Method_submitMove, null, options, request);
    }
    public virtual global::Acknowledgement disprove(global::DisproveRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return disprove(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual global::Acknowledgement disprove(global::DisproveRequest request, grpc::CallOptions options)
    {
      return CallInvoker.BlockingUnaryCall(__Method_disprove, null, options, request);
    }
    public virtual grpc::AsyncUnaryCall<global::Acknowledgement> disproveAsync(global::DisproveRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return disproveAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual grpc::AsyncUnaryCall<global::Acknowledgement> disproveAsync(global::DisproveRequest request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncUnaryCall(__Method_disprove, null, options, request);
    }
    public virtual global::GameHistory requestHistory(global::HistoryRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return requestHistory(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual global::GameHistory requestHistory(global::HistoryRequest request, grpc::CallOptions options)
    {
      return CallInvoker.BlockingUnaryCall(__Method_requestHistory, null, options, request);
    }
    public virtual grpc::AsyncUnaryCall<global::GameHistory> requestHistoryAsync(global::HistoryRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return requestHistoryAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual grpc::AsyncUnaryCall<global::GameHistory> requestHistoryAsync(global::HistoryRequest request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncUnaryCall(__Method_requestHistory, null, options, request);
    }
    /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
    protected override NetworkServiceClient NewInstance(ClientBaseConfiguration configuration)
    {
      return new NetworkServiceClient(configuration);
    }
  }

  /// <summary>Creates service definition that can be registered with a server</summary>
  /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
  public static grpc::ServerServiceDefinition BindService(NetworkServiceBase serviceImpl)
  {
    return grpc::ServerServiceDefinition.CreateBuilder()
        .AddMethod(__Method_createGame, serviceImpl.createGame)
        .AddMethod(__Method_connectToGame, serviceImpl.connectToGame)
        .AddMethod(__Method_startGame, serviceImpl.startGame)
        .AddMethod(__Method_submitMove, serviceImpl.submitMove)
        .AddMethod(__Method_disprove, serviceImpl.disprove)
        .AddMethod(__Method_requestHistory, serviceImpl.requestHistory).Build();
  }

  /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
  /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
  /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
  /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
  public static void BindService(grpc::ServiceBinderBase serviceBinder, NetworkServiceBase serviceImpl)
  {
    serviceBinder.AddMethod(__Method_createGame, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::CreateGameRequest, global::GameUpdate>(serviceImpl.createGame));
    serviceBinder.AddMethod(__Method_connectToGame, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::ConnectRequest, global::GameUpdate>(serviceImpl.connectToGame));
    serviceBinder.AddMethod(__Method_startGame, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::StartGameRequest, global::Acknowledgement>(serviceImpl.startGame));
    serviceBinder.AddMethod(__Method_submitMove, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Move, global::Acknowledgement>(serviceImpl.submitMove));
    serviceBinder.AddMethod(__Method_disprove, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::DisproveRequest, global::Acknowledgement>(serviceImpl.disprove));
    serviceBinder.AddMethod(__Method_requestHistory, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::HistoryRequest, global::GameHistory>(serviceImpl.requestHistory));
  }

}
#endregion
