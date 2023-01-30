from dataclasses import dataclass
from matplotlib import pyplot as plt
import tkinter as tk
import os


@dataclass
class Graph:
    x: list = None
    y: list = None
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


@dataclass
class GraphGUI():
    """Graph GUI TKinter"""
    gui = []

    def __post_init__(self) -> None:
        self.gui = self.createGUI()

    def createGUI(self):
        window = tk.Tk()
        window.geometry("400x400")
        window.title(
            "Enter two sets of points (x, y) (x, y) to find the midpoint of the graph")
        # Create the label for the first set of points
        firstLabel = tk.Label(text="Enter the first set of points (x, y): ")
        firstLabel.pack()

        # Create the entry for the first set of points
        firstEntry = tk.Entry(window)
        firstEntry.pack()

        # Create the label for the second set of points
        secondLabel = tk.Label(text="Enter the second set of points (x, y): ")
        secondLabel.pack()

        # Create the entry for the second set of points
        secondEntry = tk.Entry(window)
        secondEntry.pack()

        # Create the submit button
        submitButton = tk.Button(text="Submit", command=window.quit)
        submitButton.pack()

        # Start the GUI
        window.mainloop()

        # Get the values entered by the user
        firstPoints = firstEntry.get()
        secondPoints = secondEntry.get()

        # Convert the values entered by the user into lists of x and y
        first_x, first_y = [int(point.split(',')[0]) for point in firstPoints.split(
            ' ')], [int(point.split(',')[1]) for point in firstPoints.split(' ')]
        second_x, second_y = [int(point.split(',')[0]) for point in secondPoints.split(
            ' ')], [int(point.split(',')[1]) for point in secondPoints.split(' ')]

        self.gui = [first_x + second_x, first_y + second_y]

        return self.gui


def main() -> None:
    """Main function"""
    # Create the GUI
    os.system("clear")
    gui = GraphGUI()
    graph = Graph(gui.gui[0], gui.gui[1])
    print(f'set of points: {gui.gui}\nMidpoint: {graph.midPoint}')
    graph.plot()


if __name__ == "__main__":
    main()
