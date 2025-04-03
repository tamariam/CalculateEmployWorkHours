using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

class Program
{
    public class Employee
    {
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
    }

    static void Main(string[] args)
    {
        string filePath = "employees.csv"; // Path to your CSV file

        // Set up the CsvConfiguration to ignore header validation
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HeaderValidated = null,  // Disable header validation
            MissingFieldFound = null // Disable missing field validation
        };

        try
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Employee>().ToList();

                // Loop through records and print employee details
                foreach (var record in records)
                {
                    Console.WriteLine($"Employee Name: {record.EmployeeName}, Department: {record.Department}");
                    Console.WriteLine($"Monday: {record.Monday}, Tuesday: {record.Tuesday}, Wednesday: {record.Wednesday}");
                    Console.WriteLine($"Thursday: {record.Thursday}, Friday: {record.Friday}");
                    Console.WriteLine("----------------------------");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
