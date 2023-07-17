using Course.Entities;
using Course.Entities.Enums;
using System;
using System.Globalization; // Namespace para usar os formaters 



namespace Course {
    class Program {
        static void Main(string[] args) {

            Console.Write("Enter department's name: ");
            string departmentName = Console.ReadLine();

            Console.WriteLine("Worker data: ");
            Console.Write("Name: ");
            string workerName = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(departmentName);
            Worker worker = new Worker(workerName, workerLevel, baseSalary, dept);

            Console.Write("How many contracts for this worker? ");
            int quantity = int.Parse(Console.ReadLine());

            for (int i = 1; i <= quantity; i++) {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration in hours: ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            // We need to trim it -> Substring.
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine(worker);
            Console.WriteLine($"Income for {month}/{year}: " + "$" + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}


