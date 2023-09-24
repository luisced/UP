#include <iostream>
#include <string>
#include <cctype> // Para isdigit
#include "stack.h"

bool isOperator(char c)
{
    return c == '+' || c == '-' || c == '*' || c == '/';
}

int precedence(char op)
{
    switch (op)
    {
    case '+':
    case '-':
        return 1;
    case '*':
    case '/':
        return 2;
    default:
        return 0;
    }
}

std::string infixToPostfix(const std::string &infix)
{
    Stack s;
    std::string postfix;
    for (char c : infix)
    {
        if (isdigit(c) || isalpha(c))
        {
            postfix += c;
        }
        else if (c == '(')
        {
            s.push(c);
        }
        else if (c == ')')
        {
            while (!s.isEmpty() && s.peek() != '(')
            {
                postfix += s.pop();
            }
            s.pop(); // Eliminar '(' de la pila
        }
        else if (isOperator(c))
        {
            while (!s.isEmpty() && precedence(s.peek()) >= precedence(c))
            {
                postfix += s.pop();
            }
            s.push(c);
        }
    }
    while (!s.isEmpty())
    {
        postfix += s.pop();
    }
    return postfix;
}

int main()
{
    std::string infix;
    std::cout << "Introduce la expresion infija: ";
    std::cin >> infix;
    std::string postfix = infixToPostfix(infix);
    std::cout << "La expresion postfija es: " << postfix << std::endl;
    return 0;
}
