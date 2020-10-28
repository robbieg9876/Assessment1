package week11;

public class Person {
	private int height;
	private int age;
	private boolean isMale;
	/**
	 * Constructor sets values for height, age and gender
	 * @param height2
	 * @param age2
	 * @param isMale2
	 */
	public Person(int height2, int age2, boolean isMale2){
		height=height2;
		age=age2;
		isMale=isMale2;
	}
	/**
	 * Getter for height
	 * @return height
	 */
	public int getHeight() {
		return height;
	}
	/**
	 * setter for height
	 * sets @param height
	 */
	public void setHeight(int height) {
		this.height = height;
	}
	/**
	 * Getter for age
	 * @return age
	 */
	public int getAge() {
		return age;
	}
	/**
	 * Setter for age
	 * sets @param age
	 */
	public void setAge(int age) {
		this.age = age;
	}
	/**
	 * Getter for gender
	 * @return isMale
	 */
	public boolean isMale() {
		return isMale;
	}
	/**
	 * Setter for gender
	 * sets @param isMale
	 */
	public void setMale(boolean isMale) {
		this.isMale = isMale;
	}
	/**
	 * @return values of person as a string
	 */
	public String toString() {;
	return height +" , "+ age + " , "+ isMale;
	}
}
