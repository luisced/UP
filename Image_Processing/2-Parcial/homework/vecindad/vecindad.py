from dataclasses import dataclass
from typing import Dict, List, Tuple
import numpy as np

@dataclass
class Neighborhood:
    # Constants for types of neighborhoods
    FOUR_NEIGHBORS = [(-1, 0), (1, 0), (0, -1), (0, 1)]
    EIGHT_NEIGHBORS = FOUR_NEIGHBORS + [(-1, -1), (-1, 1), (1, -1), (1, 1)]

    matrix: np.ndarray
    
    def __post_init__(self):
        """Set up additional attributes after initialization."""
        self.rows, self.cols = self.matrix.shape

    def is_within_boundaries(self, i: int, j: int) -> bool:
        """Check if the indices (i, j) are within the matrix boundaries."""
        return 0 <= i < self.rows and 0 <= j < self.cols

    def _get_neighbors(self, i: int, j: int, directions: List[Tuple[int, int]]) -> List[Tuple[int, int]]:
        """Get neighbors of a cell (i, j) based on the given directions."""
        neighbors = []
        for dx, dy in directions:
            new_i, new_j = i + dx, j + dy
            if self.is_within_boundaries(new_i, new_j) and self.matrix[new_i, new_j] > 0:
                neighbors.append((new_i, new_j))
        return neighbors

    def get_four_neighbors(self, i: int, j: int) -> Dict[str, List[Tuple[int, int]]]:
        """Calculate the 4-neighborhood of the cell at position (i, j)."""
        return {'4-Neighborhood': self._get_neighbors(i, j, self.FOUR_NEIGHBORS)}

    def get_eight_neighbors(self, i: int, j: int) -> Dict[str, List[Tuple[int, int]]]:
        """Calculate the 8-neighborhood of the cell at position (i, j)."""
        return {'8-Neighborhood': self._get_neighbors(i, j, self.EIGHT_NEIGHBORS)}

# Create an instance of the class with the given matrix
matrix = np.identity(3)
neighborhood = Neighborhood(matrix)

# Calculate and display the 4-neighborhood and 8-neighborhood of the cell at position (1, 1)
four_neighbors = neighborhood.get_four_neighbors(1, 1)
eight_neighbors = neighborhood.get_eight_neighbors(1, 1)

print(four_neighbors, eight_neighbors, sep="\n")
