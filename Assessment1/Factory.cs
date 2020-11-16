using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Assessment1;

namespace Assessment1
{

	 class Factory
	{
		/// <summary>
		/// Takes in a string parameter and checks which shape it is
		/// Then returns the correct shapes class
		/// </summary>
		/// <param name="shapeName"></param>
		/// <returns></returns>
		public Shape getShape(String shapeName)
		{
			shapeName=shapeName.ToUpper().Trim();

			if (shapeName.Equals("CIRCLE"))
			{
				return new Circle();
			}
			else if (shapeName.Equals("RECTANGLE"))
			{
				return new Rectangle();
			}
			else if (shapeName.Equals("SQUARE"))
			{
				return new Square();
			}
			else if (shapeName.Equals("TRIANGLE"))
			{
				return new Triangle();
			}
			else if (shapeName.Equals("ARC"))
			{
				return new Arc();
			}
			else if (shapeName.Equals("HEXAGON"))
			{
				return new Hexagon();
			}
			else
			{
				System.ArgumentException argEx = new System.ArgumentException("ERROR FACTORY CLASS FAILURE");
				throw argEx;

			}
		}
	}
}

