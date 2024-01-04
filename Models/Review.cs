using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMedii.Models
{
    public class Review
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public int MakeupArtistID { get; set; }
    }
}
