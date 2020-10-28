package SSD;

public class ellipse extends Rectangle{
private double pointA;
private double pointB;

public double getPointA() {
	return pointA;
}

public void setPointA(double pointA) {
	this.pointA= pointA;
}

public double getPointB() {
	return pointB;
}

public void setPointB(double pointB) {
	this.pointB = pointB;
}

public double getArea() {
	return Math.PI*pointA*pointB;
}
public String toString() {
	return("This rectangle has a width of: "+getPointA()+", a height of: "+getPointB()+" and an area of: "+getArea());
}
}
