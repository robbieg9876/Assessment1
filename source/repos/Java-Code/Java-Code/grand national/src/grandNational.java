import java.util.Random;
import java.util.stream.IntStream;

import javax.swing.JFrame;
import javax.swing.JOptionPane;

public class grandNational {
	public static void main(String[] args) {
		JFrame frame = null;
		String[] names= {"Robbie","Ben","Cath","Andrew G","Katie","Janet","Deric","Charlotte","Hannah","Vicki","Andy N","Chris","Emma","Jill","Campbell","Dave","Sammy","Allison","Fred","Graham","Robbie","Ben","Cath","Andrew G","Katie","Janet","Deric","Charlotte","Hannah","Vicki","Andy N","Chris","Emma","Jill","Campbell","Dave","Sammy","Allison","Fred","Graham"};
		String[] horses= {"Tiger Roll – Davy Russell","Bristol De Mai – Daryl Jacob","Aso – Charlie Deutsch","Elegant Escape – Jonjo O’Neill Jr.","Anibale Fly – Barry Geraghty","Top Ville Ben – Tom Dowson","Beware The Bear – Jerry McGrath","Peregrine Run – Kevin Sexton","Jett – Sam Waley-Cohen","Alpha Des Obeaux – Richard Johnson","Total Recall – Paul Townend",
				"The Storyteller – Keith Donoghue",
				"Magic Of Light – Robbie Power",
				"Talkischeap – Tom Cannon",
				"Yala Enki – Bryony Frost",
				"Ballyoptic – Sam Twiston-Davies",
				"Burrows Saint – Rachael Blackmore",
				"Definitly Red – Brian Hughes",
				"Sub Lieutenant – JJ Slevin",
				"Ok Corral – Derek O’Connor",
				"Tout Est Permis – Sean Flanagan",
				"Vintage Clouds – Danny Cook",
				"Crievehill – Tom Bellamy",
				"Lake View Lad – Henry Brooke",
				"Jury Duty – Mark Enright",
				"Pleasant Company – David Mullins",
				"Acapella Bourgeois – Danny Mullins",
				"Shattered Love – Lisa O’Neill",
				"Any Second Now – Mark Walsh",
				"Potters Corner – Jack Tudor",
				"Dounikos – Luke Dempsey",
				"Kildisart – Nico de Boinville",
				"Death Duty – Gavin Brouder",
				"Ramses De Teillee – Tom Scudamore",
				"Valtor – James Bowen",
				"Saint Xavier – David Maxwell",
				"Warriors Tale – Harry Cobden",
				"Double Shuffle – Jonathan Burke",
				"Kimberlite Candy – Richie McLernon",
				"Walk In The Mill – James Best"};
		
		Random r= new Random();
		String Horse="";
		for (String Name:names) {
			Horse="";
			while(Horse.equals("")) {
				int i =r.nextInt(40);
				 Horse=horses[i];
				 if (Horse.equals("")){
					 //
				 }
				 else {
					 //JOptionPane.showMessageDialog(frame, Name+"\n"+Horse+"\n");
					 System.out.print(Name+"\n"+Horse+"\n");
					 //System.out.print("\n\n\n\n\n");
					 horses[i]="";
					 
				 }
			}
		}
	}
}
