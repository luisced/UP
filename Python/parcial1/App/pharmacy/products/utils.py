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
            Product.query.filter_by(id=product.id).first())
    except Exception as e:
        logging.error(traceback.format_exc())
        product = None

    return product
