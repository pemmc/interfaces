﻿using System;
namespace Interface.Entities
{
    public class CarRental
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        public CarRental(DateTime start, DateTime finish, Vehicle vehicle)
        {
            Start = start;
            Finish = finish;
            Vehicle = vehicle;

            //Irá incial como nulo, pois só será inicializado quando eu calcular a invoice
            // não é necessário pois o objeto associado já receebe nulo, mas deixei aqui
            // inicializado no construtor como nulo
            Invoice = null;
        }
    }
}
