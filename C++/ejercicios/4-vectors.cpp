#include <iostream>
#include <iomanip>
#include <string>
#include <vector>

using namespace std;

class Student
{
public:
    Student(string name, int age, string gender)
    {
        this->name = name;
        this->age = age;
        this->gender = gender;
    }
    string name;
    int age;
    string gender;
};

int main()
{
    vector<Student> students;
    students.push_back(Student("John", 16, "Male"));
    students.push_back(Student("Mary", 17, "Female"));
    students.push_back(Student("Bob", 15, "Female"));

    for (int i = 0; i < students.size(); i++)
    {
        cout << students[i].name << " is " << students[i].age << " years old and is in gender " << students[i].gender << endl;
    }

    return 0;
}