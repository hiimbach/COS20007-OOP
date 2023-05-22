class Counter:
    def __init__(self, name):
        self.__name = name
        self.__count = 0
    def Incremend(self):
        self.__count += 1
    def Reset(self):
        self.__count = 0

    @property
    def Ticks(self):
        return self.__count

    @property 
    def Name(self):
        return self.__name
    @Name.setter
    def Name(self, new_name):
        self.__name = new_name

class Clock:
    def __init__(self):
        self.__second = Counter("Second")
        self.__minute = Counter("Minute")
        self.__hour = Counter("Hour")

    def Tick(self):
        self.__second.Incremend()
        if self.__second.Ticks == 60:
            self.__minute.Incremend()
            self.__second.Reset()
            if self.__minute.Ticks == 60:
                self.__hour.Incremend()
                self.__minute.Reset()

    @property 
    def ReadTime(self):
        return f'{self.__hour.Ticks:02d}:{self.__minute.Ticks:02d}:{self.__second.Ticks:02d}'

    def ResetClock(self):
        self.__second.Reset()
        self.__minute.Reset()
        self.__hour.Reset()


def mult(n,x):
    if x == 1:
        return n
    else:
        return n + mult(n, x-1)

print(mult(5, 5))
