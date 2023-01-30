from dataclasses import dataclass
from matplotlib import pyplot as plt
import numpy as np


@dataclass
class Graph:
    x: list
    y: list
    midPoint = []

    def __post_init__(self) -> None:
        self.midPoint = self.findMidPoint()

    def findMidPoint(self) -> int:
        """Find the midpoint of the graph give two lists of x and y [1, 2] and [2, 1]"""
        return [(self.x[point] + self.y[point]) / 2 for point in range(len(self.x))]

        # Find the midpoint of the graph

    def plot(self) -> None:
        """Plot the graph"""
        plt.plot(self.x, self.y)
        plt.plot(self.x, self.midPoint)
        plt.show()

    def __str__(self) -> str:
        return f"Midpoint: {self.midPoint}"


def main() -> None:
    graph = Graph([1, 2], [2, 1])
    print(graph)
    graph.plot()


if __name__ == "__main__":
    main()
