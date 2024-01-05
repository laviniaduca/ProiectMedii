using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMedii.Models
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NumeClient { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string MakeupArtistName { get; set; }
        public string ServiceTitle { get; set; }

        [ForeignKey(typeof(MakeupArtist))]
        public int MakeupArtistID { get; set; }

        [ForeignKey(typeof(Service))]
        public int ServiceID { get; set; }
    }
}
