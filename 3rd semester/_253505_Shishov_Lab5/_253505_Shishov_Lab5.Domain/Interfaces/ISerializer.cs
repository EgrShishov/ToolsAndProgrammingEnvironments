using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using _253505_Shishov_Lab5.Domain.Entities;

namespace _253505_Shishov_Lab5.Domain.Interfaces
{
    public interface ISerializer
    {
        IEnumerable<Library> DeSerializeByLINQ(string fileName);
        IEnumerable<Library> DeSerializeXML(string fileName);
        IEnumerable<Library> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<Library> xxx, string fileName);
        void SerializeXML(IEnumerable<Library> xxx, string fileName);
        void SerializeJSON(IEnumerable<Library> xxx, string fileName);
    }
}
