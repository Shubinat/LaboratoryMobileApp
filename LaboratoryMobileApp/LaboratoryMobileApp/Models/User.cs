using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratoryMobileApp.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }
        public DateTime BirthDate { get; set; }
        public string PolicyNumber { get; set; }
        public string PassportNumber { get; set; }
        public string PassportSeria { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Age => (DateTime.Now - BirthDate).Days / 365;
        public string FullName => $"{Surname} {Name}" + (!string.IsNullOrWhiteSpace(Patronimyc) ? " " + Patronimyc : "");

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public User(string login, 
            string password, 
            string name, 
            string surname, 
            string patronimyc,
            DateTime birthDate,
            string policyNumber, 
            string passportNumber, 
            string passportSeria, 
            string phoneNumber, 
            string email)
        {
            Login = login;
            Password = password;
            Name = name;
            Surname = surname;
            Patronimyc = patronimyc;
            BirthDate = birthDate;
            PolicyNumber = policyNumber;
            PassportNumber = passportNumber;
            PassportSeria = passportSeria;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public User() { }
    }
}
