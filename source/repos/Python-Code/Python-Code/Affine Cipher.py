inputmessage=input("Enter your message ") 
message=inputmessage.lower()
a=int(input("Enter A"))
b=int(input("Enter B"))
i=0
   
i=0
j=0
translated=""
finaloutput=""
choice= input("Would you like to decode or encode?")
if choice == "encode":
    for symbol in message:
        num1=ord(symbol)
        num1=num1-97
        num=(num1*a)+b
        num=num%26
        i=i+1
        j=j+1
        num=num+97
        print(num)
        while num>122:
            num= num-26
            print(num)
        translated=""
        translated= translated+chr(num)
        translated=translated.upper()
        finaloutput=finaloutput+translated
        print(finaloutput)
    print("Translated message is ",finaloutput)
else:
    for symbol in message:
        num1=ord(symbol)
        num1=num1-97
        MMI = lambda A, n,s=1,t=0,N=0: (n < 2 and t%N or MMI(n, A%n, t, s-A//n*t, N or n),-1)[n<1]
        num=MMI(a,26)
        num=num*(num1-b)
        num=num%26
        num=num+97    
        while num>122:
            num= num-26
            print(num)
        while num<97:
            num=num+26
        translated=""
        translated= translated+chr(num)
        translated=translated.upper()
        finaloutput=finaloutput+translated
        print(finaloutput)
    print("Translated message is ",finaloutput)

