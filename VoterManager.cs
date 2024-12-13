using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Voter_Registration_System
{
    internal class VoterManager
    {
        private string filePath = "D:\\CIT\\II - BSCPE\\1st Sem\\2 CPE261 H1\\Programs\\Voter Registration System\\voters.csv";
        private List<Voter> voterList = new List<Voter>();

        public VoterManager()
        {
            createFileIfNotExisting();
            LoadVoterList();
        }
        public void createFileIfNotExisting()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    using (StreamWriter writer = File.CreateText(filePath))
                    {
                        // File created successfully
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create file: " + ex.Message);
            }
        }
        public void RegisterVoter()
        {
            Person person = new Person();
            person.InputDetails();


            if (IsDuplicate(person.firstName, person.lastName, person.birthday, person.sex))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Voter is already registered. Please register another voter.");
                Console.ResetColor();
            }
            else
            {
                Voter newVoter = new Voter(person.firstName, person.lastName, person.birthday, person.sex);
                newVoter.InputAddress();
                newVoter.voterID = GenerateID(newVoter.Province, newVoter.muniCity);


                voterList.Add(newVoter);
                saveVoter(newVoter);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Voter registered successfully. Voter ID: " + newVoter.voterID);
                Console.ResetColor();
            }

        }
        private bool IsDuplicate(string firstName, string lastName, DateTime birthday, char sex)
        {
            foreach (Voter voter in voterList)
            {
                if (firstName == voter.firstName && lastName == voter.lastName && birthday == voter.birthday && sex == voter.sex)
                {
                    return true;
                }
            }
            return false;
        }
        public string GenerateID(string province, string MuniCity)
        {
            Random random = new Random();
            string str = "0123456789";
            string newID = "";

            if (province == "CEBU")
            {
                newID = "22";
                if (MuniCity == "CEBU")
                {
                    newID = newID + "17";
                }
                else if (MuniCity == "DANAO")
                {
                    newID = newID + "23";
                }
                else if (MuniCity == "LAPU-LAPU")
                {
                    newID = newID + "26";
                }
                else if (MuniCity == "MANDAUE")
                {
                    newID = newID + "30";
                }
                else
                {
                    Console.WriteLine("Sorry, your address is currently not supported.");
                }
            }

            for (int i = 0; i < 7; i++)
            {
                int x = random.Next(str.Length);
                newID = newID + str[x];
            }

            return newID;
        }
        public void CheckVoterStatus()
        {
            Console.WriteLine("\n1. Voter ID \n2. Last name \n3. Province \n4. City/Municipality \n5. Barangay");
            Console.Write("How would you like to search voter? ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Please enter voter ID to check: ");
                string voterID = Console.ReadLine();

                var voter = voterList.Find(voter => voter.voterID == voterID);
                if (voter != null)
                {
                    string statusText = voter.Status ? "active" : "inactive";
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Voter ID: " + voter.voterID + ",     Status: " + statusText +
                    ",      Name: " + voter.lastName + ", " + voter.firstName +
                    ",      Sex: " + voter.sex + ",     Birthday: " + voter.birthday +
                    ",      Address: " + voter.Province + ",    " + voter.muniCity + ",     " + voter.Brgy);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Voter not found.");
                    Console.ResetColor();
                }

            }
            else if (choice == 2)
            {
                Console.Write("Please enter last name to check: ");
                string Lastname = Console.ReadLine();

                var votersByLastName = voterList.FindAll(voter => voter.lastName.Equals(Lastname, StringComparison.OrdinalIgnoreCase));
                if (votersByLastName.Count > 0)
                {
                    foreach (var voter in votersByLastName)
                    {
                        string statusText = voter.Status ? "active" : "inactive";
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Voter ID: " + voter.voterID + ",     Status: " + statusText +
                        ",      Name: " + voter.lastName + ", " + voter.firstName +
                        ",      Sex: " + voter.sex + ",     Birthday: " + voter.birthday +
                        ",      Address: " + voter.Province + ",     " + voter.muniCity + ",     " + voter.Brgy);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No voters found with the last name: " + Lastname);
                    Console.ResetColor();
                }

            }
            else if (choice == 3)
            {
                Console.Write("Please enter Province to check: ");
                string province = Console.ReadLine();
                province = province.ToUpper();

                var votersByProvince = voterList.FindAll(voter => voter.Province.Equals(province, StringComparison.OrdinalIgnoreCase));
                if (votersByProvince.Count > 0)
                {
                    foreach (var voter in votersByProvince)
                    {
                        string statusText = voter.Status ? "active" : "inactive";
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Voter ID: " + voter.voterID + ",     Status: " + statusText +
                        ",      Name: " + voter.lastName + ", " + voter.firstName +
                        ",      Sex: " + voter.sex + ",     Birthday: " + voter.birthday +
                        ",      Address: " + voter.Province + ",     " + voter.muniCity + ",     " + voter.Brgy);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No voters found in the province: " + province);
                    Console.ResetColor();
                }
            }
            else if (choice == 4)
            {
                Console.Write("Please enter City/Municipality to check: ");
                string muniCity = Console.ReadLine();
                muniCity = muniCity.ToUpper();


                var votersBymuniCity = voterList.FindAll(voter => voter.muniCity.Equals(muniCity, StringComparison.OrdinalIgnoreCase));
                if (votersBymuniCity.Count > 0)
                {
                    foreach (var voter in votersBymuniCity)
                    {
                        string statusText = voter.Status ? "active" : "inactive";
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Voter ID: " + voter.voterID + ",     Status: " + statusText +
                        ",      Name: " + voter.lastName + ", " + voter.firstName +
                        ",      Sex: " + voter.sex + ",     Birthday: " + voter.birthday +
                        ",      Address: " + voter.Province + ",     " + voter.muniCity + ",     " + voter.Brgy);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No voters found in the City/Municipality: " + muniCity);
                    Console.ResetColor();
                }
            }
            else if (choice == 5)
            {
                Console.Write("Please enter Barangay to check: ");
                string Barangay = Console.ReadLine();
                Barangay = Barangay.ToUpper();

                var votersByBrgy = voterList.FindAll(voter => voter.Brgy.Equals(Barangay, StringComparison.OrdinalIgnoreCase));
                if (votersByBrgy.Count > 0)
                {
                    foreach (var voter in votersByBrgy)
                    {
                        string statusText = voter.Status ? "active" : "inactive";
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Voter ID: " + voter.voterID + ",     Status: " + statusText +
                        ",      Name: " + voter.lastName + ", " + voter.firstName +
                        ",      Sex: " + voter.sex + ",     Birthday: " + voter.birthday +
                        ",      Address: " + voter.Province + ",     " + voter.muniCity + ",     " + voter.Brgy);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No voters found in the Barangay: " + Barangay);
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid choice.");
            }
        }
        public void UpdateVoterStatus()
        {
            Console.Write("Please enter voter ID to be updated: ");
            string IDtoUpdate = Console.ReadLine();

            var voter = voterList.Find(v => v.voterID == IDtoUpdate);
            if (voter != null)
            {
                Console.Write("Enter the last year voted (enter 0 if voter has never voted since registration): ");
                int lastYearVoted = int.Parse(Console.ReadLine());

                DateTime today = DateTime.Today;
                int year = today.Year;

                if (lastYearVoted > 0)
                {

                    int yrs = year - lastYearVoted;
                    if (yrs > 6)
                    {
                        voter.Status = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Voter has not voted for 2 consecutive elections. Voter has been deactivated.");
                        Console.ResetColor();
                    }
                    else
                    {
                        voter.Status = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Voter status remains active.");
                        Console.ResetColor();
                    }
                    voter.LastYearVoted = lastYearVoted;
                }
                else
                {
                    voter.LastYearVoted = 0;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Voter is yet to vote for the first time since their registration.");
                    Console.ResetColor();
                }

                saveAllVoters();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Voter status updated successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Voter not found.");
                Console.ResetColor();
            }
        }
        public void PrintVoterList()
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(line);
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to read the file: " + ex.Message);
                Console.ResetColor();
            }
        }
        public void DeleteVoter()
        {
            Console.Write("Please enter ID to be deleted: ");
            string IDtoDelete = Console.ReadLine();

            var voter = voterList.Find(v => v.voterID == IDtoDelete);

            if (voter != null)
            {
                Console.Write("Are you sure you want to delete voter(yes/no)? ");
                if (Console.ReadLine().ToLower() == "yes")
                {
                    voterList.Remove(voter);
                    saveAllVoters();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Voter deleted successfully.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Voter deletion cancelled.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Voter not found.");
                Console.ResetColor();
            }
        }
        private void LoadVoterList()
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var fields = line.Split(',');
                        if (fields.Length >= 11)
                        {
                            string voterID = fields[0].Trim();
                            bool status = fields[1].Trim().Equals("active", StringComparison.OrdinalIgnoreCase);
                            string lastName = fields[2].Trim();
                            string firstName = fields[3].Trim();
                            char sex = fields[4].Trim()[0];
                            DateTime birthday = DateTime.Parse(fields[5].Trim());
                            string province = fields[6].Trim();
                            string city = fields[7].Trim();
                            string brgy = fields[8].Trim();
                            DateTime regisDate = DateTime.Parse(fields[9].Trim());
                            int lastYearVoted = int.Parse(fields[10].Trim());

                            Voter voter = new Voter(firstName, lastName, birthday, sex)
                            {
                                voterID = voterID,
                                Status = status,
                                Province = province,
                                muniCity = city,
                                Brgy = brgy,
                                RegisDate = regisDate,
                                LastYearVoted = lastYearVoted,
                            };
                            voterList.Add(voter);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to load voters from file: " + ex.Message);
                Console.ResetColor();
            }
        }
        public void saveVoter(Voter voter)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    string statusText = voter.Status ? "active" : "inactive";
                    string formattedLine = String.Format("{0},          {1},        {2},        {3},        {4},        {5},        {6},        {7},        {8},        {9},        {10}",
                            voter.voterID,
                            statusText,
                            voter.lastName,
                            voter.firstName,
                            voter.sex,
                            voter.birthday.ToString("yyyy - MM - dd"),
                            voter.Province,
                            voter.muniCity,
                            voter.Brgy,
                            voter.RegisDate,
                            voter.LastYearVoted);
                    writer.WriteLine(formattedLine);

                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Voter saved to file successfully.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to save voter to the file." + ex.Message);
                Console.ResetColor();
            }
        }
        public void saveAllVoters()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    string header = String.Format("{0},         {1},        {2},        {3},        {4},        {5},        {6},        {7},        {8},        {9},        {10}",
                            "ID ", "Status", "Last name", "First name", "Sex", "Birthday", "Province", "City/Municipality", "Barangay", "Registration Date", "Last year voted");
                    writer.WriteLine(header);
                    foreach (Voter voter in voterList)
                    {
                        string statusText = voter.Status ? "active" : "inactive";
                        string formattedLine = String.Format("{0},          {1},        {2},        {3},        {4},        {5},        {6},        {7},        {8},        {9},        {10}",
                            voter.voterID,
                            statusText,
                            voter.lastName,
                            voter.firstName,
                            voter.sex,
                            voter.birthday,
                            voter.Province,
                            voter.muniCity,
                            voter.Brgy,
                            voter.RegisDate,
                            voter.LastYearVoted);
                        writer.WriteLine(formattedLine);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to update the file." + ex.Message);
                Console.ResetColor();
            }
        }
    }
}

