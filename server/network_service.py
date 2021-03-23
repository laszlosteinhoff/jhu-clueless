import grpc
import logging
from concurrent import futures
from time import sleep
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker

from generated_sources import Network_pb2_grpc
from generated_sources import Network_pb2
from models.Account import Account


# GRPC server implementation
class NetworkGrpcService(Network_pb2_grpc.NetworkServiceServicer):

    def __init__(self):
        self.users = {}
        engine = create_engine("mysql://clueless:Password1@localhost/clueless")
        self.session = sessionmaker(bind=engine)()

    # Create a new hosted game
    def createGame(self, request, context):

        print("Create game request received")

        try:
            while True:
                sleep(5)
                self.users[request.playerID] += 1
                yield Network_pb2.GameUpdate()
        except:
            print("Exception, dropped out")

    # Connect user to pending or in-progress game and subscribe to all game updates
    def connectToGame(self, request, context):

        print("Create game request received")

        try:
            while True:
                sleep(5)
                self.users[request.playerID] += 1
                yield Network_pb2.GameUpdate()
        except:
            print("Exception, dropped out")

    # Move a pending game to in-progress once enough players are connected
    def startGame(self, request, context):
        print("Received start game request: " + str(request))
        self.__get_account(request.playerID)
        return Network_pb2.Acknowledgement(success=True, message="Received request: " + str(request))

    # Validate, record, and react to the actions of a player turn
    def submitMove(self, request, context):
        print("Received submit move request: " + str(request))
        return Network_pb2.Acknowledgement(success=True, message="Received request: " + str(request))

    # Process a player's request to disprove one of the suggestions
    def disprove(self, request, context):
        print("Received disprove request: " + str(request))
        return Network_pb2.Acknowledgement(success=True, message="Received request: " + str(request))

    # Return the full history for a game so far if the player is allowed to see it
    def requestHistory(self, request, context):
        print("Received game history request: " + str(request))
        game_history = Network_pb2.GameHistory()
        sample_update = Network_pb2.GameUpdate(gameID=1, playerID=1, number=1,
                                               type=Network_pb2.GameUpdate.Type.INITIATE)
        game_history.updates.extend([sample_update])
        return Network_pb2.GameHistory()

    def __get_account(self, account_id):
        print("Querying db for account with user id " + str(account_id))
        account = self.session.query(Account).filter_by(id=account_id).first()
        print("Found user account named: " + account.name)


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
