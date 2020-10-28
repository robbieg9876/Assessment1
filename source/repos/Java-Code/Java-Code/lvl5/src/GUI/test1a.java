package GUI;

import javax.swing.JFrame;

/**
 * The main driver program for the GUI based conversion program.
 * 
 * @author mdixon
 */
public class test1a {
	 
    public static void main(String[] args) {
    	
        JFrame frame = new JFrame("Converter");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
 
       test1 panel = new test1();
        
        frame.setJMenuBar(panel.setupMenu());
    
        frame.getContentPane().add(panel);
        
        frame.pack();
        frame.setVisible(true);
    }
}


