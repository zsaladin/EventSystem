from event_system import Event, EventSystem

def callback_create_tx0(tx_hash):
    print(f"{tx_hash}, order 0")


def callback_create_tx10(tx_hash):
    print(f"{tx_hash}, order 10")


def callback_create_block0(tx_block):
    print(f"{tx_block}, order 0")


def callback_create_block10(tx_block):
    print(f"{tx_block}, order 10")


event_system = EventSystem()

event_system.subscribe(Event.create_tx, callback_create_tx10, 10)
event_system.subscribe(Event.create_tx, callback_create_tx0)

event_system.subscribe(Event.create_block, callback_create_block0)
event_system.subscribe(Event.create_block, callback_create_block10, 10)

event_system.publish(Event.create_tx, "123")
event_system.publish(Event.create_block, tx_block="abc")
