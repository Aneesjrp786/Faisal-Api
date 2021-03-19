
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dotnet.Models
{

    public class Teacher
    {
        public long Id { get; set; }
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string UserName{get; set;}
        public string Email {get; set;}
        public string Password {get; set;}

    }

}