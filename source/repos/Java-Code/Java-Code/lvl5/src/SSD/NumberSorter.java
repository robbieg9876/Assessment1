package SSD;

import java.util.Stack;


public class NumberSorter {
	public void sort(int[] numbers,boolean ascending) {
		Stack<Integer>srcStack= new Stack<Integer>();
		
		Stack<Integer>destStack= new Stack<Integer>();
		Integer next;
		for(int number : numbers) {
			srcStack.push(number);
		}
		while (srcStack.size()>0) {
			next=srcStack.pop();
			while(destStack.size()>0 &&
					(
					(ascending && destStack.peek()>next)||
					(!ascending && destStack.peek()<next)
					) 
					){
				srcStack.push(destStack.pop());
			}
				destStack.push(next);
		}
		System.out.print(destStack+"\n");
		/*
		 * for (Integer n :destStack) { System.out.print(n+","); }
		 */
		
		
}
}
