using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    using Models.Contracts;
    public class Race : IRace
    {
        private string racename;
        public string RaceName
        {
            get { return this.racename; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length<5)
                {
                    throw new ArgumentException($"Invalid race name: { value }.");
                }
                this.racename = value;
            }
        }
        private int numbersoflaps;
        public int NumberOfLaps
        {
            get { return this.numbersoflaps; }
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException($"Invalid lap numbers: { value }.");
                }
                this.numbersoflaps = value;
            }
        }
        private bool tookplace=false;
        public bool TookPlace 
        {
            get { return this.tookplace; } 
            set { tookplace = value; }
        }
        private List<IPilot> pilots;
        public ICollection<IPilot> Pilots => pilots.AsReadOnly();
        public Race()
        {
            pilots = new List<IPilot>();
        }

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }
        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
        }
        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
               
                sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            if (TookPlace==true)
            {
                sb.AppendLine("Took place: Yes");
            }
            else
            {
                sb.AppendLine("Took place: No");
            }
            return sb.ToString().Trim();
            
        }
    }
}
