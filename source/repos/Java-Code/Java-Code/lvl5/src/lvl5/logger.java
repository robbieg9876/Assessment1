package lvl5;

	import java.util.ArrayList;
	import java.util.List;

	public class logger {

		int errCount = 0;
		
		int warnCount = 0;
		
		int infoCount = 0; 
		
		int index = 0;
		//Creating an object
		List<String> messages = new ArrayList<String>();
		
		//Constructor
		void logError(String message) {
			//Calls class method to add message
			messages.add("ERROR: " + message);
			errCount++;
		}
		//Constructor
		void logWarning(String message) {
			//Calls class method to add message
			messages.add("WARNING: " + message);
			warnCount++;
		}
		//Constructor
		void logInformation(String message) {
			//Calls class method to add message
			messages.add("INFO: " + message);
			infoCount++;
		}
		//Constructor
		void displayLog(){
			for ( index = 0; index < messages.size(); index++);
			//Accesses instance variables
			System.out.println(messages.get(index));
		}
		
}
