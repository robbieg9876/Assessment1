package SSD;

public class Menu {
	public void displayMenuOption(int opt) throws InvalidOptionException{
	if(opt<1 || opt>3) {
		throw  new InvalidOptionException();
	}
	System.out.println("Menu option "+ opt +" selected");
	}
}
