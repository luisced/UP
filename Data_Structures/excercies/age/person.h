#include <iostream>
#include <cstdlib>
#include <string>
#include <chrono>
#include <ctime>

using namespace std;

#pragma once

// The Person class represents a person in our program.
class Person
{
public:
    // The day, month, and year of the person's birth.
    string day;
    string month;
    string year;

    // A constructor for a Person object.
    Person(string day, string month, string year)
    {
        this->day = day;
        this->month = month;
        this->year = year;
    }

    // Calculate the age of the person based on the current date months and days.
    void calculate_age(string day, string month, string year)
    {
        int day_int = stoi(day);
        int month_int = stoi(month);
        int year_int = stoi(year);

        auto start = chrono::system_clock::now();
        time_t end_time = chrono::system_clock::to_time_t(start);
        tm *ltm = localtime(&end_time);

        int current_day = ltm->tm_mday;
        int current_month = 1 + ltm->tm_mon;
        int current_year = 1900 + ltm->tm_year;

        int age = current_year - year_int;

        if (current_month < month_int)
        {
            age--;
        }
        else if (current_month == month_int)
        {
            if (current_day < day_int)
            {
                age--;
            }
        }
        else if (current_day == day_int)
        {
            cout << "Happy Birthday";
        }

        cout << "Your age is: " << age << endl;
    };

    // Calculate the age of the person based on the current date months and days.
    void calculate_age_months_days(
        string day, string month, string year)
    {
        int day_int = stoi(day);
        int month_int = stoi(month);
        int year_int = stoi(year);

        auto start = chrono::system_clock::now();
        time_t end_time = chrono::system_clock::to_time_t(start);
        tm *ltm = localtime(&end_time);

        int current_day_int = ltm->tm_mday;
        int current_month_int = 1 + ltm->tm_mon;
        int current_year_int = 1900 + ltm->tm_year;

        int age = current_year_int - year_int;

        if (current_month_int < month_int)
        {
            age--;
        }
        else if (current_month_int == month_int)
        {
            if (current_day_int < day_int)
            {
                age--;
            }
        }
        else if (current_day_int == day_int)
        {
            cout << "Happy Birthday";
        }

        cout << "Your age is: " << age << endl;
        // calculate months
        int months = 0;
        // If the current month is greater than the month the user entered, just subtract the two values
        if (current_month_int > month_int)
        {
            months = current_month_int - month_int;
        }
        // If the current month is less than the month the user entered, subtract the month value from 12 and add the current month value
        else if (current_month_int < month_int)
        {
            months = 12 - (month_int - current_month_int);
        }
        // If the current month and the month the user entered are the same, set the months value to 0
        else if (current_month_int == month_int)
        {
            months = 0;
        }
        // calculate days
        int days = 0;
        if (current_day_int > day_int)
        {
            days = current_day_int - day_int;
        }
        else if (current_day_int < day_int)
        {
            days = 30 - (day_int - current_day_int);
        }
        else if (current_day_int == day_int)
        {
            days = 0;
        }
        cout << "You have been alive for " << months << " Months and" << days << " Days";
    };
};

// Pelicula
// -> Nombre
// -> Director
// -> Año
// -> Genero

// generar un arreglo con 10 películas

// clase buscador función para buscar por propiedad con apuntadores
