from flask import Blueprint, request, jsonify
from pharmacy.sales.utils import *
from pharmacy.models import Sale

sale = Blueprint('sale', __name__)


@sale.route('/createSale', methods=['GET', 'POST'])
def createSaleDB():
    """This endpoint creates a new sale"""

    if request.method == 'POST':
        jsonData = request.get_json()
        data: list[dict[str, str]] = []
        response: dict[str, str] = {}
        error, code = None, None
        keys = ['bill', 'products', 'payment']
        if not jsonData:
            error, code = 'Empty Request', 400
        elif not all(key in jsonData for key in keys):
            error, code = f'Missing key: {", ".join(key for key in keys if key not in jsonData)}', 400
        else:
            message, code = f'Sale created', 200
            data.append(createSale(**jsonData))
    else:
        error, code = 'Method not allowed', 405

    response.update({'sucess': True, 'message': message, 'Sale': data, 'status_code': 200, 'error': error, 'code': code} if data and data != [] and data != [None] else {
        'sucess': False,  'message': 'Could not get content', 'status_code': 400, 'error': f'{error}', 'code': code})

    return jsonify(response)
