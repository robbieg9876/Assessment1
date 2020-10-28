package week8;

public interface MyStack<T> {

	/**
	 * Pushes an element onto the stack
	 * 
	 * @param element the element to be pushed onto the stack.
	 */
	void push(T element);
	
	/**
	 * Pops an element from the stack.
	 * 
	 * @return  the element popped from the stack
	 */
	T pop();
	
	/**
	 * Gets the element at the top of the stack, without removing it.
	 * 
	 * @return the element at the top of the stack
	 */
	T peek();
	
	/**
	 * Tests if the stack is empty.
	 * 
	 * @return true if the stack is empty
	 */
	boolean isEmpty();
	
}
