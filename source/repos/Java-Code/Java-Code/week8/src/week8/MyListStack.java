package week8;

import java.util.ArrayList;
/**
 * @author robbi
 * @param <T>
 * Code demonstrates the use of a stack using a arrayList
 */
public class MyListStack<T> implements MyStack<T> {
	/**
	 * Creates an instance of ArrayList<T>
	 */
	public ArrayList<T> elements = new ArrayList<T>();
	/**
	 * Adds item to the top of the stack
	 */
	@Override
	public void push(T element) {
		// TODO Auto-generated method stub
		elements.add(element);
	}
	/**
	 * Removes item from top off stack
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
	 * Returns the value of the item at the top of the stack
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
	 * Checks if the stack is empty 
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
