package SSD;
public class Rectangle extends lab1 {
	Rectangle() {
		super(4);
		// TODO Auto-generated constructor stub
	}
	private double width;
	private double height;
	

	
	public double getWidth() {
		return width;
	}
	
	public double getHeight() {
		return height;
	}
	
	
	public void setWidth(double width) {
		this.width=width;
	}
	
	public void setHeight(double height) {
		this.height=height;
	}
	@Override
	public double getArea() {
		return width * height;
	}
	public String toString() {
		return("This rectangle has a width of: "+getWidth()+", a height of: "+getHeight()+" and an area of: "+getArea());
	}

}
