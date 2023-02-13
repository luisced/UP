from dataclasses import dataclass
from tabulate import tabulate
import colorama

"""
1. Sales system 
2. Create a product: sku, price, name, stock, cost, caducity
3. Create a store: name, products, sales
4. Create a sale: folio, sold products, iva, subtotal, total, date, type of payment (cash, card, transfer), facture (yes, no)
"""


@dataclass
class Product:
    sku: int
    name: str
    price: float
    stock: int
    cost: float
    caducity: str
    laboratory: str


@dataclass(init=False)
class Sale(Product):
    folio: int
    products: list[Product]
    iva: float
    subtotal: float
    total: float
    date: str
    typeOfPayment: str
    facture: str

    def __init__(self, folio: int, products: list[Product], iva: float, subtotal: float, total: float, date: str, typeOfPayment: str, facture: str) -> None:
        super().__init__(self, folio, products, iva,
                         subtotal, total, date, typeOfPayment, facture)


@dataclass()
class Store:
    name: str
    products: list[Product]
    sales: list[Sale]


def createProduct() -> Product:
    """"Create a product"""
    return Product(
        sku=int(input("Enter the sku of the product: ")),
        name=input("Enter the name of the product: "),
        price=float(input("Enter the price of the product: ")),
        stock=int(input("Enter the stock of the product: ")),
        cost=float(input("Enter the cost of the product: ")),
        caducity=input("Enter the caducity of the product: "),
        laboratory=input("Enter the laboratory of the product: "),
    )


def main() -> None:
    createProduct()
