
from datetime import datetime, date
import pandas as pd


class Product:
    def __init__(self, name, presentation, laboratory, stock, cost_value, sale_value, expiration_date, iva):
        self.name = name
        self.presentation = presentation
        self.laboratory = laboratory
        self.stock = stock
        self.cost_value = cost_value
        self.sale_value = sale_value
        # We need to check if the type of data is Timestamp, if it is, we need to convert it to datetime
        if type(expiration_date) == pd._libs.tslibs.timestamps.Timestamp:
            self.expiration_date = expiration_date.to_pydatetime()
        else:
            self.expiration_date = datetime.strptime(
                expiration_date, "%d/%m/%Y")
        if iva:
            self.iva = 0.16
        else:
            self.iva = 0
        self.sku = self.generate_sku()

    def generate_sku(self):
        expiration_date = self.expiration_date.strftime("%d/%m/%Y")
        return f"{self.name[0:2]}{self.laboratory[0:2]}{expiration_date[0:2]}{expiration_date[3:5]}"


class Sale:
    def __init__(self, order_number, products, amount, subtotal, total, payment_type, billed):
        self.order_number = order_number
        self.date = date.today()
        self.products = products
        self.amount = amount
        self.subtotal = subtotal
        self.total = total
        self.payment_type = payment_type
        self.billed = billed
