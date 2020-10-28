package week9;

import java.util.Arrays;

/**
 * @author robbie
 *Code demonstrates use of a set
 */
public class setDriver {
	/**
	 * @param args
	 * Uses the methods to edit the set
	 */
	public static void main(String[] args) {

		/**
		 * Creates instance of mySet<String>
		 */
		MySet<String> s1 = new MySet<String>();



		System.out.println("Set 1:" );
		//Adds values to the set
		s1.add("2");
		s1.add("3");
		s1.add("3");
		//Checks if the set contains element 3 and outputs to console
		System.out.println("Does list have value '3' in it - "+s1.contains("3"));
		//Outputs the size of the set to console
		System.out.println("The amount of items in the set are "+s1.size());
		//Removes element from the set
		System.out.println("Remove 2 "+s1.remove("2"));
		System.out.println("The amount of items in the set are "+s1.size());
		//Removes all items and outputs to console
		System.out.println("Remove all items "+s1.removeAll(s1));
		System.out.println("The amount of items in the set are "+s1.size());
		s1.add("2");
		s1.add("3");
		s1.add("3");
		System.out.println("The amount of items in the set are "+s1.size());
		//Retains all items in the collection and outputs to console
		System.out.println("Retain all items");
		s1.retainAll(s1);
		System.out.println("The amount of items in the set are "+s1.size());
		//Converts list to array format and outputs to console
		System.out.println("In array format "+Arrays.toString(s1.toArray()));
		System.out.println("Clear set");
		s1.clear();
		System.out.println("The amount of items in the set are "+s1.size());
		/**
		 * Creates new instance of WordCounter
		 */
		WordCounter wc = new WordCounter();
		//Adds sentence to the set 'wc'
		wc.addSentence("This sentence has the word has in it twice");
		System.out.println("\nWord count\n");
		//Outputs the results of the word count to console
		wc.outputResults();


	}

}
