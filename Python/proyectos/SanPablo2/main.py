
from PyQt6.QtWidgets import QApplication
from models import *
from utils import *
import sys


def main():
    app = QApplication(sys.argv)

    window = MainWindow()
    window.show()

    app.exec()


if __name__ == '__main__':
    main()
