from collections import defaultdict


class EventSystem:
    class Callback:
        def __init__(self, callback, order):
            self.callback = callback
            self.order = order

    def __init__(self):
        self.__callbacks = defaultdict(list)

    def subscribe(self, event, callback, order=0):
        callbacks: list = self.__callbacks[event]
        callbacks.append(EventSystem.Callback(callback, order))
        callbacks.sort(key=lambda c: c.order)

    def publish(self, event):
        callbacks = self.__callbacks[type(event)]
        for callback in callbacks:
            callback.callback(event)
