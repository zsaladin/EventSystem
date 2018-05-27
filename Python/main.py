from event_system import Event, EventSystem

def callback_create_tx(tx_hash):
    print(tx_hash)


def callback_create_block(tx_block):
    print(tx_block)


event_system = EventSystem()
event_system.subscribe(Event.create_tx, callback_create_tx)
event_system.subscribe(Event.create_block, callback_create_block)

event_system.publish(Event.create_tx, "123")
event_system.publish(Event.create_block, tx_block="abc")
