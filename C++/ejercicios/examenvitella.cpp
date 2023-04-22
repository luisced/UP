#include "herencia1.h"

int main()
{
    int a[2] = {1, 2};
    a[0] = 9; // *a = 9;

    char current_dir[FILENAME_MAX];
    if (_getcwd(current_dir, sizeof(current_dir)) != NULL)
    {
        std::cout << "El directorio actual de trabajo es: " << current_dir << std::endl;
    }
    else
    {
        std::cerr << "Error al obtener el directorio actual de trabajo" << std::endl;
        return 1;
    }

    Employee *empleado = new SalaryEmployee(1, "John Smith", 1500);
    SalaryEmployee salary_employee(1, "John Smith", 1500);
    cout << typeid(salary_employee).name() << endl;
    HourlyEmployee hourly_employee(2, "Jane Doe", 40, 15);
    CommissionEmployee commission_employee(3, "Kevin Bacon", 1000, 250);

    // Usamos la clase vector<T>
    vector<Employee *> empleados;

    empleados.push_back(&salary_employee); // pushback agrega al final
    empleados.push_back(&hourly_employee);
    empleados.push_back(&commission_employee);

    PayrollSystem<vector<Employee *>>::calculate_payroll(empleados); // necesita una coleccion que sea iterable

    // Usamos la clase set
    set<Employee *> empleados1;

    empleados1.insert(&salary_employee); // se llama insert porque un conjunto no tiene orden
    empleados1.insert(&hourly_employee);
    empleados1.insert(&commission_employee);
    PayrollSystem<set<Employee *>> playrollWithSet;

    playrollWithSet.calculate_payroll(empleados1);

    // usamos la clase map y la clase
    //  Vamos a crear un vector de tuplas con el id y el nombre de los empleados
    vector<tuple<int, string>> tuplas;
    map<tuple<int, string>, double> diccionario;
    for (Employee *emp : empleados)
    {
        // Cualquiera de los dos siguientes es válido
        tuple<int, string> tmp = make_tuple(emp->getId(), emp->getName());
        tuple<int, string> tmp1(emp->getId(), emp->getName());

        tuplas.push_back(tmp1);
        diccionario.insert(make_pair(tmp1, emp->calculate_payroll()));
    }

    // Imprimir el diccionario
    /************************************************************************************
     * Nota importante para la sintaxis de obtener los elementos de una tupla
     *
     * La función std::get() es una plantilla que toma dos argumentos: el índice del
     * elemento que se desea obtener y la tupla de la que se desea obtener el elemento.
     * El índice se especifica entre corchetes angulares (< >) y se usa para indicar qué
     * elemento de la tupla se desea obtener. El primer elemento de la tupla tiene
     * un índice de 0, el segundo tiene un índice de 1, y así sucesivamente.
     * **********************************************************************************/
    for (auto elem : diccionario)
    {
        cout << "Employee: ";
        cout << "(" << get<0>(elem.first) << "," << get<1>(elem.first) << "): "
                                                                          "Salary: "
             << elem.second << endl;
    }
    delete (empleado);

    return 0;
}

funciones.cpp :

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

herencia1.h :

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
#include <direct.h>

    int
    listas1();
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

#endif // HERENCIA1_HERENCIA1_H

_________________________________________________________________________

funciones.cpp :

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

____________________________________________________________________________

herencia1.h :

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
#include <direct.h>

    int
    listas1();
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

#endif // HERENCIA1_HERENCIA1_H