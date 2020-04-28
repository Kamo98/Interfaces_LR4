using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	[Serializable]
	public class Product
	{
		private string name;
		private string code;
		private int number;
		public string Name { get => name; set => name = value; }
		public string Code { get => code; set => code = value; }
		public int Number { get => number; set => number = value; }

		public Product() { }

		public Product(string n, string c, int num)
		{
			name = n;
			code = c;
			number = num;
		}

		public override string ToString()
		{
			//return number + ". " + name + " (" + code + ")";
			return name + " (" + code + ")";
		}

	}
}
