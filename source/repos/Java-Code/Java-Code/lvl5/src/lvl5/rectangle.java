package lvl5;

import java.util.Scanner;
public class rectangle {
	  int width;
	  int height;
	  Scanner keyboard = new Scanner (System.in);
	  //Constructor
	  rectangle() {
		  System.out.print("Enter a width: ");
		  width = keyboard.nextInt();
		  System.out.print("Enter a height: ");
		  height = keyboard.nextInt();
	  }
	  //Constructor
	  int area() {
	    return width * height;
	  }
	  //Constructor
	  int perimeter() {
		  return width * 2 + height * 2;
	}
	  public static void main(String args[]) {
	  rectangle rectangle1 = new rectangle();
	  int area;
	  int perimeter;
	  area=rectangle1.area();
	  perimeter=rectangle1.perimeter();
	  System.out.println(area);
	  System.out.println(perimeter);
	  

		// 1. Add a constructor to the class that allows the width and height to be setup
		// 2. Add the missing code to the methods so that they work correctly.
		// 3. Create several instances of the Rectangle class and call the methods to test the code is working. hint: output info about each.
		// 3. Add comments and 'private'/'public' modifiers where appropriate.
		
	}
}
