namespace Voter_Registration_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VoterManager voterManager = new VoterManager();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("========================================");
            Console.WriteLine("||   Regizzter - Voter Registration   ||");
            Console.WriteLine("========================================\n");
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Voter Registration System");
                Console.WriteLine("1. Register a voter");
                Console.WriteLine("2. Search & Check Voter Status");
                Console.WriteLine("3. Update Voter Status");
                Console.WriteLine("4. Display Voter List");
                Console.WriteLine("5. Delete Voter");
                Console.WriteLine("6. Exit");
                Console.Write("Please enter your choice (1-6): ");
                int choice = int.Parse(Console.ReadLine());

                if (choice < 1 || choice > 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number between 1-6.");
                    Console.ResetColor();
                }

                try
                {
                    switch (choice)
                    {
                        case 1:     //Register a voter
                            {
                                voterManager.RegisterVoter();
                                break;
                            }
                        case 2:     //Check Voter Status
                            {
                                voterManager.CheckVoterStatus();
                                break;
                            }
                        case 3:     //Update Voter Status
                            {
                                voterManager.UpdateVoterStatus();
                                break;
                            }
                        case 4:     //Print List of registered voters
                            {
                                voterManager.PrintVoterList();
                                break;
                            }
                        case 5:     //Delete a voter
                            {
                                voterManager.DeleteVoter();
                                break;
                            }
                        case 6:     //Exit the program
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                return;
                            }
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
