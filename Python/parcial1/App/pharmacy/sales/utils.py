from datetime import datetime
from pharmacy.models import Sale, Product
from pharmacy import db
import logging
import traceback


def createSale(bill: bool, products: list[dict[Product]], payment: int) -> Sale:
    """Create a new sale"""
    try:
        sale = Sale(bill=bill, payment=payment)
        db.session.add(sale)
        db.session.commit()

        for product in products:
            productObj = Product.query.filter_by(id=product['id']).first()
            sale = createRelationProductSale(
                sale, product['id'], product['quantity'])
            if sale:
                sale.subtotal = productObj.price * product['quantity']
                sale.total = sale.subtotal if not product.iva else sale.subtotal * 1.16
            else:
                pass

        db.session.commit()

    except Exception:
        logging.error(traceback.format_exc())
        sale = None

    return sale


def createRelationProductSale(sale: Sale, product: int, quantity: int) -> Sale:
    """Create a new relation between sale and product"""
    try:
        sale = Sale.query.filter_by(id=sale.id).first()
        product = Product.query.filter_by(id=product).first()

        if sale and product and product not in sale.productID:
            if product.stock >= quantity:
                sale.productID.append(product)
                product.stock -= quantity
                db.session.commit()
            else:
                raise ValueError('Insufficient stock')
        else:
            raise ValueError('Sale or product does not exist')

    except Exception:
        logging.error(traceback.format_exc())
        sale = None

    return sale
