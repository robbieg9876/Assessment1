package lvl5;

public class cards {
   private final int MAX = 52; 

   private int faceValue; 

   public cards()
   {
      faceValue = 1;
   }
   public int select()
   {
      faceValue = (int)(Math.random() * MAX) + 1;

      return faceValue;
   }
   public String toString()
   {
      String result = Integer.toString(faceValue);

      return result;
   }
   public static void main(String args[]) {
	   boolean Selected=false;
	   	int Card1,CardNumber = 0;
	   	String suit,faceValue;
		cards card1 = new cards();
		int [] selected = new int[5];
		for (int index = 0; index < 5; index++)
		{
			Selected=true;
			Card1=card1.select();
			for (int index2 = 0; index2 < 5; index2++)
			{
				if (Card1==selected[index2]) {
						while (Selected) {
							Card1=card1.select();
							Selected=false;
						}
				}
			}
		if (Card1<=13) {
			suit="Diamonds";
			selected[index]=Card1;
			CardNumber=Card1;
		}
		else if(Card1<=26) {
			suit="Hearts";
			selected[index]=Card1;
			CardNumber=Card1-13;
		}
		else if(Card1<=39) {
			suit="Spades";
			selected[index]=Card1;
			CardNumber=Card1-26;
		}
		else {
			suit="Clubs";
			selected[index]=Card1;
			CardNumber=Card1-39;
		}
		if (CardNumber==1) {
			faceValue="Ace";
		}
		else if (CardNumber==11) {
			faceValue="Jack";
		}
		else if (CardNumber==12) {
			faceValue="Queen";
		}
		else if (CardNumber==13) {
			faceValue="King";
		}
		else {
			faceValue=Integer.toString(CardNumber);
		}
		System.out.println(faceValue+" of "+suit);
		
		}
	}
}
