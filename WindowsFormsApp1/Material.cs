using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	[Serializable]
	public class Material
	{
		private string name;
		private string code;

		public string Name { get => name; set => name = value; }
		public string Code { get => code; set => code = value; }

		public Material() { }

		public Material (string n, string c)
		{
			name = n;
			code = c;
		}
		public override string ToString()
		{
			return name + " (" + code + ")";
		}

	}
}
