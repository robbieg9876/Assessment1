package GUI.C3528718;
import java.awt.Color;
import static java.awt.event.InputEvent.CTRL_DOWN_MASK;
import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.text.DecimalFormat;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JCheckBox;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.KeyStroke;

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
public class MainPanel extends JPanel {
	//Creates list
	private final static String[] list = { "inches/cm","Miles/Nautical Miles","Acres/Hectares","Miles per hour/Kilometres per hour","Yards/Metres","Celsius/Fahrenheit","Degrees/Radians" };
	// Defines Elements
	private JTextField textField;
	private JLabel resultLabel;
	private JComboBox<String> combo;
	JTextArea textArea;
	JFrame f;
	private JLabel countLabel;
	private int countTotal=0;
	JCheckBox checkBox= new JCheckBox("Reverse");
	JFrame f2;
	//creates menu
	JMenuBar setupMenu() {
		//makes a new menu bar
		JMenuBar menuBar = new JMenuBar();
		//Creates headings for menu bar
		JMenu m1 = new JMenu("File");
		JMenu m2 = new JMenu("Help");
		//Adds headings to the menu bar
		menuBar.add(m1);
		menuBar.add(m2);
		//Gets image for exit item
		 ImageIcon iconExit = new ImageIcon("C:\\Users\\robbi\\eclipse-workspace\\lvl5\\src\\GUI\\exit.png");
		JMenuItem item1 = new JMenuItem("Exit",iconExit);
		//Sets shortcut for exit and adds to menu
		item1.setMnemonic(KeyEvent.VK_E); 
		m1.add(item1);
		//Creates action listener called exitListener and adds it to item1
		ActionListener exitListener = new exitListener();
		item1.addActionListener(exitListener);
		item1.setAccelerator(KeyStroke.getKeyStroke('E', CTRL_DOWN_MASK));  
		//Defines an image for about and adds it to menu
		ImageIcon iconAbout = new ImageIcon("C:\\Users\\robbi\\eclipse-workspace\\lvl5\\src\\GUI\\about.png");
		JMenuItem item2 = new JMenuItem("About",iconAbout);
		//Sets shortcut for menu and adds to menu
		item2.setMnemonic(KeyEvent.VK_A); 
		//Sets tooltip for 'item1'
		item1.setToolTipText("Click this or press ctrlE to exit the program");
		//adds About  item to the Help menu option
		m2.add(item2);
		//Creates action listener called aboputListener and adds it to about
		ActionListener aboutListener = new aboutListener();
		item2.addActionListener(aboutListener);
		item2.setAccelerator(KeyStroke.getKeyStroke('A', CTRL_DOWN_MASK));
		//Sets tooltips for menu items
		item1.setToolTipText("Click this or press ctrlE to exit the program");
		item2.setToolTipText("Click this  or press ctrlA to see info about the program");
		//returns menuBar to mainPanel class
		return menuBar;
	}


	MainPanel() {
		//Creates action listener called ConvertListener and create drop down list 
		ActionListener convertlistener = new ConvertListener();
		combo = new JComboBox<String>(list);
		combo.addActionListener(convertlistener); //convert values when option changed
		combo.setToolTipText("Select which units you want to convert");
		//Creates label 'inputLabel'
		JLabel inputLabel = new JLabel("Enter value:");
		checkBox.setToolTipText("Click this to reverse the conversion");
		//Creates conversion button and adds tool tips
		JButton convertButton = new JButton("Convert");
		convertButton.addActionListener(convertlistener); // convert values when pressed
		convertButton.setToolTipText("Click this button to convert the value typed");
		//Creates label 'resultLabel'
		resultLabel = new JLabel("---");
		//Creates text field 'textField' with size 5
		textField = new JTextField(5);
	    textField.addActionListener(convertlistener);
		textField.setToolTipText("Enter a valid number");
		//adds combo, labels ,textFiled and buttons to frame
		add(combo);
		add(inputLabel);
		add(textField);
		add(checkBox);
		add(convertButton);
		add(resultLabel);
		// Creates button 'clearButton'
		JButton clearButton= new JButton("Clear");
		ActionListener ClearListener = new clearListener();
		clearButton.addActionListener(ClearListener);
		add(clearButton);
		clearButton.setToolTipText("Click this button to clear the value typed , the result and reset the number of conversions");
		//Creates label 'countLabel' which shows the value of 'countTotal' as a string
		countLabel = new JLabel("Conversion count : "+countTotal);
		//Adds 'countLabel' to frame
		add(countLabel);
		//Sets tooltip for 'countLabel'
		countLabel.setToolTipText("Shows the number of conversions");
		
		//sets the frame size and background colour
		setPreferredSize(new Dimension(800, 80));
		setBackground(Color.LIGHT_GRAY);


	}

	private class ConvertListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent event) {
			//Initialises string 'text' with the value of 'textField' with no white space
			String text = textField.getText().trim();
			//checks if 'text' is empty
			if (text.isEmpty() == false) {
				//if it isn't :
				try {
					//Try to convert text to a double ,this checks if the value inputted is a number
				double value = Double.parseDouble(text);

				// the factor applied during the conversion
				double factor = 0;

				// the offset applied during the conversion.
				double offset = 0;

				// Setup the correct factor/offset values depending on required conversion
				switch (combo.getSelectedIndex()) {
				// uses selection to go on a different branch depending on which item in 'combo' is selected
				case 0: // inches/cm
					factor = 2.54;
					break;
				case 1: // Miles/NauticalMiles
					factor = 0.86897583;
					break;
				case 2: // Acres/Hectares
					factor = 0.404686;
					break;
				case 3: // Miles per hour/ Kilometres per hour
					factor = 1.609344;
					break;
				case 4: // Yards/Metres
					factor = 0.9144;
					break;
				case 5: // Celsius/Fahrenheit
					factor = 1.8;
					offset= 32;
					break;
				case 6: // Degrees/Radians
					factor = Math.PI/180;
					break;
				}
				// Iniatilzes  double 'result' by calculating the conversion
				double result = factor * value + offset;
				//checks if the variable 'checked'is true
				 if (checkBox.isSelected()) { 
					 //if it is the conversion is reversed
					  result = (value-offset)/factor;
					 }
				//increments count by 1
				countTotal++;
				//changes the value of 'label' to show the result of the conversion , this is shown to 2 decimal places
				DecimalFormat format = new DecimalFormat("0.00");
				resultLabel.setText(format.format(
                       result));
				//changes the value of 'countLabel' to show the current value of 'count'
				countLabel.setText("Conversion count : "+countTotal);
					} 
				//catch for the try , to check if the value is a number
				catch (NumberFormatException e)
				{
					//Error message is shown to tell user to enter a valid number
					JOptionPane.showMessageDialog(f, " Error value entered is not a valid number, \n Please enter a number into the text field before converting");
					//Clears 'textField
					textField.setText("");
				}
			}
			//If 'textField' is empty
			else {
				//Error message is shown to tell user to enter a number into the text field
				JOptionPane.showMessageDialog(f, " Error text area is empty, \n Please enter a number into the text field before converting");
			}
		}

	}

	private class exitListener implements ActionListener {
		public void actionPerformed(ActionEvent event) {
			//Exits the program
			System.exit(0);

		}
	}
	private class aboutListener implements ActionListener {
		public void actionPerformed(ActionEvent event) {
			//Shows a message giving an explanation about the program
			JOptionPane.showMessageDialog(f, "This is a graphics panel that shows unit conversions by Robbie Giles, Copyright 2019");
		}
	}
	private class clearListener implements ActionListener {
		public void actionPerformed(ActionEvent event) {
			//clears 'textField' and 'resultLabel'
			textField.setText("");
			resultLabel.setText("");
			//resets 'count' to 0 and changes 'countLabel' to show the change
			countTotal=0;
			countLabel.setText("Conversion count : "+countTotal);

		}
	}
}

