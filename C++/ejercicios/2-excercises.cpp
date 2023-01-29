#include <iostream>
#include <string>
#include <map>

using namespace std;
void sum()
{
    int a, b, c;
    cout << "Enter 3 numbers: ";
    cin >> a >> b >> c;
    cout << "The sum of the numbers is: " << a + b + c << endl;
}

void largestNumber()
{
    int a, b;
    cout << "Enter 2 numbers separated by spaces: ";
    cin >> a >> b;
    if (a > b)
    {
        cout << "The largest number is: " << a << endl;
    }
    else
    {
        cout << "The largest number is: " << b << endl;
    }
}

void smallestNumber()
{
    int a, b;
    cout << "enter 2 numbers separated by spaces: ";
    cin >> a >> b;
    if (a < b)
    {
        cout << "The smallest number is: " << a << endl;
    }
    else
    {
        cout << "The smallest number is: " << b << endl;
    }
}

void AreaOfTriangle()
{
    int a, b;
    cout << "Enter the base and height of the triangle: ";
    cin >> a >> b;
    cout << "The area of the triangle is: " << (a * b) / 2 << endl;
}

void evenOrOdd()
{
    int a;
    cout << "Enter a number to see if its even or odd: ";
    cin >> a;
    if (a % 2 == 0)
    {
        cout << "The number is even" << endl;
    }
    else
    {
        cout << "The number is odd" << endl;
    }
}

void leapYear()
{
    int year;
    cout << "Enter a year: ";
    cin >> year;
    if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
    {
        cout << "The year is a leap year" << endl;
    }
    else
    {
        cout << "The year is not a leap year" << endl;
    }
}

void numberDay()
{
    int day;
    cout << "Enter a number between 1 and 7: ";
    cin >> day;
    map<int, string> days;
    days[1] = "Monday";
    days[2] = "Tuesday";
    days[3] = "Wednesday";
    days[4] = "Thursday";
    days[5] = "Friday";
    days[6] = "Saturday";
    days[7] = "Sunday";
    cout << "The day is: " << days[day] << endl;
}

void evenNumbers()
{
    int a;
    cout << "Enter a number: ";
    cin >> a;

    for (int i; i < a; i++)
    {
        if (i % 2 == 0)
        {
            cout << i << endl;
        }
    }
}

int main()
{
    // sum();
    // largestNumber();
    // smallestNumber();
    // AreaOfTriangle();
    // evenOrOdd();
    // leapYear();
    numberDay();
    evenNumbers();
    return 0;
}
