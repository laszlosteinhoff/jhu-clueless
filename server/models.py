from sqlalchemy import Column, Integer, String, ForeignKey, Table, Enum
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import relationship
import enum

Base = declarative_base()


class Account(Base):
    __tablename__ = 'account'

    id = Column(Integer, primary_key=True)
    name = Column(String)


class CardType(enum.Enum):
    WEAPON = 'weapon'
    SUSPECT = 'suspect'
    ROOM = 'room'


class Card(Base):
    __tablename__ = 'card'

    id = Column(Integer, primary_key=True)
    card_type = Column(Enum(CardType))


class GameStatus(enum.Enum):
    CREATED = 'created'
    STARTED = 'started'
    COMPLETED = 'completed'


class Game(Base):
    __tablename__ = 'game'

    id = Column(Integer, primary_key=True)
    status = Column(Enum(GameStatus))
    weapon_id = Column(Integer, ForeignKey('card.id'))
    suspect_id = Column(Integer, ForeignKey('card.id'))
    room_id = Column(Integer, ForeignKey('card.id'))

    weapon = relationship('', foreign_keys=[weapon_id])
    suspect = relationship('Card', foreign_keys=[suspect_id])
    room = relationship('Card', foreign_keys=[room_id])
Card

player_card_association = Table('player_card', Base.metadata,
                                Column('player_id', Integer, ForeignKey('player.id')),
                                Column('card_id', Integer, ForeignKey('card.id')))


class Player(Base):
    __tablename__ = 'player'

    id = Column(Integer, primary_key=True)
    account_id = Column(Integer, ForeignKey('account.id'))
    game_id = Column(Integer, ForeignKey('game.id'))
    number = Column(Integer)
    name = Column(String)

    account = relationship('Account')
    game = relationship('Game')
    cards = relationship('Card', secondary=player_card_association)


class Move(Base):
    __tablename__ = 'move'

    id = Column(Integer, primary_key=True)
    player_id = Column(Integer, ForeignKey('player.id'))
    number = Column(Integer)
    location = Column(Integer)
    weapon_id = Column(Integer, ForeignKey('card.id'))
    suspect_id = Column(Integer, ForeignKey('card.id'))
    room_id = Column(Integer, ForeignKey('card.id'))

    player = relationship('Player')
    weapon = relationship('Card', foreign_keys=[weapon_id])
    suspect = relationship('Card', foreign_keys=[suspect_id])
    room = relationship('Card', foreign_keys=[room_id])
