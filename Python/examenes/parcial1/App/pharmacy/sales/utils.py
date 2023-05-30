from sqlalchemy.orm import joinedload
from pharmacy.models import Sale, Product, Ticket, Payments
from pharmacy import db
from datetime import datetime, timedelta
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


def filterSales(filterSale: str) -> list[dict]:
    """Filter sales"""
    try:
        if isinstance(filterSale, str):
            match filterSale:
                case 'all':
                    sales = [getSale(sale) for sale in Sale.query.all()]
                # case 'soonToExpire':
                #     sales = [
                #         getSale(sale) for sale in Sale.query.filter(Sale.date.between(
                #             datetime.now(), datetime.now() + timedelta(days=30))).all()
                #     ]
                # case 'expired':
                #     sales = [
                #         getSale(sale) for sale in Sale.query.filter(Sale.date < datetime.now()).all()
                #     ]
                case _:
                    sales = None
        elif isinstance(filterSale, dict):
            if 'id' in filterSale:
                sales = getSale(Sale.query.filter_by(
                    id=filterSale['id']).first())
            elif 'bill' in filterSale:
                sales = [getSale(sale) for sale in Sale.query.filter_by(
                    bill=filterSale['bill']).all()]
            elif 'payment' in filterSale:
                sales = [getSale(sale) for sale in Sale.query.filter_by(
                    payment=filterSale['payment']).all()]
            elif 'year' in filterSale:
                sales = [getSale(sale) for sale in
                         Sale.query.filter(Sale.date.between(datetime(int(filterSale['year']), 1, 1), datetime(int(filterSale['year']), 12, 31))).all()]
            elif 'start' in filterSale and 'end' in filterSale:
                sales = [getSale(sale) for sale in Sale.query.filter(Sale.date.between(
                    filterSale['start'], filterSale['end'])).all()]
            elif 'month' in filterSale and 'year' in filterSale:
                sales = [getSale(sale) for sale in Sale.query.filter(Sale.date.between(
                    datetime(int(filterSale['year']),
                             int(filterSale['month']), 1),
                    datetime(int(filterSale['year']), int(filterSale['month'])+1, 1) - timedelta(days=1))
                ).all()]
            else:
                sales = None
        else:
            sales = None
    except Exception as e:
        logging.error(traceback.format_exc())
        sales = None

    return sales
