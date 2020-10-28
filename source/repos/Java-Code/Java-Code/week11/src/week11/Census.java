package week11;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
/**
 * @author robbi
 * Code demonstrates sorting using an ArrayList
 */
public class Census {
	/**
	 * Creates new instance of ArrayList<Person>
	 */
	private List<Person> people = new ArrayList<Person>();
	/** 
	 *adds @param person to list
	 */
	void addPerson(Person person) {
		people.add(person);
	}
	/**
	 * 
	 * removes @param person from list
	 * @return @param person
	 */
	boolean removePerson(Person person) {
		return people.remove(person);
	}
	/**
	 * Gets size of the list
	 * @return people.size()
	 */
	int countPeople() {
		return people.size();
	}
	/**
	 * Gets amount of Males in the list
	 * @return count of Females
	 */
	int countMales() {
		int countM=0;
		for(Person person:people) {
			if (person.isMale()){
				countM++;
			}
		}
		return countM;
	}
	/**
	 * Gets amount of Females in the list
	 * @return count of Females
	 */
	int countFemales() {
		int countF=0;
		for(Person person:people) {
			if (person.isMale()){
			}
			else {
				countF++;
			}
		}
		return countF;
	}
	/**
	 * Iterates through the list and adds values to string
	 * Returns string
	 */
	public String toString() {
		String person1="";
		for(Person person:people) {
			person1= person1 +person.toString()+"\n";
		}
		return person1;
	}
	/**
	 * Sorts items in list by age
	 * @return list in correct order
	 */
	void sortOnAge() {
		Collections.sort(people, new Comparator<Person>(){

			@Override
			public int compare(Person p1, Person p2) {

				return Integer.compare(p1.getAge(), p2.getAge());

			}

		});
	}
	/**
	 * Sorts items in list by height
	 * @return list in correct order
	 */
	void sortOnHeight() {
		Collections.sort(people, new Comparator<Person>(){

			@Override
			public int compare(Person p1, Person p2) {

				return Integer.compare(p1.getHeight(), p2.getHeight());

			}

		});
	}
	/**
	 * Sorts items in list by gender
	 * @return list in correct order
	 */
	void sortOnGender() {
		Collections.sort(people, new Comparator<Person>(){

			@Override
			public int compare(Person p1, Person p2) {
				int P1=0;
				int P2=0;
				if (p1.isMale()){
					P1=1;
				}
				else {
					P1=-1;
				}
				if (p2.isMale()){
					P2=1;
				}
				else {
					P2=-1;
				}
				return Integer.compare(P1,P2);

			}

		});
	}


}
