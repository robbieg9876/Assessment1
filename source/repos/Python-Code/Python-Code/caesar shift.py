##  User defined Function
message=input("Enter your message ") ## Input is a built in function
key=0 ## Inialisation
key=int(input("Enter key")) ## Assignment statement
##    while key >26: ## Iteration and condional statement
##        key=int(input("Enter another key"))
 ## Parameter , argument
translated=""
finaloutput=""
for symbol in message:
    num=ord(symbol)
    num=num+key
    while num>122:
        num= num-26
    translated= translated+chr(num)
    translated=translated.upper()
    finaloutput=finaloutput+translated
print("Translated message is ",finaloutput)
## If statements are selection statements
