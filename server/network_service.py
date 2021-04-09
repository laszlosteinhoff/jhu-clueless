import grpc
import logging
import queue
from concurrent import futures
from time import sleep
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker

from generated_sources import Network_pb2_grpc
from generated_sources import Network_pb2 as nw
from models.Account import Account


# GRPC server implementation
class NetworkGrpcService(Network_pb2_grpc.NetworkServiceServicer):

    # Holds a message queue for each connected user to distribute updates
    streams = {}
    # An empty marker update that can be inserted into a queue to terminate the stream
    terminate_flag = nw.GameUpdate()

    def __init__(self):
        engine = create_engine("mysql://clueless:Password1@localhost/clueless")
        self.session = sessionmaker(bind=engine)()

    # Create a new hosted game
    def createGame(self, request, context):

        print("Create game request received")
        account = self.__get_account(request.playerID)

        ###
        # Code to create game and player entries goes here

        player = 1  # FIXME this should be the newly created player object
        ###

        return self.__stream_updates(player)

    # Connect user to pending or in-progress game and subscribe to all game updates
    def connectToGame(self, request, context):

        print("Connect to game request received")
        account = self.__get_account(request.playerID)

        ###
        # Code to fetch the existing game they are trying to join and create new player entry goes here

        player = 2  # FIXME this should be the newly created player object
        ###

        return self.__stream_updates(player)

    # Move a pending game to in-progress once enough players are connected
    def startGame(self, request, context):
        print("Received start game request")
        self.__get_account(request.playerID)

        ###
        # Switch game status to started, fetch all players, and send them the initiate message

        players = [1, 2]  # FIXME this will be the list of players queried from the database

        for player in players:
            # FIXME this is just a test message with hard coded values, it should be replaced
            if player in NetworkGrpcService.streams.keys():
                NetworkGrpcService.streams[player].put(
                    nw.GameUpdate(gameID=1, playerID=player, number=1, type=nw.GameUpdate.INITIATE))

        return nw.Acknowledgement(success=True, message="Received request: " + str(request))

    # Validate, record, and react to the actions of a player turn
    def submitMove(self, request, context):
        print("Received submit move request: " + str(request))
        account = self.__get_account(request.playerID)

        # Forward appropriate information about the turn to all players in the game through their stream
        players = [1, 2]  # FIXME these should be the players from the database
        for player in players:
            # FIXME these are just test messages
            # Note that ONLY the player taking the turn should see which card was disproven. Leave it blank for the rest
            turn = nw.PlayerTurn(playerID=1, room=1, suspect=1, weapon=1, location=1, disprovingPlayer=2)
            if player in NetworkGrpcService.streams.keys():
                NetworkGrpcService.streams[player].put(
                    nw.GameUpdate(gameID=1, playerID=player, number=1, type=nw.GameUpdate.TURN, turn=turn))

        # Check which player needs to disprove and send them the prompt
        disprovingPlayer = 2
        if disprovingPlayer in NetworkGrpcService.streams.keys():
            NetworkGrpcService.streams[player].put(
                nw.GameUpdate(gameID=1, playerID=player, number=1, type=nw.GameUpdate.PROMPT))

        return nw.Acknowledgement(success=True, message="Received request: " + str(request))

    # Process a player's request to disprove one of the suggestions
    def disprove(self, request, context):
        print("Received disprove request: " + str(request))
        self.__get_account(request.playerID)

        # Pass on the disproven card to the player whose turn it was

        player = 1  # FIXME this should be the player whose turn it is
        if player in NetworkGrpcService.streams.keys():
            NetworkGrpcService.streams[player].put(nw.GameUpdate(gameID=1, playerID=player, number=1, type=nw.GameUpdate.TURN))

        return nw.Acknowledgement(success=True, message="Received request: " + str(request))

    # Return the full history for a game so far if the player is allowed to see it
    def requestHistory(self, request, context):
        print("Received game history request: " + str(request))
        self.__get_account(request.playerID)
        game_history = nw.GameHistory()
        sample_update = nw.GameUpdate(gameID=1, playerID=1, number=1,
                                               type=nw.GameUpdate.Type.INITIATE)
        game_history.updates.extend([sample_update])
        return nw.GameHistory()

    def __get_account(self, account_id):
        account = self.session.query(Account).filter_by(id=account_id).first()
        return account

    # This registers a new queue to send messages to this player into the streams dictionary, and then sets
    # up a loop to forward game updates on to that player when they appear in the queue
    def __stream_updates(self, player):
        # Create a queue that will be passed any updates to forward to the client
        update_queue = queue.Queue()
        # Add queue to dictionary of active connections, keyed by game and player ID
        NetworkGrpcService.streams[player] = update_queue
        try:
            while True:
                # Wait for an update to appear on the queue
                update = update_queue.get()
                # If the received update is the terminate flag, break out and terminate the stream
                if update == NetworkGrpcService.terminate_flag:
                    break
                print(f'Sending a new update out to stream for player {player}')
                yield update
        except:
            del NetworkGrpcService.streams[player]
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
