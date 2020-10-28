package GUI;

//********************************************************************
//PushCounter.java       Java Foundations
//
//Demonstrates a graphical user interface and an event listener.
//********************************************************************

import javax.swing.JFrame;

public class exitExample2
{
//-----------------------------------------------------------------
//Creates and displays the main program frame.
//-----------------------------------------------------------------
public static void main(String[] args)
{
JFrame frame = new JFrame("Push Counter");
frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

exitExample panel = new  exitExample();
frame.getContentPane().add(panel);

frame.pack();
frame.setVisible(true);
}
}
