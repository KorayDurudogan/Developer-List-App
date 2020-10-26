using System.Collections.Generic;

namespace DeveloperListApp.Models
{
    public class Team
    {
        public Team()
        {
            this.Developers = new List<Developer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Developer> Developers { get; set; }
    }
}
