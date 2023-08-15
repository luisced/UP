#include <iostream>
#include <cstdlib>
#include <string>

using namespace std;

#pragma once

class util
{
private:
    int num1, num2;
    double result;

public:
    void get_numbers();

    void multiply();

    void sum();
};

class Student
{
public:
    string name;
    int age;
    double grade;
    bool status;

    Student(string name, int age, double grade, bool status)
    {
        this->name = name;
        this->age = age;
        this->grade = grade;
        this->status = status;
    }

    void print()
    {
        cout << "Name: " << name << endl;
        cout << "Age: " << age << endl;
        cout << "Grade: " << grade << endl;
        cout << "Status: " << status << endl;
    }
};