using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpaceStation.Core
{
    using Core.Contracts;
    using Models.Astronauts;
    using Models.Planets;
    using Repositories.Contracts;
    using Repositories;
    using Models.Planets.Contracts;
    using Models.Astronauts.Contracts;
    using Models.Mission;

    public class Controller : IController
    {
        private readonly IRepository<IPlanet> planets;
        private readonly IRepository<IAstronaut> astronauts;
        private int ExploredPlanets = 0;
        public Controller()
        {
            this.planets = new PlanetRepository();
            this.astronauts = new AstronautRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type != "Meteorologist" && type != "Geodesist" && type != "Biologist")
            {
                throw new InvalidOperationException ("Astronaut type doesn't exists!");

            }
            if (type == "Meteorologist")
            {
                Meteorologist mg = new Meteorologist(astronautName);
                astronauts.Add(mg);
            }
            else if (type == "Geodesist")
            {
                Geodesist go = new Geodesist(astronautName);
                astronauts.Add(go);
            }
            else
            {
                Biologist bi = new Biologist(astronautName);
                astronauts.Add(bi);
            }
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet pl = new Planet(planetName);
            foreach (var item in items)
            {
                pl.Items.Add(item);
            }
            planets.Add(pl);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            Mission ms = new Mission();
            var planet = planets.FindByName(planetName);
            var above = astronauts.Models.Where(x => x.Oxygen > 60).ToList();
            if (above.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet!");
            }
          //  int alivecount = above.Count;
            ms.Explore(planet, above);
            ExploredPlanets++;
            int dead = above.Where(x => x.Oxygen == 0).ToList().Count;
            planets.Remove(planet);

            return $"Planet: {planetName} was explored! Exploration finished with {dead} dead astronauts!";

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{ExploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var item in astronauts.Models)
            {

                sb.AppendLine($"Name: { item.Name}");
                sb.AppendLine($"Oxygen: { item.Oxygen}");
                if (item.Bag.Items.Count != 0)
                {
                    List<string> bags = new List<string>();
                    foreach (var bag in item.Bag.Items)
                    {
                        bags.Add(bag);
                    }
                    sb.AppendLine($"Bag items: {string.Join(", ", bags)}");
                }
                else
                {
                    sb.AppendLine("Bag items: none");
                }

            }
            return sb.ToString().Trim();
        }

        public string RetireAstronaut(string astronautName)
        {
            var name = astronauts.FindByName(astronautName);

            if (name == null)
            {
                throw new InvalidOperationException
                   ($"Astronaut {astronautName} doesn't exists!");
            }
            astronauts.Remove(name);
            return $"Astronaut {astronautName} was retired!";

        }
    }
}
