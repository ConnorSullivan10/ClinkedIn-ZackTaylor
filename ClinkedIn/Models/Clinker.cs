using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Clinker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LineItem> Services { get; set; }
        public List<string> Interests { get; set; }
        public List<Clinker> Friends { get; set; }
        public List<Clinker> Enemies { get; set; }
    }

    public class LineItem
    {
        public string Service { get; set; }
        public bool IsRequested { get; set; }
    }
}
