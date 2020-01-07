using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TekENotions.API.Models
{
    public class InspiredPatterns
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Needles { get; set; }
        public string YarnWeight { get; set; }
        public string Yardage { get; set; }
        public string ImageURL { get; set; }
        public string RavelryURL { get; set; }
        public bool Knitting { get; set; }
        public bool Crochet { get; set; }
        public string Theme { get; set; }
        public DateTime DateCreated { get; set; }
        public int RavelryId { get; set; }
    }
}
