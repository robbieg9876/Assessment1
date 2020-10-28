package week9;

import java.util.HashMap;
import java.util.Map;
/**
 * @author robbi
 * Code demonstrates use of a map to create a word counter
 */
public class WordCounter {
	/**
	 * Creates new HashMap
	 */
	 private final Map<String,Integer> wordMap = new HashMap<String, Integer>();
	 /**
	  * adds @param word to the map if it isn't already in it
	  * adds 1 to the count for that word
	  */
	 void addWord(String word) {
		 if(wordMap.containsKey(word)) {
			//Seen this word before 
			int count = wordMap.get(word);
			count++;
			wordMap.put(word, count);
		 }
		 else {
			 //Not seen this word before
			 wordMap.put(word, 1);
		 }
	 }
	 /**
	  * Splits @param sentence into words and then calls addWord() for each word
	  */
	 void addSentence(String sentence) {
		 String[] splitText;
		 splitText = sentence.split(" ");
		 for (int Index = 0; splitText.length > Index; Index++) {
			 addWord(splitText[Index]);
		 }
	 }
	 /**
	  * Outputs the words in the wordMap and the count for each word 
	  */
	 public void outputResults() {
		 for (String key : wordMap.keySet()) {
			 int count=wordMap.get(key);
			 System.out.println(key+" "+count);
			 
		 }
	 }
}
