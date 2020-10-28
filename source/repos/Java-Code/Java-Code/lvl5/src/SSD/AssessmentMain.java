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
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import javax.swing.ImageIcon;
import javax.swing.JButton;
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
import java.io.BufferedReader;
import java.io.InputStreamReader;






public class AssessmentMain  extends JPanel{


	JFrame frame;
	JLabel fileLabel;
	JLabel selectLabel;
	JLabel patternsLabel;
	JTextArea patternTextArea;
	public byte[] patternABC = new byte[] {0x41, 0x42, 0x43};
	public byte[] patternXYZ = new byte[] {0x58, 0x59, 0x5A};
	public ArrayList<List<Byte>> patterns=new ArrayList<List<Byte>>();
	public int value;
	public byte b;
	public int addPatternIndex;
	String[] splitText;
	String directoryName;
	String output="";
	File[] files;
	File file;
	//creates menu
	public JMenuBar setupMenu() {
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
		JMenuItem load = new JMenuItem("Scan File",iconLoad);
		load.setMnemonic(KeyEvent.VK_S); 
		//adds Load  item to the Help menu option
		file.add(load);
		//Creates action listener called loadListener and adds it to load
		ActionListener loadListener = new loadListener();
		load.addActionListener(loadListener);
		load.setAccelerator(KeyStroke.getKeyStroke('S', CTRL_DOWN_MASK));

		ImageIcon iconLoadPattern = new ImageIcon("C:\\Users\\robbi\\eclipse-workspace\\lvl5\\src\\GUI\\load.jpg");
		JMenuItem loadPattern = new JMenuItem("Load pattern file",iconLoadPattern);
		loadPattern.setMnemonic(KeyEvent.VK_L); 
		//adds Load  item to the Help menu option
		file.add(loadPattern);
		//Creates action listener called loadListener and adds it to load
		ActionListener loadPatternListener = new loadPatternListener();
		loadPattern.addActionListener(loadPatternListener);
		loadPattern.setAccelerator(KeyStroke.getKeyStroke('L', CTRL_DOWN_MASK));
		load.setToolTipText("Click this or press ctrl+l to load the scanner");
		exit.setToolTipText("Click this or press ctrl+e to exit the program");
		about.setToolTipText("Click this  or press ctrl+a to see info about the program");
		loadPattern.setToolTipText("Click this or press ctrl+p to load a pattern file");

		//returns menuBar to mainPanel class
		return menuBar;
	}
	AssessmentMain(){

		selectLabel = new JLabel("Current Patterns to look for:");
		//Creates label 'resultLabel'
		patternsLabel = new JLabel("");
		//add text field
		patternTextArea = new JTextArea(100,170);
		patternTextArea.setEditable(false);
		//adds combo, labels ,textFiled and buttons to frame
		add(selectLabel);
		add(patternsLabel);
		add(patternTextArea);
		// Creates button 'clearButton'


		//sets the frame size and background colour
		setPreferredSize(new Dimension(800, 80));
		setBackground(Color.YELLOW);



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
			fc.setMultiSelectionEnabled(true);
			fc.setFileSelectionMode(JFileChooser.FILES_AND_DIRECTORIES);
			//
			// disable the "All files" option.
			//
			//returns the value of the file the user chooses
			int returnVal = fc.showOpenDialog(frame);
			//checks if a file has been opened in the file chooser
			if (returnVal == JFileChooser.APPROVE_OPTION) {
				output="";
				//sets the file selected to 'file'
				files = fc.getSelectedFiles();
				Arrays.asList(files).forEach(x -> {
					if (x.isDirectory()) {
						directoryName=x.getName();
						files = new File(x.getAbsolutePath()).listFiles();
						output="Directory: "+directoryName+" ("+files.length+" files)";
					}
				});
				load();

			} 


		}
	}
	public void load() {
		// Important to use a buffered input stream, since reading a single byte at a time from file input stream would be very slow
		for (int i=0;files.length>i;i++) {
			output=output+"\n\n Filename: "+files[i]+" :";
			InputStream inputStream = null;
			try {
				inputStream = new BufferedInputStream(new FileInputStream(files[i]));
			} catch (FileNotFoundException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			int next; // the most recently read byte from the file.

			// read each byte of the file (until the end of the file has been reached), looking for any of the patterns
			try {
				int index1=0;
				int index2=0;
				int bytecount=0;
				boolean empty=true;

				while ((next = inputStream.read()) != -1) { 
					byte nextByte = (byte)next; //convert the value read into an 8 bit byte bytecount++;
					bytecount++;
					// compare value of 'nextByte' with the next byte within the pattern to be detected 
					if (nextByte == patternABC[index1]) {

						index1++; 
						if (index1==patternABC.length) { 
							String patternInHex="";
							for (int index=0;patternABC.length>index;index++) {
								patternInHex=patternInHex+Integer.toHexString(patternABC[index]);
							}
							output=output+"\n Pattern found: "+patternInHex+", at offset: "+(bytecount-patternABC.length)+" (0x"+Integer.toHexString(bytecount-patternABC.length)+") within the file.";
							index1=0; 
							empty=false; 
						} 
					} 
					else { 
						index1=0; 
					} 
					if (nextByte ==patternXYZ[index2]) {
						index2++; 
						if (index2==patternXYZ.length) {
							String patternInHex="";
							for (int index=0;patternXYZ.length>index;index++) {
								patternInHex=patternInHex+Integer.toHexString(patternXYZ[index]);
							}
							output=output+"\n Pattern found:"+patternInHex+", at offset: "+(bytecount-patternXYZ.length)+" (0x"+Integer.toHexString(bytecount-patternXYZ.length)+") within the file.";
							index2=0; 
							empty=false; 
						} 
					} 
					else { 
						index2=0; 
					}
				}

				for(int index =0;patterns.size()>index;index++) {
					int patternIndex=index;
					int byteIndex=0;
					bytecount=0;
					try {
						inputStream = new BufferedInputStream(new FileInputStream(files[i]));
					} catch (FileNotFoundException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
					while ((next = inputStream.read()) != -1) {
						byte nextByte = (byte)next;   // convert the value read into an 8 bit byte
						bytecount++;
						if(nextByte==patterns.get(patternIndex).get(byteIndex)) {
							byteIndex++;
							if (byteIndex==(patterns.get(patternIndex).size())){
								String patternInHex="";
								for (int hexIndex=0;(patterns.get(patternIndex)).size()>hexIndex;hexIndex++) {
									patternInHex=patternInHex+Integer.toHexString((patterns.get(patternIndex)).get(hexIndex));
									System.out.print(patternInHex+"\n");
								}
								output=output+ "\n Pattern found: "+patternInHex +", at offset: "+(bytecount-(patterns.get(patternIndex).size()))+" (0x"+Integer.toHexString(bytecount-(patterns.get(patternIndex).size()))+ ") within the file.";
								byteIndex=0;
								empty=false;
							}
						}
						else {
							byteIndex=0;
						}
					}
				}
				if(empty) {
					output=output+"\n No patterns found";
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
		String outPut=output;
		patternTextArea.setText(outPut);
	}

	private  class loadPatternListener implements ActionListener {
		public void actionPerformed(ActionEvent event) {
			patterns.clear();
			//Create a file chooser and opens a dialog
			final JFileChooser fc = new JFileChooser();
			//returns the value of the file the user chooses
			int returnVal = fc.showOpenDialog(frame);
			//checks if a file has been opened in the file chooser
			if (returnVal == JFileChooser.APPROVE_OPTION) {
				//sets the file selected to 'file'
				file = fc.getSelectedFile();
				patternsLabel.setText(file.getAbsolutePath());
				patternTextArea.setText("");
			}
			BufferedReader in;
			try {
				//tries to read the file
				in = new BufferedReader(
						new InputStreamReader(
								new FileInputStream(file), "UTF8"));
				//loops through each line of text in the file:
				String textLine;
				while ((textLine=in.readLine())!=null) {
					List<Byte> patternArray = new ArrayList<Byte>();
					try {
						//Splits the line into three different strings
						splitText = textLine.split(" ");
						
						for(addPatternIndex=0;splitText.length>addPatternIndex;addPatternIndex++) {
							if (splitText[addPatternIndex].length()==2) {
								int decimal=Integer.parseInt(splitText[addPatternIndex],16);
								if (decimal>=128) {
									b=(byte) (-256+decimal);
								}
								else {
									b=(byte)(decimal);
								}
								patternArray.add(b);

							}
							else {
								JOptionPane.showMessageDialog(frame,splitText[addPatternIndex]+"is too big a value to fit a byte");
							}



						}
						if (patternArray.size()==splitText.length) {
							patterns.add(patternArray);
						}
						//checks if any of the three strings are empty
						//if they are then the strings aren't added to the arrayList
						//and the whole line is added to the errorList arrayList

					}
					catch(ArrayIndexOutOfBoundsException e) {
						JOptionPane.showMessageDialog(frame,"Number >80");
					}
					catch(NumberFormatException e1) {
						JOptionPane.showMessageDialog(frame,"Invalid chars "+splitText[addPatternIndex]);
					}
				}

			}
			catch (UnsupportedEncodingException e1) {
				JOptionPane.showMessageDialog(frame,"character coding is unsupported");

			} catch (FileNotFoundException e2) {
				JOptionPane.showMessageDialog(frame,"File not found");
			} catch (IOException e3) {
				JOptionPane.showMessageDialog(frame,"Input/Output exception occurred");
			}
		}
	}
	
	
}
