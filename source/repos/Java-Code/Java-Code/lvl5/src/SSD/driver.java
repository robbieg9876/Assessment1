package SSD;

import java.util.Scanner;

public class driver {
	public static void main(String[] args ) {
	WordProcessor wp = new WordProcessor();// creates a new instance
	String sentence;// Initializes sentence
	Scanner scan = new Scanner (System.in);
	System.out.println ("Enter a sentence");
    sentence = scan.nextLine();// User inputs a sentence
    scan.close();//closes scanner
    wp.setText(sentence); //the sentence is used in the word processor class
    System.out.println("words= "+wp.countWords(null));//outputs the number of words
    System.out.println("letters= "+wp.countLetters(null)); //outputs the number of letters
    System.out.println("length= "+wp.getLength(null)); //outputs the number of length
    
}
}
