package week8;

import java.util.LinkedList;
/**
 * @author robbi
 * @param <T>
 * Code demonstrates a stack-queue using a linked list
 */
public class MyStackQueue<T> implements MyStack<T>,MyQueue<T>{
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
	 * Adds item to the top of the stack/back of queue
	 */
	public void push(T element) {
		// TODO Auto-generated method stub
		elements.add(element);
	}
	/**
	 * Removes item from top off stack/back of queue
	 * or returns null if the stack is empty
	 */
	@Override
	public T pop() {
		// TODO Auto-generated method stub
		if (elements.isEmpty()) {
			return null;
		}
		else {
		int length=elements.size();
		return elements.remove(length-1);
		
		}
		
	}
	/**
	 * Returns the value of the item at the top of the stack/ back of the queue
	 * or returns null if the stack is empty
	 */
	@Override
	public T peek() {
		// TODO Auto-generated method stub
		if (elements.isEmpty()) {
			return null;
		}
		else {
		 int length=elements.size();
		 return elements.get(length-1);
		}
		
	}
	/**
	 * Checks if the stack-queue is empty
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
