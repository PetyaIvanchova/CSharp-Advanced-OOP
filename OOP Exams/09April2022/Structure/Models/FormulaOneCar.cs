using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    using Models.Contracts;
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length<3)
                {
                    throw new ArgumentException($"Invalid car model: { value }.");
                }
                this.model = value;

            }
        }
        private int horsepower;
        public int Horsepower
        {
            get { return this.horsepower; }
           private set
            {
                if (value<900 || value>1050)
                {
                    throw new ArgumentException($"Invalid car horsepower: { value }.");
                }
                this.horsepower = value;
            }
        }
        private double enginedisplacement;
        public double EngineDisplacement
        {
            get { return this.enginedisplacement; }
           private set
            {
                if (value<1.6 || value>2.00)
                {
                    throw new ArgumentException($"Invalid car engine displacement: { value }.");
                }
                this.enginedisplacement = value;
            }
        }
        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        public double RaceScoreCalculator(int laps)
        {
            return EngineDisplacement / Horsepower * laps;
        }

    }
}
