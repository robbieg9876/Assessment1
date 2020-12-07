using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Creates an inteface with the methods needed for the shape class
/// </summary>
public interface Shapes
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="C"></param>
	/// <param name="list"></param>
	void set(Color C, params int[] list);

	/// <summary>
	/// 
	/// </summary>
	/// <param name="g"></param>
	void draw(Graphics g);
	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	double calcArea();

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	double calcPerimeter();
}

abstract class Shape:Shapes
	{
		protected Color colour;
		protected int x, y;
	/// <summary>
	/// Initialises the pen colour and the drawing position
	/// </summary>
		public Shape()
		{
			colour = Color.Red;
			x = y = 100;
		}

		/// <summary>
		/// Gets the parameters for pen colour and drawing postion and then assigns the values to the local variables
		/// </summary>
		/// <param name="colour"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Shape(Color colour, int x, int y)
		{
			this.colour = colour;
			this.x = x;
			this.y = y;
		}

	/// <summary>
	/// Initialises method to draw shapes
	/// </summary>
	/// <param name="g"></param>
	/// 
		public abstract void draw(Graphics g);
	
	/// <summary>
	/// Initialises method to draw a filled shape
	/// </summary>
	/// <param name="g"></param>
		public abstract void fill(Graphics g);

	/// <summary>
	/// Initialise a method to calculate the area of the shape
	/// </summary>
	/// <returns></returns>
	public abstract double calcArea();
	
	/// <summary>
	/// Initialise a method to calculate the area of the shape
	/// </summary>
	/// <returns></returns>
	public abstract double calcPerimeter();

	/// <summary>
	/// Sets the colour and the int values from the parameters passed
	/// </summary>
	/// <param name="colour"></param>
	/// <param name="list"></param>
	public virtual void set(Color colour, params int[] list)
	{
		this.colour = colour;
		this.x = list[0];
		this.y = list[1];
	}
	/// <summary>
	/// Returns the string for the shape being drawn
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		return base.ToString() + "    " + this.x + "," + this.y + " : ";
	}

	}