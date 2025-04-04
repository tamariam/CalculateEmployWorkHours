using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;

namespace CsvReaderDemo
{
    // Define the EmployeeWorkHours class at the beginning
    public class EmployeeWorkHours
    {
        public required string EmployeeName { get; set; }
        public required string Department { get; set; }
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Path to the CSV file
            string filePath = @"C:\Users\abuli\OneDrive\Pictures\Desktop\ConsoleApp1\ConsoleApp1\employees.csv";

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Read the records into a list of EmployeeWorkHours objects
                var records = csv.GetRecords<EmployeeWorkHours>().ToList();

                foreach (var record in records)
                {
                    // Accessing the data using get/set properties
                    string employeeName = record.EmployeeName;
                    string department = record.Department;

                    // Output each record
                    Console.WriteLine($"Employee: {employeeName}, Department: {department}");
                    Console.WriteLine($"Monday: {record.Monday}, Tuesday: {record.Tuesday}, Wednesday: {record.Wednesday}, Thursday: {record.Thursday}, Friday: {record.Friday}");
                    Console.WriteLine();
                }
            }
        }
    }
}
