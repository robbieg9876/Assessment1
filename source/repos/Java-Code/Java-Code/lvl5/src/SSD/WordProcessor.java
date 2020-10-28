package SSD;

public class WordProcessor implements lab2 {	
private String text = "";
String getText() {
	
	return text;
}
void setText(String text) {
	
	this.text = text;
}
public int countWords(String sentence) {
	if ( sentence == null )	// use 'text' if null sentence given.
		sentence = text;
	int words=0;
	String[] splitText = sentence.split(" ");//splits the sentence into individual words
	words=splitText.length; //gets the amount values in the array
	return words;
}
@Override
public int countLetters(String sentence) {
	int letters=0;
	if ( sentence == null )	// use 'text' if null sentence given.
		sentence = text;
	for (int i=0;i<sentence.length();i++) {
		if(Character.isLetter(sentence.charAt(i))) {//checks if the char is a letter and adds to letters if it is
			letters++;
		}
	}
	return letters;
}
@Override
public int getLength(String sentence) {
	int length=0;
	if ( sentence == null )	// use 'text' if null sentence given.
		sentence = text;
	length=sentence.length(); //gets the amount of chars in the sentence
	return length;
}
}
