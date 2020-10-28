<html>
   
   <head>
      <title>Sending HTML email using PHP</title>
   </head>
   
   <body>
      <h3>hello</h3>
      <?php
      print( "Hello");
// the message
$msg = "First line of text\nSecond line of text";

// use wordwrap() if lines are longer than 70 characters
$msg = wordwrap($msg,70);

// send email
$retval=mail("robbiegiles@hotmail.co.uk","My subject",$msg);
        
         
         if( $retval == true ) {
            echo "Message sent successfully...";
         }else {
            echo "Message could not be sent...";
         }
      ?>
      
   </body>
</html>