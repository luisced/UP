from sqlalchemy.orm import joinedload
from pharmacy.models import Sale, Product, Ticket, Payments
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
            createTicket(product['id'], product['quantity'], sale.id)
            if sale:
                sale.subtotal = productObj.price * product['quantity']
                sale.total = sale.subtotal if not productObj.iva else sale.subtotal * 1.16
            else:
                pass

        db.session.commit()

    except Exception:
        logging.error(traceback.format_exc())
        sale = None

    return sale


def createTicket(product: int, quantity: int, sale: int) -> Ticket:
    """Create a new ticket for a sale"""
    try:
        product = Product.query.filter_by(id=product).first()

        if product:
            if product.stock >= quantity:
                ticket = Ticket(productID=product.id,
                                quantity=quantity, saleID=sale)
                db.session.add(ticket)
                db.session.commit()
                if ticket:
                    product.stock -= quantity
                    db.session.commit()
                else:
                    raise ValueError('Ticket not created')
            else:
                raise ValueError('Insufficient stock')
        else:
            raise ValueError('Sale or product does not exist')

        db.session.add(ticket)
        db.session.commit()

    except Exception:
        logging.error(traceback.format_exc())
        sale = None

    return ticket


def getSale(sale: Sale) -> dict:
    """Get a sale"""
    try:

        sale = Sale.toDict(Sale.query.filter_by(id=sale.id).first())
        sale['payment'] = getattr(
            Payments.query.filter_by(id=sale['payment']).first(), 'type', None)
        sale['products'] = []

        for ticket in Ticket.query.filter_by(saleID=sale['id']).all():
            product = Product.query.filter_by(id=ticket.productID).first()
            sale['products'].append(
                {'name': product.name, 'quantity': ticket.quantity})

    except Exception as e:
        logging.error(traceback.format_exc())
        sale = None

    return sale
