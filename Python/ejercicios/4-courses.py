from dataclasses import dataclass


@dataclass
class Course:
    name: str
    grade: float


def createCourse():
    """Create a course"""
    print("Enter the name of the course")
    name = input()
    print("Enter the grade of the course")
    grade = float(input())
    course = Course(name, grade)

    return course


def courses() -> list[str]:
    """ask the user how """
    print("How many courses are you taking?")
    numCourses = int(input())
    coursesList = [createCourse() for course in range(numCourses)]

    return coursesList


def calculateGPA(courses: list[str]) -> float:
    """Calculate the GPA"""
    gpa = sum(course.grade for course in courses) / len(courses)

    return gpa


courses = courses()

print(calculateGPA(courses), courses)
