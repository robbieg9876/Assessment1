package SSD;

public class ArrayProcessor {
	public int getArrayLength(Object [] a) {
		int count=0;
		try {
		while(true) {
			Object t = a[count];
			count++;
		}
		}
		catch(ArrayIndexOutOfBoundsException e){
			return count;
		}
	}
	
}