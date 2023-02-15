#include <iostream>
#include <string>
#include <vector>
#include <ctime>
#include <map>


using namespace std;


class Pharmacy{
    public:
        string name;
        Pharmacy(string name){
            this->name = name;
        }
};

class Product{
    public:
        string id;
        string sku;
        string name;
        string presentation;
        string laboratory;
        int stock;
        float cost;
        float price;
        string expirationDate;
        bool iva;

        Product(string id, string sku, string name, string presentation, string laboratory, int stock, float cost, float price, string expirationDate, bool iva){
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
};

class Sale{
    public:
        string orderNumber;
        string date;
        vector<Product> products;
        int productsSold;
        float subtotal;
        float total;
        string paymentMethod;
        bool bill;
        Sale(string orderNumber, string date, vector<Product> products, int productsSold, float subtotal, float total, string paymentMethod, bool bill){
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



int  main(){
    return 0;
}