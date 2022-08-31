namespace A1_Ticketing_System_Moldenauer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.csv";
            string choice;
            do
            {
                // prompt user for selection
                Console.WriteLine("\nTicketing System\n" +
                                  "--------------------\n" +
                                  "1 for Reading data from a ticket file\n" +
                                  "2 for writing data to a ticket file\n" +
                                  "Any other key will exit the program");
                Console.Write(">");


                // read response from user
                choice = Console.ReadLine();


                switch (choice)
                {
                    // read data from file
                    case "1":
                        Console.WriteLine("\n*Read Ticket File*");
                        if (File.Exists(file))
                        {
                            StreamReader sr = new StreamReader(file);
                            string[] lines = File.ReadAllLines(file);
                            // while (!sr.EndOfStream)
                            // {
                            //     string line = sr.ReadLine();
                            //     Console.WriteLine(line);
                            // }

                            for (int i = 1; i < lines.Length; i++)
                                Console.WriteLine(lines[i]);
                        }
                        else
                        {
                            Console.WriteLine("File does not exist");
                        }
                        break;


                    // write data to file selection
                    case "2":
                        string header = "TicketID,Summary,Status,Priority,Submitter,Assigned,Watching";
                        List<string> tickets = new List<string>();

                        string summary, status, priority, submitter, assigned;

                        string ticketControl = "";
                        string watchingControl = "";

                        int loop = 1;

                        StreamWriter sw = new StreamWriter(file);

                        Console.WriteLine("*Write Ticket File*");

                        do
                        {
                            string watching = null;
                            int watchCount = 0;

                            Console.Write("Summary: ");
                            summary = Console.ReadLine();

                            Console.Write("Status: ");
                            status = Console.ReadLine();

                            Console.Write("Priority: ");
                            priority = Console.ReadLine();

                            Console.Write("Submitter: ");
                            submitter = Console.ReadLine();

                            Console.Write("Assigned: ");
                            assigned = Console.ReadLine();

                            do
                            {
                                Console.Write("Watching (enter -1 end watching list): ");
                                watchingControl = Console.ReadLine();
                                if (watchingControl == "-1")
                                {
                                    break;
                                }
                                if (watchCount > 0)
                                    watching += "|";
                                watching += watchingControl;  //+ (watchCount > 0 ? "|" : "")
                                watchCount++;
                            } while (watchingControl != "-1");

                            // write header only
                            if (loop == 1)
                            {
                                sw.WriteLine(header);
                            }

                            // write data from user
                            // sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", loop, summary, status, priority, submitter, assigned, watching);
                            sw.WriteLine($"{loop},{summary},{status},{priority},{submitter},{assigned},{watching}");

                            loop++;

                            // promt the user to enter another ticket
                            Console.Write("Would you like to enter another ticket? (Y for yes / N for no): ");
                            ticketControl = Console.ReadLine().ToUpper();
                        } while (ticketControl.Equals("Y"));

                        sw.Close();
                        break;
                    default:
                        Console.WriteLine("na");
                        break;
                }

            } while (choice == "1" || choice == "2");

        }
    }
}