// See https://aka.ms/new-console-template for more information
namespace CabInvoice
{
    class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to cab Invoice Generator");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.Normal);
            double fare = invoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine($"Fare :{fare}");
            Console.ReadLine();
            InvoiceSummary invoiceTotalFare = new InvoiceSummary(3, 5);
            Console.WriteLine(invoiceTotalFare);
        }
    }
}
