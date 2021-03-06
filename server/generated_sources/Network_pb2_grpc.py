# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
"""Client and server classes corresponding to protobuf-defined services."""
import grpc

import generated_sources.Network_pb2 as Network__pb2


class NetworkServiceStub(object):
    """Missing associated documentation comment in .proto file."""

    def __init__(self, channel):
        """Constructor.

        Args:
            channel: A grpc.Channel.
        """
        self.createGame = channel.unary_stream(
                '/NetworkService/createGame',
                request_serializer=Network__pb2.CreateGameRequest.SerializeToString,
                response_deserializer=Network__pb2.GameUpdate.FromString,
                )
        self.connectToGame = channel.unary_stream(
                '/NetworkService/connectToGame',
                request_serializer=Network__pb2.ConnectRequest.SerializeToString,
                response_deserializer=Network__pb2.GameUpdate.FromString,
                )
        self.startGame = channel.unary_unary(
                '/NetworkService/startGame',
                request_serializer=Network__pb2.StartGameRequest.SerializeToString,
                response_deserializer=Network__pb2.Acknowledgement.FromString,
                )
        self.submitMove = channel.unary_unary(
                '/NetworkService/submitMove',
                request_serializer=Network__pb2.Move.SerializeToString,
                response_deserializer=Network__pb2.Acknowledgement.FromString,
                )
        self.disprove = channel.unary_unary(
                '/NetworkService/disprove',
                request_serializer=Network__pb2.DisproveRequest.SerializeToString,
                response_deserializer=Network__pb2.Acknowledgement.FromString,
                )
        self.requestHistory = channel.unary_unary(
                '/NetworkService/requestHistory',
                request_serializer=Network__pb2.HistoryRequest.SerializeToString,
                response_deserializer=Network__pb2.GameHistory.FromString,
                )
        self.accuse = channel.unary_unary(
                '/NetworkService/accuse',
                request_serializer=Network__pb2.Accusation.SerializeToString,
                response_deserializer=Network__pb2.Acknowledgement.FromString,
                )


class NetworkServiceServicer(object):
    """Missing associated documentation comment in .proto file."""

    def createGame(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def connectToGame(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def startGame(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def submitMove(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def disprove(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def requestHistory(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def accuse(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')


def add_NetworkServiceServicer_to_server(servicer, server):
    rpc_method_handlers = {
            'createGame': grpc.unary_stream_rpc_method_handler(
                    servicer.createGame,
                    request_deserializer=Network__pb2.CreateGameRequest.FromString,
                    response_serializer=Network__pb2.GameUpdate.SerializeToString,
            ),
            'connectToGame': grpc.unary_stream_rpc_method_handler(
                    servicer.connectToGame,
                    request_deserializer=Network__pb2.ConnectRequest.FromString,
                    response_serializer=Network__pb2.GameUpdate.SerializeToString,
            ),
            'startGame': grpc.unary_unary_rpc_method_handler(
                    servicer.startGame,
                    request_deserializer=Network__pb2.StartGameRequest.FromString,
                    response_serializer=Network__pb2.Acknowledgement.SerializeToString,
            ),
            'submitMove': grpc.unary_unary_rpc_method_handler(
                    servicer.submitMove,
                    request_deserializer=Network__pb2.Move.FromString,
                    response_serializer=Network__pb2.Acknowledgement.SerializeToString,
            ),
            'disprove': grpc.unary_unary_rpc_method_handler(
                    servicer.disprove,
                    request_deserializer=Network__pb2.DisproveRequest.FromString,
                    response_serializer=Network__pb2.Acknowledgement.SerializeToString,
            ),
            'requestHistory': grpc.unary_unary_rpc_method_handler(
                    servicer.requestHistory,
                    request_deserializer=Network__pb2.HistoryRequest.FromString,
                    response_serializer=Network__pb2.GameHistory.SerializeToString,
            ),
            'accuse': grpc.unary_unary_rpc_method_handler(
                    servicer.accuse,
                    request_deserializer=Network__pb2.Accusation.FromString,
                    response_serializer=Network__pb2.Acknowledgement.SerializeToString,
            ),
    }
    generic_handler = grpc.method_handlers_generic_handler(
            'NetworkService', rpc_method_handlers)
    server.add_generic_rpc_handlers((generic_handler,))


 # This class is part of an EXPERIMENTAL API.
class NetworkService(object):
    """Missing associated documentation comment in .proto file."""

    @staticmethod
    def createGame(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_stream(request, target, '/NetworkService/createGame',
            Network__pb2.CreateGameRequest.SerializeToString,
            Network__pb2.GameUpdate.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def connectToGame(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_stream(request, target, '/NetworkService/connectToGame',
            Network__pb2.ConnectRequest.SerializeToString,
            Network__pb2.GameUpdate.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def startGame(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/NetworkService/startGame',
            Network__pb2.StartGameRequest.SerializeToString,
            Network__pb2.Acknowledgement.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def submitMove(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/NetworkService/submitMove',
            Network__pb2.Move.SerializeToString,
            Network__pb2.Acknowledgement.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def disprove(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/NetworkService/disprove',
            Network__pb2.DisproveRequest.SerializeToString,
            Network__pb2.Acknowledgement.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def requestHistory(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/NetworkService/requestHistory',
            Network__pb2.HistoryRequest.SerializeToString,
            Network__pb2.GameHistory.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def accuse(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/NetworkService/accuse',
            Network__pb2.Accusation.SerializeToString,
            Network__pb2.Acknowledgement.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)
