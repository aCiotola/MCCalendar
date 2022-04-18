using MCCalendar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace MCCalendar.Database
{
    public class CalendarContext : DbContext
    {
        public DbSet<Client> clients { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public string DbPath { get; }

        public CalendarContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            if (!Directory.Exists(System.IO.Path.Join(path, "MCCalendar")))
                Directory.CreateDirectory(System.IO.Path.Join(path, "MCCalendar"));

            DbPath = System.IO.Path.Join(path, "MCCalendar/MCCalendarDB.db");
            Database.EnsureCreated();
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
