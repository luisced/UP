from pharmacy.models import Laboratory
from pharmacy import db
import logging
import traceback


def createLaboratory(name: str) -> Laboratory:
    """Create a new laboratory"""
    try:
        if not Laboratory.query.filter_by(name=name).first():
            laboratory = Laboratory(name=name)
            db.session.add(laboratory)
            db.session.commit()
        else:
            raise ValueError('Laboratory already exists')
    except Exception as e:
        logging.error(traceback.format_exc())
        laboratory = None

    return laboratory
