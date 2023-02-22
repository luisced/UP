#include <iostream>
#include <string>
#include <vector>
#include <ctime>
#include <chrono>
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
    vector<Product> products;
    vector<Sale> sales;
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
        cout << "╔═════════════════════════════════╗" << endl;
        cout << "║ ID ║                                 " << endl;
        cout << "╠════╣═════════════════════════════╣" << endl;
        for (int i = 0; i < this->sales.size(); i++)
        {
            this->sales[i].print();
        }
    }
    void listProducts()
    {
        consoleClear();
        vector<string> headers = {"ID", "SKU", "Name", "Presentation", "Laboratory", "Stock", "Cost", "Price", "Expire Date", "IVA"};
        vector<vector<string>> data;
        for (int i = 0; i < this->products.size(); i++)
        {
            vector<string> row;
            row.push_back(to_string(this->products[i].id));
            row.push_back(this->products[i].sku);
            row.push_back(this->products[i].name);
            row.push_back(this->products[i].presentation);
            row.push_back(this->products[i].laboratory);
            row.push_back(to_string(this->products[i].stock));
            row.push_back(to_string(this->products[i].cost));
            row.push_back(to_string(this->products[i].price));
            row.push_back(this->products[i].expirationDate);
            row.push_back(to_string(this->products[i].iva));
            data.push_back(row);
        }
        // for (int i = 0; i < this->products.size(); i++)
        // {
        //     this->products[i].print();
        // }
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
        temporaryProducts.clear();
        this->temporaryProducts.push_back(product);
    }

    vector<map<string, int>> getTemporaryProducts()
    {
        return this->temporaryProducts;
    }

private:
    void buildTable(const vector<string> &headers, const vector<vector<string>> &data)
    {
        // Determine the maximum width of each column
        vector<size_t> widths(headers.size(), 0);
        for (const auto &row : data)
        {
            for (size_t i = 0; i < row.size(); i++)
            {
                widths[i] = max(widths[i], row[i].size());
            }
        }

        // Print the table
        cout << setfill(' ') << left;
        cout << setw(widths[0]) << headers[0] << " ";
        for (size_t i = 1; i < headers.size(); i++)
        {
            cout << "│ " << setw(widths[i]) << headers[i] << " ";
        }
        cout << endl;

        cout << setfill(' ') << left;
        cout << setw(widths[0]) << "╠═══"
             << "═";
        for (size_t i = 1; i < headers.size(); i++)
        {
            cout << "╪═══" << setfill('═') << setw(widths[i]) << "═";
            cout << setfill(' ') << left << "═";
        }
        cout << "╣" << endl;

        for (const auto &row : data)
        {
            cout << setfill(' ') << left;
            cout << setw(widths[0]) << row[0] << " ";
            for (size_t i = 1; i < row.size(); i++)
            {
                cout << "│ " << setw(widths[i]) << row[i] << " ";
            }
            cout << endl;
        }

        cout << setfill(' ') << left;
        cout << setw(widths[0]) << "╚═══"
             << "═";
        for (size_t i = 1; i < headers.size(); i++)
        {
            cout << "╧═══" << setfill('═') << setw(widths[i]) << "═";
            cout << setfill(' ') << left << "═";
        }
        cout << "╝" << endl;
    }
};

static DB db;

class Menu
{
public:
    // Constructor to initialize the menu options
    Menu(const vector<string> &options) : options_(options) {}

    // Display the menu and prompt for user input
    int display()
    {
        while (true)
        {

            system("clear");
            printTitle();
            cout << "\u001b[34m";
            cout << "╔═════════════════════════════════╗" << endl;
            cout << "║            MAIN MENU            ║" << endl;
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

    void printTitle()
    {
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
    getline(cin, presentation);
    displayInputBox("Enter the product price");
    cin >> price;
    displayInputBox("Enter the product cost");
    cin >> cost;
    displayInputBox("Enter the product stock");
    cin >> stock;
    displayInputBox("Enter the laboratory");
    cin >> laboratory;
    displayInputBox("Enter the expiration date");
    getline(cin, expirationDate);
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
                total += product.second * (db.findProductByName(product.first).price * 1.16);
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
}

int main()
{

    vector<string> options = {"Create Product", "List Products", "Create Sale", "List Sales", "Exit"};
    Menu menu(options);
    int choice = menu.display();
    while (choice != 5)
    {
        switch (choice)
        {
        case 1:
            createProduct();
            break;
        case 2:
            db.listProducts();
            pressEnterToContinue();
            break;
        case 3:
            createSale();
            break;
        case 4:
            db.listSales();
            pressEnterToContinue();
            break;
        case 5:
            break;
        }
        choice = menu.display();
    }
    return 0;
}
