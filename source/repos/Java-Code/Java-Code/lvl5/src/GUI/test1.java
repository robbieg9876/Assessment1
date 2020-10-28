package GUI;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.JTextField;

/**
 * The main graphical panel used to display conversion components.
 * 
 * This is the starting point for the assignment.
 * 
 * The variable names have been deliberately made vague and generic, and most comments have been removed.
 * 
 * You may want to start by improving the variable names and commenting what the existing code does.
 * 
 * @author mdixon
 */
@SuppressWarnings("serial")
public class test1 extends JPanel {
	JTextArea ta;
	JFrame f;


	JMenuBar setupMenu() {

		JMenuBar menuBar = new JMenuBar();

		JMenu m1 = new JMenu("File");
		JMenu m2 = new JMenu("Help");

		menuBar.add(m1);
		menuBar.add(m2);

		JMenuItem item1 = new JMenuItem("Exit");
		m1.add(item1);
		
		JMenuItem item2 = new JMenuItem("About");
		m2.add(item2);
		return menuBar;
		}
	public void actionPerformed(ActionEvent e)
	  {
	    String str = e.getActionCommand();		// know the menu item selected by the user
	    System.out.println("You selected " + str);
	  }
	  public static void main(String args[])
	  {
	    new test1();
	  }
	}


