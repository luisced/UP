from dataclasses import dataclass


@dataclass
class Producto_Base:
    nombre: str
    tiene_iva: bool

    def imprimir_producto_base(self) -> str:
        '''Imprime el producto base a partir del nombre'''
        return (f'\nNombre: {self.nombre}\nIVA: {self.tiene_iva}')


class Batch:
    Id: int
    laboratorio: str
    costo: float
    precio: float
    cantidad: int


@dataclass
class Producto(Producto_Base):
    '''Hereda propiedades de producto_base'''
    Id: int
    batches: list[Batch]

    # propiedades heredadas
    nombre: str
    tiene_iva: bool

    def detalle_producto(self) -> str:
        '''Imprime el producto a partir del nombre y los batches'''
        return (f'\nNombre: {self.nombre}\nBatches: {self.batches}\nNombre: {self.nombre}\nIVA: {self.tiene_iva}')
