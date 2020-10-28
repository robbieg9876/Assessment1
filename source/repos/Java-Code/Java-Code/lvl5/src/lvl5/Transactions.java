package lvl5;

//********************************************************************
//Transactions.java       Java Foundations
//
//Demonstrates the creation and use of multiple Account objects.
//********************************************************************

public class Transactions
{
//-----------------------------------------------------------------
//  Creates some bank accounts and requests various services.
//-----------------------------------------------------------------
public static void main (String[] args)
{
  accountt acct1 = new accountt ("Ted Murphy", 72354, 25.59);
  accountt acct2 = new accountt ("Angelica Adams", 69713, 500.00);
  accountt acct3 = new accountt ("Edward Demsey", 93757, 769.32);

  acct1.deposit (44.10);  // return value ignored

  double adamsBalance = acct2.deposit (75.25);
  System.out.println ("Adams balance after deposit: " +
                      adamsBalance);

  System.out.println ("Adams balance after withdrawal: " + 
                      acct2.withdraw (480, 1.50));

  acct3.withdraw (-100.00, 1.50);  // invalid transaction

  acct1.addInterest();
  acct2.addInterest();
  acct3.addInterest();

  System.out.println ();
  System.out.println (acct1);
  System.out.println (acct2);
  System.out.println (acct3);
}
}
