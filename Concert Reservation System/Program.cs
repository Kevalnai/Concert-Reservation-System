using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert_Reservation_System
{
   

class Seat
    {
        public string CustomerName { get; set; }
        public bool IsReserved { get; set; }

        public Seat()
        {
            CustomerName = "";
            IsReserved = false;
        }
    }

    class ConcertHall
    {
        private Seat[,] seats;

        public ConcertHall(int rows, int seatsPerRow)
        {
            seats = new Seat[rows + 1, seatsPerRow + 1];
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= seatsPerRow; j++)
                {
                    seats[i, j] = new Seat();
                }
            }
        }

        public void AddReservation(string name, int row, int seat)
        {
            if (seats[row, seat].IsReserved)
            {
                Console.WriteLine("Seat is already reserved.");
            }
            else
            {
                seats[row, seat].CustomerName = name;
                seats[row, seat].IsReserved = true;
                Console.WriteLine("Reservation successful!");
            }
        }

        public void EditReservation(string name, int row, int seat)
        {
            if (seats[row, seat].IsReserved)
            {
                seats[row, seat].CustomerName = name;
                Console.WriteLine("Reservation updated!");
            }
            else
            {
                Console.WriteLine("Seat is not yet reserved.");
            }
        }

        public void CancelReservation(int row, int seat)
        {
            if (seats[row, seat].IsReserved)
            {
                Console.Write("Confirm reservation cancellation (y/n): ");
                char choice = char.ToLower(Console.ReadKey().KeyChar);
                if (choice == 'y')
                {
                    seats[row, seat].CustomerName = "";
                    seats[row, seat].IsReserved = false;
                    Console.WriteLine("\nReservation cancelled.");
                }
                else if (choice == 'n')
                {
                    Console.WriteLine("\nReservation not cancelled.");
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Reservation not cancelled.");
                }
            }
            else
            {
                Console.WriteLine("\nNo reservation found.");
            }
        }

        public void DisplaySeatingChart()
        {
            Console.WriteLine("\nSeating Chart:");
            for (int i = 1; i < seats.GetLength(0); i++)
            {
                Console.Write($"Row {i}: ");
                for (int j = 1; j < seats.GetLength(1); j++)
                {
                    if (seats[i, j].IsReserved)
                    {
                        Console.Write(seats[i, j].CustomerName + " ");
                    }
                    else
                    {
                        Console.Write(j + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Concert Reservation System!");

            Console.Write("Enter the number of rows: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of seats per row: ");
            int seatsPerRow = int.Parse(Console.ReadLine());

            ConcertHall concertHall = new ConcertHall(rows, seatsPerRow);

            while (true)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Add New Reservation");
                Console.WriteLine("2. Edit Existing Reservation");
                Console.WriteLine("3. Cancel Reservation");
                Console.WriteLine("4. Display Seating Chart");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddNewReservation(concertHall);
                        break;
                    case 2:
                        EditExistingReservation(concertHall);
                        break;
                    case 3:
                        CancelReservation(concertHall);
                        break;
                    case 4:
                        concertHall.DisplaySeatingChart();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddNewReservation(ConcertHall concertHall)
        {
            Console.WriteLine("\nAdd New Reservation:");

            concertHall.DisplaySeatingChart();

            Console.Write("Enter customer's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter row number: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Enter seat number: ");
            int seat = int.Parse(Console.ReadLine());

            concertHall.AddReservation(name, row, seat);
        }

        static void EditExistingReservation(ConcertHall concertHall)
        {
            Console.WriteLine("\nEdit Existing Reservation:");

            concertHall.DisplaySeatingChart();

            Console.Write("Enter row number: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Enter seat number: ");
            int seat = int.Parse(Console.ReadLine());

            Console.Write("Enter new customer's name: ");
            string newName = Console.ReadLine();

            concertHall.EditReservation(newName, row, seat);
        }

        static void CancelReservation(ConcertHall concertHall)
        {
            Console.WriteLine("\nCancel Existing Reservation:");

            concertHall.DisplaySeatingChart();

            Console.Write("Enter row number: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Enter seat number: ");
            int seat = int.Parse(Console.ReadLine());

            concertHall.CancelReservation(row, seat);
        }
    }

}

