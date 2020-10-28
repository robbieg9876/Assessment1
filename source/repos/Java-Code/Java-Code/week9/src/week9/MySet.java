package week9;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.Set;
/**
 * @author robbie
 * @param <T>
 * Code demonstates the use of a set using an ArrayList
 */
public class MySet<T> implements Set<T> {
	/** 
	 * Creates of instance  of ArrayList
	 */
	private java.util.List<T> list = new ArrayList<T>();
	/**
	 * Adds @param element to the list 
	 * if the list does not already contain @param element
	 * @return true or false
	 */
	@Override
	public boolean add(T element) {
		if (list.contains(element)) {
			return false;
		}
		list.add(element);
		return true;
	}

	/**
	 * Adds all the @param element in the collection
	 * calls add(T element) for each @param element
	 */
	@Override
	public boolean addAll(Collection<? extends T> element) {
		//Loop and check if each element is already on the list
		for (T i :element) {
			list.add(i);
		}
		return false;
	}

	/**
	 * Empties the list
	 */
	@Override
	public void clear() {
		list.clear();

	}

	/**
	 * Checks if the list contains @param element
	 * @return true or false
	 */
	@Override
	public boolean contains(Object element) {
		return list.contains(element);
	}
	/**
	 * Checks if the list contains all the @param element in the collection
	 * @return true or false
	 */
	@Override
	public boolean containsAll(Collection<?> element) {
		return list.containsAll(element);
	}

	/**
	 * Checks if the list is empty
	 * @return true or false
	 */
	@Override
	public boolean isEmpty() {
		return list.isEmpty();
	}
	/**
	 * Iterates through the list
	 * @return every element in list
	 */
	@Override
	public Iterator<T> iterator() {
		return list.iterator();
	}
	/**
	 * Removes @param element from list
	 * @return @param element
	 */
	@Override
	public boolean remove(Object element) {
		return list.remove(element);
	}

	/**
	 * Removes all the @param element from the collection
	 * @return all the @param element removed
	 */
	@Override
	public boolean removeAll(Collection<?> element) {
		return list.removeAll(element);
	}

	/**
	 * Keep all the @param element from the collection that are in the list
	 * @return all the @param element retained
	 */
	@Override
	public boolean retainAll(Collection<?> element) {
		return list.retainAll(element);
	}
	/**
	 * @return the size of the list
	 */
	@Override
	public int size() {
		return list.size();
	}
	/**
	 * Converts the list to an array
	 * @return list is an array
	 */
	@Override
	public Object[] toArray() {
		return list.toArray();
	}
	/**
	 * Converts all the @param element in the list to an array
	 * @return list as an array
	 */
	@Override
	public <T> T[] toArray(T[] element) {
		return list.toArray(element);
	}
}
