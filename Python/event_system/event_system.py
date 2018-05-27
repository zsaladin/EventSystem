from collections import defaultdict



class EventSystem:
    def __init__(self):
        self.__callbacks = defaultdict(list)

    def subscribe(self, event, callback:callable):
        callbacks = self.__callbacks[event]
        callbacks.append(callback)

    def publish(self, event, *args, **kwargs):
        callbacks = self.__callbacks[event]
        for callback in callbacks:
            callback(*args, **kwargs)
