package SSD;

import javax.swing.JFrame;



public class JavaPanel {
	 
    public static void main(String[] args) {
    	
        JFrame frame = new JFrame("Pattern Scanner");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
 
        PatternScanner panel = new PatternScanner();
        
        frame.setJMenuBar(panel.setupMenu());
        
        frame.getContentPane().add(panel);
        
        frame.pack();
        frame.setVisible(true);
    }
}
