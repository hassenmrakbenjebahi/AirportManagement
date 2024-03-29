﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        // public int Id { get; set; }
        [Key]
        [StringLength(7)]

        public string PassportNumber { get; set; }
        [MinLength(3),MaxLength(10,ErrorMessage ="invalid first name")]
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Date f Birth")]
        public DateTime BirthDate { get; set; }
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        public int? TelNumber { get; set; }
        //[DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? EmailAddress { get; set; }

        public  IList<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "FirstName: " + FirstName + " LastName: " + LastName + " date of Birth: " + BirthDate;
        }
        //Le polymorphisme par signature

        //1-

        public bool CheckProfile(string firstName, string lastName)
        {
            return FirstName == firstName && LastName == lastName;
        }

        //2-

        public bool CheckProfile(string firstName, string lastName, string email)
        {
            return FirstName == firstName && LastName == lastName && EmailAddress == email;
        }

        // 3- 
        public bool login(string firstName, string lastName, string email = null)
        {
            if (email != null)
                return FirstName == firstName && LastName == lastName && EmailAddress == email;

                return CheckProfile(firstName, lastName);   
        }
        // Polymorphisme par héritge
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passenger");
        }
    }
}
