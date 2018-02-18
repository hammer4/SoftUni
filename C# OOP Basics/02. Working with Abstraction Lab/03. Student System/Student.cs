using System;
using System.Collections.Generic;
using System.Text;

public class Student
{
    private string name;
    private int age;
    private double grade;

    public Student(string name, int age, double grade)
    {
        this.name = name;
        this.age = age;
        this.grade = grade;
    }

    public override string ToString()
    {
        string gradeComment = GetGradeComment();

        return $"{name} is {age} years old. {gradeComment}";
    }

    private string GetGradeComment()
    {
        if(grade >= 5)
        {
            return "Excellent student.";
        }
        else if(grade >= 3.50)
        {
            return "Average student.";
        }
        else
        {
            return "Very nice person.";
        }
    }
}