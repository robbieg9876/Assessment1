package SSD;

public class Week4Driver {
	public static void main(String[] args ) {
		Subject subjectArray= new Subject[5];
		Maths m1 = new Maths();
		m1.setTutor("D.Trump");
		m1.setRoom("The white house");
		
		subjectArray[0]=m1;
		
		Art a1= new Art();
		a1.setTutor("Salvador Dali");
		a1.setRoom("Figueres");
		subjectArray[1]= a1;
		
		Physics p1=new Physics();
		p1.setTutor("Isaac Newton");
		p1.setRoom("Lab1");
		subjectArray[2]= p1;
		
		
	}
	}
