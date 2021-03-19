
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dotnet.Models
{
	public class Mcqs
	{
		public long Id { get; set; }
		public string Question { get; set; }
		public string Option1 { get; set; }
		public string Option2 { get; set; }
		public string Option3 { get; set; }
		public string Option4 { get; set; }
		public string Correct_Answer { get; set; }
		public string Score{ get; set; }
		public TypeOfBtn Type {get ; set;} 
		public long SubjectId { get; set; }
        public virtual Subject subject { get; set; }		
	}
	   public enum TypeOfBtn
    {
        RadioButton,
        TextBox,
		CheckBox,
		DropDown

    }

}