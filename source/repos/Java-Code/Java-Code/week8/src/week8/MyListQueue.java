package week8;

import java.util.LinkedList;
/**
 * @author robbi
 * @param <T>
 * Code demonstrates the use of queues using a linked list
 */
public class MyListQueue<T> implements MyQueue<T> {
	/**
	 * Creates an instance of 'LinkedList'
	 */
	public LinkedList<T> elements = new LinkedList<T>();

	/**
	 * Adds item to the back of the queue
	 */
	@Override
	public void queue(T element) {
		// TODO Auto-generated method stub
		elements.addLast(element);
	}
	/**
	 * Removes first item in the queue
	 * or returns null if the queue is empty
	 */
	@Override
	public T dequeue() {
		// TODO Auto-generated method stub
		if (elements.isEmpty()) {
			return null;
		}
		else {
			return elements.removeFirst();

		}
	}
	/**
	 * Returns the first item in the queue
	 * or returns null if the queue is empty
	 */
	@Override
	public T front() {
		// TODO Auto-generated method stub
		if (elements.isEmpty()) {
			return null;
		}
		else {
			return elements.getFirst();
		}
	}
	/**
	 * Checks if the queue is empty
	 * and returns true or false
	 */
	@Override
	public boolean isEmpty() {
		// TODO Auto-generated method stub
		if (elements.isEmpty()) {
			return true;
		}
		else {
			return false;
		}
	}

}
