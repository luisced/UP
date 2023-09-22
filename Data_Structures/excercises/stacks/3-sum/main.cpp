#include "stack.h"
#include "vector"

void displaySumProcess(int digit1, int digit2, int carry, int sumDigit)
{
    std::cout << "Digit from stack1: " << digit1 << ", Digit from stack2: " << digit2;
    std::cout << ", Carry: " << carry << ", Sum of Digits: " << sumDigit << std::endl;
}

int main()
{
    int num1, num2;
    int carry = 0;

    std::cout << "Enter the first number: ";
    std::cin >> num1;

    std::cout << "Enter the second number: ";
    std::cin >> num2;

    Stack stack1;
    Stack stack2;

    // Convert numbers to strings to reverse them
    std::string str1 = std::to_string(num1);
    std::string str2 = std::to_string(num2);

    // Push digits of reversed num1 into stack1
    for (char c : str1)
        stack1.push(c - '0');

    // Push digits of reversed num2 into stack2
    for (char c : str2)
        stack2.push(c - '0');

    std::vector<int> result;

    // Add digits one by one starting from the leftmost
    while (!stack1.isEmpty() || !stack2.isEmpty() || carry > 0)
    {
        int digit1 = stack1.pop();
        int digit2 = stack2.pop();

        int tempSum = digit1 + digit2 + carry;
        carry = tempSum / 10;

        result.push_back(tempSum % 10);
        displaySumProcess(digit1, digit2, carry, tempSum % 10);
    }

    std::cout << "The sum of the two numbers is: ";
    for (int i = 0; i < result.size(); ++i)
    {
        std::cout << result[i];
    }
    std::cout << std::endl;

    return 0;
}
