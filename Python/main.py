from event_system import Event, EventSystem

def callback_create_tx10(event):
    print(f"{event}, order 10")


def callback_create_block10(event):
    print(f"{event}, order 10")


class Test:
    def __init__(self, order):
        self.order = order

    def callback_create_tx(self, event):
        print(f"{event}, order {self.order}")

    def callback_create_block(self, event):
        print(f"{event}, order {self.order}")


event_system = EventSystem()

test = Test(0)

event_system.subscribe(Event.CreateBlock, test.callback_create_block, test.order)
event_system.subscribe(Event.CreateBlock, callback_create_block10, 10)

event_system.subscribe(Event.CreateTx, test.callback_create_tx, test.order)
event_system.subscribe(Event.CreateTx, callback_create_tx10, 10)
event_system.unsubscribe(Event.CreateTx, test.callback_create_tx)


e = Event.CreateBlock(block_hash="123")
event_system.publish(e)

e = Event.CreateTx(tx_hash="abc")
event_system.publish(e)
