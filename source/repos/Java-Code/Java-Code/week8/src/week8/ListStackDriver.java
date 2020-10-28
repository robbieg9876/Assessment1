package week8;
/**
 * @author robbie
 *Code demonstrates the use of:
 *a stack using a list structure,
 *a queue using a list structure,
 *a stack-queue using a list structure. 
 */

public class ListStackDriver {
	/**
	 * 
	 * @param args
	 * Shows all the methods and outputs to console
	 */
	public static void main(String[] args) {
		//Creates instances of 'MyListStack
		MyStack<String> s1 = new MyListStack<String>();
		MyQueue<String> s2 = new MyListQueue<String>();
		MyStackQueue<String> s3 = new MyStackQueue<String>();

		System.out.println("Stack 1 - arrayList stack" );

		//Adds items to the stack
		s1.push("1");
		s1.push("2");
		s1.push("3");
		s1.push("999");

		while ( !s1.isEmpty() ) {
			//Removes items from the stack and outputs to console
			System.out.println("Popped " + s1.pop());

		}

		System.out.println("\nQueue 1 - LinkedList queue" );

		//Adds items to the back of the queue
		s2.queue("1");
		s2.queue("2");
		s2.queue("3");
		s2.queue("99");

		while ( !s2.isEmpty() ) {
			//Removes items from the front of the queue and outputs to console
			System.out.println("Dequeued " + s2.dequeue());

		}






		System.out.println("\nStackQueue" );
		//Adds items to the stack-queue
		s3.push("1");
		s3.push("2");
		s3.queue("3");
		s3.queue("99");



		while ( !s3.isEmpty() ) {
			//Item removed from back of the queue
			System.out.println("Popped " + s3.pop());
			//Item removed from front of the queue
			System.out.println("Dequeued " + s3.dequeue());

		}
	}
}
