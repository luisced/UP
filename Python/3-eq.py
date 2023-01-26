from dataclasses import dataclass
from math import e
import math


@dataclass
class formula:
    x: float = 0
    result: float = 0

    def __post_init__(self) -> None:
        self.result = self.calculate()

    def calculate(self) -> float:
        '''Calculate the result of the formula
        f(x) = e^(-|x|) * Cos(2 * pi * x)")'''
        return (e**(-abs(self.x)) * math.cos(2 * math.pi * self.x))

    def __str__(self) -> str:
        return f'f({self.x}) = {self.result}'


def main() -> None:
    x = float(input("Enter a value for x: "))
    formula = formula(x)
    print(formula)
