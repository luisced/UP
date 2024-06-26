from flask import Blueprint, request, jsonify
from pharmacy.products.utils import *
from pharmacy.models import Product

product = Blueprint('product', __name__)


@product.route('/createProduct', methods=['GET', 'POST'])
def createProductDB():
    '''This endpoint creates a new product'''

    if request.method == 'POST':
        jsonData = request.get_json()
        data: list[dict[str, str]] = []
        response: dict[str, str] = {}
        error, code = None, None
        keys = ['name', 'presentation', 'cost',
                'price', 'stock', 'expireDate', 'iva', 'laboratory']
        if not jsonData:
            error, code = 'Empty Request', 400
        elif not all(key in jsonData for key in keys):
            error, code = f'Missing key: {", ".join(key for key in keys if key not in jsonData)}', 400
        else:
            message, code = f'Product {jsonData["name"]} created', 200
            print(jsonData)
            data.append(createProduct(**jsonData))
    else:
        error, code = 'Method not allowed', 405

    response.update({'sucess': True, 'message': message, 'Product': data, 'status_code': 200, 'error': error, 'code': code} if data and data != [] and data != [None] else {
        'sucess': False,  'message': 'Could not get content', 'status_code': 400, 'error': f'{error}', 'code': code})
    return jsonify(response)


@product.route('/getProduct', methods=['GET'])
def getProductDB():
    '''This endpoint gets a product'''

    jsonData = request.get_json()
    data: list[dict[str, str]] = []
    response: dict[str, str] = {}
    error, code = None, None
    keys = ['filter']
    if request.method == 'GET':
        if not jsonData:
            error, code = 'Empty Request', 400
        elif not all(key in jsonData for key in keys):
            error, code = f'Missing key: {", ".join(key for key in keys if key not in jsonData)}', 400
        else:
            data = filterProducts(jsonData['filter'])
            message, code = f'{len(data)} Products found', 200
    else:
        error, code = 'Method not allowed', 405

    response.update({'sucess': True, 'message': message, 'Product': data, 'status_code': 200, 'error': error, 'code': code} if data and data != [] and data != [None] else {
        'sucess': False,  'message': 'Could not get content', 'status_code': 400, 'error': f'{error}', 'code': code})
    return jsonify(response)


@product.route('/updateProduct', methods=['GET', 'PUT'])
def updateProductDB():
    '''This endpoint updates a product'''

    if request.method == 'PUT':
        jsonData = request.get_json()
        data: list[dict[str, str]] = []
        response: dict[str, str] = {}
        error, code = None, None
        keys = ['id', 'name', 'presentation', 'cost',
                'price', 'stock', 'expireDate', 'iva']
        if not jsonData:
            error, code = 'Empty Request', 400
        elif not all(key in jsonData for key in keys):
            error, code = f'Missing key: {", ".join(key for key in keys if key not in jsonData)}', 400
        else:
            message, code = f'Product {jsonData["id"]} updated', 200
            data.append(updateProduct(**jsonData))
    else:
        error, code = 'Method not allowed', 405

    response.update({'sucess': True, 'message': message, 'Product': data, 'status_code': 200, 'error': error, 'code': code} if data and data != [] and data != [None] else {
        'sucess': False,  'message': 'Could not get content', 'status_code': 400, 'error': f'{error}', 'code': code})
    return jsonify(response)


@product.route('/deleteProduct', methods=['GET', 'DELETE'])
def deleteProductDB():
    '''This endpoint deletes a product'''

    if request.method == 'DELETE':
        jsonData = request.get_json()
        data: list[dict[str, str]] = []
        response: dict[str, str] = {}
        error, code = None, None
        keys = ['id']
        if not jsonData:
            error, code = 'Empty Request', 400
        elif not all(key in jsonData for key in keys):
            error, code = f'Missing key: {", ".join(key for key in keys if key not in jsonData)}', 400
        else:
            message, code = f'Product {jsonData["id"]} deleted', 200
            data.append(getProduct(deleteProduct(
                Product.query.filter_by(id=jsonData['id']).first())))
    else:
        error, code = 'Method not allowed', 405

    response.update({'sucess': True, 'message': message, 'Product': data, 'status_code': 200, 'error': error, 'code': code} if data and data != [] and data != [None] else {
        'sucess': False,  'message': 'Could not get content', 'status_code': 400, 'error': f'{error}', 'code': code})
    return jsonify(response)
