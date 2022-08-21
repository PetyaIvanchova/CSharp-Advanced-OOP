﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    using Models.Contracts;
    public class Pilot : IPilot
    {
        private string fullname;
        public string FullName
        {
            get { return this.fullname; }
           private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length<5)
                {
                    throw new ArgumentException($"Invalid pilot name: { value }.");
                }
                this.fullname = value;
            }
        }

        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if (value==null)
                {
                    throw new NullReferenceException("Pilot car can not be null.");
                }
                this.car = value;
            }
        }
        private int numbersofwins = 0;
        public int NumberOfWins
        {
            get=>numbersofwins; 
            set {
                numbersofwins = value;
            } }
        private IFormulaOneCar car;
        private bool canrace = false;
        public bool CanRace
        {
            get { return this.canrace; }
            private set { canrace = value; }
        }
       
        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }
        public Pilot(string fullname)
        {
            FullName = fullname;
            NumberOfWins = 0;
        }
        public void WinRace()
        {
            NumberOfWins++;
         
        }
        public override string ToString()
        {
            return $"Pilot { FullName } has { NumberOfWins } wins.";
        }
    }
}
