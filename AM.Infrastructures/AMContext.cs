
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructures
{
    public class AMContext:DbContext // classe generique de config de la base 
    {

        //Quelles sont les entites => tables ; declaration des dbsets*

        public DbSet<Flight> Flights { get; set; }  
        public DbSet<Plane> Planes { get; set; }  
        public DbSet<Traveller> Travellers { get; set; }  
        public DbSet<Passenger> Passengers { get; set; }  
        public DbSet<Staff> Staffs { get; set; }


        // chaine de cnx 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=Airport;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        //4 lancement des commandes 
        /*
         * add-migration Nom_mig => enregistrer l'etat actuel du code  
         * 
         */
    }

}
