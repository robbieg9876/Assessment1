package SSD;

public class ArrayDriver {
	public static void main(String[] args) throws InvalidOptionException {
	ArrayProcessor ap = new ArrayProcessor();// creates a new instance
	int len = ap.getArrayLength(new String[] {"one","two","three"});
	System.out.println("array length is " +len);
	
	Menu me = new Menu();
	try {
		me.displayMenuOption(3);
		me.displayMenuOption(0);
	}
	catch(InvalidOptionException e){
		System.out.println(e.getMessage());
	}
	}
}