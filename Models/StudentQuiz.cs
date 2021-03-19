using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dotnet.Models
{

    public class StudentQuiz
    {
        public long Id { get; set; }
        public string duration {get; set;}
        public string marks {get; set;}
        public long StudentId { get; set; }
        public virtual Student student { get; set; }
        public long SubjectId { get; set; }
        public virtual Subject subject { get; set; }
    }
}