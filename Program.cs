namespace TheConsoleLottery;

class Program
{
    
    
    static void Main(string[] args) {
        // 5 lottonummer;

        static int GetNumberOfTickets() {
            bool isNumber;
            int number;
            
            do {
                Console.WriteLine();
                Console.WriteLine("How many tickets do you want");
                isNumber = int.TryParse(Console.ReadLine(), out number);
            } while (!isNumber);

            return number;
        }
        
        static int[] GetTicketNumbers(int number, int[] array) {
            
            for (int i = 0; i < number; i++) {
                bool isNumber;
                int ticketNumber;
            
                Console.WriteLine("What ticket number do you want?");
            
                do {
                    isNumber = int.TryParse(Console.ReadLine(), out ticketNumber);
                } while (!isNumber);

                array[i] = ticketNumber;
            }
            return array;
        }
        
        static int[] GetWinningNumbers(int[] array) {
            Random random = new Random();
            for (int i = 0; i < 3; i++) {
                int number;
            
                do {
                    number = random.Next(1, 51);
                } while (array.Contains(number));

                array[i] = number;
            }

            return array;
        }
        
        static int ComapareNumbers(int[] playerArray, int[] randomArray) {
            int matchingNumbers = 0;
            foreach (int number in randomArray) {
                if (playerArray.Contains(number)) matchingNumbers++;
            }

            return matchingNumbers;
        }
        
        void ShowResult(int number) {
            switch (number) {
                case 1 : 
                    Console.WriteLine("You got one number right!");
                    break;
                case 2 : 
                    Console.WriteLine("You got two numbers right!");
                    break;
                case 3 :
                    Console.WriteLine("You won the JackPot!!! Congratulations!");
                    break;
                default :
                    Console.WriteLine("You won nothing, better luck next time!");
                    break;
            }
        }
        
        int numberOfTickets = GetNumberOfTickets();
        
        int[] tickets = new int[numberOfTickets];
        int[] winningNumbers = new int[3];

        tickets = GetTicketNumbers(numberOfTickets, tickets);
        winningNumbers = GetWinningNumbers(winningNumbers);

        int matchingNumbers = ComapareNumbers(tickets, winningNumbers);

        ShowResult(matchingNumbers);
        
    }
}