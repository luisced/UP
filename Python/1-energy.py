from dataclasses import dataclass


@dataclass
class Ticket:
    userName: str
    watts: float
    total: float = 0
    base_price: float = 50
    pricing_tiers = {
        50: 1,
        100: 1.2,
        200: 1.3,
        300: 1.4,
        400: 1.5
    }

    def __post_init__(self) -> None:
        if not self.userName:
            raise ValueError("Name is required.")
        if self.watts <= 0:
            raise ValueError("Watts must be a positive number.")
        self.total = self.calculate()

    def calculate(self) -> float:
        '''Calculate the total price of the bill'''
        total_price = self.base_price
        for usage, multiplier in self.pricing_tiers.items():
            if self.watts > usage:
                total_price *= multiplier
        return total_price

    def breakdown(self):
        base = f"Base price: {self.base_price}$"
        usage = f"Additional charge for usage above 50 watts: {self.total - self.base_price}$"
        return base + "\n" + usage

    @classmethod
    def get_pricing_tiers(cls):
        return cls.pricing_tiers

    def __str__(self):
        return f'{self.userName}, your total bill is {self.total}$'


def main() -> None:
    name = input("Enter your name: ")
    watts = float(input("How many Watt/hr you have in your bill: "))
    ticket = Ticket(name, watts)
    print(ticket)
    print("\nBill breakdown:")
    print(ticket.breakdown())


if __name__ == '__main__':
    main()
