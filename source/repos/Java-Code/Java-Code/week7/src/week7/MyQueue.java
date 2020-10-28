package week7;
/**
 * @author robbie
 * @param <T>
 * Defines methods to be used
 */
public interface MyQueue<T> {
	/**
	 * Adds item to the back of the queue
	 * @param element the item to added to the queue.
	 */
	void queue(T element);
	/**
	 * Removes item from the back of the queue
	 * @return the item removed
	 * @throws MyQueueException 
	 */
	T dequeue() throws MyQueueException  ;
	/**
	 * Returns the item at the front of the queue
	 * @return front item
	 */
	T front() throws MyQueueException;
	/**
	 * Checks if the queue is empty
	 * @return true or false
	 */
	boolean isEmpty();
}
