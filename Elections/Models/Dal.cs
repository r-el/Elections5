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
            Candidate candidate = new Candidate
            {
                FullName = "Simple Candidate"
            };
            VotingArea votingArea = new VotingArea
            {
                Name = "Jerusalem"
            };
            Voter voter = new Voter
            {
                PhoneID = "0512345678",
                FullName = "Ariel Tanami",
                Mail = "rel@mail.com",
                Password = "rel12345"
            };
            Voter voter2 = new Voter
            {
                PhoneID = "0501234567",
                FullName = "Ariel Tanami",
                Mail = "rel@mail.com",
                Password = "rel12345"
            };
            VoterPhoneInElections voterPhoneInElections1 = new VoterPhoneInElections
            {
                Voter = voter,
                Elections = elections,
                Candidate = candidate,
                VotingArea = votingArea
            };
            VoterPhoneInElections voterPhoneInElections2 = new VoterPhoneInElections
            {
                Voter = voter2,
                Elections = elections,
                Candidate = candidate,

            };
            Problem problem = new Problem
            {
                Description = "Simple Problem",
                VoterPhoneInElections = voterPhoneInElections1
            };
            ProblemNotes problemNote = new ProblemNotes
            {
                Content = "Simple Problem Note",
                Problem = problem,
                VisitorPhoneID = "0587979345"
            };

            Stam.Add(stam);
            Managers.Add(manager);
            Elections.Add(elections);
            VotersPhonesInElections.Add(voterPhoneInElections1);
            VotersPhonesInElections.Add(voterPhoneInElections2);
            Voters.Add(voter);
            Problems.Add(problem);
            ProblemNotes.Add(problemNote);
            Candidates.Add(candidate);
            VotingAreas.Add(votingArea);

            SaveChanges();
        }
        //---------------------------------------- End Data Seeding ------------------------------//


        //---------------------------------------- Creating Tables -----------------------------//
        public DbSet<Stam> Stam { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Elections> Elections { get; set; }
        public DbSet<VoterPhoneInElections> VotersPhonesInElections { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<ProblemNotes> ProblemNotes { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<VotingArea> VotingAreas { get; set; }
        //---------------------------------------- End Creating Tables -------------------------//
    }
}