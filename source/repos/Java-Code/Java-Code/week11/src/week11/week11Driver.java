package week11;

/**
 * @author robbi
 * Code Demonstrates sorting using an ArrayList
 */
public class week11Driver  {
	/**
	 * @param args
	 * Demonstates methods to sort age, gender and height
	 */
	public static void main(String[] args) {
		/**
		 * Creates new instance of Census();
		 */
		Census census1 = new Census();
		//Adds persons to the ArrayList
		Person person1 = new Person(190,19,true);
		Person person2 = new Person(170,20,false);
		Person person3 = new Person(200,23,true);
		Person person4 = new Person(160,21,false);
		Person person5 = new Person(180,22,true);
		census1.addPerson(person1);
		census1.addPerson(person2);
		census1.addPerson(person3);
		census1.addPerson(person4);
		census1.addPerson(person5);
		//Outputs the count of people, males and females and outputs to console
		System.out.print("Numner of people is "+census1.countPeople()+"\n");
		System.out.print("Numner of males is "+census1.countMales()+"\n");
		System.out.print("Numner of females is "+census1.countFemales()+"\n");
		System.out.print("\nRemove person 3\n\n");
		//Removes a person from the ArrayList
		census1.removePerson(person3);
		System.out.print("Numner of people is "+census1.countPeople()+"\n");
		System.out.print("Numner of males is "+census1.countMales()+"\n");
		System.out.print("Numner of females is "+census1.countFemales()+"\n\n");
		System.out.print("Unsorted: \n");
		//Outputs ArrayList as a string to console
		System.out.print(census1.toString());
		//Sorts ArrayList by age and outputs to console
		census1.sortOnAge();
		System.out.print("Sorted by age: \n");
		System.out.print(census1.toString());
		//Sorts ArrayList by height and outputs to console
		census1.sortOnHeight();
		System.out.print("Sorted by height: \n");
		System.out.print(census1.toString());
		//Sorts ArrayList by gender and outputs to console
		census1.sortOnGender();
		System.out.print("Sorted by gender: \n");
		System.out.print(census1.toString());
	}
}
