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

    }
}

