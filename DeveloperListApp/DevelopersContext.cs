using DeveloperListApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperListApp
{
    public class DevelopersContext
    {
        private readonly List<Developer> _developers = new List<Developer>
        {
            new Developer { Id = 1, Name = "Developer 1" },
            new Developer { Id = 2, Name = "Developer 2" },
            new Developer { Id = 3, Name = "Developer 3" },
            new Developer { Id = 4, Name = "Developer 4" },
            new Developer { Id = 5, Name = "Developer 5" },
            new Developer { Id = 6, Name = "Developer 6" },
            new Developer { Id = 7, Name = "Developer 7" },
            new Developer { Id = 8, Name = "Developer 8" },
            new Developer { Id = 9, Name = "Developer 9" },
            new Developer { Id = 10, Name = "Developer 10" }
        };

        private readonly List<Team> _teams = new List<Team>();

        public DevelopersContext()
        {
            PopulateTeams();
        }

        private void PopulateTeams()
        {
            var epicWins = new Team { Id = 1, Name = "EpicWins" };
            var powerBank = new Team { Id = 2, Name = "PowerBank" };

            foreach (var developer in _developers)
            {
                if (developer == null)
                    continue;

                if (developer.Id < 7)
                    epicWins.Developers.Add(developer);
                else
                    powerBank.Developers.Add(developer);
            }

            _teams.Clear();

            _teams.Add(epicWins);
            _teams.Add(powerBank);
        }

        public List<Developer> GetDevelopers()
        {
            return _developers;
        }

        public List<Team> GetTeams()
        {
            return _teams;
        }

        public Developer GetDeveloperById(int id)
        {
            return _developers.Where(p => p.Id == id).FirstOrDefault();
        }

        public Team GetTeamById(int id)
        {
            return _teams.Where(p => p.Id == id).FirstOrDefault();
        }

        public Developer AddDeveloper(Developer developer)
        {
            this._developers.Add(developer);
            PopulateTeams();
            return developer;
        }
    }
}
