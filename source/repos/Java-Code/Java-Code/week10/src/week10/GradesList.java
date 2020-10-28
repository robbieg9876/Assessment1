package week10;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
/**
 * @author robbie
 *The code demonstrates the use of an arrayList to input grades
 */
public class GradesList implements Iterable<Float> {
	/**
	 * Creates instance of ArrayList<Float>
	 */
	private List<Float> grades = new ArrayList<Float>();
	/**
	 * Adds @param grade to list
	 */
	void addGrade(float grade) {
		grades.add(grade);
	}
	/**
	 * loops through the list to calculate the average grade
	 * @return average grade
	 * or @return 0 if the list is empty
	 */
	float getAverageGrade() {
		float total=0;
		for(float f : grades){
			total+=f;
		}
		if (grades.isEmpty()){
			return 0;
		}
		else {
			return total/grades.size();
		}

	}
	/**
	 * Iterates through the list
	 * @return all the grades in the list
	 */
	public Iterator<Float> iterator() {
		return grades.iterator();
	}


}
