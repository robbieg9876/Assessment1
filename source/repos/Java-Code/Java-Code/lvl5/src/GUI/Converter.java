package GUI;

import java.awt.Color;
import java.io.IOException;
import javax.swing.BorderFactory;
import javax.swing.BoxLayout;
import javax.swing.JFrame;
import javax.swing.JPanel;
/**
 * The main driver program for the GUI based conversion program.
 * 
 * @author mdixon
 */
public class Converter {
	 
    public static void main(String[] args) throws IOException {
    	
        JFrame frame = new JFrame("Converter");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        
        JPanel masterPanel= new JPanel();
        
        masterPanel.setLayout(new BoxLayout(masterPanel,BoxLayout.PAGE_AXIS));
        
        
        
        MainPanel panel = new MainPanel();
        
        currencyPanel currencyPanel = new currencyPanel();
  
        currencyPanel.setBorder(BorderFactory.createMatteBorder(
                10, 10, 10, 10, Color.blue));
        
        masterPanel.add(panel);
        masterPanel.add(currencyPanel);
        
        frame.setJMenuBar(currencyPanel.setupMenu());
    
        frame.getContentPane().add(masterPanel);
        
        frame.pack();
        frame.setVisible(true);
        
        panel.currencyPanel=currencyPanel;
        currencyPanel.mainPanel=panel;
    }
}


