using System.Globalization;

namespace Interface.Entities
{
    public class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double TotalPayment
        {
            //aqui é um exemplo de PROPRIEDADE CALCULADA
            get { return BasicPayment + Tax; }

        }

        public override string ToString()
        {
            
            return "Basic Payment: "
                + BasicPayment.ToString("C", new CultureInfo("pt-BR").NumberFormat)
                + "\nTax: "
                + Tax.ToString("C", new CultureInfo("pt-BR").NumberFormat)
                + "\nTotal payment: "
                + TotalPayment.ToString("C", new CultureInfo("pt-BR").NumberFormat);

        }
       
    }
    
}
