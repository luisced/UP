#include <iostream>
#include <string>

using namespace std;
int main()
{
    string name;
    double energy, cost = 50;

    cout << "What is your name?: ";
    getline(cin, name);
    cout << "What is your Wattage?: ";
    cin >> energy;

    if (energy < 100 && energy > 0)
    {
        cost = cost;
    }
    else if (energy > 99 && energy < 200)
    {
        cost *= 1.5;
    }
    else if (energy > 199 && energy < 300)
    {
        cost *= 2;
    }
    else
    {
        cost *= 2.5;
    }

    cout << "Hello " << name << ", your cost is $" << cost << endl;
    return 0;
}