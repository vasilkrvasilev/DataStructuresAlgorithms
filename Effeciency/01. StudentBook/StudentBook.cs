using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StudentBook
{
    public static void Main()
    {
        // Generate student book from file and print it to the console
        Console.WriteLine("Enter the name of the information file");    //students.txt
        string studentFile = Console.ReadLine();
        SortedDictionary<string, SortedSet<Student>> studentBook =
            GenerateStudentBook(studentFile);
        PrintStudentBook(studentBook);
    }

    /// <summary>
    /// Read file and add element to the student book (courses with students)
    /// </summary>
    /// <param name="file">File name</param>
    /// <exception cref="ArgumentNullException">
    /// If file name is null or white space</exception>
    /// <remarks>Use UTF-8 encoding</remarks>
    /// <returns>Created student book</returns>
    public static SortedDictionary<string, SortedSet<Student>> GenerateStudentBook(string file)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            throw new ArgumentNullException(
                "Invalid input! File name cannot be null or white space.");
        }

        SortedDictionary<string, SortedSet<Student>> studentBook =
            new SortedDictionary<string, SortedSet<Student>>();
        StreamReader reader = new StreamReader(file, Encoding.GetEncoding("UTF-8"));
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] content = line.Split('|');
                string firstName = content[0].Trim();
                string lastName = content[1].Trim();
                string course = content[2].Trim();
                Student student = new Student(firstName, lastName);
                AddToStudentBook(studentBook, student, course);
                line = reader.ReadLine();
            }
        }

        return studentBook;
    }

    /// <summary>
    /// Add student to input student book (courses with students)
    /// </summary>
    /// <param name="studentBook">Input student book</param>
    /// <param name="student">Student to add</param>
    /// <param name="course">Course of the student</param>
    /// <exception cref="ArgumentNullException">
    /// If student book, student or course are equal to null</exception>
    private static void AddToStudentBook(SortedDictionary<string, SortedSet<Student>> studentBook,
        Student student, string course)
    {
        if (studentBook == null || student == null || course == null)
        {
            throw new ArgumentNullException(
                "Invalid input! Student book, student and course cannot be null.");
        }

        if (studentBook.ContainsKey(course))
        {
            studentBook[course].Add(student);
        }
        else
        {
            SortedSet<Student> courseList = new SortedSet<Student>();
            courseList.Add(student);
            studentBook.Add(course, courseList);
        }
    }

    /// <summary>
    /// Print the content of the student book
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If student book is equal to null</exception>
    /// <param name="studentBook">Student book to print</param>
    public static void PrintStudentBook(SortedDictionary<string, SortedSet<Student>> studentBook)
    {
        if (studentBook == null)
        {
            throw new ArgumentNullException(
                "Invalid input! Student book cannot be null.");
        }

        foreach (var course in studentBook)
        {
            Console.Write("{0}: ", course.Key);
            foreach (var student in course.Value)
            {
                Console.Write("Student: {0} ", student.ToString());
            }

            Console.WriteLine();
        }
    }
}