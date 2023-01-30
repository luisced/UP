from dataclasses import dataclass
from matplotlib import pyplot as plt
import tkinter as tk
import numpy as np


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
        first_label = tk.Label(text="Enter the first set of points (x, y): ")
        first_label.pack()

        # Create the entry for the first set of points
        first_entry = tk.Entry(window)
        first_entry.pack()

        # Create the label for the second set of points
        second_label = tk.Label(text="Enter the second set of points (x, y): ")
        second_label.pack()

        # Create the entry for the second set of points
        second_entry = tk.Entry(window)
        second_entry.pack()

        # Create the submit button
        submit_button = tk.Button(text="Submit", command=window.quit)
        submit_button.pack()

        # Start the GUI
        window.mainloop()

        # Get the values entered by the user
        first_points = first_entry.get()
        second_points = second_entry.get()

        # Convert the values entered by the user into lists of x and y
        first_x, first_y = [int(point.split(',')[0]) for point in first_points.split(
            ' ')], [int(point.split(',')[1]) for point in first_points.split(' ')]
        second_x, second_y = [int(point.split(',')[0]) for point in second_points.split(
            ' ')], [int(point.split(',')[1]) for point in second_points.split(' ')]

        x1 = first_x + second_x
        y1 = first_y + second_y

        self.gui = [x1, y1]

        return self.gui


def main() -> None:
    """Main function"""
    # Create the GUI
    gui = GraphGUI()
    graph = Graph(gui.gui[0], gui.gui[1])

    print(f'set of points: {gui.gui}\nMidpoint: {graph.midPoint}')
    graph.plot()

    # # Create the graph
    # graph = Graph(first_x, first_y)

    # # graph = Graph(first_x + second_x, first_y + second_y)
    # # print(graph)
    # graph.plot()


if __name__ == "__main__":
    main()
