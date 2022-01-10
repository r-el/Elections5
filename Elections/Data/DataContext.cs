using Elections.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Data
{
    public class DataContext : DbContext
    {
        // ctor for dependency injection container
        public DataContext(DbContextOptions options) : base(options) {}

        // Creating tables in db
        public DbSet<Stam> Stam { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Models.Elections> Elections { get; set; }
        public DbSet<VoterPhoneInElections> VotersPhonesInElections { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<ProblemNotes> ProblemNotes { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<VotingArea> VotingAreas { get; set; }

    }
}
