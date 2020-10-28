package SSD;

public class ArrayStackDriver {
	public static void main(String[] args ) {
		MyArrayStack AS = new MyArrayStack();
		MyLinkedStack LS = new MyLinkedStack();
		System.out.print(AS.peek(element));
		System.out.print(AS.pop(element));
		System.out.print(AS.push(element));
		System.out.print(LS.peek(element));
		System.out.print(LS.pop(element));
		System.out.print(LS.push(element));
	}
}
