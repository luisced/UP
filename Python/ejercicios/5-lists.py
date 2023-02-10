from dataclasses import dataclass
from tabulate import tabulate


def evenListNumbers() -> list[int]:
    """Return a list of even numbers"""
    return [int(input("Enter a number: "))
            for i in range(int(input("How many numbers do you want to enter? "))
                           ) if i % 2 == 0]


def evaluateTwoList() -> str:
    """Evaluate two lists"""
    a = ['b', 'c', 'd', 'e', 'f', 'g', 'h']
    b = ['b', 1, 'a', 2, 'd', 'i', 10, 'b', ]
    numberCommonElements = 0
    for element in a:
        if element in b:
            numberCommonElements += 1

    return f"{numberCommonElements} common elements in the two lists"


def uniqueElements() -> list[str]:
    """Return a list of unique elements of two lists"""
    a = [n for n in input(
        "Enter the elements of list 1 separated by spaces: ").split()]
    b = [n for n in input(
        "Enter the elements of list 2 separated by spaces: ").split()]

    return [n for n in a if n not in b] + [n for n in b if n not in a]


def convertListToString() -> str:
    """Convert a list to a string"""
    return "".join([n for n in input("Enter the elements of list 1 separated by spaces: ").split()])


def replaceLastElement() -> list[str]:
    """" Replace the last element with the elements of another list"""
    a = [1, 2, 3, 'a']
    b = [4, 5, 6, 7, 8]
    a[-1] = b
    return a


def moveZeroDigitsToEnd() -> list[int]:
    """Move all the 0 digits to the end of the list"""
    a = [3, 4, 0, 0, 0, 6, 2, 0, 6, 7, 6, 0, 0,
         0, 9, 10, 7, 4, 4, 5, 3, 0, 0, 2, 9, 7, 1]

    return [n for n in a if n != 0] + [n for n in a if n == 0]


def averageOfTwoLIsts() -> float:
    """Return the average of two lists"""
    a = [float(n) for n in input(
        "Enter the elements of list 1 separated by spaces: ").split()]
    b = [float(n) for n in input(
        "Enter the elements of list 2 separated by spaces: ").split()]

    return sum(a + b) / len(a + b)


@dataclass
class Product:
    name: str
    price: float
    quantity: int


@dataclass(init=False)
class Sale(Product):
    name: Product
    quantity: int

    def __init__(self, name: str, quantity: int) -> None:
        super().__init__(self, name, quantity)


stock = []
quantitypurchased = []
sales = []


def salesMenu() -> None:
    """Sales menu"""
    menu = """
    1. Add a product to the stock
    2. Create a sale
    3. See the stock 
    4. View the sale
    5. Exit
    """
    print(menu)
    option = int(input("Enter an option: "))
    while option != 5:
        match option:
            case 1:
                addProductToStock()
            case 2:
                createSale()
            case 3:
                seeStock()
            case 4:
                viewSale()
            case 5:
                exit()
            case _:
                print("Invalid option")
        print(menu)
        option = int(input("Enter an option: "))


def addProductToStock() -> Product:
    """Create a product"""
    name = input("Enter the name of the product: ")
    price = float(input("Enter the price of the product: "))
    quantity = int(input("Enter the quantity of the product: "))
    stock.append(Product(name, price, quantity))


def seeStock() -> list[Product]:
    """See the stock"""
    print(tabulate(stock, headers="keys", tablefmt="fancy_grid"))


def createSale() -> None:
    """Create a sale"""
    name = input("Enter the name of the product: ")
    quantity = int(input("Enter the quantity of the product: "))
    if name in [product.name for product in stock] and quantity <= [product.quantity for product in stock if product.name == name][0]:
        sales.append(Sale(name=name, quantity=quantity))
        quantitypurchased.append((name, quantity))
        for product in stock:
            if product.name == name:
                product.quantity -= quantity
    else:
        print("Invalid product or quantity")


def viewSale() -> None:
    """View the sale"""
    print(tabulate(sales, headers="keys", tablefmt="fancy_grid"))


def main() -> None:
    print(averageOfTwoLIsts())


if __name__ == __name__:
    main()
