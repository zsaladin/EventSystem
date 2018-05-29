from collections import namedtuple

class Event:
    CreateTx = namedtuple('CreateTx', 'tx_hash')
    CreateBlock = namedtuple('CreateBlock', 'block_hash')
