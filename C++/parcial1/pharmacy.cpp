#include <iostream>
#include <string>
#include <vector>
#include <ctime>
#include <map>

using namespace std;

class PaymMethod
{
public:
    string methods[3] = {"Efectivo", "Tarjeta de Crédito", "Tarjeta de Débito"};
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

    Product(string id, string sku, string name, string presentation, string laboratory, int stock, float cost, float price, string expirationDate, bool iva)
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

    void showProduct()
    {
        cout << "ID: " << this->id << endl;
        cout << "SKU: " << this->sku << endl;
        cout << "Nombre: " << this->name << endl;
        cout << "Presentación: " << this->presentation << endl;
        cout << "Laboratorio: " << this->laboratory << endl;
        cout << "Stock: " << this->stock << endl;
        cout << "Costo: " << this->cost << endl;
        cout << "Precio: " << this->price << endl;
        cout << "Fecha de Vencimiento: " << this->expirationDate << endl;
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

class SalesSystem
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
                sale.products[j].showProduct();
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
};

class Menu
{
public:
    // Constructor to initialize the menu options
    Menu(const std::vector<std::string> &options) : options_(options) {}

    // Display the menu and prompt for user input
    int display()
    {
        while (true)
        {
            std::cout << "===================================" << std::endl;
            std::cout << "|            MAIN MENU            |" << std::endl;
            std::cout << "===================================" << std::endl;
            for (int i = 0; i < options_.size(); i++)
            {
                std::cout << "| " << (i + 1) << ". " << options_[i] << std::endl;
            }
            std::cout << "===================================" << std::endl;
            std::cout << "Enter your choice (1-" << options_.size() << "): ";

            int choice;
            std::cin >> choice;

            if (choice >= 1 && choice <= options_.size())
            {
                return choice;
            }
            else
            {
                std::cout << "Invalid choice. Please try again." << std::endl;
            }
        }
    }

private:
    std::vector<std::string> options_;
};

int main()
{

    std::vector<std::string> options = {"Agregar Producto", "Crear Venta", "Listar Ventas", "Salir"};
    Menu menu(options);
    int choice = menu.display();

    switch (choice)
    {
    case 1:
        // Handle option 1
        break;
    case 2:
        // Handle option 2
        break;
    case 3:
        // Handle option 3
        break;
    case 4:
        // Handle option 4
        break;
    case 5:
        // Exit the program
        break;
    default:
        // This should not happen
        std::cerr << "Error: Invalid choice" << std::endl;
        break;
    }
    return 0;
}
