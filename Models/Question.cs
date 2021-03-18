
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dotnet.Models
{
	public class Question
	{
		public long Id { get; set; }
		public string Description { get; set; }
		public string Option1 { get; set; }
		public string Option2 { get; set; }
		public string Option3 { get; set; }
		public string Option4 { get; set; }
		public string Answer { get; set; }
		public long SubjectId { get; set; }
        public virtual Subject subject { get; set; }		
	}
}