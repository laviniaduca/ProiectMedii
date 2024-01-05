using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using ProiectMedii.Models;

namespace ProiectMedii.Data
{
    public class MakeupDatabase
    {
        readonly SQLiteAsyncConnection _database;

        // constructorul
        public MakeupDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MakeupArtist>().Wait();
            _database.CreateTableAsync<Review>().Wait();
            _database.CreateTableAsync<Appointment>().Wait();
            _database.CreateTableAsync<Service>().Wait();
        }


        // ------------ CRUD MAKEUP ARTIST -----------------
        // returneaza toate records (lista) din MakeupArtist
        public Task<List<MakeupArtist>> GetMakeupArtistsAsync()
        {
            return _database.Table<MakeupArtist>().ToListAsync();
        }

        // returneaza un record specific pe baza ID-ului
        public Task<MakeupArtist> GetMakeupArtistAsync(int id)
        {
            return _database.Table<MakeupArtist>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }

        // salveaza un record MakeupArtist in baza de date,asincron
        public Task<int> SaveMakeupArtistAsync(MakeupArtist makeupArtist)
        {
            if (makeupArtist.ID != 0)
            {
                return _database.UpdateAsync(makeupArtist);
            }
            else
            {
                return _database.InsertAsync(makeupArtist);
            }
        }

        // sterge un record
        public Task<int> DeleteMakeupArtistAsync(MakeupArtist makeupArtist)
        {
            return _database.DeleteAsync(makeupArtist);
        }


        // --------------- CRUD SERVICE ---------------
        // returneaza toate records (lista) din Service
        public Task<List<Service>> GetServicesAsync()
        {
            return _database.Table<Service>().ToListAsync();
        }

        // returneaza un record specific pe baza ID-ului
        public Task<Service> GetServiceAsync(int id)
        {
            return _database.Table<Service>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        // salveaza un record Service in baza de date, asincron
        public Task<int> SaveServiceAsync(Service service)
        {
            if (service.ID != 0)
            {
                return _database.UpdateAsync(service);
            }
            else
            {
                return _database.InsertAsync(service);
            }
        }

        // sterge un record
        public Task<int> DeleteServiceAsync(Service service)
        {
            return _database.DeleteAsync(service);
        }

        public async Task<List<string>> GetAllServiceTitlesAsync()
        {
            var services = await _database.Table<Service>().ToListAsync();
            return services.Select(s => s.Title).ToList();
        }

        public Task<Service> GetServiceByTitleAsync(string title)
        {
            return _database.Table<Service>()
                .Where(s => s.Title == title)
                .FirstOrDefaultAsync();
        }



        // ------------- CRUD APPOINTMENT ------------
        // returneaza toate records in Appointment
        public Task<List<Appointment>> GetAppointmentsAsync()
        {
            return _database.Table<Appointment>().ToListAsync();
        }

        // returneaza un record specific pe baza ID-ului
        public Task<Appointment> GetAppointmentAsync(int id)
        {
            return _database.Table<Appointment>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        // salveaza un record Appintment in baza de date, asincron
        public Task<int> SaveAppointmentAsync(Appointment appointment)
        {
            if (appointment.ID != 0)
            {
                return _database.UpdateAsync(appointment);
            }
            else
            {
                return _database.InsertAsync(appointment);
            }
        }

        // sterge un record
        public Task<int> DeleteAppointmentAsync(Appointment appointment)
        {
            return _database.DeleteAsync(appointment);
        }


        // --------------- CRUD REVIEW ----------------
        // returneaza toate record (lista) din Review
        public Task<List<Review>> GetReviewsAsync()
        {
            return _database.Table<Review>().ToListAsync();
        }

        // returneaza un record specific pe baza ID-ului
        public Task<Review> GetReviewAsync(int id)
        {
            return _database.Table<Review>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        // salveaza un record Review in baza de date, asincron
        public Task<int> SaveReviewAsync(Review review)
        {
            if (review.ID != 0)
            {
                return _database.UpdateAsync(review);
            }
            else
            {
                return _database.InsertAsync(review);
            }
        }

        // sterge un record
        public Task<int> DeleteReviewAsync(Review review)
        {
            return _database.DeleteAsync(review);
        }
    }
}
