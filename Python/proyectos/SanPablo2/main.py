
from PyQt6.QtWidgets import QApplication
from models import *
from utils import *
import sys


def main():
    app = QApplication(sys.argv)

    welcome_screen = WelcomeScreen()
    welcome_screen.show()
    app.exec()


if __name__ == "__main__":
    main()
