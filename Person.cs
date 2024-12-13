using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Voter_Registration_System
{
    internal class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthday { get; set; }
        public char sex { get; set; }
        public Person() { }
        public Person(string firstName, string lastName, DateTime birthday, char sex)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthday = birthday;
            this.sex = sex;
        }
        private int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthday.Year;

            if (birthday.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
        public void InputDetails()
        {
            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();

            try
            {
                Console.Write("Enter birthday (yyyy-mm-dd): ");
                birthday = DateTime.Parse(Console.ReadLine());

                if (GetAge() < 18)
                {
                    throw new InvalidOperationException("Voter must be at least 18 years old to register.");
                }
            }
            catch (FormatException)
            {
                throw new InvalidOperationException("Invalid date format. Please enter a valid birthday (yyyy-mm-dd).");
            }

            Console.Write("Enter sex (M/F): ");
            char sexInput = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (sexInput != 'F' && sexInput != 'M' && sexInput != 'f' && sexInput != 'm')
            {
                throw new InvalidOperationException("Invalid input for sex. Please enter 'M' for male or 'F' for female.");
            }
            sex = char.ToUpper(sexInput);
        }
    }
}
