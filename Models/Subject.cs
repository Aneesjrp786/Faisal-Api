using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace dotnet.Models
{
	public class Subject
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public long maxtime {get; set;}
		public int maxattempts {get; set;}
		public long UserId { get; set; }
        public virtual User User { get; set; }
	}
}