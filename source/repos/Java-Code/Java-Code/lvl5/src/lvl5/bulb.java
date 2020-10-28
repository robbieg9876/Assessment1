package lvl5;
import java.util.Scanner;
public class bulb {
	private boolean light;
	
	public bulb(boolean light){
		this.setLight(light);
	}
	
	public boolean getLight() {
		return light;
	}
	
	public void setLight(boolean light) {
		this.light = light;
	}
	
	public static class Lights{
		public static void main(String[] args ) {
			String inputs="a";
			bulb s1= new bulb(true);
			  Scanner keyboard = new Scanner (System.in);
			while (inputs.equals("a")){
				System.out.print("press a to switch lights or press enter to exit ");
				  inputs = keyboard.next();
				  if (s1.getLight()==true) {
					  System.out.println("ON");
					  s1.setLight(false);
				  }
				  else if(s1.getLight()==false) {
					  System.out.println("OFF");
					  s1.setLight(true);
				  }
			}
			  keyboard.close();
		  }
}
}
