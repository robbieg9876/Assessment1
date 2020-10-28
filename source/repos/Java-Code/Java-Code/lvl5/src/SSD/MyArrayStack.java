package SSD;


public class MyArrayStack<T> implements MyStack<T> {

	/**
	 * Underlying array which stores the elements of the stack.
	 */
	@SuppressWarnings("unchecked")
	private T [] elements = (T[]) new Object[100];
	
	/**
	 * The number of elements currently on the stack.
	 */
	private int count = 0;
	
	
	@Override
	public void push(T element) {
		// could check whether array was full, then realocate to larger array.
		elements[count++] = element;
	}

	@Override
	public T pop() {
		
		if ( count > 0 )	 {
			T result = elements[--count];

			// allow memory to be freed.
			elements[count] = null;

			return result;
		}
		
		return null;
	}

	@Override
	public T peek() {
		
		if ( count > 0 )
			return elements[count-1];
		
		return null;
	}

	@Override
	public boolean isEmpty() {

		return (count == 0);
	}

}
