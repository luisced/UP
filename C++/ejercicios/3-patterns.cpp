#include <iostream>
#include <string>
#include <map>

using namespace std;

void primeNumbers()
{
    int a;
    printf("Enter a number: ");
    cin >> a;
    for (int i = 2; i < a; i++)
    {
        if (a % a == 0 && a % i == 0)
        {
            cout << i << endl;
        }
    }
}

void squarePattern()
{
    int a;
    printf("Enter a number: ");
    cin >> a;
    for (int i = 0; i < a; i++)
    {
        for (int j = 0; j < a; j++)
        {
            cout << " *";
        }
        cout << endl;
    }
}

void cubeNumbers()
{
    int a;
    printf("Enter a number: ");
    cin >> a;
    for (int i = 0; i < a; i++)
    {
        printf("%d ", i * i * i);
    }
}

void multiplicationTable()
{
    int a;
    printf("Enter a number: ");
    cin >> a;
    for (int i = 1; i <= 10; i++)
    {
        cout << a << " x " << i << " = " << a * i << endl;
    }
}

void harmonicSeries()
{
    int a;
    printf("Enter a number: ");
    cin >> a;
    for (int i = 1; i <= a; i++)
    {
        cout << "1/" << i << " + ";
    }
}

void reverseANumber()
{
    int a;
    printf("Enter a number: ");
    cin >> a;
    int reverse = 0;
    while (a != 0)
    {
        reverse = reverse * 10;
        reverse = reverse + a % 10;
        a = a / 10;
    }
    cout << "The reverse of the number is: " << reverse << endl;
}

void lenghString()
{
    string a;
    printf("Enter a string: ");
    getline(cin, a);
    int count = 0;
    for (int i : a)
    {
        count++;
    }
    cout << "The length of the string is: " << count << endl;
}

void digitFrecuency()
{
    int a;
    int one, two, three, four, five, six, seven, eight, nine, zero;
    printf("Enter a number: ");
    cin >> a;
    // print the number of times each digit appears in the number
    while (a != 0)
    {
        int digit = a % 10;
        switch (digit)
        {
        case 0:
            zero++;
            break;
        case 1:
            one++;
            break;
        case 2:
            two++;
            break;
        case 3:
            three++;
            break;
        case 4:
            four++;
            break;
        case 5:
            five++;
            break;
        case 6:
            six++;
            break;
        case 7:
            seven++;
            break;
        case 8:
            eight++;
            break;
        case 9:
            nine++;
            break;
        }
        a = a / 10;
    }
    cout << "0: " << zero << endl;
    cout << "1: " << one << endl;
    cout << "2: " << two << endl;
    cout << "3: " << three << endl;
    cout << "4: " << four << endl;
    cout << "5: " << five << endl;
    cout << "6: " << six << endl;
    cout << "7: " << seven << endl;
    cout << "8: " << eight << endl;
    cout << "9: " << nine << endl;
    cout << endl;
}

static void numberToWord()
{
    int a;
    printf("Enter a number: ");
    cin >> a;
    map<int, string> numbers;
    numbers[0] = "zero";
    numbers[1] = "one";
    numbers[2] = "two";
    numbers[3] = "three";
    numbers[4] = "four";
    numbers[5] = "five";
    numbers[6] = "six";
    numbers[7] = "seven";
    numbers[8] = "eight";
    numbers[9] = "nine";
    numbers[10] = "ten";

    cout << numbers[a] << endl;
}

void numberPyramid()
{
    int a;
    printf("Enter a number: ");
    cin >> a;
    for (int i = 1; i <= a; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            cout << i;
        }
        cout << endl;
    }
}

int main()
{
    numberPyramid();
    return 0;
}