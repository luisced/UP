from dataclasses import dataclass
from datetime import datetime
from itertools import combinations
from functools import lru_cache
import networkx as nx
import matplotlib.pyplot as plt
import timeit


# define subject


@dataclass
class Subject:
    id: int
    name: str
    start_time: datetime  # H:M
    end_time: datetime  # H:M
    days: dict[list[str]] # monday : startTime - endTime

    def __repr__(self) -> str:
        return f"id: {self.id} {self.name} ({self.start_time.strftime('%H:%M')} - {self.end_time.strftime('%H:%M')})"


# create objects


subjects = [
    # first variant
    Subject(1, "Math", datetime(2021, 1, 1, 8, 30),datetime(2021, 1, 1, 10, 0)),
    Subject(2, "English", datetime(2021, 1, 1, 10, 0),
            datetime(2021, 1, 1, 11, 30)),
    Subject(3, "Science", datetime(2021, 1, 1, 11, 30),
            datetime(2021, 1, 1, 13, 0)),
    Subject(4, "History", datetime(2021, 1, 1, 13, 0),
            datetime(2021, 1, 1, 14, 30)),
    Subject(5, "Geography", datetime(2021, 1, 1, 14, 30),
            datetime(2021, 1, 1, 16, 0)),
    Subject(6, "Physics", datetime(2021, 1, 1, 16, 0),
            datetime(2021, 1, 1, 17, 30)),
    Subject(7, "Chemistry", datetime(2021, 1, 1, 17, 30),
            datetime(2021, 1, 1, 19, 0)),
    Subject(8, "Biology", datetime(2021, 1, 1, 19, 0),
            datetime(2021, 1, 1, 20, 30)),
    Subject(9, "Literature", datetime(2021, 1, 1, 7, 0),
            datetime(2021, 1, 1, 8, 30)),
    Subject(10, "Economics", datetime(2021, 1, 1, 15, 30),
            datetime(2021, 1, 1, 22, 0)),

    # second variant
    Subject(11, "Math", datetime(2021, 1, 1, 8, 0),
            datetime(2021, 1, 1, 9, 0)),
    Subject(12, "English", datetime(2021, 1, 1, 10, 0),
            datetime(2021, 1, 1, 11, 30)),
    Subject(13, "Science", datetime(2021, 1, 1, 10, 0),
            datetime(2021, 1, 1, 11, 0)),
    Subject(14, "History", datetime(2021, 1, 1, 11, 0),
            datetime(2021, 1, 1, 12, 0)),
    Subject(15, "Geography", datetime(2021, 1, 1, 12, 0),
            datetime(2021, 1, 1, 13, 0)),
    Subject(16, "Physics", datetime(2021, 1, 1, 13, 0),
            datetime(2021, 1, 1, 14, 0)),
    Subject(17, "Chemistry", datetime(2021, 1, 1, 14, 0),
            datetime(2021, 1, 1, 15, 0)),
    Subject(18, "Biology", datetime(2021, 1, 1, 15, 0),
            datetime(2021, 1, 1, 16, 0)),
    Subject(19, "Literature", datetime(2021, 1, 1, 16, 0),
            datetime(2021, 1, 1, 17, 0)),
    Subject(20, "Economics", datetime(2021, 1, 1, 17, 0),
            datetime(2021, 1, 1, 18, 0)),

]

# This code finds all possible combinations of subjects that do not overlap,
# and prints them out. If there are no combinations, it prints a message
# saying so.

# Se crea un diccionario donde se almacena cada id
subject_dict = {subject.id: subject for subject in subjects}


def subjects_overlap(id1: int, id2: int) -> bool:
    """Se checa que start_time no sea mayor a end_time"""
    subject1 = subject_dict[id1]
    subject2 = subject_dict[id2]
    return not (subject1.end_time <= subject2.start_time or subject1.start_time >= subject2.end_time)
                # or subject1.start_time == subject2.start_time)


@lru_cache(maxsize=None)
def find_valid_combinations():
    """Se hacen las combinaciones de todas las materias que no se superpongan"""

    graph = nx.Graph()  # Se crea un grafo

    for subject in subjects:
        graph.add_node(subject.id, subject=subject)

        # para cada materia dentro de la lista, se crea un nodo

    for id1, id2 in combinations(subject_dict.keys(), 2):
        if not subjects_overlap(id1, id2):
            graph.add_edge(id1, id2)

        # Se checa que no se superpongan las materias, si no se superponen se crea una arista

    cliques = nx.find_cliques(graph)
    # Un clique es un subconjunto en el que todos los nodos están interconectados entre sí
    # Es decir, un subjonjunto de la lista subjects donde todas las materias son compatibles

    # Ahora se checa que las combinaciones sean válidas, que no se repita más de una materia por horario
    valid_combinations = []
    for clique in cliques:
        valid_combination = [graph.nodes[node]["subject"] for node in clique]
        subject_names = [subject.name for subject in valid_combination]
        if len(subject_names) == len(set(subject_names)):
            valid_combinations.append(valid_combination)

    # Si no existen combinaciones, se manda error
    if not valid_combinations:
        print("No valid combinations of subjects found.")
    else:
        # De lo contrario se añade cada combinación a la lista sorteado por la hora de comienzo
        for i, combination in enumerate(valid_combinations, 1):
            sorted_combination = sorted(
                combination, key=lambda time: time.start_time)
            print(f"Combination {i}:")
            for subject in sorted_combination:
                print(f"  {subject}")
            print()

    pos = nx.spring_layout(graph)
    nx.draw(graph, pos, with_labels=True, node_color="lightblue",
            font_size=8, node_size=2000)


elapsed_time = timeit.timeit(find_valid_combinations, number=1)
print(
    f"Elapsed time: {elapsed_time:.4f} seconds")
plt.show()


