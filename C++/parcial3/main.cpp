#include <iostream>
#include <iomanip>
#include <string>
#include <vector>
#include <ctime>
#include <chrono>
#include <sstream>
#include "models.h"
#include "db_instance.h"
#include "utils.h"
#include <map>

using namespace std;

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
