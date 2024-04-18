using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Islamic_Dreams
{
	public class DropDown
	{
		public string Text{get;set;}
		public int Value { get; set; }
	}

	public class DreamsByBook
	{
		public string Book { get; set; }
		public List<DropDown> Dreams { get; set; }

		
	}
	public class DreamsByAuthor
	{
		public string Author{ get; set; }
		public List<DropDown> Dreams { get; set; }


	}
}