#include <iostream>
#include <string>
#include <vector>
#include <ctime>
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

    Product(int id, string sku ,string name, string presentation, string laboratory, int stock, float cost, float price, string expirationDate, bool iva)
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
    string orderNumber;
    string date;
    vector<Product> products;
    int productsSold;
    float subtotal;
    float total;
    string paymentMethod;
    bool bill;
    Sale(string orderNumber, string date, vector<Product> products, int productsSold, float subtotal, float total, string paymentMethod, bool bill)
    {
        this->orderNumber = orderNumber;
        this->date = date;
        this->products = products;
        this->productsSold = productsSold;
        this->subtotal = subtotal;
        this->total = total;
        this->paymentMethod = paymentMethod;
        this->bill = bill;
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

    void createSale(Sale sale)
    {
        this->sales.push_back(sale);
    }

    void listSales()
    {
        double totalSales = 0, cardSalesAmount = 0, cashSalesAmount = 0, debitCardSalesAmount = 0, billedSales = 0, unbilledSales = 0;

        for (int i = 0; i < this->sales.size(); i++)
        {
            Sale sale = this->sales[i];
            cout << "Número de Orden: " << sale.orderNumber << endl;
            cout << "Fecha: " << sale.date << endl;
            cout << "Productos: " << endl;
            for (int j = 0; j < sale.products.size(); j++)
            {
                sale.products[j].print();
            }
            cout << "Productos Vendidos: " << sale.productsSold << endl;
            cout << "Subtotal: " << sale.subtotal << endl;
            cout << "Total: " << sale.total << endl;
            cout << "Método de Pago: " << sale.paymentMethod << endl;
            cout << "Facturado: " << sale.bill << endl;
            cout << endl;
            totalSales += sale.total;
            if (sale.paymentMethod == "Efectivo")
            {
                cashSalesAmount += sale.total;
            }
            else if (sale.paymentMethod == "Tarjeta de Crédito")
            {
                cardSalesAmount += sale.total;
            }
            else if (sale.paymentMethod == "Tarjeta de Débito")
            {
                debitCardSalesAmount += sale.total;
            }
            if (sale.bill)
            {
                billedSales += sale.total;
            }
            else
            {
                unbilledSales += sale.total;
            }
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
    // cout << "Payments:" << endl;
    // for (int i = 0; i < 3; i++) {
    //     string method = payment.methods[i];
    //     cout << method << endl;
    // }
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

    Product product(id, sku,name, presentation, laboratory,stock  ,cost, price, expirationDate, iva);
    db.addProduct(product);
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
            break;
        case 4:
            break;
        case 5:
            break;
        }
        choice = menu.display();
    }
    return 0;
}
