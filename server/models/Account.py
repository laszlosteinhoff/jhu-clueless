from sqlalchemy import Column, Integer, String
from sqlalchemy.ext.declarative import declarative_base


class Account(declarative_base()):
    __tablename__ = 'account'

    id = Column(Integer, primary_key=True)
    name = Column(String)
