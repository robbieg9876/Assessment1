package SSD;
public class shapeDriver {
	  public static void main(String[] args ) {
		  Rectangle r1= new Rectangle();
		  r1.setHeight(10);
		  r1.setWidth(5);
		  Rectangle r2= new Rectangle();
		  r2.setHeight(7);
		  r2.setWidth(8);
		  circle c1 = new circle();
		  c1.setRadius(10);
		  circle c2 = new circle();
		  c2.setRadius(5);
		  ellipse e1= new ellipse();
		  e1.setPointA(5);
		  e1.setPointB(3);
		  ellipse e2= new ellipse();
		  e2.setPointA(9);
		  e2.setPointB(2);
		  System.out.println(r1.toString());
		  System.out.println(r2.toString());
		  System.out.println(c1.toString());
		  System.out.println(c2.toString());
		  System.out.println(e1.toString());
		  System.out.println(e2.toString());
	  }
	  }
