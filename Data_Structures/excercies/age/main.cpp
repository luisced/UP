#include <iostream>
#include "person.h"

using namespace std;

int main()
{

    cout << "enter day: " << endl;
    string day;
    cin >> day;
    cout << "enter month" << endl;
    string month;
    cin >> month;
    cout << "enter year" << endl;
    string year;
    cin >> year;
    Person person(day, month, year);

    person.calculate_age_months_days(person.day, person.month, person.year);

    return 0;
};
