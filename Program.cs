//Gruppuppgift
//Mauricio Corte, Max Berglund, Edwin Torres
//.NET24

namespace TheConsoleLottery;

class Program
{
    //Hello
    static void Main(string[] args) {
        int balance = 100;
        Console.WriteLine("Welcome to The Console Lottery. You have 100$ in your account. Each ticket costs 10$ Good luck!");

        bool gameActive = true;
        while (gameActive)
        { 
            TheGame();
            // Console.Clear();
            Console.WriteLine("Do you want to play again? (y/n)");

            bool isValid = false;
            do {
                string? userInput = Console.ReadLine();
                if (userInput == "y" || userInput == "n") {
                    isValid = true;
                    if (userInput == "n") gameActive = false;
                }

            } while (!isValid);
        }
        
        void TheGame() {
            int GetNumberOfTickets() 
            {
                bool isNumber;
                int number;
                
                do
                {
                    //Console.Clear();
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

            void CalculateBalance (int numberOfTickets) {
                // Console.Clear();
                Console.WriteLine($"you have purchased {numberOfTickets} tickets for {numberOfTickets * 10}$\nYou currently have {balance - (numberOfTickets * 10)}$ left.");
                balance -= numberOfTickets * 10;
            }

            int[] GetTicketNumbers(int number, int[] array, int numberOfTickets)
            {

                for (int i = 0; i < number; i++)
                {
                    bool isNumber;
                    int ticketNumber;
                    //Console.Clear();
                    Console.WriteLine($"Choose a number for your ({i + 1}/{numberOfTickets}) ticket:");
                    //Hello
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
                    var result = array.Select(n => n == 0 ? "X" : n.ToString());
                    Console.WriteLine("Chosen Numbers: [{0}]", string.Join(", ", result));
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
                        number = random.Next(1, 4);
                    } while (array.Contains(number));

                    array[i] = number;
                }

                return array;
            }

            int ComapareNumbers(int[] playerArray, int[] randomArray) {
                int matchingNumbers = 0;
                foreach (int number in randomArray) {
                    if (playerArray.Contains(number)) {
                        matchingNumbers++;
                    }
                }
                return matchingNumbers;
            }

            void ShowResult(int number) {
                //Console.Clear();
                switch (number)
                {
                    case 1:
                        balance += 100;
                        Console.WriteLine("You got one number right! You win 100$");
                        break;
                    case 2:
                        balance += 200;
                        Console.WriteLine("You got two numbers right! You win 200$");
                        break;
                    case 3:
                        balance += 10000;
                        Console.WriteLine("JackPot!!! Congratulations! You win 10000$");
                        break;
                    default:
                        Console.WriteLine("You won nothing, better luck next time!");
                        break;
                }
            }
            int numberOfTickets = GetNumberOfTickets();
            CalculateBalance(numberOfTickets);

            int[] tickets = new int[numberOfTickets];
            int[] winningNumbers = new int[3];

            tickets = GetTicketNumbers(numberOfTickets, tickets, numberOfTickets);
            winningNumbers = GetWinningNumbers(winningNumbers);

            int matchingNumbers = ComapareNumbers(tickets, winningNumbers);

            ShowResult(matchingNumbers);
        }
    }
}