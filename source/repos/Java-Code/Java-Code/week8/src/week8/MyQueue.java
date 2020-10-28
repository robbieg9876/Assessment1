package week8;
/**
 * @author robbi
 * @param <T>
 * Creates methods to demostrate a queue using a linkedList
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
	 */
	T dequeue();
	/**
	 * Returns the item at the front of the queue
	 * @return front item
	 */
	T front();
	/**
	 * Checks if the queue is empty
	 * @return true or false
	 */
	boolean isEmpty();
}
