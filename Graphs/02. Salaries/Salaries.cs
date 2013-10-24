using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

public class Salaries
{
    static bool[,] hierarchy;
    static long[] salaries;

    static void Main()
    {
        // Read the input and create matrix of neighborhood
        int numberEmployees = int.Parse(Console.ReadLine());
        hierarchy = new bool[numberEmployees, numberEmployees];
        for (int row = 0; row < numberEmployees; row++)
        {
            string employeeData = Console.ReadLine();
            for (int column = 0; column < numberEmployees; column++)
            {
                if (employeeData[column] == 'Y')
                {
                    hierarchy[row, column] = true;
                }
            }
        }

        // Calculate recursively salary of each employee and their sum
        salaries = new long[numberEmployees];
        long salariesSum = 0;
        for (int count = 0; count < numberEmployees; count++)
        {
            salariesSum += CalculateSalary(count);
        }

        Console.WriteLine(salariesSum);
    }

    private static long CalculateSalary(int id)
    {
        // Bottom of recursion - salary is already calculated
        if (salaries[id] > 0)
        {
            return salaries[id];
        }

        // Calculate salary of current employee by 
        // Recursively calculating salaries of its subordinates (if there are such)
        long employeeSalary = 0;
        for (int count = 0; count < hierarchy.GetLength(0); count++)
        {
            if (hierarchy[id, count])
            {
                employeeSalary += CalculateSalary(count);
            }
        }

        // If current employee does not have subordinates its salary is 1
        if (employeeSalary == 0)
        {
            employeeSalary = 1;
        }

        salaries[id] = employeeSalary;
        return salaries[id];
    }
}