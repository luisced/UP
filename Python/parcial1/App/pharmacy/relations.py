from pharmacy.models import *
from pharmacy import db

RelationProductSale = db.Table('RelationProductSale',
                               db.Column('productID', db.Integer, db.ForeignKey(
                                   'Product.id'), primary_key=True),
                               db.Column('saleID', db.Integer, db.ForeignKey(
                                   'Sale.id'), primary_key=True)
                               )
