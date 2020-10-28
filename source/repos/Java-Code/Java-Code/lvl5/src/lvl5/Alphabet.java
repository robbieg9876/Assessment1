package lvl5;

	import java.util.Scanner;

	public class Alphabet {

		public static void main(String[] args) {
			
			// 1. Write the shortest possible program that outputs the numbers between 0 and 100 to the console. hint: use a loop.	
			int Min=0;
			int Max=101;
			while(Min<Max){
				System.out.println(Min);
				Min= Min+1;
				
			}
			// 2. Write the shortest possible program that outputs all the lower case letters of the alphabet to the console. hint: use a loop with a 'char' type variable.
			Scanner keyboard = new Scanner (System.in);
			
			char[] alphabet = "abcdefghijklmnopqrstuvwxyz".toCharArray();
			int index;
			
			for (index = 0; index < alphabet.length; index++)
			{
				System.out.println(alphabet[index]);
			} 
			
			keyboard.close();
			
			
			// 3. Write the shortest possible program that outputs all the upper case letters of the alphabet, in reverse order, to the console. 
			char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".toCharArray();
			
			for (index = Alphabet.length-1; index>=0; index--)
			{
				System.out.println(Alphabet[index]);
			} 
			
			keyboard.close();
		}

	}
