from PyQt6.QtWidgets import QApplication, QMainWindow, QPushButton, QVBoxLayout, QWidget, QInputDialog, QMessageBox, QPlainTextEdit
from models import *
import sys

misProductos: list[Producto] = []


def crear_producto_base(nombre: str, tiene_iva: bool) -> Producto_Base:
    '''Crea un producto base a partir del nombre y si tiene iva'''
    return Producto_Base(nombre, tiene_iva)


class MainWindow(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Productos App")

        self.main_widget = QWidget()
        self.setCentralWidget(self.main_widget)

        self.layout = QVBoxLayout()
        self.main_widget.setLayout(self.layout)

        self.agregar_producto_button = QPushButton("Agregar producto")
        self.agregar_producto_button.clicked.connect(self.agregar_productos)
        self.layout.addWidget(self.agregar_producto_button)

        self.agregar_batch_button = QPushButton("Agregar batch")
        self.agregar_batch_button.clicked.connect(self.agregar_batch)
        self.layout.addWidget(self.agregar_batch_button)

        self.imprimir_productos_button = QPushButton("Imprimir productos")
        self.imprimir_productos_button.clicked.connect(self.imprimir_productos)
        self.layout.addWidget(self.imprimir_productos_button)

        self.guardar_en_archivo_button = QPushButton("Guardar en archivo")
        self.guardar_en_archivo_button.clicked.connect(self.guardar_en_archivo)
        self.layout.addWidget(self.guardar_en_archivo_button)

        self.output_text = QPlainTextEdit()
        self.output_text.setReadOnly(True)
        self.layout.addWidget(self.output_text)

    def agregar_productos(self):
        nombre, ok = QInputDialog.getText(
            self, 'Agregar producto', 'Ingrese el nombre del producto:')
        if ok:
            tiene_iva, ok = QInputDialog.getItem(self, 'Agregar producto', 'Tiene iva?', [
                                                 'True', 'False'], 0, False)
            if ok:
                producto_base: Producto_Base = crear_producto_base(
                    nombre, tiene_iva == 'True')
                producto: Producto = Producto(
                    nombre, tiene_iva == 'True', len(misProductos) + 1, [])
                producto.Id = len(misProductos) + 1
                misProductos.append(producto)
                QMessageBox.information(
                    self, 'Producto agregado', f'Producto {producto.nombre} creado con exito')

    def agregar_batch(self):
        product_id, ok = QInputDialog.getInt(
            self, 'Agregar batch', 'Introduzca el id del producto:')
        if ok:
            for product in misProductos:
                if product.Id == product_id:
                    laboratorio, ok = QInputDialog.getText(
                        self, 'Agregar batch', 'Ingrese el laboratorio:')
                    if ok:
                        costo, ok = QInputDialog.getDouble(
                            self, 'Agregar batch', 'Ingrese el costo:')
                        if ok:
                            precio, ok = QInputDialog.getDouble(
                                self, 'Agregar batch', 'Ingrese el precio:')
                            if ok:
                                cantidad, ok = QInputDialog.getInt(
                                    self, 'Agregar batch', 'Ingrese la cantidad:')
                                if ok:
                                    batch: Batch = Batch()
                                    batch.laboratorio = laboratorio
                                    batch.costo = costo
                                    batch.precio = precio
                                    batch.cantidad = cantidad
                                    batch.Id = len(product.batches) + 1
                                    product.batches.append(batch)
                                    QMessageBox.information(
                                        self, 'Batch agregado', 'Batch agregado con exito')
                                    return
            QMessageBox.warning(self, 'Error', 'No existe el producto')

    def imprimir_productos(self):
        self.output_text.clear()
        for producto in misProductos:
            self.output_text.appendPlainText(producto.imprimir_producto_base())
            for batch in producto.batches:
                self.output_text.appendPlainText(str(batch))

    def guardar_en_archivo(self):
        file_name, ok = QInputDialog.getText(
            self, 'Guardar en archivo', 'Ingrese el nombre del archivo:')
        if ok:
            try:
                with open(file_name, 'w') as file:
                    for producto in misProductos:
                        file.write(producto.imprimir_producto_base() + '\n')
                        for batch in producto.batches:
                            file.write(str(batch) + '\n')
                QMessageBox.information(
                    self, 'Archivo guardado', f'Productos guardados con exito en {file_name}')
            except Exception as e:
                QMessageBox.warning(
                    self, 'Error', f'No se pudo guardar el archivo: {str(e)}')


app = QApplication(sys.argv)

window = MainWindow()
window.show()

app.exec()
