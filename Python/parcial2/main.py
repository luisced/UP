from models import *
from utils import *
from datetime import datetime, date, timedelta
import pandas as pd

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


def main():
    main_menu()


if __name__ == '__main__':
    main()
