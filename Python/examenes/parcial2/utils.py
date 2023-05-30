from models import *

pd.set_option('display.max_rows', None)
pd.set_option('display.max_columns', None)
pd.options.display.width = 0

# We need to create 2 data frames, one for the inventory and one for the sales
# We wil use the file named "data.xlsx" to store the data

# We will start by reading the first sheet of the file, which contains the inventory
inventory_df = pd.read_excel("DB/Inventory.xlsx", sheet_name="Inventory")
# We will read the second sheet of the file, which contains the sales
sales_df = pd.read_excel("DB/Sales.xlsx", sheet_name="Sales")

# We want to convert the data frame into a list of lists, so we can work with it
inventory = inventory_df.values.tolist()
sales = sales_df.values.tolist()


# We want to convert the inventory and sales lists into lists of objects
for i in range(len(inventory)):
    inventory[i] = Product(name=str(inventory[i][2]), presentation=inventory[i][3], laboratory=inventory[i][4],
                           stock=inventory[i][5], cost_value=inventory[i][6], sale_value=inventory[i][7],
                           expiration_date=inventory[i][8], iva=inventory[i][9])
for i in range(len(sales)):
    sales[i] = Sale(order_number=sales[i][1], products=sales[i][3], amount=sales[i][4], subtotal=sales[i][5],
                    total=sales[i][6], payment_type=sales[i][7], billed=sales[i][8])


def add_product():
    name = input("Please enter the product name: ")
    presentation = input("Please enter the product presentation: ")
    laboratory = input("Please enter the laboratory: ")
    stock = input("Please enter the stock: ")
    cost_value = input("Please enter the cost value: ")
    sale_value = input("Please enter the sale value: ")
    expiration_date = input("Please enter the expiration date (dd/mm/yyyy): ")
    iva = input("The product has taxes? (y/n):")
    if iva == "y":
        iva = True
    else:
        iva = False
    product = Product(name, presentation, laboratory, int(stock), float(cost_value), float(sale_value), expiration_date,
                      iva)
    inventory.append(product)
    print("Product added successfully!")


def create_sale():
    if len(inventory) == 0:
        print("There are no products in the inventory, please add a product first.")
        return
    else:
        sales_bought = []

        show_all_products()
        order_number = input(
            "Please enter the ids of the products to sell separated by comas: ")
        order_number = order_number.split(",")
        products = []
        for order in order_number:
            products.append(inventory[int(order) - 1])

        for product in products:
            print(f"Product selected: {product.name}")
            amount = int(
                input("Please enter the amount of the product to sell: "))
            if amount > product.stock:
                print("There is not enough stock of the product.")
                return
            product.stock -= amount
            subtotal = product.sale_value * amount
            if product.iva:
                total = subtotal * 1.16
            else:
                total = subtotal
            payment_type = input("Please enter the payment type (cash/card): ")
            billed = input("Was the order billed? (y/n): ")
            if billed == "y":
                billed = True
            else:
                billed = False
            order_number = len(sales) + 1
            sale = Sale(order_number, product, amount,
                        subtotal, total, payment_type, billed)
            sales_bought.append(sale)
            print("Sale created successfully!")
            print(f"Total to pay: {total}")
            print(f"Total taxes: {total - subtotal}")

        products_names = ', '.join([product.name for product in products])
        amounts = ', '.join([str(sale.amount) for sale in sales_bought])
        subtotal = sum([sale.subtotal for sale in sales_bought])
        total = sum([sale.total for sale in sales_bought])
        payment_type = sales_bought[0].payment_type
        billed = sales_bought[0].billed

        final_sale = Sale(len(sales) + 1,
                          products_names,
                          amounts,
                          subtotal,
                          total,
                          payment_type,
                          billed)

        sales.append(final_sale)


def show_all_products():
    products = []
    for product in inventory:
        products.append(
            [product.sku, product.name, product.presentation, product.laboratory, product.stock, product.cost_value,
             product.sale_value, product.expiration_date, product.iva])
    df = pd.DataFrame(products,
                      columns=["sku", "name", "presentation", "laboratory", "stock", "cost_value", "sale_value",
                               "expiration_date", "iva"], index=None)
    print(f"\n{df}\n")


def list_all_sales():
    sales_data_frame = []
    for sale in sales:
        sales_data_frame.append(
            [sale.order_number, sale.date, sale.products, sale.amount, sale.subtotal, sale.total,
             sale.payment_type, sale.billed])
    df = pd.DataFrame(sales_data_frame,
                      columns=["order_number", "date", "name", "amount",
                               "subtotal", "total", "payment_type", "billed"],
                      index=None)
    return df


def list_all_products():
    products_df = []
    for product in inventory:
        products_df.append(
            [product.sku, product.name, product.presentation, product.laboratory, product.stock, product.cost_value,
             product.sale_value, product.expiration_date, product.iva])
    df = pd.DataFrame(products_df,
                      columns=["sku", "name", "presentation", "laboratory", "stock", "cost_value", "sale_value",
                               "expiration_date", "iva"], index=None)
    return df


def list_all_the_sales_filtered():
    sales_data_frame = list_all_sales()
    print(f"What information would you like to see?")
    print("1. Order number")
    print("2. Date")
    print("3. Name")
    print("4. Amount")
    print("5. Subtotal")
    print("6. Total")
    print("7. Payment type")
    print("8. Billed")
    option = input("Please enter the option number: ")
    if option == "1":
        order_number = int(input("Please enter the order number: "))
        print(
            sales_data_frame.loc[sales_data_frame["order_number"] == order_number])
    elif option == "2":
        Date = input("Please enter the date (dd/mm/yyyy): ")
        print(sales_data_frame.loc[sales_data_frame["date"]
              == datetime.strptime(Date, "%d/%m/%Y")])
    elif option == "3":
        name = int(input("Please enter the name: "))
        print(sales_data_frame.loc[sales_data_frame["name"] == name])
    elif option == "4":
        amount = int(input("Please enter the amount: "))
        print(sales_data_frame.loc[sales_data_frame["amount"] == amount])
    elif option == "5":
        subtotal = float(input("Please enter the subtotal: "))
        print(sales_data_frame.loc[sales_data_frame["subtotal"] == subtotal])
    elif option == "6":
        total = float(input("Please enter the total: "))
        print(sales_data_frame.loc[sales_data_frame["total"] == total])
    elif option == "7":
        payment_type = input("Please enter the payment type: ")
        print(
            sales_data_frame.loc[sales_data_frame["payment_type"] == payment_type])
    elif option == "8":
        billed = input("Please enter the billed (y/n): ")
        if billed == "y":
            billed = True
        else:
            billed = False
        print(sales_data_frame.loc[sales_data_frame["billed"] == billed])


def see_specific_product_information():
    df = list_all_products()
    print(f"What information would you like to see?")
    print("1. SKU")
    print("2. Name")
    print("3. Presentation")
    print("4. Laboratory")
    print("5. Stock")
    print("6. Cost value")
    print("7. Sale value")
    print("8. Expiration date")
    print("9. IVA")
    option = input("Please enter the option number: ")
    if option == "1":
        print(df["sku"])
    elif option == "2":
        print(df["name"])
    elif option == "3":
        print(df["presentation"])
    elif option == "4":
        print(df["laboratory"])
    elif option == "5":
        print(df["stock"])
    elif option == "6":
        print(df["cost_value"])
    elif option == "7":
        print(df["sale_value"])
    elif option == "8":
        print(df["expiration_date"])
    elif option == "9":
        print(df["iva"])


def see_specific_sale_information():
    df = list_all_sales()
    print(f"What information would you like to see?")
    print("1. Order number")
    print("2. Date")
    print("3. Name")
    print("4. Amount")
    print("5. Subtotal")
    print("6. Total")
    print("7. Payment type")
    print("8. Billed")
    option = input("Please enter the option number: ")
    if option == "1":
        print(df["order_number"])
    elif option == "2":
        print(df["date"])
    elif option == "3":
        print(df["name"])
    elif option == "4":
        print(df["amount"])
    elif option == "5":
        print(df["subtotal"])
    elif option == "6":
        print(df["total"])
    elif option == "7":
        print(df["payment_type"])
    elif option == "8":
        print(df["billed"])


def list_products_soon_to_expiry():
    # List products in the inventory that are soon to expiry (2 months or less)
    df = list_all_products()
    print(df.loc[df["expiration_date"] <= datetime.now() + timedelta(days=60)])


def update_excel():
    # First, we need to modify all the dates to strings, so they can be saved in the Excel file
    sales_data_frame = list_all_sales()
    sales_data_frame["date"] = sales_data_frame["date"].apply(
        lambda x: x.strftime("%d/%m/%Y"))
    products_data_frame = list_all_products()
    products_data_frame["expiration_date"] = products_data_frame["expiration_date"].apply(
        lambda x: x.strftime("%d/%m/%Y"))

    # Now we do the same for the inventory
    inventory_data_frame = list_all_products()
    inventory_data_frame["expiration_date"] = inventory_data_frame["expiration_date"].apply(
        lambda x: x.strftime("%d/%m/%Y"))

    # Now we save the sales dataframes in the Excel file
    with pd.ExcelWriter("DB/Sales.xlsx") as writer:
        sales_data_frame.to_excel(writer, sheet_name="Sales")

    # Now we save the inventory dataframes in the Excel file
    with pd.ExcelWriter("DB/Inventory.xlsx") as writer:
        inventory_data_frame.to_excel(writer, sheet_name="Inventory")


def reports():
    while True:
        print("Please select an option:")
        print("1. See specific sale information")
        print("2. List all the sales")
        print("3. List all the sales filtered")
        print("4. See specific product information")
        print("5. List all the inventory")
        print("6. List products soon to expiry")
        print("7. Exit")
        option = input("Please enter the option number: ")
        print("\n\n\n\n\n\n\n\n\n\n\n\n\n\n")
        if option == "1":
            see_specific_sale_information()
        elif option == "2":
            print(list_all_sales())
        elif option == "3":
            list_all_the_sales_filtered()
        elif option == "4":
            see_specific_product_information()
        elif option == "5":
            print(list_all_products())
        elif option == "6":
            list_products_soon_to_expiry()
        elif option == "7":
            break


def main_menu():
    while True:
        print("Please select an option:")
        print("1. Add product")
        print("2. Create sale")
        print("3. Reports")
        print("4. Sales reports")
        print("5. Update Database")
        print("6. Exit")
        option = input("Please enter the option number: ")
        print("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n")
        if option == "1":
            add_product()
        elif option == "2":
            create_sale()
        elif option == "3":
            reports()
        elif option == "4":
            pass
        elif option == "5":
            update_excel()
        elif option == "6":
            break
        else:
            print("Invalid option!")
