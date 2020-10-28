package SSD;

public class circle extends lab1{
	circle() {
		super(1);
		// TODO Auto-generated constructor stub
	}
	private double radius;
	

	
	public double getradius() {
		return radius;
	}
	
	public void setRadius(double radius) {
		this.radius=radius;
	}
	@Override
	public double getArea() {
		return Math.PI*radius*radius;
	}
	public String toString() {
		return("This circle has radius of: "+getradius()+ "and an area of: "+getArea());
	}
}
