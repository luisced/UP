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
    displayInputBox("Enter the product stock");
    cin >> stock;
    displayInputBox("Enter the laboratory");
    getline(cin, laboratory);
    displayInputBox("Enter the expiration date");
    getline(cin, expirationDate);

    id = db.products.size() + 1;
    sku = randomString();

    Product product(id, sku, name, presentation, laboratory, stock, cost, price, expirationDate, iva);
    db.addProduct(product);
}

static Product addProductToSale()
{
    string productName, findProduct;
    int id, productsSold, stock;
    float subtotal, total;
    bool bill;
    vector<Product> products;

    displayInputBox("Enter the product name");
    cin >> productName;
    Product product = db.findProductByName(productName);
    if (product.id == 0)
    {
        cout << "Product not found" << endl;
        return product;
        pressEnterToContinue();
    }
    displayInputBox("What quantity would you like to buy?");
    cin >> stock;
    if (stock > product.stock)
    {
        cout << "Not enough stock" << endl;
        return product;
        pressEnterToContinue();
    }
    else
    {
        product.stock -= stock;
        Product updatedproduct(product.id, product.sku, product.name, product.presentation, product.laboratory, product.stock, product.cost, product.price, product.expirationDate, product.iva);
        db.updateProduct(product.id, updatedproduct);
    }
    return product;
}

static void createSale()
{

    string date, productName, buyProduct, payMethod;
    int productsSold, stock, paymentOption, orderNumber;
    float subtotal, total;
    bool bill;
    vector<Product> products;
    vector<map<string, int>> productList;
    PaymMethod payments;

    while (true)
    {
        Product product = addProductToSale();
        if (product.id == 0)
        {
            break;
        }
        else
        {
            products.push_back(product);
            displayInputBox("Would you like to add another product? (y/n)");
            cin >> buyProduct;
            if (buyProduct == "n")
            {
                for (int i = 0; i < products.size(); i++)
                {
                    Product product = products[i];
                    map<string, int> productMap;
                    productMap.insert(pair<string, int>(product.name, product.stock));
                    productList.push_back(productMap);
                }
                break;
            }
        }
    }
    // display payments:

    displayInputBox("Enter the payment method, please input a number");
    for (int i = 0; i < 3; i++)
    {
        cout << i + 1 << ". " << payments.methods[i] << endl;
    }
    cin >> paymentOption;
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

    // calculate subtotal sum al cost
    for (int i = 0; i < products.size(); i++)
    {
        subtotal += products[i].price;
    }

    // // calculate total sum al cost + iva
    for (int i = 0; i < products.size(); i++)
    {
        total += products[i].price + products[i].iva;
    }

    // todays date
    time_t now = time(0);
    tm *ltm = localtime(&now);
    date = to_string(1900 + ltm->tm_year) + "-" + to_string(1 + ltm->tm_mon) + "-" + to_string(ltm->tm_mday);

    // bill
    displayInputBox("Would you like a bill? (y/n)");
    string billInput;
    cin >> billInput;
    bill = true ? billInput == "y" : false;

    // order number
    orderNumber = db.sales.size() + 1;

    Sale sale(orderNumber, date, productList, subtotal, total, payMethod, bill);
    db.addSale(sale);
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
