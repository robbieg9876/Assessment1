package week7;
/**
 * @author robbie
 * @param <T>
 * Code shows how a queue structure works
 */
public class MyLinkedQueue<T> implements MyQueue<T>{
	// The linked element at the head of the queue (first element to join)
	private LinkElement<T> head;
	// The linked element at the end of the queue (last element to join)
	private LinkElement<T> last;
	/**
	 * An item is added to the back of the queue
	 * This item becomes 'last'
	 */
	public void queue(T element) {
		LinkElement<T> linkElement = new LinkElement<T>();
		linkElement.theElement=element;
		if(last!=null) {
			last.prevElement=linkElement;
			last=linkElement;
		}
		if (head==null) {
			head=linkElement;
			last=linkElement;
		}
	}
	/**
	 * The item at the front of the queue is removed
	 * The next item in the queue becomes the 'head'
	 * @throws MyQueueException 
	 */
	public T dequeue() throws MyQueueException {
		LinkElement<T> linkElement = new LinkElement<T>();
		if (isEmpty()) {
			throw new MyQueueException("ERROR - No items in the queue:");
		}
		T element =head.theElement;
		// pop the link element from the stack, by pointing top to the prev element.
		linkElement= head.prevElement;
		head=linkElement;
		if(last==null) {
			last=linkElement;
		}
		return element;
	}
	/**
	 * Returns the value of the first item in the queue
	 * Or returns null if there is no items in the queue
	 */
	public T front() throws MyQueueException  {
		if (head != null) {
			return head.theElement;
		}
		else {
			throw new MyQueueException("ERROR - No items in the queue:");
		}
	}
	/**
	 * Checks if the queue is empty
	 * Returns true or false
	 */
	public boolean isEmpty() {
		if (head==null) {
			return true;
		}
		else {
			return false;
		}
	}

}
