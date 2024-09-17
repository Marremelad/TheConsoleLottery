namespace TheConsoleLottery;

class Program
{
    static void Main(string[] args) {
        bool gameActive = true;
        while (gameActive==true)
        {
            TheGame();
            Console.WriteLine("Do you want to play again? (y/n)");
            if ((Console.ReadLine() ?? string.Empty).ToLower() == "n") gameActive = false;
        }

        void TheGame()
        {
            static int GetNumberOfTickets()
            {
                bool isNumber;
                int number;

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("How many tickets do you want");
                    isNumber = int.TryParse(Console.ReadLine(), out number);
                    if (!isNumber || number < 1)
                    {
                        Console.WriteLine("Invalid number. Please enter a valid number.");
                        isNumber = false;
                    }
                } while (!isNumber);

                return number;
            }

            int[] GetTicketNumbers(int number, int[] array, int numberOfTickets)
            {

                for (int i = 0; i < number; i++)
                {
                    bool isNumber;
                    int ticketNumber;
    
                    Console.WriteLine($"Choose a number for your ({i + 1}/{numberOfTickets}) ticket:");
    
                    do {
                        isNumber = int.TryParse(Console.ReadLine(), out ticketNumber);
        
                        if (!isNumber) {
                            Console.WriteLine("Invalid number. Please enter a valid number.");
                            isNumber = false;
                        } else if (ticketNumber < 1 || ticketNumber > 50) {
                            Console.WriteLine("Number must be between 1 and 50.");
                            isNumber = false;
                        } else if (array.Contains(ticketNumber)) {
                            Console.WriteLine("Number already chosen. Please choose a different number.");
                            isNumber = false;
                        }
                    } while (!isNumber);

                    array[i] = ticketNumber;
                }

                return array;
            }

            int[] GetWinningNumbers(int[] array)
            {
                Random random = new Random();
                for (int i = 0; i < 3; i++)
                {
                    int number;

                    do
                    {
                        number = random.Next(1, 51);
                    } while (array.Contains(number));

                    array[i] = number;
                }

                return array;
            }

            int ComapareNumbers(int[] playerArray, int[] randomArray)
            {
                int matchingNumbers = 0;
                foreach (int number in randomArray)
                {
                    if (playerArray.Contains(number)) matchingNumbers++;
                }

                return matchingNumbers;
            }

            void ShowResult(int number)
            {
                switch (number)
                {
                    case 1:
                        Console.WriteLine("You got one number right!");
                        break;
                    case 2:
                        Console.WriteLine("You got two numbers right!");
                        break;
                    case 3:
                        Console.WriteLine("You won the JackPot!!! Congratulations!");
                        break;
                    default:
                        Console.WriteLine("You won nothing, better luck next time!");
                        break;
                }
            }

            int numberOfTickets = GetNumberOfTickets();

            int[] tickets = new int[numberOfTickets];
            int[] winningNumbers = new int[3];

            tickets = GetTicketNumbers(numberOfTickets, tickets, numberOfTickets);
            winningNumbers = GetWinningNumbers(winningNumbers);

            int matchingNumbers = ComapareNumbers(tickets, winningNumbers);

            ShowResult(matchingNumbers);
        }
    }
}