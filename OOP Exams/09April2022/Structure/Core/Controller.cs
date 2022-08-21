using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Formula1.Core
{
    using Repositories.Contracts;
    using Models.Contracts;
    using Models;
    using Repositories;
    using Core.Contracts;
    public class Controller : IController
    {
        private readonly IRepository<IRace> races;
        private readonly IRepository<IPilot> pilots;
        private readonly IRepository<IFormulaOneCar> cars;
        public Controller()
        {
            races = new RaceRepository();
            pilots = new PilotRepository();
            cars = new FormulaOneCarRepository();

        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            var plname = pilots.FindByName(pilotName);

            if (plname == null || plname.Car != null)
            {
                return $"Pilot { pilotName } does not exist or has a car.";
            }
            var crmodel = cars.FindByName(carModel);
            if (crmodel == null)
            {
                return $"Car { carModel } does not exist.";
            }
            plname.AddCar(crmodel);
            cars.Remove(crmodel);
            return $"Pilot { pilotName } will drive a {cars.GetType().Name} { carModel } car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var rcname = races.FindByName(raceName);
            var plfullname = pilots.FindByName(pilotFullName);
            if (rcname == null)
            {
                return $"Race { raceName } does not exist.";
            }
            if (plfullname == null || !plfullname.CanRace || rcname.TookPlace)
            {
                return $"Can not add pilot { pilotFullName } to the race.";
            }
            rcname.AddPilot(plfullname);
            return $"Pilot { pilotFullName } is added to the { raceName } race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            var sth = cars.FindByName(model);
            if (sth != null)
            {
                return $"Formula one car { model } is already created.";
            }
            if (type != "Ferrari" && type != "Williams")
            {
                return $"Formula one car type { type } is not valid.";
            }
            if (type == "Ferrari")
            {
                Ferrari fr = new Ferrari(model, horsepower, engineDisplacement);
                cars.Add(fr);
            }
            else
            {
                Williams wl = new Williams(model, horsepower, engineDisplacement);
                cars.Add(wl);
            }
            return $"Car { type }, model { model } is created.";
        }

        public string CreatePilot(string fullName)
        {
            var name = pilots.FindByName(fullName);
            if (name != null)
            {
                return $"Pilot { fullName } is already created.";
            }
            Pilot pilot = new Pilot(fullName);
            pilots.Add(pilot);
            return $"Pilot { fullName } is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var sth = races.FindByName(raceName);
            if (sth != null)
            {
                return $"Race { raceName } is already created.";
            }
            Race rc = new Race(raceName, numberOfLaps);
            races.Add(rc);
            return $"Race { raceName } is created.";
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            var list = pilots.Models.OrderByDescending(x => x.NumberOfWins).ToList();
            foreach (var item in list)
            {
                sb.AppendLine($"Pilot { item.FullName } has { item.NumberOfWins } wins.");
            }
            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            var r = races.Models.ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in r)
            {
                if (item.TookPlace)
                {
                    sb.AppendLine(item.RaceInfo());
                }

            }
            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            var sth = races.FindByName(raceName);
            if (sth == null)
            {
                return $"Race { raceName } does not exist.";
            }
            if (sth.Pilots.Count < 3)
            {
                return $"Race { raceName } cannot start with less than three participants.";
            }
            if (sth.TookPlace)
            {
                return "Can not execute race { raceName }.";
            }
            //var list = cars.Models.OrderByDescending(x => x.RaceScoreCalculator).ToList();
            var topDrivers = sth.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(sth.NumberOfLaps)).ToList();

            return $"Pilot {topDrivers[0]} wins the { raceName } race.";
            return $"Pilot {topDrivers[1]} is second in the { raceName } race.";
            return $"Pilot {topDrivers[2]} is third in the { raceName } race.";

        }
    }
}
