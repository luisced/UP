#include "herencia1.h"

Employee::Employee(int id, std::string name)
{
    this->id = id;
    this->name = name;
}
int Employee::getId()
{
    return this->id;
}
string Employee::getName()
{
    return this->name;
}
void Employee::setId(int id)
{
    this->id = id;
}
void Employee::setName(string name)
{
    this->name = name;
}

SalaryEmployee::SalaryEmployee(int id, string name, double weekly_salary) : Employee(id, name)
{
    this->weekly_salary = weekly_salary;
}
double SalaryEmployee::calculate_payroll()
{
    return weekly_salary;
}

HourlyEmployee::HourlyEmployee(int id, string name, int hours_worked, double hour_rate) : Employee(id, name)
{
    this->hour_rate = hour_rate;
    this->hours_worked = hours_worked;
}

double HourlyEmployee::calculate_payroll()
{
    return hours_worked * this->hour_rate;
}
CommissionEmployee::CommissionEmployee(int id, string name, double weekly_salary, double commission) : SalaryEmployee(id, name, weekly_salary)
{
    this->commission = commission;
}
double CommissionEmployee::calculate_payroll()
{
    double fixed = SalaryEmployee::calculate_payroll();
    return fixed + commission;
}
