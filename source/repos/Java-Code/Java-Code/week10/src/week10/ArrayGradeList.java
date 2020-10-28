package week10;

import java.util.ConcurrentModificationException;
import java.util.Iterator;
import java.util.NoSuchElementException;
/**
 * @author robbi
 * Code demonstrates the use of an array to store grades
 */
public class ArrayGradeList implements Iterable<Float> {
	//Create array and initialise variables
	private float [] grades = new float[20];
	private int count = 0; 
	private int iteratorModCount = 0; 
	/**
	 * @author robbi
	 *Iterates through the array
	 *Checks that the array is the correct size
	 */
	class GradesIterator implements Iterator<Float>{
		int next=0;
		@Override
		public boolean hasNext() {
			if (count!=iteratorModCount) {
				throw new ConcurrentModificationException();
			}
			return (next<count);
		}
		@Override
		public Float next() {
			if(next<count) {
				return grades[next++];
			}
			throw new NoSuchElementException();
		}
		@Override
		public void remove() throws UnsupportedOperationException
		{
			throw new UnsupportedOperationException();
		}
	}
	/**
	 * Stores the value of count to iteratorModCount 
	 * calls GradesIterator() to check size of array is correct
	 */
	public Iterator<Float> iterator() {
		iteratorModCount = count;
		return new GradesIterator();
	}
	/**
	 *Adds @param grade to array
	 *Increments count by 1
	 */
	void addGrade(float grade) {
		grades[count]=grade;
		count++;
	}
	/**
	 * Iterates through array to get total grade
	 * Then divides this value by the length of the array to workout average grade
	 * @return average grade 
	 * Or if the array is empty @return 0
	 */
	float getAverageGrade() {
		float total=0;
		for(float f : grades){
			total+=f;
		}
		if (grades.length==0){
			return 0;
		}
		else {
			return total/count;
		}
	}




}
