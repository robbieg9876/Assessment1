package week7;

/**
 * @author robbie
 * Driver for the queue
 **/
public class QueueDriver {
	/**
	 * Demonstrates all the methods
	 * Outputs to the console
	 * @throws MyQueueException 
	 */
	public static void main(String[] args) throws MyQueueException {

		//Creates an instance of MyLinkedQueue
		MyQueue<String> s1 = new MyLinkedQueue<String>();
		System.out.println("Queue1- Linked Queue" );
		//Adds values to queue
		s1.queue("2");
		s1.queue("3");
		s1.queue("4");
		//Outputs first value in queue
		System.out.println("first in queue:"+s1.front());
		//Removes first item in queue
		System.out.println("Popped " + s1.dequeue());
		//Outputs the new first item in the queue
		System.out.println("first in queue:"+s1.front());
		//Removes first item in queue
		System.out.println("Popped " + s1.dequeue());
		//Outputs the new first item in the queue
		System.out.println("first in queue:"+s1.front());
		System.out.println("Popped " + s1.dequeue());
		System.out.println("Popped " + s1.dequeue());	
	}
}
