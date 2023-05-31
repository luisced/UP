from PyQt6.QtWidgets import QMainWindow, QPushButton, QVBoxLayout, QWidget, QInputDialog, QMessageBox, QDialog, QTableWidget, QTableWidgetItem, QInputDialog, QMessageBox, QComboBox, QLineEdit, QLabel
from models import *
import pandas as pd
from datetime import datetime, timedelta


class FilterSalesDialog(QDialog):
    def __init__(self, parent=None):
        super(FilterSalesDialog, self).__init__(parent)

        self.layout = QVBoxLayout()
        self.setLayout(self.layout)

        self.field_label = QLabel("Select field to filter:")
        self.layout.addWidget(self.field_label)

        self.field_combo = QComboBox()
        self.field_combo.addItems(
            ["Order number", "Date", "Name", "Amount", "Subtotal", "Total", "Payment type", "Billed"])
        self.layout.addWidget(self.field_combo)

        self.field_label = QLabel("Select field to filter:")
        self.layout.addWidget(self.field_label)

        self.field_combo = QComboBox()
        self.field_combo.addItems(
            ["Order number", "Date", "Name", "Amount", "Subtotal", "Total", "Payment type", "Billed"])
        self.layout.addWidget(self.field_combo)

        self.value_label = QLabel("Enter value to filter:")
        self.layout.addWidget(self.value_label)

        self.value_line_edit = QLineEdit()
        self.layout.addWidget(self.value_line_edit)

        self.filter_button = QPushButton("Filter")
        self.filter_button.clicked.connect(self.filter_sales)
        self.layout.addWidget(self.filter_button)

    def filter_sales(self):
        field = self.field_combo.currentText()
        value = self.value_line_edit.text()
        self.parent().list_all_the_sales_filtered(field, value)


class ReportsDialog(QDialog):
    def __init__(self, parent=None):
        super(ReportsDialog, self).__init__(parent)

        self.layout = QVBoxLayout()
        self.setLayout(self.layout)

        self.product_info_button = QPushButton(
            "See Specific Product Information")
        self.product_info_button.clicked.connect(
            self.parent().see_specific_product_information)
        self.layout.addWidget(self.product_info_button)

        self.sale_info_button = QPushButton("See Specific Sale Information")
        self.sale_info_button.clicked.connect(
            self.parent().see_specific_sale_information)
        self.layout.addWidget(self.sale_info_button)

        self.expiry_button = QPushButton("List Products Soon to Expiry")
        self.expiry_button.clicked.connect(
            self.parent().list_products_soon_to_expiry)
        self.layout.addWidget(self.expiry_button)

    def open_filter_sales_dialog(self):
        self.filter_sales_dialog = FilterSalesDialog(self)
        self.filter_sales_dialog.show()


class MainWindow(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle(
            "Product and Sales Management: Valeria, Itzayana, Dani")

        self.resize(1200, 800)

        self.main_widget = QWidget()
        self.setCentralWidget(self.main_widget)

        self.layout = QVBoxLayout()
        self.main_widget.setLayout(self.layout)

        self.table_widget = QTableWidget()
        self.layout.addWidget(self.table_widget)

        self.sales_table_widget = QTableWidget()
        self.layout.addWidget(self.sales_table_widget)

        self.add_product_button = QPushButton("Add product")
        self.add_product_button.clicked.connect(self.add_product)
        self.layout.addWidget(self.add_product_button)

        # Add more buttons for the other options in your menu

        self.create_sale_button = QPushButton("Create sale")
        self.create_sale_button.clicked.connect(self.create_sale)
        self.layout.addWidget(self.create_sale_button)

        self.show_all_products_button = QPushButton("Show all products")
        self.show_all_products_button.clicked.connect(self.show_all_products)
        self.layout.addWidget(self.show_all_products_button)

        self.show_all_sales_button = QPushButton("Show all sales")
        self.show_all_sales_button.clicked.connect(self.list_all_sales)
        self.layout.addWidget(self.show_all_sales_button)

        pd.set_option('display.max_rows', None)
        pd.set_option('display.max_columns', None)
        pd.options.display.width = 100

        # Filtered sales

        # self.filter_field_label = QLabel("Select field to filter sale:")
        # self.layout.addWidget(self.filter_field_label)

        # self.filter_field_combo_box = QComboBox()
        # self.filter_field_combo_box.addItems(["order_number", "date", "name", "amount",
        #                                       "subtotal", "total", "payment_type", "billed"])
        # self.layout.addWidget(self.filter_field_combo_box)

        # self.filter_input_label = QLabel("Enter value to filter:")
        # self.layout.addWidget(self.filter_input_label)

        # self.filter_input_line_edit = QLineEdit()
        # self.layout.addWidget(self.filter_input_line_edit)

        # self.filter_button = QPushButton("Filter Sales")
        # self.filter_button.clicked.connect(self.list_all_the_sales_filtered)
        # self.layout.addWidget(self.filter_button)

        self.update_button = QPushButton("Update Excel")
        self.update_button.clicked.connect(self.update_excel)
        self.layout.addWidget(self.update_button)

        self.reports_button = QPushButton("Reports")
        self.reports_button.clicked.connect(self.open_reports_dialog)
        self.layout.addWidget(self.reports_button)

        inventory_df = pd.read_excel(
            "DB/Inventory.xlsx", sheet_name="Inventory")
        sales_df = pd.read_excel("DB/Sales.xlsx", sheet_name="Sales")

        self.inventory = inventory_df.values.tolist()
        self.sales = sales_df.values.tolist()

        for i in range(len(self.inventory)):
            self.inventory[i] = Product(name=str(self.inventory[i][1]), presentation=self.inventory[i][2], laboratory=self.inventory[i][3],
                                        stock=self.inventory[i][4], cost_value=self.inventory[i][5], sale_value=self.inventory[i][6],
                                        expiration_date=self.inventory[i][7], iva=self.inventory[i][8])
        for i in range(len(self.sales)):
            self.sales[i] = Sale(order_number=self.sales[i][1], products=self.sales[i][3], amount=self.sales[i][4], subtotal=self.sales[i][5],
                                 total=self.sales[i][6], payment_type=self.sales[i][7], billed=self.sales[i][8])

    def add_product(self):
        name, ok = QInputDialog.getText(
            self, 'Add product', 'Please enter the product name:')
        if ok:
            presentation, ok = QInputDialog.getText(
                self, 'Add product', 'Please enter the product presentation:')
            if ok:
                laboratory, ok = QInputDialog.getText(
                    self, 'Add product', 'Please enter the laboratory:')
                if ok:
                    stock, ok = QInputDialog.getInt(
                        self, 'Add product', 'Please enter the stock:')
                    if ok:
                        cost_value, ok = QInputDialog.getDouble(
                            self, 'Add product', 'Please enter the cost value:')
                        if ok:
                            sale_value, ok = QInputDialog.getDouble(
                                self, 'Add product', 'Please enter the sale value:')
                            if ok:
                                expiration_date, ok = QInputDialog.getText(
                                    self, 'Add product', 'Please enter the expiration date (dd/mm/yyyy):')
                                if ok:
                                    iva, ok = QInputDialog.getItem(
                                        self, 'Add product', 'The product has taxes?', ['y', 'n'], 0, False)
                                    if ok:
                                        if iva == "y":
                                            iva = True
                                        else:
                                            iva = False
                                        product = Product(name, presentation, laboratory, int(stock), float(
                                            cost_value), float(sale_value), expiration_date, iva)
                                        self.inventory.append(product)
                                        QMessageBox.information(
                                            self, 'Product added', 'Product added successfully!')

    def create_sale(self):
        if len(self.inventory) == 0:
            QMessageBox.warning(
                self, 'No products', 'There are no products in the inventory, please add a product first.')
            return
        else:
            sales_bought = []

            self.show_all_products()
            order_number, ok = QInputDialog.getText(
                self, 'Create sale', 'Please enter the ids of the products to sell separated by comas:')
            if not ok:
                return
            order_number = order_number.split(",")
            products = []
            for order in order_number:
                products.append(self.inventory[int(order) - 1])

            for product in products:
                QMessageBox.information(
                    self, 'Product selected', f'Product selected: {product.name}')
                amount, ok = QInputDialog.getInt(
                    self, 'Create sale', 'Please enter the amount of the product to sell:')
                if not ok or amount > product.stock:
                    QMessageBox.warning(
                        self, 'Not enough stock', 'There is not enough stock of the product.')
                    return
                product.stock -= amount
                subtotal = product.sale_value * amount
                if product.iva:
                    total = subtotal * 1.16
                else:
                    total = subtotal
                payment_type, ok = QInputDialog.getText(
                    self, 'Create sale', 'Please enter the payment type (cash/card):')
                if not ok:
                    return
                billed, ok = QInputDialog.getItem(
                    self, 'Create sale', 'Was the order billed?', ['y', 'n'], 0, False)
                if not ok:
                    return
                order_number = len(self.sales) + 1
                sale = Sale(order_number, product, amount,
                            subtotal, total, payment_type, billed == 'y')
                sales_bought.append(sale)
                QMessageBox.information(self, 'Sale created', 'Sale created successfully!\n' +
                                        f'Total to pay: {total}\n' +
                                        f'Total taxes: {total - subtotal}')

            products_names = ', '.join([product.name for product in products])
            amounts = ', '.join([str(sale.amount) for sale in sales_bought])
            subtotal = sum([sale.subtotal for sale in sales_bought])
            total = sum([sale.total for sale in sales_bought])
            payment_type = sales_bought[0].payment_type
            billed = sales_bought[0].billed

            final_sale = Sale(len(self.sales) + 1,
                              products_names,
                              amounts,
                              subtotal,
                              total,
                              payment_type,
                              billed)

            self.sales.append(final_sale)

    def show_all_products(self):
        products = []
        for product in self.inventory:
            products.append(
                [product.sku, product.name, product.presentation, product.laboratory, product.stock, product.cost_value,
                 product.sale_value, product.expiration_date, product.iva])

        self.table_widget.setRowCount(len(products))
        self.table_widget.setColumnCount(9)
        self.table_widget.setHorizontalHeaderLabels(["sku", "name", "presentation", "laboratory", "stock", "cost_value", "sale_value",
                                                     "expiration_date", "iva"])

        for i, product in enumerate(products):
            for j, field in enumerate(product):
                self.table_widget.setItem(i, j, QTableWidgetItem(str(field)))

    def list_all_sales(self):
        sales_data_frame = []
        for sale in self.sales:
            sales_data_frame.append(
                [sale.order_number, sale.date, sale.products, sale.amount, sale.subtotal, sale.total,
                 sale.payment_type, sale.billed])

        self.sales_table_widget.setRowCount(len(sales_data_frame))
        self.sales_table_widget.setColumnCount(8)
        self.sales_table_widget.setHorizontalHeaderLabels(["order_number", "date", "name", "amount",
                                                           "subtotal", "total", "payment_type", "billed"])

        for i, sale in enumerate(sales_data_frame):
            for j, field in enumerate(sale):
                self.sales_table_widget.setItem(
                    i, j, QTableWidgetItem(str(field)))

    def list_all_products(self):
        products_df = []
        for product in self.inventory:
            products_df.append(
                [product.sku, product.name, product.presentation, product.laboratory, product.stock, product.cost_value,
                 product.sale_value, product.expiration_date, product.iva])

        self.products_table_widget.setRowCount(len(products_df))
        self.products_table_widget.setColumnCount(9)
        self.products_table_widget.setHorizontalHeaderLabels(["sku", "name", "presentation", "laboratory", "stock", "cost_value", "sale_value",
                                                              "expiration_date", "iva"])

        for i, product in enumerate(products_df):
            for j, field in enumerate(product):
                self.products_table_widget.setItem(
                    i, j, QTableWidgetItem(str(field)))

    def list_all_sales(self):
        sales_data_frame = []
        for sale in self.sales:
            sales_data_frame.append(
                [sale.order_number, sale.date, sale.products, sale.amount, sale.subtotal, sale.total,
                 sale.payment_type, sale.billed])

        self.sales_table_widget.setRowCount(len(sales_data_frame))
        self.sales_table_widget.setColumnCount(8)
        self.sales_table_widget.setHorizontalHeaderLabels(["order_number", "date", "name", "amount",
                                                           "subtotal", "total", "payment_type", "billed"])

        for i, sale in enumerate(sales_data_frame):
            for j, field in enumerate(sale):
                self.sales_table_widget.setItem(
                    i, j, QTableWidgetItem(str(field)))

    def list_all_the_sales_filtered(self):
        field = self.filter_field_combo_box.currentText()
        value = self.filter_input_line_edit.text()

        sales_df = pd.DataFrame([vars(sale) for sale in self.sales])
        filtered_sales_df = sales_df.loc[sales_df[field] == value]

        self.sales_table_widget.setRowCount(len(filtered_sales_df))
        for i, sale in filtered_sales_df.iterrows():
            for j, field in enumerate(sale):
                self.sales_table_widget.setItem(
                    i, j, QTableWidgetItem(str(field)))

        self.filter_input_line_edit.clear()

    def see_specific_product_information(self):
        field = QInputDialog.getItem(self, "Select Field", "Field:", [
                                     "sku", "name", "presentation", "laboratory", "stock", "cost_value", "sale_value", "expiration_date", "iva"], 0, False)
        if field[1]:
            products_df = pd.DataFrame([vars(product)
                                       for product in self.inventory])
            QMessageBox.information(
                self, "Product Information", str(products_df[field[0]]))

    def see_specific_sale_information(self):
        field = QInputDialog.getItem(self, "Select Field", "Field:", [
                                     "order_number", "date", "name", "amount", "subtotal", "total", "payment_type", "billed"], 0, False)
        if field[1]:
            sales_df = pd.DataFrame([vars(sale) for sale in self.sales])
            QMessageBox.information(
                self, "Sale Information", str(sales_df[field[0]]))

    def list_products_soon_to_expiry(self):
        products_df = pd.DataFrame([vars(product)
                                   for product in self.inventory])
        soon_to_expiry_df = products_df.loc[products_df["expiration_date"] <= datetime.now(
        ) + timedelta(days=60)]
        QMessageBox.information(
            self, "Products Soon to Expiry", str(soon_to_expiry_df))

    def update_excel(self):
        sales_df = pd.DataFrame([vars(sale) for sale in self.sales])
        sales_df["date"] = sales_df["date"].apply(
            lambda x: x.strftime("%d/%m/%Y"))
        sales_df.to_excel("DB/Sales.xlsx", sheet_name="Sales")

        inventory_df = pd.DataFrame([vars(product)
                                    for product in self.inventory])
        inventory_df["expiration_date"] = inventory_df["expiration_date"].apply(
            lambda x: x.strftime("%d/%m/%Y"))
        inventory_df.to_excel("DB/Inventory.xlsx", sheet_name="Inventory")

        QMessageBox.information(self, "Update Excel",
                                "Excel files have been updated.")

    def open_reports_dialog(self):
        self.reports_dialog = ReportsDialog(self)
        self.reports_dialog.show()
