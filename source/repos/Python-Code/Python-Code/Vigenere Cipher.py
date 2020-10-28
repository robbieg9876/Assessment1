inputmessage=input("Enter your message ") 
message=inputmessage.lower()
array1=[[""],[""],[""],[""],[""],[""],[""],[""],[""],[""],[""],[""],[""],[""],[""]]
array2=[[""],[""],[""],[""],[""],[""],[""],[""],[""],[""],[""],[""],[""],[""],[""]]
array1=list(array1)
array2=list(array2)
key=0 
key=str(input("Enter key"))
key=key.lower()
i=0
for symbol in key:
    array1[i]=symbol
    print(array1[i])
    i=i+1
k=i   
i=0
j=0
translated=""
finaloutput=""
choice= input("Would you like to decode or encode?")
if choice == "encode":
    for symbol in message:
        if j==k:
            j=0
        num1=ord(symbol)
        num2=ord(array1[j])
        num=num1+num2
        num=num-97
        i=i+1
        j=j+1
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
        if j==k:
            j=0
        num1=ord(symbol)
        num2=ord(array1[j])
        num=num1-num2
        num=num+97
        i=i+1
        j=j+1
        print(num)
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

