from pharmacy import db
from pharmacy.relations import *
from dataclasses import dataclass
from datetime import datetime
from random import randint


@dataclass
class Pharmacy(db.Model):
    __tablename__ = 'Pharmacy'
    id: int = db.Column(db.Integer, primary_key=True)
    name: str = db.Column(db.String(100), nullable=False, default='Pharmacy')
    status: bool = db.Column(db.Boolean, nullable=False, default=True)
    creationDate: datetime = db.Column(
        db.DateTime, nullable=False, default=datetime.utcnow)
    lastUpdate: datetime = db.Column(
        db.DateTime, nullable=False, default=datetime.utcnow, onupdate=datetime.utcnow)


@dataclass
class Laboratory(db.Model):
    __tablename__ = 'Laboratory'
    id: int = db.Column(db.Integer, primary_key=True)
    name: str = db.Column(db.String(100), nullable=False, default='Laboratory')
    status: bool = db.Column(db.Boolean, nullable=False, default=True)
    creationDate: datetime = db.Column(
        db.DateTime, nullable=False, default=datetime.utcnow)
    lastUpdate: datetime = db.Column(
        db.DateTime, nullable=False, default=datetime.utcnow, onupdate=datetime.utcnow)


@dataclass
class Product(db.Model):
    __tablename__ = 'Product'
    id: int = db.Column(db.Integer, primary_key=True)
    name: str = db.Column(db.String(100), nullable=False, default='Product')
    presentation: str = db.Column(
        db.String(100), nullable=False, default='Presentation')
    sku: str = db.Column(db.String(100), nullable=False,
                         default=db.text("CONCAT(LEFT(name, 3), LEFT(presentation, 3), FLOOR(RAND() * 9000) + 1000)"))
    cost: float = db.Column(db.Float, nullable=False, default=0.0)
    price: float = db.Column(db.Float, nullable=False, default=0.0)
    stock: int = db.Column(db.Integer, nullable=False, default=0)
    price: float = db.Column(db.Float, nullable=False, default=0.0)
    expireDate: datetime = db.Column(
        db.Date, nullable=False, default=datetime.utcnow)
    iva: bool = db.Column(db.Boolean, nullable=False, default=True)
    status: bool = db.Column(db.Boolean, nullable=False, default=True)
    creationDate: datetime = db.Column(
        db.DateTime, nullable=False, default=datetime.utcnow)
    lastUpdate: datetime = db.Column(
        db.DateTime, nullable=False, default=datetime.utcnow, onupdate=datetime.utcnow)

    # Foreign Keys
    laboratory: int = db.Column(
        db.Integer, db.ForeignKey('Laboratory.id'), nullable=False)


@dataclass
class Payments(db.Model):
    __tablename__ = 'Payments'
    id: int = db.Column(db.Integer, primary_key=True)
    name: str = db.Column(db.String(100), nullable=False, default='Payment')
    status: bool = db.Column(db.Boolean, nullable=False, default=True)
    creationDate: datetime = db.Column(
        db.DateTime, nullable=False, default=datetime.utcnow)
    lastUpdate: datetime = db.Column(
        db.DateTime, nullable=False, default=datetime.utcnow, onupdate=datetime.utcnow)


@dataclass
class Sale(db.Model):
    __tablename__ = 'Sale'

    id: int = db.Column(db.Integer, primary_key=True)
    subtotal: float = db.Column(db.Float, nullable=False, default=0.0)
    total: float = db.Column(db.Float, nullable=False, default=0.0)
    date: datetime = db.Column(
        db.DateTime, nullable=False, default=datetime.utcnow)
    bill: bool = db.Column(db.Boolean, nullable=False, default=True)
    status: bool = db.Column(db.Boolean, nullable=False, default=True)
    creationDate: datetime = db.Column(
        db.DateTime, nullable=False, default=datetime.utcnow)
    lastUpdate: datetime = db.Column(
        db.DateTime, nullable=False, default=datetime.utcnow, onupdate=datetime.utcnow)

    # Foreign Keys
    payment: int = db.Column(
        db.Integer, db.ForeignKey('Payments.id'), nullable=False)

    # Relationships
    productID = db.relationship('Product', secondary=RelationProductSale,
                                backref=db.backref('saleID', lazy=True))

    def __post_init__(self):
        self.quantity: int = db.Column(db.Integer, nullable=False,
                                       default=len(self.productID))
        self.subtotal: float = db.Column(db.Float, nullable=False,
                                         default=sum([product.price for product in self.productID]))

        self.total: float = db.Column(db.Float, nullable=False,
                                      default=self.subtotal * 1.16 if self.iva else self.subtotal)
