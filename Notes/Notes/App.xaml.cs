using System;
using System.IO;
using Notes.Data;
using Xamarin.Forms;

namespace Notes
{
    public partial class App : Application
    {
        /*
         * This code defines a Database property that creates a new
         * NoteDatabase instance as a singleton, passing in the
         * filename of the database as the argument to the
         * NoteDatabase constructor. The advantage of exposing the
         * database as a singleton is that a single database
         * connection is created that's kept open while the
         * application runs, therefore avoiding the expense of
         * opening and closing the database file each time a
         * database operation is performed.
         * 
         */
        static NoteDatabase database;

        // Create the database connection as a singleton.
        public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}