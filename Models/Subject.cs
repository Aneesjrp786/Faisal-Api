using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace dotnet.Models
{
	public class Subject
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public TypeOfQuiz Type {get ; set;} 
		public long duration {get; set;}
		public int num_of_attemps {get; set;}
		public long TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
	}
	   public enum TypeOfQuiz
    {
        Survey,
        Quiz,
		Questionnaire,
    }

}