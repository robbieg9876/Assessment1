import javax.swing.JFrame;

public class panel {



		 
	    public static void main(String[] args) {
	    	
	        JFrame frame = new JFrame("Pattern Scanner");
	        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	 
	        grandNational panel = new grandNational();
	        
	        frame.pack();
	        frame.setVisible(true);
	    }
	}
