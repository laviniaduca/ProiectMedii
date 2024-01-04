using System;
using ProiectMedii.Data;
using System.IO;

namespace ProiectMedii;

public partial class App : Application
{
    static MakeupDatabase database;
    public static MakeupDatabase Database
    {
        get
        {
            if (database == null)
            {
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Makeup.db3");
                Console.WriteLine($"Database path: {dbPath}");

                database = new MakeupDatabase(dbPath);
                Console.WriteLine("Database initialized.");
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
