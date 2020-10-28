package SSD;

public class StackDriver {
	public static void main(String[] args) {


		MyStack<String> s1 = new MyArrayStack<String>();
		
		MyStack<String> s2 = new MyLinkedStack<String>();
		
		System.out.println("Stack 1 - array stack" );

		
		s1.push("1");
		s1.push("2");
		s1.push("3");
		
		while ( !s1.isEmpty() ) {
			
			System.out.println("Popped " + s1.pop());
			
		}
		
		
		System.out.println("Stack 2 - linked stack" );
		
		s2.push("1");
		s2.push("2");
		s2.push("3");
		
		while ( !s2.isEmpty() ) {
			
			System.out.println("Popped " + s2.pop());
			
		}
	}

}
