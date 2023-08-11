//
// Created by barba on 18/03/2023.
//

#ifndef HERENCIA1_HERENCIA1_H
#define HERENCIA1_HERENCIA1_H
#include <string>
#include <vector>
#include <set>
#include <tuple>
#include <map>
#include <iostream>
#include <fstream>
#include <sstream>
#include <utility>

int listas1();
int ejercicio1();
int rangos();
int rangos1();

using namespace std;

class Employee
{
public:
    Employee(int id, string name);
    Employee() {}
    int getId();
    string getName();
    void setId(int);
    void setName(string);
    virtual double calculate_payroll() = 0;
    ~Employee()
    {
        cout << "Corrieron 0 a todos los empleados" << endl;
    }

private:
    int id;
    string name;
};
template <typename T>
class PayrollSystem
{
public:
    static double calculate_payroll(T employees)
    {
        double total = 0;
        for (Employee *emp : employees)
        { // le pide a employees su iterador y lo itera
            total += emp->calculate_payroll();
            cout << " Payroll for " << typeid(*emp).name() << " " << emp->getId() << " " << emp->getName() << endl;
            cout << "Check Amount " << emp->calculate_payroll() << endl;
        }
        return total;
    }
};

class SalaryEmployee : public Employee
{
private:
    double weekly_salary;
    static int a; //-miembro de clase
public:
    SalaryEmployee(int id, string name, double weekly_salary);
    double calculate_payroll();
    ~SalaryEmployee()
    {

        cout << "Corrieron 1 a todos los empleados" << endl;
    }
    static void f()
    {
        SalaryEmployee borrame(5, "borrame", 1500);
        borrame.weekly_salary = 123456;
    }
};

class HourlyEmployee : public Employee
{
private:
    int hours_worked;
    double hour_rate;

public:
    HourlyEmployee(int id, string name, int hours_worked, double hour_rate);
    virtual double calculate_payroll();
    ~HourlyEmployee()
    {

        cout << "Corrieron 1 a todos los empleados" << endl;
    }
};

class CommissionEmployee : public SalaryEmployee
{
private:
    double commission;

public:
    CommissionEmployee(int id, string name, double weekly_salary, double commission);
    virtual double calculate_payroll();
    ~CommissionEmployee()
    {

        cout << "Corrieron 2 a todos los empleados" << endl;
    }
};

// class department
class Department
{
private:
    string name;
    int id;

public:
    Department(string name, int id);
    string getName();
    int getId();
    void setName(string name);
    void setId(int id);
    ~Department();
};

// class empresa
class Empresa
{
private:
    string name;
    int id;
    vector<Department *> departments;

public:
    Empresa(string name, int id);
    string getName();
    int getId();
    void setName(string name);
    void setId(int id);
    void addDepartment(Department *department);
    vector<Department *> getDepartments();
    ~Empresa();
};

#endif // HERENCIA1_HERENCIA1_H
