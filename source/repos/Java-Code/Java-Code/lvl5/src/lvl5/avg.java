package lvl5;
import java.util.Scanner;
public class avg {
	public static void main(String[] args) {
		Scanner scan1 = new Scanner (System.in);
		String number="0";
		int total=0;
		int count=0;
		double average=0;
		while (number.equals("")== false)
		{
			System.out.print("Enter a number");
			number = scan1.nextLine();
			try {
				int Number= Integer.parseInt(number);
				total=total+Number;	
				count=count+1;
			}
			catch (NumberFormatException e)
			{		
				System.out.println("Error cannot convert");

			}	

		} 
		/* System.out.println(total); */
		average=total/count;
		/* System.out.println(count); */
	    average = (double)total / count;
		System.out.println(average);
		scan1.close();
	}
}
