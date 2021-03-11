import grpc
import logging
from concurrent import futures
from time import sleep

from generated_sources import Network_pb2_grpc
from generated_sources import Network_pb2


class NetworkGrpcService(Network_pb2_grpc.NetworkServiceServicer):

    def __init__(self):
        self.users = {}

    def heartbeat(self, request, context):

        print("Heartbeat request received")

        # If this is a new user ID, add them to the dict and start their count at 0
        if request.playerID not in self.users.keys():
            self.users[request.playerID] = 0

        try:
            while True:
                sleep(5)
                self.users[request.playerID] += 1
                print("Yielding again")
                yield Network_pb2.HeartbeatResponse(success=True, count=self.users[request.playerID], message="Success")
        except:
            print("Exception, dropped out")


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
