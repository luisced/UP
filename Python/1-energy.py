from dataclasses import dataclass


@dataclass
class Ticket:
    userName: str
    watts: float
    total: float

    def __post_init__(self):
        self.total = self.calculate()

    def calculate(self):
        if self.watts < 50 and self.watts > 0:
            price = 50
        elif self.watts > 49 and self.watts < 100:
            price = 50 * 1.2
        elif self.watts > 99 and self.watts < 200:
            price = 50 * 1.3
        elif self.watts > 199 and self.watts < 300:
            price = 50 * 1.4
        elif self.watts >= 400:
            price = 50 * 1.5
        else:
            pass
        return price

    def __str__(self):
        return f'{self.userName} you have to pay {self.total}'


def main():
    name = input("Enter your name: ")
    watts = float(input("How many Watt/hr you have in your bill: "))
    ticket = Ticket(name, watts, 0)
    print(ticket)


if __name__ == '__main__':
    main()
