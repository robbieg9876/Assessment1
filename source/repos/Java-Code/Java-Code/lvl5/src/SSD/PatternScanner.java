package SSD;
import static java.awt.event.InputEvent.CTRL_DOWN_MASK;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.List;
import javax.swing.ImageIcon;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.KeyStroke;

import org.junit.Test;

import java.io.BufferedReader;
import java.io.InputStreamReader;
@SuppressWarnings("serial")
public class PatternScanner extends JPanel {
	/**
	 * Initialises variables
	 */
	//Initialise variables for GUI
	JFrame frame;
	JLabel fileLabel;
	JLabel selectLabel;
	JLabel patternsLabel;
	JTextArea patternTextArea;
	//Initialise variables for byte patterns
	public byte[] patternABC = new byte[] { 0x41, 0x42, 0x43 };
	public byte[] patternXYZ = new byte[] { 0x58, 0x59, 0x5A };
	public ArrayList<List<Byte>> patterns = new ArrayList<List<Byte>>();
	public ArrayList<Integer> byteCounts = new ArrayList<Integer>();
	public int value;
	public byte bytes;
	public int addPatternIndex;
	//Initialise variables for the file loader
	String[] splitText;
	String directoryName;
	String output = "";
	File[] files;
	File file;

	/**
	 * Sets menu bar
	 * Adds action listener to menu options
	 * @return menuBar
	 */
	// creates menu
	public JMenuBar setupMenu() {
		// makes a new menu bar
		JMenuBar menuBar = new JMenuBar();
		// Creates headings for menu bar
		JMenu file = new JMenu("File");
		JMenu help = new JMenu("Help");
		// Adds headings to the menu bar
		menuBar.add(file);
		menuBar.add(help);
		// Gets image for exit item
		ImageIcon iconExit = new ImageIcon("C:\\Users\\robbi\\eclipse-workspace\\lvl5\\src\\GUI\\exit.png");
		JMenuItem exit = new JMenuItem("Exit", iconExit);
		// Sets shortcut for exit and adds to menu
		exit.setMnemonic(KeyEvent.VK_E);
		file.add(exit);
		// Creates action listener called exitListener and adds it to item1
		ActionListener exitListener = new exitListener();
		exit.addActionListener(exitListener);
		exit.setAccelerator(KeyStroke.getKeyStroke('E', CTRL_DOWN_MASK));
		// Defines an image for about and adds it to menu
		ImageIcon iconAbout = new ImageIcon("C:\\Users\\robbi\\eclipse-workspace\\lvl5\\src\\GUI\\about.png");
		JMenuItem about = new JMenuItem("About", iconAbout);
		// Sets shortcut for menu and adds to menu
		about.setMnemonic(KeyEvent.VK_A);
		// adds About item to the Help menu option
		help.add(about);
		// Creates action listener called aboutListener and adds it to about
		ActionListener aboutListener = new aboutListener();
		about.addActionListener(aboutListener);
		about.setAccelerator(KeyStroke.getKeyStroke('A', CTRL_DOWN_MASK));
		ImageIcon iconLoad = new ImageIcon("C:\\Users\\robbi\\eclipse-workspace\\lvl5\\src\\GUI\\load.jpg");
		JMenuItem scanFile = new JMenuItem("Scan File", iconLoad);
		scanFile.setMnemonic(KeyEvent.VK_S);
		// adds Load item to the Help menu option
		file.add(scanFile);
		// Creates action listener called loadListener and adds it to load
		ActionListener scanListener = new scanListener();
		scanFile.addActionListener(scanListener);
		scanFile.setAccelerator(KeyStroke.getKeyStroke('S', CTRL_DOWN_MASK));
		ImageIcon iconLoadPattern = new ImageIcon("C:\\Users\\robbi\\eclipse-workspace\\lvl5\\src\\GUI\\load.jpg");
		JMenuItem loadPattern = new JMenuItem("Load pattern file", iconLoadPattern);
		loadPattern.setMnemonic(KeyEvent.VK_L);
		// adds Load item to the Help menu option
		file.add(loadPattern);
		// Creates action listener called loadListener and adds it to load
		ActionListener loadPatternListener = new loadPatternListener();
		loadPattern.addActionListener(loadPatternListener);
		loadPattern.setAccelerator(KeyStroke.getKeyStroke('L', CTRL_DOWN_MASK));
		scanFile.setToolTipText("Click this or press ctrl+l to load the scanner");
		exit.setToolTipText("Click this or press ctrl+e to exit the program");
		about.setToolTipText("Click this  or press ctrl+a to see info about the program");
		loadPattern.setToolTipText("Click this or press ctrl+p to load a pattern file");
		// returns menuBar to mainPanel class
		return menuBar;
	}
	/** 
	 * Sets the GUI
	 * Sets label and text area
	 */
	public PatternScanner() {

		selectLabel = new JLabel("Pattern File uploaded:");
		// Creates label 'resultLabel'
		patternsLabel = new JLabel("<none>");
		// add text field
		patternTextArea = new JTextArea(100, 170);
		patternTextArea.setEditable(false);
		patternTextArea.setText("Select a file or directory to be scannned using the menu");
		// adds combo, labels ,textFiled and buttons to frame
		add(selectLabel);
		add(patternsLabel);
		add(patternTextArea);
		// Creates button 'clearButton'
		// sets the frame size and background colour
		setPreferredSize(new Dimension(800, 80));
		setBackground(Color.YELLOW);
	}
	/**
	 * Exits the program
	 */
	private class exitListener implements ActionListener {
		@Test
		public void actionPerformed(ActionEvent event) {
			// Exits the program
			System.exit(0);

		}
	}
	/**
	 * Shows dialog box with explanation of the program
	 */
	private class aboutListener implements ActionListener {
		@Test
		public void actionPerformed(ActionEvent event) {
			// Shows a message giving an explanation about the program
			JOptionPane.showMessageDialog(frame,"Pattern Scanner \n This is a graphics panel that allows users to scan files for byte patterns \n ©Robbie Giles 2020 ");
		}
	}
	/**
	 * User selects file/directory
	 * calls scan() method
	 */
	private class scanListener implements ActionListener {
		@Test
		public void actionPerformed(ActionEvent event) {
			// Create a file chooser and opens a dialog
			final JFileChooser fc = new JFileChooser();
			fc.setMultiSelectionEnabled(true);
			fc.setFileSelectionMode(JFileChooser.FILES_AND_DIRECTORIES);
			//
			// disable the "All files" option.
			//
			// returns the value of the\a file the user chooses
			int returnVal = fc.showOpenDialog(frame);
			// checks if a file has been opened in the file chooser
			if (returnVal == JFileChooser.APPROVE_OPTION) {
				output = "";
				// sets the file selected to 'file'
				files = fc.getSelectedFiles();
				file= fc.getSelectedFile();
				//checks if the user selects a directory to scan through
				if (file.isDirectory()) {
					directoryName = file.getName();
					files = new File(file.getAbsolutePath()).listFiles();
					output = "Directory: " + directoryName + " (" + files.length + " files)";
				}
				//call scan method
				scan();

			}

		}
	}
	/**
	 * Goes through each file
	 * Looks for patterns in each file
	 * Outputs found message if a pattern is found
	 * Showing the pattern and where in the file it is found
	 */
	@Test
	public void scan() {
		
		// Important to use a buffered input stream, since reading a single byte at a
		// time from file input stream would be very slow
		try {
			for (int i = 0; files.length > i; i++) {
				output = output + "\n\n Filename: " + files[i] + " : \n";
				InputStream inputStream = null;
				try {
					inputStream = new BufferedInputStream(new FileInputStream(files[i]));
				} catch (FileNotFoundException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				int next; // the most recently read byte from the file.

				// read each byte of the file (until the end of the file has been reached),
				// looking for any of the patterns
				try {
					int index1 = 0;
					int index2 = 0;
					int bytecount = 0;
					boolean empty = true;
					try {
						inputStream = new BufferedInputStream(new FileInputStream(files[i]));
					} catch (FileNotFoundException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
					bytecount = 0;
					for (int index = 0; patterns.size() > index; index++) {
						byteCounts.add(0);
					}
					while ((next = inputStream.read()) != -1) {
						byte nextByte = (byte) next; // convert the value read into an 8 bit byte
						bytecount++;
						//compares the next byte with the byte in patternABC array 
						//at the current index
						if (nextByte == patternABC[index1]) {
							//goes to the next index 
							index1++;
							//Checks if the current index value is the same as the array length
							if (index1 == patternABC.length) {
								//This means that  patternABC has been found
								String patternInHex = "";
								//converts byte back to hex
								for (int index = 0; patternABC.length > index; index++) {
									patternInHex = patternInHex + Integer.toHexString(patternABC[index]);
								}
								//Adds the pattern found to the output string
								output = output + "\n Pattern found: " + patternInHex + ", at offset: "
										+ (bytecount - patternABC.length) + " (0x"
										+ (Integer.toHexString(bytecount - patternABC.length)).toUpperCase() + ") within the file.";
								index1 = 0;
								empty = false;
							}
						} else {
							//resets index
							index1 = 0;
						}
						//compares the next byte with the byte in patternABC array 
						//at the current index
						if (nextByte == patternXYZ[index2]) {
							//goes to next index
							index2++;
							//Checks if the current index value is the same as the array length
							if (index2 == patternXYZ.length) {
								//This means that patternXYZ has been found
								String patternInHex = "";
								//converts byte back to hex
								for (int index = 0; patternXYZ.length > index; index++) {
									patternInHex = patternInHex + Integer.toHexString(patternXYZ[index]);
								}
								//Adds the pattern found to the output string
								output = output + "\n Pattern found:" + patternInHex + ", at offset: "
										+ (bytecount - patternXYZ.length) + " (0x"
										+ (Integer.toHexString(bytecount - patternXYZ.length)).toUpperCase() + ") within the file.";
								index2 = 0;
								empty = false;
							}
						} else {
							//resets the index
							index2 = 0;
						}
						//loops through the arrayList patterns 
						for (int index = 0; patterns.size() > index; index++) {
							int patternIndex = index;
							if (nextByte == patterns.get(patternIndex).get(byteCounts.get(patternIndex))) {
								//increases the index in the byteCounts array at index patternIndex by 1
								byteCounts.set(patternIndex, byteCounts.get(patternIndex) + 1);
								// checks if the index value in the arrray at index patternIndex is equal to the length of the patternArray
								if (byteCounts.get(patternIndex) == (patterns.get(patternIndex).size())) {
									//converts number back to hex
									String patternInHex = "";
									for (int hexIndex = 0; (patterns.get(patternIndex)).size() > hexIndex; hexIndex++) {
										if ((patterns.get(patternIndex).get(hexIndex)) < 0) {
											patternInHex = patternInHex
													+ Integer.toHexString((patterns.get(patternIndex).get(hexIndex)) + 256);
										} else {
											patternInHex = patternInHex
													+ Integer.toHexString(patterns.get(patternIndex).get(hexIndex));
										}
									}
									//adds pattern to output string
									output = output + "\n Pattern found: " + patternInHex + ", at offset: "
											+ (bytecount - (patterns.get(patternIndex).size())) + " (0x"
											+ (Integer.toHexString(bytecount - (patterns.get(patternIndex).size()))).toUpperCase()
											+ ") within the file.";
									byteCounts.set(patternIndex, 0);
									empty = false;
								}
							} else {
								//resets index to 0
								byteCounts.set(patternIndex, 0);
							}
						}
					}
					//if no patterns are found in the selected file 
					if (empty) {
						// error message is added to output string
						output = output + "\n No patterns found";
					}

				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}

				try {
					inputStream.close();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
		}
		catch(NullPointerException e) {
		}
		//Outputs the patterns found to the text area
		String outPut = output;
		patternTextArea.setText(outPut);
	}
	/**
	 * User selects pattern file
	 * Loops through file to get each pattern
	 * Checks if the pattern is valid
	 * If valid pattern is added to array list
	 * If not ignored
	 * Outputs the valid and invalid patterns to the text area
	 * 
	 */
	private class loadPatternListener implements ActionListener {
		@Test
		public void actionPerformed(ActionEvent event) {
			//clears arrayList patterns
			patterns.clear();
			// Create a file chooser and opens a dialog
			final JFileChooser fc = new JFileChooser();
			// returns the value of the file the user chooses
			int returnVal = fc.showOpenDialog(frame);
			// checks if a file has been opened in the file chooser
			if (returnVal == JFileChooser.APPROVE_OPTION) {
				// sets the file selected to 'file'
				file = fc.getSelectedFile();
				patternsLabel.setText(file.getAbsolutePath());
				patternTextArea.setText("");

				BufferedReader in;
				try {
					// tries to read the file
					in = new BufferedReader(new InputStreamReader(new FileInputStream(file), "UTF8"));
					// loops through each line of text in the file:
					String textLine;
					String patternsToSearch = "Patterns to search for: \n";
					String errors = "Invalid patterns: \n \n";
					//loops through each line in the text file
					while ((textLine = in.readLine()) != null) {
						//initializes array list patternArray
						List<Byte> patternArray = new ArrayList<Byte>();
						try {
							// Splits the line into three different strings
							splitText = textLine.split(" ");
							//loops through each element in the splitText array
							for (addPatternIndex = 0; splitText.length > addPatternIndex; addPatternIndex++) {
								//Checks  if the hex value is correct size (should be 2 digits)
								if (splitText[addPatternIndex].length() ==2) {
									//converts hex value to byte
									int decimal = Integer.parseInt(splitText[addPatternIndex], 16);
									//has to change decimal value as java works in twos complement
									//e.g. any decimal over 128 is actually a negative byte
									if (decimal >= 128) {
										bytes = (byte) (-256 + decimal);
									} else {
										bytes = (byte) (decimal);
									}
									//adds byte to patternArray
									patternArray.add(bytes);

								} else {
									//adds error message to string errors
									errors = errors + textLine + " because " + splitText[addPatternIndex]
											+ " is too big a value to fit a byte\n\n";
								}

							}
							patternsToSearch = patternsToSearch + "\n";
							//If all split text values are valid
							if (patternArray.size() == splitText.length) {
								//patternArray is added to patterns arrayList
								patterns.add(patternArray);
								patternsToSearch = patternsToSearch + textLine + "\n";
							}
							// checks if any of the three strings are empty
							// if they are then the strings aren't added to the arrayList
							// and the whole line is added to the errorList arrayList

						} catch (ArrayIndexOutOfBoundsException e) {
						} catch (NumberFormatException e1) {
							//adds error message if one of the split text values is invalid
							errors = errors + textLine + " because " + splitText[addPatternIndex] + " is an invalid char\n\n";
						}
					}
					if (errors.equals("Invalid patterns: \n \n")) {
						errors="";
					}
					//adds all the successful patterns loaded and the invalid patterns to the text area
					patternTextArea.setText(patternsToSearch+"\n There are "+patterns.size()+" valid patterns \n \n" + errors);
					//catch errors output to frame
				} catch (UnsupportedEncodingException e1) {
					JOptionPane.showMessageDialog(frame, "character coding is unsupported");

				} catch (FileNotFoundException e2) {
					JOptionPane.showMessageDialog(frame, "File not found");
				} catch (IOException e3) {
					JOptionPane.showMessageDialog(frame, "Input/Output exception occurred");
				}
			}
		}
	}

}

