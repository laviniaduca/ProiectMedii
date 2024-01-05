using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

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
        public string ServiceTitle { get; set; }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Service))]
        public int? ServiceID { get; set; }

        [OneToMany]
        public List<Appointment> Appointments { get; set; }

        [OneToMany]
        public List<Review> Reviews { get; set; }
    }
}
