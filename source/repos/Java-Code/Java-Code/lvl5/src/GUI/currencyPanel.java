package GUI;
import static java.awt.event.InputEvent.CTRL_DOWN_MASK;

import java.awt.Color;

import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Scanner;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.KeyStroke;

@SuppressWarnings("serial")
public class currencyPanel extends JPanel {
	//Creates list
	// Defines Elements
	JTextField userInputTextField;
	JLabel resultLabel;
	JFrame frame;
	String symbol;
	File file = new File("C:\\Users\\robbi\\eclipse-workspace\\lvl5\\src\\GUI\\currency.txt"); 
	Scanner readText=null;
	String currency;
	String currencyFactor;
	int index=0;
	//initialises array lists and combo box
	public ArrayList<String> CurrencyList=new ArrayList<String>(); 
	public ArrayList<String> FactorList=new ArrayList<String>(); 
	public ArrayList<String> SymbolList=new ArrayList<String>(); 
	public ArrayList<String> ErrorList=new ArrayList<String>();
	public JComboBox<String> currencyCombo =  new JComboBox<String>();
	public String errors="File Errors:";
	//links to mainPanel class to allow use of its methods and attributes
	public MainPanel mainPanel;


	JMenuBar setupMenu() {
		//makes a new menu bar
		JMenuBar menuBar = new JMenuBar();
		//Creates headings for menu bar
		JMenu file = new JMenu("File");
		JMenu help = new JMenu("Help");
		//Adds headings to the menu bar
		menuBar.add(file);
		menuBar.add(help);
		//Gets image for exit item
		ImageIcon iconExit = new ImageIcon("C:\\Users\\robbi\\eclipse-workspace\\lvl5\\src\\GUI\\exit.png");
		JMenuItem exit = new JMenuItem("Exit",iconExit);
		//Sets shortcut for exit and adds to menu
		exit.setMnemonic(KeyEvent.VK_E); 
		file.add(exit);
		//Creates action listener called exitListener and adds it to item1
		ActionListener exitListener = new exitListener();
		exit.addActionListener(exitListener);
		exit.setAccelerator(KeyStroke.getKeyStroke('E', CTRL_DOWN_MASK));  
		//Defines an image for about and adds it to menu
		ImageIcon iconAbout = new ImageIcon("C:\\Users\\robbi\\eclipse-workspace\\lvl5\\src\\GUI\\about.png");
		JMenuItem about = new JMenuItem("About",iconAbout);
		//Sets shortcut for menu and adds to menu
		about.setMnemonic(KeyEvent.VK_A); 
		//adds About  item to the Help menu option
		help.add(about);
		//Creates action listener called aboutListener and adds it to about
		ActionListener aboutListener = new aboutListener();
		about.addActionListener(aboutListener);
		about.setAccelerator(KeyStroke.getKeyStroke('A', CTRL_DOWN_MASK));  
		ImageIcon iconLoad = new ImageIcon("C:\\Users\\robbi\\eclipse-workspace\\lvl5\\src\\GUI\\load.jpg");
		JMenuItem load = new JMenuItem("Load",iconLoad);
		load.setMnemonic(KeyEvent.VK_L); 
		//adds Load  item to the Help menu option
		file.add(load);
		//Creates action listener called loadListener and adds it to load
		ActionListener loadListener = new loadListener();
		load.addActionListener(loadListener);
		load.setAccelerator(KeyStroke.getKeyStroke('L', CTRL_DOWN_MASK));
		load.setToolTipText("Click this or press ctrl+l to exit the program");
		exit.setToolTipText("Click this or press ctrl+e to exit the program");
		about.setToolTipText("Click this  or press ctrl+a to see info about the program");
		//returns menuBar to mainPanel class
		return menuBar;
	}
	currencyPanel(){
		load();
		//Creates action listener called ConvertListener and create drop down list 
		ActionListener convertlistener = new ConvertListener();
		currencyCombo.setToolTipText("Select which units you want to convert");
		//Creates label 'inputLabel'
		JLabel inputLabel = new JLabel("Enter value:");
		//Creates conversion button and adds tool tips
		JButton convertButton = new JButton("Convert");
		convertButton.addActionListener(convertlistener); // convert values when pressed
		convertButton.setToolTipText("Click to convert");
		//Creates label 'resultLabel'
		resultLabel = new JLabel("---");
		//Creates text field 'textField' with size 5
		userInputTextField = new JTextField(5);
		userInputTextField.addActionListener(convertlistener);
		userInputTextField.setToolTipText("Enter a valid number");
		//adds combo, labels ,textFiled and buttons to frame
		add(currencyCombo);
		add(inputLabel);
		add(userInputTextField);
		add(convertButton);
		add(resultLabel);
		// Creates button 'clearButton'


		//sets the frame size and background colour
		setPreferredSize(new Dimension(800, 80));
		setBackground(Color.YELLOW);



	}



	private class ConvertListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent event) {
			//Initialises string 'text' with the value of 'textField' with no white space
			String text = userInputTextField.getText().trim();
			//checks if 'text' is empty
			if (text.isEmpty() == false) {
				//if it isn't :
				try {
					//Try to convert text to a double ,this checks if the value inputted is a number
					// Setup the correct factor/offset values depending on required conversion
					index=currencyCombo.getSelectedIndex();
					// uses selection to go on a different branch depending on which item in 'combo' is selected

					double value = Double.parseDouble(text);
					double factor= Double.parseDouble(FactorList.get(index));
					symbol=SymbolList.get(index);
					// Iniatilises  double 'result' by calculating the conversion
					double result = factor * value ;
					//checks if the variable 'checked'is true
					if (mainPanel.checkBox.isSelected()) { 
						//if it is the conversion is reversed
						result = value/factor;
						symbol="£";
					}
					//increments count by 1
					mainPanel.countIncrement();
					//changes the value of 'label' to show the result of the conversion , this is shown to 2 decimal places
					DecimalFormat format = new DecimalFormat("0.00");

					resultLabel.setText(symbol+format.format(result));

				} 
				//catch for the try , to check if the value is a number
				catch (NumberFormatException e)
				{
					//Error message is shown to tell user to enter a valid number
					JOptionPane.showMessageDialog(frame, " Error value entered is not a valid number, \n Please enter a number into the text field before converting");
					//Clears 'textField
					userInputTextField.setText("");
				}
			}
			//If 'textField' is empty
			else {
				//Error message is shown to tell user to enter a number into the text field
				JOptionPane.showMessageDialog(frame, " Error text area is empty, \n Please enter a number into the text field before converting");
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
			JOptionPane.showMessageDialog(frame, "This is a graphics panel that shows unit conversions by Robbie Giles, Copyright 2019");
		}
	}
	private class loadListener implements ActionListener {
		public void actionPerformed(ActionEvent event) {
			//Create a file chooser and opens a dialog
			final JFileChooser fc = new JFileChooser();
			//returns the value of the file the user chooses
			int returnVal = fc.showOpenDialog(frame);
			//checks if a file has been opened in the file chooser
			if (returnVal == JFileChooser.APPROVE_OPTION) {
				//sets the file selected to 'file'
				file = fc.getSelectedFile();
			}

			load();
		}
	}
	public void load() {
		//clears all the arrayLists and 'currencyCombo'
		currencyCombo.removeAllItems();
		CurrencyList.clear();
		FactorList.clear();
		SymbolList.clear();
		ErrorList.clear();
		errors="File Errors:";
		BufferedReader in;
		try {
			//tries to read the file
			in = new BufferedReader(
					new InputStreamReader(
							new FileInputStream(file), "UTF8"));
			//loops through each line of text in the file:
			String textLine;
			while ((textLine=in.readLine())!=null) {
				try {
					//Splits the line into three different strings
					String[] splitText = textLine.split(",");
					String currencys=(splitText[0].trim());
					String factor=(splitText[1].trim());
					String symbol =(splitText[2].trim());
					//checks if any of the three strings are empty
					//if they are then the strings aren't added to the arrayList
					//and the whole line is added to the errorList arrayList
					if (currencys.equals("")) {
						ErrorList.add(textLine);
					}
					else {
						if (factor.equals("")) {
							ErrorList.add(textLine);
						}
						else {
							if (symbol.equals("")) {
								ErrorList.add(textLine);
							}
							else {

								try {
									//tries to parse factor
									Double.parseDouble(factor);
									//Adds strings to the relevant arrayList
									FactorList.add(factor);
									CurrencyList.add(currencys);
									SymbolList.add(symbol);
								}
								catch(NumberFormatException e) {
									ErrorList.add(textLine);
								}

							}
						}
					}
				}

				catch(ArrayIndexOutOfBoundsException e) {
					ErrorList.add(textLine);
				}
			}
			//closes buffered reader
			in.close();
		} catch (UnsupportedEncodingException e1) {
			JOptionPane.showMessageDialog(frame,"character coding is unsupported");

		} catch (FileNotFoundException e2) {
			JOptionPane.showMessageDialog(frame,"File not found");
		} catch (IOException e3) {
			JOptionPane.showMessageDialog(frame,"Input/Output exception occurred");
		}

		//loops through CurrencyList 
		//and adds the values to currencyCombo
		index=0;
		while(index<CurrencyList.size()) {
			currencyCombo.addItem(CurrencyList.get(index));
			index++;
		}
		index=0;
		//loops through ErrorList 
		//and adds the values to string 'errors'
		while (index<ErrorList.size()) {
			errors= (errors+"\n"+ ErrorList.get(index));
			index++;
		}
		//sends a message to the screen
		//showing all the errors for that file
		JOptionPane.showMessageDialog(frame, errors);

	}
}

