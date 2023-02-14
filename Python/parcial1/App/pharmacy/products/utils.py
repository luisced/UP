from pharmacy.models import Product
from pharmacy.tools.tools import toDict
from pharmacy import db
from datetime import datetime
import logging
import traceback


def createProduct(name: str, presentation: str, cost: float, price: float, stock: int, expireDate: datetime, iva: bool, ) -> Product:
    """Create a new product"""
    try:
        if not Product.query.filter_by(name=name).first():
            product = Product(name=name, presentation=presentation, cost=cost,
                              price=price, stock=stock, expireDate=datetime.strptime(expireDate, '%d/%m/%Y'), iva=iva, laboratory=1)
            db.session.add(product)
            db.session.commit()
        else:
            raise ValueError('Product already exists')
    except Exception:
        logging.error(traceback.format_exc())
        product = Product.query.filter_by(name=name).first()

    return product


def getProduct(product: Product) -> dict[Product]:
    """Get a product"""
    try:
        product = Product.toDict(
            Product.query.filter_by(id=product.id, status=True).first())
    except Exception as e:
        logging.error(traceback.format_exc())
        product = None

    return product


def updateProduct(id: Product, name: str, presentation: str, cost: float, price: float, stock: int, expireDate: datetime, iva: bool, ) -> Product:
    """Update a product"""
    try:

        if Product.query.filter_by(id=id).first():
            product = Product.query.filter_by(id=id).first()
            product.name = name if name != '' else product.name
            product.presentation = presentation if presentation != '' else product.presentation
            product.cost = cost if cost != '' else product.cost
            product.price = price if price != '' else product.price
            product.stock = stock if stock != '' else product.stock
            product.expireDate = datetime.strptime(
                expireDate, '%d/%m/%Y') if expireDate != '' else product.expireDate
            product.iva = iva if iva != '' else product.iva
            product.laboratory = 1
            db.session.commit()
        else:
            raise ValueError('Product does not exist')
    except Exception:
        logging.error(traceback.format_exc())
        product = Product.query.filter_by(name=name).first()

    return product


def deleteProduct(id: Product) -> Product:
    """Delete a product"""
    try:
        if Product.query.filter_by(id=id).first():
            product = Product.query.filter_by(id=id).first()
            product.status = False
            db.session.commit()
        else:
            raise ValueError('Product does not exist')
    except Exception:
        logging.error(traceback.format_exc())
        product = Product.query.filter_by(id=id).first()

    return product
