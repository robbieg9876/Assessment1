package week7;
/**
 * @author robbi
 *Exception class
 */
public class MyQueueException extends Exception {

	/**
	 * Throws exception if dequeue() is attempted when the queue is empty
	 */
	private static final long serialVersionUID = 1L;

	public MyQueueException(String string) {
		System.out.println("ERROR - No items in the queue:");
	}

}
