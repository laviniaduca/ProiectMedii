using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProiectMedii.Models
{
    public class MakeupArtist
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public string PhoneNumber { get; set; }

        public int ServiceID { get; set; }
    }
}
