﻿namespace TheConsoleLottery;

class Program
{
    
    
    static void Main(string[] args) {
        // 5 lottonummer;

        static int getNumberOfTickets() {
            bool isNumber;
            int number;
            
            do {
                Console.WriteLine();
                Console.WriteLine("How many tickets do you want");
                isNumber = int.TryParse(Console.ReadLine(), out number);
            } while (!isNumber);

            return number;
        }
        
        static int[] getTicketNumbers(int number, int[] array) {
            
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
        
        // Initialises arrays.
        int numberOfTickets = getNumberOfTickets();
        
        int[] tickets = new int[numberOfTickets];
        int[] winningNumbers = new int[3];
        
        
        
        
        
        // Get winning numbers.
        for (int i = 0; i < 3; i++) {
            int number;
            
            do {
                number = random.Next(1, 51);
            } while (winningNumbers.Contains(number));

            winningNumbers[i] = number;
        }
        
        
        // Validates matches between chosen numbers and winning numbers.
        int matchingNumbers = 0;
        foreach (int number in winningNumbers) {
            if (tickets.Contains(number)) matchingNumbers++;
        }
        
        switch (matchingNumbers) {
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
}