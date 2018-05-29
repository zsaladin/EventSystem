from event_system import Event, EventSystem

def callback_create_tx0(event):
    print(f"{event}, order 0")


def callback_create_tx10(event):
    print(f"{event}, order 10")


def callback_create_block0(event):
    print(f"{event}, order 0")


def callback_create_block10(event):
    print(f"{event}, order 10")


event_system = EventSystem()

event_system.subscribe(Event.CreateTx, callback_create_tx10, 10)
event_system.subscribe(Event.CreateTx, callback_create_tx0)

event_system.subscribe(Event.CreateBlock, callback_create_block0)
event_system.subscribe(Event.CreateBlock, callback_create_block10, 10)

e = Event.CreateBlock(block_hash="123")
event_system.publish(e)

e = Event.CreateTx(tx_hash="abc")
event_system.publish(e)
