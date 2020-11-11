using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface Shapes
{
	void set(Color C, params int[] list);
	void draw(Graphics g);
	double calcArea();
	double calcPerimeter();
}

abstract class Shape:Shapes
	{
		protected Color colour;
		protected int x, y;
		public Shape()
		{
			colour = Color.Red;
			x = y = 100;
		}
		
		public Shape(Color colour, int x, int y)
		{
			this.colour = colour;
			this.x = x;
			this.y = y;
		}
		public abstract void draw(Graphics g);
		public abstract void fill(Graphics g);
	public abstract double calcArea();
		public abstract double calcPerimeter();

		public virtual void set(Color colour, params int[] list)
		{
		this.colour = colour;
		this.x = list[0];
		this.y = list[1];
		}
		public override string ToString()
		{
		return base.ToString() + "    " + this.x + "," + this.y + " : ";
		}

	}