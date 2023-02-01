from dataclasses import dataclass


@dataclass
class Course:
    name: str
    grade: float


def createCourse():
    """Create a course"""
    return Course(input("Enter the name of the course"), float(input("Enter the grade of the course")))


def courses() -> list[str]:
    """ask the user how """
    return [createCourse() for course in range(int(input("How many courses are you taking?")))]


def calculateGPA(courses: list[str]) -> float:
    """Calculate the GPA"""
    return sum(course.grade for course in courses) / len(courses)


courses = courses()

print(calculateGPA(courses), courses)
