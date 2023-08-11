
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <iomanip>
#include <string>
#include <vector>
#include <ctime>
#include <chrono>
#include <sstream>
#include <stdlib.h>
// #include <windows.h>
#include <map>

using namespace std;

// C L A S E S

class PaymMethod
{
public:
    string methods[3] = {"Cash", "CreditCard", "DebitCard"};
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
    string laboratory;

    Sale(int orderNumber, string date, vector<map<string, int>> productList, float subtotal, float total, string paymentMethod, bool bill, string laboratory)
    {
        this->orderNumber = orderNumber;
        this->date = date;
        this->productList = productList;
        this->subtotal = subtotal;
        this->total = total;
        this->paymentMethod = paymentMethod;
        this->bill = bill;
        this->laboratory = laboratory;
    }
    void print()
    {
        cout << "--------------------------------------------------------- " << endl;
        cout << "Order number: " << this->orderNumber << endl;
        cout << "Date: " << this->date << endl;
        cout << "Products: " << endl;
        for (int i = 0; i < productList.size(); i++)
        {
            cout << productList[i].begin()->first << " " << productList[i].begin()->second << endl;
        }
        cout << "\nSubtotal: " << this->subtotal << endl;
        cout << "Total: " << this->total << endl;
        cout << "Pay method: " << this->paymentMethod << endl;
        cout << "Bill: " << this->bill << endl;
        cout << "--------------------------------------------------------- " << endl;
        cout << endl;
    }
};

static void pressEnterToContinue()
{
    cout << "Press Enter to continue...";
    cin.ignore();
    cin.get();
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

// static void consoleClear()
//{
//  system("clear");
// }

class DB
{
public:
    vector<Product> products = {};
    vector<Sale> sales = {};

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
        float total = 0;
        // consoleClear();
        for (int i = 0; i < this->sales.size(); i++)
        {
            this->sales[i].print();
            total += this->sales[i].total;
        }
        cout << "Total: " << total << endl;
    }

    void listProducts()
    {

        // consoleClear();
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
        // consoleClear();
        int oderNumber;
        cout << "Please, enter the ID: " << endl;
        float totalSold = 0;
        cin >> oderNumber;

        for (int i = 0; i < this->sales.size(); i++)
        {
            if (this->sales[i].orderNumber == oderNumber)
            {

                this->sales[i].print();
                totalSold += this->sales[i].total;
            }
        }
    }

    void SaleFilterByYear()
    {
        // consoleClear();
        int year;
        float totalSold = 0;
        cout << "Please, input the year: ";
        cin >> year;

        for (int i = 0; i < this->sales.size(); i++)
        {
            if (this->sales[i].date.substr(0, 4) == to_string(year))
            {
                this->sales[i].print();
                totalSold += this->sales[i].total;
            }
        }
        cout << "Total sold: " << totalSold << endl;
    }

    void SaleFilterByMonth()
    {
        // consoleClear();
        string month;
        float totalSold = 0;

        cout << "Please, Input the month: ";
        cin >> month;

        for (int i = 0; i < this->sales.size(); i++)
        {
            if (this->sales[i].date.substr(5, 2) == month)
            {
                this->sales[i].print();
                totalSold += this->sales[i].total;
            }
        }
    }

    void ProductFilterBySoonToExpire()
    {
        // consoleClear();
        auto now = chrono::system_clock::now();
        auto thirtyDaysAgo = now - chrono::hours(24 * 30);

        for (auto product : this->products)
        {

            tm t = {};
            istringstream ss(product.expirationDate);
            ss >> get_time(&t, "%Y-%m-%d");
            auto time = chrono::system_clock::from_time_t(mktime(&t));
            if (time >= thirtyDaysAgo && time <= now)
            {
                product.print();
            }
        }
    }

    bool getProductByName(string name)
    {
        for (auto product : this->products)
        {
            if (product.name == name)
            {
                return true;
            }
        }
        return false;
    }

    void SaleFilterByDateRange()
    {
        // consoleClear();
        string date1, date2;
        float totalSold = 0;
        cout << "Dear customer, please input the first date: ";
        cin >> date1;
        cout << "Please input the first date: ";
        cin >> date2;

        for (int i = 0; i < this->sales.size(); i++)
        {
            if (this->sales[i].date >= date1 && this->sales[i].date <= date2)
            {
                this->sales[i].print();
                totalSold += this->sales[i].total;
            }
        }
        cout << "Total sold: " << totalSold << endl;
    }

    void SaleFilterByPaymentMethod()
    {
        // consoleClear();
        string paymentMethod;
        float totalSold = 0;

        cout << "Dear customer, please input the payment method: ";
        cin >> paymentMethod;

        for (int i = 0; i < this->sales.size(); i++)
        {
            if (this->sales[i].paymentMethod == paymentMethod)
            {
                this->sales[i].print();
                totalSold += this->sales[i].total;
            }
        }
        cout << "Total sold: " << totalSold << endl;
    }

    void SaleFilterByBill() // redacción
    {
        // consoleClear();
        bool bill;
        char billChar;
        float totalSold = 0;
        cout << "Was the order billed? (y/n): ";
        cin >> billChar;
        bill = billChar == 'y' ? true : false;

        for (int i = 0; i < this->sales.size(); i++)
        {
            if (this->sales[i].bill == bill)
            {
                this->sales[i].print();
                totalSold += this->sales[i].total;
            }
        }
        cout << "Total sold: " << totalSold << endl;
    }

    void SaleFilterByLab() // redacción
    {
        // consoleClear();
        string Laboratory;
        float totalSold = 0;
        cout << "Dear customer, please input the name of the laboratory: ";
        cin >> Laboratory;

        for (int i = 0; i < this->products.size(); i++)
        {
            if (this->products[i].laboratory == Laboratory)
            {
                this->sales[i].print();
                totalSold += this->sales[i].total;
            }
        }
        cout << "Total sold: " << totalSold << endl;
    }

    void ProductFilterByName()
    {
        // consoleClear();
        string name;
        cout << "Dear customer, please input the name: ";
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
        // consoleClear();
        string laboratory;
        cout << "Dear customer, please input the laboratory: ";
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
            // system("clear");
            printTitle();
            cout << menuTitle_ << string(29 - menuTitle_.size(), ' ') << endl;
            for (int i = 0; i < options_.size(); i++)
            {
                cout << i + 1 << ". " << options_[i] << string(29 - options_[i].size(), ' ') << endl;
            }

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
        cout << "\033[30;47m\n\t W e l c o m e   t o   S a n   P a b l o   D r u g s t o r e \033[0m\033[36m" << endl;
        cout << " ";
        cout << endl;
    }
};

static void displayInputBox(string prompt)
{
    // consoleClear();
    string userInput;

    int promptLength = prompt.length();
    int boxWidth = promptLength + 6;

    cout << "" << prompt << "";

    for (int i = 0; i < boxWidth - 2; i++)
    {
        cout << "";
    }
    cout << " ";
    cout << ": ";
}

// Helper function to validate and get a non-empty string input
string getNonEmptyStringInput(const string &prompt)
{
    string input;
    while (true)
    {
        displayInputBox(prompt);
        cin >> input;
        if (!input.empty())
        {
            break;
        }
        displayInputBox("Input cannot be empty");
    }
    return input;
}

// Helper function to validate and get a positive float input
float getPositiveFloatInput(const string &prompt)
{
    float input;
    while (true)
    {
        displayInputBox(prompt);
        if (cin >> input && input > 0)
        {
            break;
        }
        cin.clear();
        // cin.ignore(numeric_limits<streamsize>::max(), '\n');
        displayInputBox("Invalid input, please enter a positive number");
    }
    return input;
}

// Helper function to validate and get a non-negative integer input
int getNonNegativeIntInput(const string &prompt)
{
    int input;
    while (true)
    {
        displayInputBox(prompt);
        if (cin >> input && input >= 0)
        {
            break;
        }
        cin.clear();
        /* cin.ignore(numeric_limits<streamsize>::max(), '\n');*/
        displayInputBox("Invalid input, please enter a non-negative integer");
    }
    return input;
}

// Helper function to validate and get a yes/no boolean input
bool getYesNoInput(const string &prompt)
{
    while (true)
    {
        displayInputBox(prompt);
        string input;
        cin >> input;
        if (input == "y")
        {
            return true;
        }
        else if (input == "n")
        {
            return false;
        }
        displayInputBox("Invalid input, please enter y or n");
    }
}

void createProduct()
{
    string name = getNonEmptyStringInput("\nDear customer, please enter the name of your product ");
    if (db.getProductByName(name))
    {
        displayInputBox("Product already exists");
        pressEnterToContinue();
        return;
    }
    string presentation = getNonEmptyStringInput("Enter the product presentation (Ex.: \"tablet500mg\") ");
    float price = getPositiveFloatInput("Enter the product price value");
    float cost = getPositiveFloatInput("Enter the product cost value");
    int stock = getNonNegativeIntInput("Enter the stock");
    string laboratory = getNonEmptyStringInput("Enter the laboratory");
    string expirationDate = getNonEmptyStringInput("Enter the expiration date (YYYY-mm-dd)");
    bool iva = getYesNoInput("Does your product has IVA? (y/n)");

    int id = db.products.size() + 1;
    string sku = randomString();

    Product product(id, sku, name, presentation, laboratory, stock, cost, price, expirationDate, iva);
    db.addProduct(product);

    displayInputBox("Product added successfully...");
}

static void createSale()
{
    if (db.products.size() == 0)
    {
        cout << "You must add products first." << endl;
        pressEnterToContinue();
        return;
    }
    string date, buyProduct, payMethod;
    int productsSold, stock, paymentOption, orderNumber;
    float subtotal = 0.0, total = 0.0;
    bool bill;
    string laboratory;
    vector<map<string, int>> productList;
    PaymMethod payments;

    // Ask for the product name
    string productName;
    productName = getNonEmptyStringInput(
        "Please, enter the product name that you want to buy ");

    Product product = db.findProductByName(productName);

    while (product.id == 0)
    {
        displayInputBox("Product not found, try again or type 'exit' to exit. ");
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
    stockInventory = getNonNegativeIntInput(
        "Enter the quantity that you want to buy?");
    while (stockInventory > product.stock)
    {
        stockInventory = getNonNegativeIntInput(
            "Enter the quantity that you want to buy");
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
    displayInputBox("Please, input the number of the payment method that you want ");
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
    displayInputBox("Do you require a bill? (y/n)");
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

    date = to_string(1900 + ltm->tm_year) + " " + to_string(1 + ltm->tm_mon) + " " + to_string(ltm->tm_mday);

    // order number
    orderNumber = db.sales.size() + 1;

    // add sale to the database

    Sale sale(orderNumber, date, productList, subtotal, total, payMethod, bill, laboratory);
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

    // consoleClear();
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

    vector<string> options = {"\033[36mCreate Product", "Create Sale", "Reports", "Exit\033[0m"};
    vector<string> options2 = {"Specific sale info ", "All sales", "Sale by date", "Sale by Pay method", "Sale by Lab", "Sale by Bill ", "Product Info.", "Product by Lab", "Product soon to expire", "All Product", "Exit"};

    Menu menu(options, "\033[36m ---- MENU ---- \033[0m");
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
            Menu menu2(options2, "\033[32m ---- REPORTS ---- \033[0m");
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
                    db.SaleFilterByLab();
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