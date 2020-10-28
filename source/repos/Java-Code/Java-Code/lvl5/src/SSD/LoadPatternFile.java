package SSD;

import java.io.BufferedInputStream;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;

public class LoadPatternFile extends PatternScanner {
	public    void scan() {
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
				try {
					inputStream = new BufferedInputStream(new FileInputStream(files[i]));
				} catch (FileNotFoundException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				bytecount=0;
				for(int index=0;patterns.size()>index;index++) {
					byteCounts.add(0);
				}
				while ((next = inputStream.read()) != -1) {
					byte nextByte = (byte)next;   // convert the value read into an 8 bit byte
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
				for(int index =0;patterns.size()>index;index++) {
					int patternIndex=index;
					if(nextByte==patterns.get(patternIndex).get(byteCounts.get(patternIndex))) {
						byteCounts.set(patternIndex,byteCounts.get(patternIndex)+1);
							if (byteCounts.get(patternIndex)==(patterns.get(patternIndex).size())){
								String patternInHex="";
								for (int hexIndex=0;(patterns.get(patternIndex)).size()>hexIndex;hexIndex++) {
									if((patterns.get(patternIndex).get(hexIndex))<0) {
										patternInHex=patternInHex+Integer.toHexString((patterns.get(patternIndex).get(hexIndex))+256);
									}
									else {
										patternInHex=patternInHex+Integer.toHexString(patterns.get(patternIndex).get(hexIndex));
									}	
								}
								output=output+ "\n Pattern found: "+patternInHex +", at offset: "+(bytecount-(patterns.get(patternIndex).size()))+" (0x"+Integer.toHexString(bytecount-(patterns.get(patternIndex).size()))+ ") within the file.";
								byteCounts.set(patternIndex,0);
								empty=false;
							}
						}
						else {
							byteCounts.set(patternIndex,0);
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
}
