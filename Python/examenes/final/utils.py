from models import *


misProductos: list[Producto]


def crear_producto_base(nombre: str, tiene_iva: bool) -> Producto_Base:
    '''Crea un producto base a partir del nombre y si tiene iva'''
    return Producto_Base(nombre, tiene_iva)


def agregar_batch() -> Batch:
    '''Agrega un batch a la lista de batches dentro de un producto'''

    product_id: int = int(input("introduzca el id del producto: "))
    for product in misProductos:
        if product.Id == product_id:
            batch: Batch = Batch()
            batch.laboratorio = input('Ingrese el laboratorio: ')
            batch.costo = float(input('Ingrese el costo: '))
            batch.precio = float(input('Ingrese el precio: '))
            batch.cantidad = int(input('Ingrese la cantidad: '))
            batch.Id = len(product.batches) + 1
            product.batches.append(batch)
            return batch
        else:
            print('No existe el producto')
            return None


def agregar_productos() -> None:
    '''Agrega un producto a la lista de productos'''
    nombre: str = input('Ingrese el nombre del producto: ')
    tiene_iva: bool = input('Tiene iva? (True/False): ')
    producto_base: Producto_Base = crear_producto_base(nombre, tiene_iva)
    producto: Producto = Producto(nombre, tiene_iva)
    producto.Id = len(misProductos) + 1
    misProductos.append(producto)
    print(f'Producto {producto.nombre} creado con exito')


def imprimir_productos() -> str:
    '''Imprime los productos'''
    for producto in misProductos:
        print(producto.imprimir_producto_base())
        for batch in producto.batches:
            print(batch)
    return 'Productos impresos con exito'


def guardar_en_archivo(file_name: str) -> None:
    '''Guarda los productos en un archivo'''
    with open(file_name, 'w') as file:
        for producto in misProductos:
            file.write(producto.imprimir_producto_base())
            for batch in producto.batches:
                file.write(batch)
    print('Productos guardados con exito')


def menu() -> None:
    '''Print menu with options to use all funcs'''
    print('''
    1. Agregar producto
    2. Agregar batch
    3. Imprimir productos
    4. Guardar en archivo
    5. Salir
    ''')

    option: int = int(input('Ingrese una opcion: '))
    while True:
        match option:
            case 1:
                agregar_productos()
            case 2:
                agregar_batch()
            case 3:
                imprimir_productos()
            case 4:
                guardar_en_archivo('productos.txt')
            case 5:
                print('Saliendo...')
                exit()
            case _:
                print('Opcion invalida')
                menu()
