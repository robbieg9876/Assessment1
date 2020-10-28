package lvl5;


public class Sphere {
	private double diameter;
	public Sphere(double Diameter){
		this.diameter= Diameter;
	}
	 public double getDiameter() {
		return diameter;
	}
	public void setDiameter(double Diameter) {
			this.diameter=Diameter;
	}
	public double volume() {
		double radius=diameter/2;
		return 4/3.0*Math.PI*(radius)*(radius)*(radius);
	}
	public double surfaceArea() {
		double radius=diameter/2;
		return 4*Math.PI*(radius)*(radius);
	}
	public String toString() {
		return("A sphere is a 3d shape with a diameter of: "+diameter+"With a volume of: "+volume());
	}
	public static class MultiSphere{
	  public static void main(String[] args ) {
		  Sphere s1= new Sphere(10);
		  System.out.println(s1.getDiameter());
		  
	  }
}
}

