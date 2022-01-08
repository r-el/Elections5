using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class Dal : DbContext
    {
        //---------------------------------------- Ctor ----------------------------------------//
        private Dal() : base("data source=localhost\\SQLEXPRESS;"
                                + " initial catalog = ElectionsMVC;"
                                + " user id = sa; password = 1234;")
        {
            // Delete and Recreate the DB if Model Change
            Database.SetInitializer<Dal>(new DropCreateDatabaseIfModelChanges<Dal>());

            // Seed Stam data
            if (Stam.Count() == 0) Seed();
        }
        //---------------------------------------- End Ctor ------------------------------------//


        //---------------------------------------- Get DB --------------------------------------//
        private static Dal Data;
        public static Dal Get{
            get
            {
                if (Data == null) Data = new Dal();

                return Data;
            }
        }
        //---------------------------------------- End Get DB ----------------------------------//


        //---------------------------------------- Data Seeding ----------------------------------//
        private void Seed()
        {
            Stam stam = new Stam
            {
                StamString = "Stam String",
                StamInt = 0
            };
            Manager manager = new Manager
            {
               FullName = "Ariel Tanami",
               Mail = "rel@mail.com",
               Phone = "0587979345",
               Password = "rel12345",
            };
            Elections elections = new Elections
            {
                Name = "בחירות 2022",
                EndDate = DateTime.Now.AddDays(30),
                Manager = manager
            };
            VoterPhoneInElections voterPhoneInElections1 = new VoterPhoneInElections
            {
                Phone = "0501234567",
                Elections = elections
            };
            VoterPhoneInElections voterPhoneInElections2 = new VoterPhoneInElections
            {
                Phone = "0512345678",
                Elections = elections
            };
            Voter voter = new Voter
            {
                PhoneID = "0587979345",
                FullName = "Ariel Tanami",
                Mail = "rel@mail.com",
                Password = "rel12345"
            };

            Stam.Add(stam);
            Managers.Add(manager);
            Elections.Add(elections);
            VotersPhonesInElections.Add(voterPhoneInElections1);
            VotersPhonesInElections.Add(voterPhoneInElections2);
            Voters.Add(voter);

            SaveChanges();
        }
        //---------------------------------------- End Data Seeding ------------------------------//


        //---------------------------------------- Creating Tables -----------------------------//
        public DbSet<Stam> Stam { get; set; }
        public DbSet<Elections> Elections { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<VoterPhoneInElections> VotersPhonesInElections { get; set; }
        //---------------------------------------- End Creating Tables -------------------------//
    }
}