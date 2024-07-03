using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRab5App.Domain.Entities
{
    public class Artist : Entity
    {
        private List<Song> _songs = new();
        private Artist() { }

        public Artist(string name, DateTime birthDate, string country)
        {
            Name = name;
            BirthDate = birthDate;
            Country = country;
        }

        public IEnumerable<Song> Songs { get => _songs.AsReadOnly(); }
        public string Name { get; set; }

        public DateTime BirthDate { get; private set; }

        public string Country { get; private set; }
    }
}
