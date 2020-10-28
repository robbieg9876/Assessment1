package week10;

import java.util.Iterator;
/**
 * @author robbi
 *Code demonstrates use of array and array list to  store grades
 */
public class gradesDriver {
	/**
	 * @param args
	 * Uses methods to edit array and array list
	 */
	public static void main(String[] args) {
		/**
		 * Creates new instance of GradesList()
		 */
		GradesList gradesList = new GradesList();
		System.out.println("Grades List");
		//Adds grades to the list
		gradesList.addGrade(67);
		gradesList.addGrade(73);
		gradesList.addGrade(50.7f);
		gradesList.addGrade(80.4f);
		//Iterates through list
		Iterator<Float> iter = gradesList.iterator();

		while (iter.hasNext()) {
			//Outputs the next value in the list to console
			float f= iter.next();
			System.out.println("The next value is: "+f);
		}
		//Outputs the average grade in the list to console
		System.out.println("Average grade is: "+gradesList.getAverageGrade());
		/**
		 * Creates new instance of ArrayGradeList()
		 */
		ArrayGradeList gradesList2 = new ArrayGradeList();
		System.out.println("\nArray Grades List");
		//Adds grades to array
		gradesList2.addGrade(67);
		gradesList2.addGrade(70);
		gradesList2.addGrade(50.7f);
		gradesList2.addGrade(80.4f);
		//Iterates through array
		Iterator<Float> iter2 = gradesList2.iterator();

		while (iter2.hasNext()) {
			//Outputs next value in array to console
			float f= iter2.next();
			System.out.println("The next value is: "+f);
		}
		//Outputs the average grade in the array to console
		System.out.println("Average grade is: "+gradesList2.getAverageGrade());
}
}
