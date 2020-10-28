package SSD;

public class MyLinkedStack<T> implements MyStack<T>{
	/**
	 * The linked element at the top of the stack.
	 */
	private LinkElement<T> top;
		
	
	@Override
	public void push(T element) {
		
		// create a new LinkElement to wrap the stacked element, and point at previous top element.
		top = new LinkElement<T>(element, top);
	}

	@Override
	public T pop() {
		
		if ( top != null )	{
			// Gets the current element from the top of the stack.
			T element = top.getElement();
			
			// pop the link element from the stack, by pointing top to the prev element.
			top = top.getPrevLinkElement();
			
			return element;
		}
		
		return null;
	}

	@Override
	public T peek() {
		
		if ( top != null )	
			return top.getElement();
		
		return null;
	}

	@Override
	public boolean isEmpty() {

		return (top == null);
	}

}
