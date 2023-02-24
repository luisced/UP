#include <iostream>
#include <iomanip>
#include <string>
#include <vector>
#include <ctime>
#include <chrono>
#include <sstream>

#include <map>

using namespace std;

class PaymMethod
{
public:
    string methods[3] = {"Cash", "Credit Card", "Debit Card"};
};

class Pharmacy
{
public:
    string name;
    Pharmacy(string name)
    {
        this->name = name;
    }
};

class Product
{
public:
    int id;
    string sku;
    string name;
    string presentation;
    string laboratory;
    int stock;
    float cost;
    float price;
    string expirationDate;
    bool iva;

    Product(int id, string sku, string name, string presentation, string laboratory, int stock, float cost, float price, string expirationDate, bool iva)
    {
        this->id = id;
        this->sku = sku;
        this->name = name;
        this->presentation = presentation;
        this->laboratory = laboratory;
        this->stock = stock;
        this->cost = cost;
        this->price = price;
        this->expirationDate = expirationDate;
        this->iva = iva;
    }

    void print()
    {
        cout << "ID: " << this->id << endl;
        cout << "SKU: " << this->sku << endl;
        cout << "Name: " << this->name << endl;
        cout << "Presentation: " << this->presentation << endl;
        cout << "Laboratory: " << this->laboratory << endl;
        cout << "Stock: " << this->stock << endl;
        cout << "Cost: " << this->cost << endl;
        cout << "Price: " << this->price << endl;
        cout << "Expire Date: " << this->expirationDate << endl;
        cout << "IVA: " << this->iva << endl;
    }
};

class Sale
{
public:
    int orderNumber;
    string date;
    vector<map<string, int>> productList;
    int productsSold;
    float subtotal;
    float total;
    string paymentMethod;
    bool bill;
    Sale(int orderNumber, string date, vector<map<string, int>> productList, float subtotal, float total, string paymentMethod, bool bill)
    {
        this->orderNumber = orderNumber;
        this->date = date;
        this->productList = productList;
        this->subtotal = subtotal;
        this->total = total;
        this->paymentMethod = paymentMethod;
        this->bill = bill;
    }
    void print()
    {
        cout << "Número de Orden: " << this->orderNumber << endl;
        cout << "Fecha: " << this->date << endl;
        cout << "Productos: " << endl;
        for (int i = 0; i < productList.size(); i++)
        {
            cout << productList[i].begin()->first << " " << productList[i].begin()->second << endl;
        }
        cout << "Subtotal: " << this->subtotal << endl;
        cout << "Total: " << this->total << endl;
        cout << "Método de Pago: " << this->paymentMethod << endl;
        cout << "Facturado: " << this->bill << endl;
        cout << endl;
    }
};
static void pressEnterToContinue()
{
    cout << "Press Enter to continue...";
    cin.ignore();
    cin.get();
}

static void consoleClear()
{
    system("clear");
}

static string randomString()
{
    string str = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    int pos;
    char randomString[10];
    for (int i = 0; i < 10; ++i)
    {
        pos = ((rand() % (str.size() - 1)));
        randomString[i] = str[pos];
    }
    return randomString;
}

class DB
{
public:
    vector<Product> products = {
        Product(1, "123456789", "Paracetamol", "Tabletas", "Bayer", 100, 10, 15, "2019-12-31", true),
        Product(2, "123456789", "Ibuprofeno", "Tabletas", "Pfizer", 100, 10, 15, "2021-12-31", true),
        Product(3, "123456789", "Aspirina", "Tabletas", "Astra", 100, 10, 15, "2022-12-31", false),
        Product(4, "123456789", "Cetirizina", "Tabletas", "Bayer", 100, 10, 15, "2023-02-10", true),
    };
    vector<Sale> sales = {
        Sale(1001, "2022-01-01", {{{"Product 1", 2}, {"Product 2", 1}}, {{"Product 3", 4}}}, 100.00, 115.00, "Credit Card", true),
        Sale(1002, "2021-01-05", {{{"Product 2", 3}}, {{"Product 1", 1}, {"Product 3", 2}}}, 50.00, 58.50, "Cash", false),
        Sale(1003, "2019-02-10", {{{"Product 3", 5}}}, 25.00, 28.75, "Debit Card", true),
        Sale(1004, "2019-03-15", {{{"Product 1", 2}, {"Product 3", 1}}}, 75.00, 86.25, "Cash", false),
        Sale(1005, "2022-12-20", {{{"Product 2", 1}}, {{"Product 1", 3}, {"Product 3", 2}}}, 80.00, 92.00, "Credit Card", true)};

    vector<map<string, int>> temporaryProducts;
    void addProduct(Product product)
    {
        this->products.push_back(product);
    }

    Product findProductByName(string product)
    {

        // return the products name and the quantity, else deliver an error
        for (int i = 0; i < this->products.size(); i++)
        {
            if (this->products[i].name == product)
            {
                return this->products[i];
            }
        }

        return Product(0, "", "", "", "", 0, 0, 0, "", false);
    }

    void addSale(Sale sale)
    {
        this->sales.push_back(sale);
    }

    void listSales()
    {
        consoleClear();

        for (int i = 0; i < this->sales.size(); i++)
        {
            this->sales[i].print();
        }
    }
    void listProducts()
    {
        consoleClear();
        for (int i = 0; i < this->products.size(); i++)
        {
            this->products[i].print();
        }
    }

    void updateProduct(int id, Product product)
    {
        for (int i = 0; i < this->products.size(); i++)
        {
            if (this->products[i].id == id)
            {
                this->products[i] = product;
            }
        }
    }

    void addTemporaryProduct(map<string, int> product)
    {
        this->temporaryProducts.push_back(product);
    }

    vector<map<string, int>> getTemporaryProducts()
    {
        return this->temporaryProducts;
    }

    void clearTemporaryProducts()
    {
        this->temporaryProducts.clear();
    }

    // filters

    void SaleFilterByOrderNumber()
    {
        consoleClear();
        int oderNumber;
        cout << "Enter the order number: ";
        cin >> oderNumber;

        for (int i = 0; i < this->sales.size(); i++)
        {
            if (this->sales[i].orderNumber == oderNumber)
            {
                this->sales[i].print();
            }
            else
            {
                cout << "Sale was not found" << endl;
            }
        }
    }

    void SaleFilterByYear()
    {
        consoleClear();
        int year;
        cout << "Enter the year: ";
        cin >> year;

        for (int i = 0; i < this->sales.size(); i++)
        {
            if (this->sales[i].date.substr(0, 4) == to_string(year))
            {
                this->sales[i].print();
            }
        }
    }

    void SaleFilterByMonth()
    {
        consoleClear();
        string month;
        cout << "Enter the month: ";
        cin >> month;

        for (int i = 0; i < this->sales.size(); i++)
        {
            if (this->sales[i].date.substr(5, 2) == month)
            {
                this->sales[i].print();
            }
        }
    }
    void ProductFilterBySoonToExpire()
    {
        consoleClear();
        auto now = chrono::system_clock::now();
        auto thirtyDaysAgo = now - chrono::hours(24 * 30);

        for (auto product : this->products)
        {

            tm t = {};
            istringstream ss(product.expirationDate);
            ss >> get_time(&t, "%Y-%m-%d");
            auto expirationDate = chrono::system_clock::from_time_t(mktime(&t));

            if (expirationDate < thirtyDaysAgo)
            {
                product.print();
            }
        }
    }

    void SaleFilterByDateRange()
    {
        consoleClear();
        string date1, date2;
        cout << "Enter the first date: ";
        cin >> date1;
        cout << "Enter the second date: ";
        cin >> date2;

        for (int i = 0; i < this->sales.size(); i++)
        {
            if (this->sales[i].date >= date1 && this->sales[i].date <= date2)
            {
                this->sales[i].print();
            }
        }
    }

    void SaleFilterByPaymentMethod()
    {
        consoleClear();
        string paymentMethod;
        cout << "Enter the payment method: ";
        cin >> paymentMethod;

        for (int i = 0; i < this->sales.size(); i++)
        {
            if (this->sales[i].paymentMethod == paymentMethod)
            {
                this->sales[i].print();
            }
        }
    }

    void SaleFilterByBill()
    {
        consoleClear();
        bool bill;
        char billChar;
        cout << "Bill(y/n): ";
        cin >> billChar;
        bill = billChar == 'y' ? true : false;

        for (int i = 0; i < this->sales.size(); i++)
        {
            if (this->sales[i].bill == bill)
            {
                this->sales[i].print();
            }
        }
    }

    void ProductFilterByName()
    {
        consoleClear();
        string name;
        cout << "Enter the name: ";
        cin >> name;

        for (int i = 0; i < this->products.size(); i++)
        {
            if (this->products[i].name == name)
            {
                this->products[i].print();
            }
        }
    }

    void ProductFilterByLaboratory()
    {
        consoleClear();
        string laboratory;
        cout << "Enter the laboratory: ";
        cin >> laboratory;

        for (int i = 0; i < this->products.size(); i++)
        {
            if (this->products[i].laboratory == laboratory)
            {
                this->products[i].print();
            }
        }
    }
};

static DB db;

class Report
{
};

class Menu
{
public:
    // Constructor to initialize the menu options and title
    Menu(const vector<string> &options, const string &menuTitle) : options_(options), menuTitle_(menuTitle) {}

    // Display the menu and prompt for user input
    int display()
    {
        while (true)
        {
            system("clear");
            printTitle();
            cout << "\u001b[34m";
            cout << "╔═════════════════════════════════╗" << endl;
            cout << "║ " << menuTitle_ << string(29 - menuTitle_.size(), ' ') << "   ║" << endl;
            cout << "╠═════════════════════════════════╣" << endl;
            for (int i = 0; i < options_.size(); i++)
            {
                cout << "║ " << i + 1 << ". " << options_[i] << string(29 - options_[i].size(), ' ') << "║" << endl;
            }
            cout << "╚═════════════════════════════════╝" << endl;
            cout << "Enter your option (1-" << options_.size() << "): ";

            int choice;
            cin >> choice;

            if (choice >= 1 && choice <= options_.size())
            {
                return choice;
            }
            else
            {
                cout << "Invalid option, please try again:" << endl;
            }
        }
    }

private:
    vector<string> options_;
    string menuTitle_;

    void printTitle()
    {
        cout << "\n\n\n";
        cout << "\u001b[32m";
        cout << "░██████╗░█████╗░███╗░░██╗  ██████╗░░█████╗░██████╗░██╗░░░░░░█████╗░" << endl;
        cout << "██╔════╝██╔══██╗████╗░██║  ██╔══██╗██╔══██╗██╔══██╗██║░░░░░██╔══██╗" << endl;
        cout << "╚█████╗░███████║██╔██╗██║  ██████╔╝███████║██████╦╝██║░░░░░██║░░██║" << endl;
        cout << "░╚═══██╗██╔══██║██║╚████║  ██╔═══╝░██╔══██║██╔══██╗██║░░░░░██║░░██║" << endl;
        cout << "██████╔╝██║░░██║██║░╚███║  ██║░░░░░██║░░██║██████╦╝███████╗╚█████╔╝" << endl;
        cout << "╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝  ╚═╝░░░░░╚═╝░░╚═╝╚═════╝░╚══════╝░╚════╝░" << endl;
        cout << endl;
    }
};

static void displayInputBox(string prompt)
{
    consoleClear();
    string userInput;

    int promptLength = prompt.length();
    int boxWidth = promptLength + 6;

    cout << "╔";
    for (int i = 0; i < boxWidth - 2; i++)
    {
        cout << "═";
    }
    cout << "╗" << endl;

    cout << "║   " << prompt << " ║" << endl;

    cout << "╚";
    for (int i = 0; i < boxWidth - 2; i++)
    {
        cout << "═";
    }
    cout << "╝" << endl;
    cout << "Enter your option: ";
}

static void createProduct()
{
    PaymMethod payment;
    string name, presentation, laboratory, expirationDate, sku;
    int stock, id;
    float cost, price;
    bool iva;
    displayInputBox("Enter the product name");
    cin >> name;
    displayInputBox("Enter the product presentation");
    cin >> presentation;
    displayInputBox("Enter the product price");
    cin >> price;
    displayInputBox("Enter the product cost");
    cin >> cost;
    displayInputBox("Enter the product stock");
    cin >> stock;
    displayInputBox("Enter the laboratory");
    cin >> laboratory;
    displayInputBox("Enter the expiration date");
    cin >> expirationDate;
    displayInputBox("Is the product taxable? (y/n)");
    string tax;
    cin >> tax;
    iva = true ? tax == "y" : false;

    id = db.products.size() + 1;
    sku = randomString();

    Product product(id, sku, name, presentation, laboratory, stock, cost, price, expirationDate, iva);
    db.addProduct(product);
}

static void createSale()
{
    if (db.products.size() == 0)
    {
        cout << "There are no products to sell" << endl;
        pressEnterToContinue();
        return;
    }
    string date, buyProduct, payMethod;
    int productsSold, stock, paymentOption, orderNumber;
    float subtotal = 0.0, total = 0.0;
    bool bill;
    vector<map<string, int>> productList;
    PaymMethod payments;

    // Ask for the product name
    string productName;
    displayInputBox("Enter the product name");
    cin >> productName;
    Product product = db.findProductByName(productName);

    while (product.id == 0)
    {
        displayInputBox("Product not found, Enter the product name or type 'exit' to exit");
        cin >> productName;
        if (productName == "exit")
        {
            return;
        }
        else
        {
            product = db.findProductByName(productName);
        }
    }

    if (product.id == 0)
    {
        cout << "Product not found" << endl;
        return;
        pressEnterToContinue();
    }
    // Ask for the quantity, if the quantity is greater than the stock, show an error message
    int stockInventory;
    displayInputBox("What quantity would you like to buy?");
    cin >> stockInventory;
    while (stockInventory > product.stock)
    {
        displayInputBox("Not enough stock, What quantity would you like to buy?");
        cin >> stockInventory;
    }
    product.stock -= stockInventory;
    string anotherProduct;
    displayInputBox("Would you like to add another product? (y/n)");
    cin >> anotherProduct;
    if (anotherProduct == "y")
    {
        map<string, int> productMap;
        productMap.insert(pair<string, int>(product.name, stockInventory));
        db.addTemporaryProduct(productMap);
        createSale();
        return;
    }
    else
    {
        map<string, int> productMap;
        productMap.insert(pair<string, int>(product.name, stockInventory));
        db.addTemporaryProduct(productMap);
    }
    // display payments:
    displayInputBox("Enter the payment method, please input a number");
    cout << "\n";
    for (int i = 0; i < 3; i++)
    {
        cout << i + 1 << ". " << payments.methods[i] << endl;
    }
    cin >> paymentOption;
    while (paymentOption > 3 || paymentOption < 1)
    {
        cout << "Invalid option, please try again: " << endl;
        cin >> paymentOption;
    }
    switch (paymentOption)
    {
    case 1:
        payMethod = payments.methods[0];
        break;
    case 2:
        payMethod = payments.methods[1];
        break;
    case 3:
        payMethod = payments.methods[2];
        break;
    default:
        break;
    }

    // bill
    string billInput;
    displayInputBox("Would you like a bill? (y/n)");
    cin >> billInput;
    bill = true ? billInput == "y" : false;

    // fetch products from the temporary list
    productList = db.getTemporaryProducts();
    // calculate subtotal sum all productList map values´
    for (const auto &productMap : productList)
    {
        for (const auto &product : productMap)
        {
            subtotal += product.second * db.findProductByName(product.first).price;
        }
    }

    // calculate total sum al cost + iva if the product is taxable
    for (const auto &productMap : productList)
    {
        for (const auto &product : productMap)
        {
            if (db.findProductByName(product.first).iva)
            {
                total += product.second * (db.findProductByName(product.first).price + (db.findProductByName(product.first).price * 0.16));
            }
            else
            {
                total += product.second * db.findProductByName(product.first).price;
            }
        }
    }

    // todays date
    time_t now = time(0);
    tm *ltm = localtime(&now);
    date = to_string(1900 + ltm->tm_year) + "-" + to_string(1 + ltm->tm_mon) + "-" + to_string(ltm->tm_mday);

    // order number
    orderNumber = db.sales.size() + 1;

    // add sale to the database

    Sale sale(orderNumber, date, productList, subtotal, total, payMethod, bill);
    db.addSale(sale);
    // Update the stock
    Product updatedproduct(product.id, product.sku, product.name, product.presentation, product.laboratory, product.stock, product.cost, product.price, product.expirationDate, product.iva);
    db.updateProduct(product.id, updatedproduct);
    db.clearTemporaryProducts();

    // clear the temporary list
}

// fliter sales by date menu

static void filterbydate()
{
    vector<string> options3 = {"By year", "By month", "By date range", "Exit"};

    consoleClear();
    cout << "Sales filtered by date" << endl;
    Menu menu3(options3, "SALES FILTERED BY DATE");
    int choice3 = menu3.display();
    switch (choice3)
    {
    case 1:
        db.SaleFilterByYear();
        pressEnterToContinue();
        break;
    case 2:
        db.SaleFilterByMonth();
        pressEnterToContinue();
        break;
    case 3:
        db.SaleFilterByDateRange();
        pressEnterToContinue();
        break;
    case 4:
        return;
    }
}

int main()
{

    vector<string> options = {"Create Product", "Create Sale", "Generate Report", "Exit"};
    vector<string> options2 = {"See specific sale information", "List all the sales", "S.filtered by date", "S. by payment method", "S. by lab", "S. by bill", "P. information", "P. by Laboratory", "P. soon to expire", "All Products",
                               "Exit"};

    Menu menu(options, "MAIN MENU");
    int choice = menu.display();
    while (choice != 4)
    {
        switch (choice)
        {
        case 1:
            createProduct();
            break;
        case 2:
            createSale();
            break;
        case 3:
            Menu menu2(options2, "REPORTS");
            int choice2 = menu2.display();
            while (choice2 != 11)
            {
                switch (choice2)
                {
                case 1:

                    db.SaleFilterByOrderNumber();
                    pressEnterToContinue();
                    break;
                case 2:
                    db.listSales();
                    pressEnterToContinue();
                    break;
                case 3:
                    filterbydate();
                    break;
                case 4:
                    db.SaleFilterByPaymentMethod();
                    pressEnterToContinue();
                    break;
                case 5:
                    db.listSales();
                    pressEnterToContinue();
                    break;
                case 6:
                    db.SaleFilterByBill();
                    pressEnterToContinue();
                    break;
                case 7:
                    db.ProductFilterByName();

                    pressEnterToContinue();
                    break;
                case 8:
                    db.ProductFilterByLaboratory();
                    pressEnterToContinue();
                    break;
                case 9:
                    db.ProductFilterBySoonToExpire();
                    pressEnterToContinue();
                    break;
                case 10:
                    db.listProducts();
                    pressEnterToContinue();
                    break;
                }
                choice2 = menu2.display();
            }
            break;
        }
        choice = menu.display();
    }
    return 0;
}
