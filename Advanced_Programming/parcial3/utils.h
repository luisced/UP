#include <iostream>
#include <iomanip>
#include <string>
#include <vector>
#include <ctime>
#include <chrono>
#include "models.h"
#include "db_instance.h"
#include <fstream>
#include <sstream>
#include <map>

using namespace std;

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

static void displayInputBox(string prompt)
{
    system("clear");
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
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
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
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
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
    string name = getNonEmptyStringInput("Enter the product name");
    if (db.getProductByName(name))
    {
        displayInputBox("Product already exists");
        pressEnterToContinue();
        return;
    }
    string presentation = getNonEmptyStringInput("Enter the product presentation");
    float price = getPositiveFloatInput("Enter the product price");
    float cost = getPositiveFloatInput("Enter the product cost");
    int stock = getNonNegativeIntInput("Enter the product stock");
    string laboratory = getNonEmptyStringInput("Enter the laboratory");
    string expirationDate = getNonEmptyStringInput("Enter the expiration date");
    bool iva = getYesNoInput("Is the product taxable? (y/n)");

    int id = db.products.size() + 1;
    string sku = randomString();

    Product product(id, sku, name, presentation, laboratory, stock, cost, price, expirationDate, iva);
    db.addProduct(product);

    displayInputBox("Product added successfully");
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
    productName = getNonEmptyStringInput(
        "Enter the product name or type 'exit' to exit");

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
    stockInventory = getNonNegativeIntInput(
        "What quantity would you like to buy?");
    while (stockInventory > product.stock)
    {
        stockInventory = getNonNegativeIntInput(
            "What quantity would you like to buy?");
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

    system("clear");
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

void saveDataToCSV(const string &filename, const DB &db)
{
    ofstream file(filename);
    if (!file.is_open())
    {
        cout << "Error opening file for writing." << endl;
        return;
    }

    // Write product data to CSV
    file << "Product ID,SKU,Name,Presentation,Laboratory,Stock,Cost,Price,Expiration Date,IVA" << endl;
    for (const auto &product : db.products)
    {
        file << product.id << "," << product.sku << "," << product.name << "," << product.presentation << ","
             << product.laboratory << "," << product.stock << "," << product.cost << "," << product.price << ","
             << product.expirationDate << "," << (product.iva ? "true" : "false") << endl;
    }

    file << endl;

    // Write sale data to CSV
    file << "Order Number,Date,Product List,Subtotal,Total,Payment Method,Bill" << endl;
    for (const auto &sale : db.sales)
    {
        file << sale.orderNumber << "," << sale.date << ",";
        for (const auto &productMap : sale.productList)
        {
            for (const auto &product : productMap)
            {
                file << product.first << ":" << product.second << ";";
            }
        }
        file << "," << sale.subtotal << "," << sale.total << "," << sale.paymentMethod << "," << (sale.bill ? "true" : "false") << endl;
    }

    file.close();
    cout << "Data saved to " << filename << " successfully." << endl;
}

void loadDataFromCSV(const string &filename, DB &db)
{
    ifstream file(filename);
    if (!file.is_open())
    {
        cout << "Error opening file for reading." << endl;
        return;
    }

    // Skip the header lines
    string line;
    getline(file, line);
    getline(file, line);

    // Read product data from CSV
    db.products.clear();
    int lineCount = 3; // Start from line 3 (after the header lines)
    while (getline(file, line) && !line.empty())
    {
        stringstream ss(line);
        string field;
        vector<string> fields;
        while (getline(ss, field, ','))
        {
            fields.push_back(field);
        }

        if (fields.size() == 10)
        {
            try
            {
                int id = stoi(fields[0]);
                string sku = fields[1];
                string name = fields[2];
                string presentation = fields[3];
                string laboratory = fields[4];
                int stock = stoi(fields[5]);
                float cost = stof(fields[6]);
                float price = stof(fields[7]);
                string expirationDate = fields[8];
                bool iva = (fields[9] == "true");

                Product product(id, sku, name, presentation, laboratory, stock, cost, price, expirationDate, iva);
                db.products.push_back(product);
            }
            catch (const exception &e)
            {
                cerr << "Error parsing product data at line " << lineCount << ": " << e.what() << endl;
                file.close();
                return;
            }
        }

        lineCount++;
    }

    // Skip the empty line between product and sale data
    getline(file, line);

    // Read sale data from CSV
    db.sales.clear();
    lineCount++; // Increment line count for the empty line
    while (getline(file, line))
    {
        stringstream ss(line);
        string field;
        vector<string> fields;
        while (getline(ss, field, ','))
        {
            fields.push_back(field);
        }

        if (fields.size() == 7)
        {
            try
            {
                int orderNumber = stoi(fields[0]);
                string date = fields[1];

                vector<map<string, int>> productList;
                stringstream productListStream(fields[2]);
                string productStr;
                while (getline(productListStream, productStr, ';'))
                {
                    stringstream productStream(productStr);
                    string productName;
                    getline(productStream, productName, ':');
                    int productQuantity = stoi(productStream.str());

                    map<string, int> productMap;
                    productMap.insert({productName, productQuantity});
                    productList.push_back(productMap);
                }

                float subtotal = stof(fields[3]);
                float total = stof(fields[4]);
                string paymentMethod = fields[5];
                bool bill = (fields[6] == "true");

                Sale sale(orderNumber, date, productList, subtotal, total, paymentMethod, bill);
                db.sales.push_back(sale);
            }
            catch (const exception &e)
            {
                cerr << "Error parsing sale data at line " << lineCount << ": " << e.what() << endl;
                file.close();
                return;
            }
        }

        lineCount++;
    }

    file.close();
    cout << "Data loaded from " << filename << " successfully." << endl;
}
