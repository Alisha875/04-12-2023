using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Assignment27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Sam",
                LastName = "Doe",
                Salary = 50000.50
            };

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("employee.bin", FileMode.Create))
            {
                binaryFormatter.Serialize(fileStream, employee);
            }

            using (FileStream fileStream = new FileStream("employee.bin", FileMode.Open))
            {
                Employee deserializedEmployee = (Employee)binaryFormatter.Deserialize(fileStream);

                Console.WriteLine("Binary Deserialization:");
                DisplayEmployeeDetails(deserializedEmployee);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            using (FileStream fileStream = new FileStream("employee.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, employee);
            }

            using (FileStream fileStream = new FileStream("employee.xml", FileMode.Open))
            {
                Employee deserializedEmployee = (Employee)xmlSerializer.Deserialize(fileStream);

                Console.WriteLine("\nXML Deserialization:");
                DisplayEmployeeDetails(deserializedEmployee);
            }

            Console.ReadKey(); 
        }

        static void DisplayEmployeeDetails(Employee employee)
        {
            Console.WriteLine($"ID: {employee.Id}");
            Console.WriteLine($"First Name: {employee.FirstName}");
            Console.WriteLine($"Last Name: {employee.LastName}");
            Console.WriteLine($"Salary: {employee.Salary}\n");
        }
    }
}
    

