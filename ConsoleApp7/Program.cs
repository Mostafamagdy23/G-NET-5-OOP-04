namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        { 
        }
            #region Part 01 - Theoretical Answers

            // Q1: Difference between static binding and dynamic binding?

            // Static Binding:
            // Happens at compile time.
            // Used with method overloading.

            // Dynamic Binding:
            // Happens at runtime.
            // Used with method overriding and virtual methods.



            // Q2: Difference between method overloading and method overriding?

            // Method Overloading:
            // Same method name with different parameters.
            // Happens in the same class.
            // Compile time.

            // Method Overriding:
            // Same method name and parameters.
            // Happens between base and child class.
            // Runtime.



            // Q3: Keywords used for Method Overriding?

            // virtual:
            // Used in base class to allow overriding.

            // override:
            // Used in child class to change base method.

            // base:
            // Used to call base class method.

            #endregion


            #region Ticket Base Class

class Ticket
        {
            public int TicketId { get; set; }
            public string MovieName { get; set; }
            public decimal Price { get; set; }

            public decimal PriceAfterTax
            {
                get { return Price * 1.14m; }
            }

            // Method Overloading
            public void SetPrice(decimal price)
            {
                Price = price;
                Console.WriteLine($"Setting price directly: {price}");
            }

            public void SetPrice(decimal basePrice, decimal multiplier)
            {
                Price = basePrice * multiplier;
                Console.WriteLine($"Setting price with multiplier: {basePrice} x {multiplier} = {Price}");
            }

            // Virtual Method
            public virtual void PrintTicket()
            {
                Console.WriteLine($"Ticket #{TicketId} | {MovieName} | Price: {Price} EGP | After Tax: {PriceAfterTax:F2} EGP");
            }
        }

        #endregion



        #region StandardTicket Class

        class StandardTicket : Ticket
        {
            public string SeatNumber { get; set; }

            public override void PrintTicket()
            {
                base.PrintTicket();
                Console.WriteLine($"  Seat: {SeatNumber}");
            }
        }

        #endregion



        #region VIPTicket Class

        class VIPTicket : Ticket
        {
            public bool LoungeAccess { get; set; }
            public decimal ServiceFee { get; set; }

            public override void PrintTicket()
            {
                base.PrintTicket();

                string lounge = LoungeAccess ? "Yes" : "No";

                Console.WriteLine($"  Lounge: {lounge} | Service Fee: {ServiceFee} EGP");
            }
        }

        #endregion



        #region IMAXTicket Class

        class IMAXTicket : Ticket
        {
            public bool Is3D { get; set; }

            public override void PrintTicket()
            {
                base.PrintTicket();

                string imax = Is3D ? "Yes" : "No";

                Console.WriteLine($"  IMAX 3D: {imax}");
            }
        }

        #endregion


        #region Cinema Class

        class Cinema
        {
            private Ticket[] tickets = new Ticket[10];
            private int count = 0;

            public void OpenCinema()
            {
                Console.WriteLine("========== Cinema Opened ==========");
                Console.WriteLine("Projector started.\n");
            }

            public void CloseCinema()
            {
                Console.WriteLine("\n========== Cinema Closed ==========");
                Console.WriteLine("Projector stopped.");
            }

            public void AddTicket(Ticket t)
            {
                tickets[count++] = t;
            }

            public void PrintAllTickets()
            {
                Console.WriteLine("\n========== All Tickets ==========");

                for (int i = 0; i < count; i++)
                {
                    tickets[i].PrintTicket();
                }
            }

            // Static Method
            public static void ProcessTicket(Ticket t)
            {
                Console.WriteLine("\n========== Process Single Ticket ==========");
                t.PrintTicket();
            }
        }

        #endregion




        #region Main Program

        class MainProgram
        {
            static void Main()
            {
                Cinema cinema = new Cinema();

                cinema.OpenCinema();

                Console.WriteLine("========== SetPrice Test ==========");

                // Standard Ticket
                StandardTicket t1 = new StandardTicket()
                {
                    TicketId = 1,
                    MovieName = "Inception",
                    SeatNumber = "A-5"
                };

                t1.SetPrice(150);

                // VIP Ticket
                VIPTicket t2 = new VIPTicket()
                {
                    TicketId = 2,
                    MovieName = "Avengers",
                    LoungeAccess = true,
                    ServiceFee = 50
                };

                t2.SetPrice(100, 1.5m);

                // IMAX Ticket
                IMAXTicket t3 = new IMAXTicket()
                {
                    TicketId = 3,
                    MovieName = "Dune",
                    Is3D = false
                };

                t3.SetPrice(180);

                // Add Tickets
                cinema.AddTicket(t1);
                cinema.AddTicket(t2);
                cinema.AddTicket(t3);

                // Print All
                cinema.PrintAllTickets();

                // Process Single Ticket
                Cinema.ProcessTicket(t2);

                cinema.CloseCinema();
            }
        }

        #endregion
    }
}

