import grpc
import logging
from concurrent import futures
from time import sleep

from generated_sources import Network_pb2_grpc
from generated_sources import Network_pb2


class NetworkGrpcService(Network_pb2_grpc.NetworkServiceServicer):

    def __init__(self):
        self.users = {}

    def createGame(self, request, context):

        print("Create game request received")

        try:
            while True:
                sleep(5)
                self.users[request.playerID] += 1
                yield Network_pb2.GameUpdate()
        except:
            print("Exception, dropped out")

    def connectToGame(self, request, context):

        print("Create game request received")

        try:
            while True:
                sleep(5)
                self.users[request.playerID] += 1
                yield Network_pb2.GameUpdate()
        except:
            print("Exception, dropped out")

    def startGame(self, request, context):
        print("Received start game request: " + str(request))
        return Network_pb2.Acknowledgement(success=True, message="Received request: " + str(request))

    def submitMove(self, request, context):
        print("Received submit move request: " + str(request))
        return Network_pb2.Acknowledgement(success=True, message="Received request: " + str(request))

    def disprove(self, request, context):
        print("Received disprove request: " + str(request))
        return Network_pb2.Acknowledgement(success=True, message="Received request: " + str(request))

    def requestHistory(self, request, context):
        print("Received game history request: " + str(request))
        game_history = Network_pb2.GameHistory()
        sample_update = Network_pb2.GameUpdate(gameID=1, playerID=1, number=1,
                                               type=Network_pb2.GameUpdate.Type.INITIATE)
        game_history.updates.extend([sample_update])
        return Network_pb2.GameHistory()



def serve():
    server = grpc.server(
        futures.ThreadPoolExecutor(max_workers=10),
        options=[('grpc.keepalive_time_ms', 1000)])
    Network_pb2_grpc.add_NetworkServiceServicer_to_server(NetworkGrpcService(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    server.wait_for_termination()


if __name__ == '__main__':
    logging.basicConfig()
    serve()
