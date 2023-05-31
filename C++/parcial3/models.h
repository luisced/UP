#include <iostream>
#include <iomanip>
#include <string>
#include <vector>
#include <ctime>
#include <chrono>
#include <sstream>
#include <map>

#ifndef MODELS_H
#define MODELS_H

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

#endif