using System;

using Interface.Entities;

namespace Interface.Services
{
    public class RentalService
    {
        public double PricePerHour { get; private set; }    
        public double PricePerDay { get; private set; }

        //Declaração de dependência, já instanciando, fica muito dependente do BrazilTaxService
        //Fica só para o Brasil.. se tiver que trocar este serviço... vou ter que criar o outro serviço e ainda mexer
        //nesta classe RentalService
        //vamos mudar isso por meio de INTERFACE
        //era assim.. mass criamos o SERVICO TAXSERVICE... com o brasiltaxservice com classe concreta
        //private BrazilTaxService _brazilTaxService = new BrazilTaxService();

        //Declaração da INTERFACE
        private ITaxService _taxService;

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;

            _taxService = taxService;

        }

        public void ProcessInvoice(CarRental carRental)
        {
            //Duração da minha locação
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;

            //arredondando para cima Math.Ceiling
            if (duration.TotalHours <= 12.0)
            {
                
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);

            }

            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);

            }

            double tax = _taxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);

        }
        
    }
}
