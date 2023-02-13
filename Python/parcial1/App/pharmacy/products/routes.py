from flask import Blueprint, request, jsonify

product = Blueprint('product', __name__)


@product.route('/createProduct', methods=['GET', 'POST'])
def createProductDB():
    '''This endpoint creates a new product'''

    if request.method == 'GET':
        jsonData = request.get_json()
        data: list[dict[str, str]] = []
        response: dict[str, str] = {}
        error, code = None, None
        if not jsonData or not all(jsonData.values()):
            error, code = 'Missing data', 400
        elif ('name', 'presentation', 'cost', 'price', 'stock', 'expireDate', 'iva') not in jsonData:
            error, code = 'Missing data', 400
        else:
            print(jsonData.values())
            message, code = f'Product'
    else:
        error, code = 'Method not allowed', 405

    response.update({'sucess': True, 'message': message, 'Schedule': data, 'status_code': 200, 'error': error, 'code': code} if data and data != [] and data != [None] else {
        'sucess': False,  'message': 'Could not get content', 'status_code': 400, 'error': f'{error}', 'code': code})
    return jsonify(response)
