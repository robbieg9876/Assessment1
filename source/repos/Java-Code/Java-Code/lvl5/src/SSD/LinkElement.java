package SSD;

public class LinkElement<T> {
	/**
	 * The stored element.
	 */
	private final T theElement;
	
	/**
	 * The previous link element in the linked stack, can be null if no previous link element exists.
	 */
	private final LinkElement<T> prevElement;

	/**
	 * Gets the stored element.
	 * 
	 * @return the stored element.
	 */
	public T getElement() {
		
		return theElement;
	}
	
	/**
	 * Gets the previous link element in the linked stack, can be null if no previous element exists.
	 * @return the previous link element in the linked stack
	 */
	LinkElement<T> getPrevLinkElement() {
	
		return prevElement;
	}
	
	/**
	 * 
	 * @param theElement the stored element.
	 * @param prevElement  the previous element in the linked stack.
	 */
	LinkElement(T theElement, LinkElement<T> prevElement) {
		
		this.theElement = theElement;
		this.prevElement = prevElement;
	}
}

