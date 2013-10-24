using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student : IComparable<Student>
{
    private string firstName;
    private string lastName;

    public Student(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    /// <summary>
    /// Get and set First name of the student
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If try to set first name to null or white space</exception>
    public string FirstName
    {
        get { return this.firstName; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(
                    "Invalid input! First name cannot be empty or white space.");
            }

            this.firstName = value;
        }
    }

    /// <summary>
    /// Get and set Last name of the student
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If try to set last name to null or white space</exception>
    public string LastName
    {
        get { return this.lastName; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(
                    "Invalid input! Last name cannot be empty or white space.");
            }

            this.lastName = value;
        }
    }

    /// <summary>
    /// Compare students by their Last and than First name
    /// </summary>
    /// <param name="other">Student to compare with</param>
    /// <exception cref="InvalidOperationException">
    /// If try to compare student to null</exception>
    /// <returns>Negative, 0 or positive number</returns>
    public int CompareTo(Student other)
    {
        if (other == null)
        {
            throw new InvalidOperationException(
                "Invalid comparison! Cannot compare with null value.");
        }

        int result = this.LastName.CompareTo(other.LastName);
        if (result == 0)
        {
            result = this.FirstName.CompareTo(other.FirstName);
        }

        return result;
    }

    /// <summary>
    /// Override ToString method to return string representation of
    /// last and first name of the student
    /// </summary>
    /// <returns>Student as string</returns>
    public override string ToString()
    {
        return this.FirstName + " " + this.LastName;
    }
}