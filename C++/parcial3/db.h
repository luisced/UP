#include <iostream>
#include <iomanip>
#include <string>
#include <vector>
#include <ctime>
#include <chrono>
#include <sstream>
#include "models.h"
#include <map>
#ifndef DB_H
#define DB_H

class DB
{
public:
    vector<Product> products = {
        Product(1, "123456789", "Paracetamol", "Tabletas", "Bayer", 100, 10, 15, "2019-12-31", true),
        Product(2, "123456789", "Ibuprofeno", "Tabletas", "Pfizer", 100, 10, 15, "2021-12-31", true),
        Product(3, "123456789", "Aspirina", "Tabletas", "Astra", 100, 10, 15, "2022-12-31", false),
        Product(4, "123456789", "Cetirizina", "Tabletas", "Bayer", 100, 10, 15, "2023-05-07", true),
    };
    vector<Sale> sales = {
        Sale(1, "2022-01-01", {{{"Product 1", 2}, {"Product 2", 1}}, {{"Product 3", 4}}}, 100.00, 115.00, "Credit Card", true),
        Sale(2, "2021-01-05", {{{"Product 2", 3}}, {{"Product 1", 1}, {"Product 3", 2}}}, 50.00, 58.50, "Cash", false),
        Sale(3, "2019-02-10", {{{"Product 3", 5}}}, 25.00, 28.75, "Debit Card", true),
        Sale(4, "2019-03-15", {{{"Product 1", 2}, {"Product 3", 1}}}, 75.00, 86.25, "Cash", false),
        Sale(5, "2023-12-20", {{{"Product 2", 1}}, {{"Product 1", 3}, {"Product 3", 2}}}, 80.00, 92.00, "Credit Card", true)};

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
        system("clear");
        for (int i = 0; i < this->sales.size(); i++)
        {
            this->sales[i].print();
            total += this->sales[i].total;
        }
        cout << "Total: " << total << endl;
    }
    void listProducts()
    {

        system("clear");
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
        system("clear");
        int oderNumber;
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
        system("clear");
        int year;
        float totalSold = 0;
        cout << "Enter the year: ";
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
        system("clear");
        string month;
        float totalSold = 0;

        cout << "Enter the month: ";
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
        system("clear");
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
        system("clear");
        string date1, date2;
        float totalSold = 0;
        cout << "Enter the first date: ";
        cin >> date1;
        cout << "Enter the second date: ";
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
        system("clear");
        string paymentMethod;
        float totalSold = 0;

        cout << "Enter the payment method: ";
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

    void SaleFilterByBill()
    {
        system("clear");
        bool bill;
        char billChar;
        float totalSold = 0;
        cout << "Bill(y/n): ";
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

    void ProductFilterByName()
    {
        system("clear");
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
        system("clear");
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

#endif