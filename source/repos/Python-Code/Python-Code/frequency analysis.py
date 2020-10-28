frequency_analysis = { "a" : 0,  "b" : 0,  "c" : 0,  "d" : 0,  "e" : 0,"f" : 0,  "g" : 0,
    "h" : 0,  "i" : 0,  "j" : 0,  "k" : 0,  "l" : 0,  "m" : 0,  "n" : 0,  "o" :   0,
    "p" : 0,  "q" : 0,  "r" : 0,  "s" : 0,  "t" : 0,  "u" : 0,  "v" : 0,  "w" : 0,
    "x" : 0,  "y" : 0,  "z" : 0 }
listing = []
lettersArray = ("e","a","t","n","i","r","o","s","h","l","c","d","g","u","w","p","b","f","y","n","k","v","x","z","j","q")
alphabetArray = 'abcdefghijklmnopqrstuvwxyz'
i=0
text = input("Please Enter text to decipher").lower()

for letter in text:

    if letter.isalpha():
        frequency_analysis[letter] += 1

def get_num (frequency_analysis):
    return frequency_analysis[1]


unsorted_items = frequency_analysis.items()
sorted_items = sorted(unsorted_items, key = get_num)

descending = reversed(sorted_items)
descending = list(descending)
inorder = list()
for char in descending:
    inorder.append(char)
print(inorder)
outtext=""
for key in inorder:

    if key[1] > 0:

        print (key)
i=0
while i<26:
    print(inorder[i],"is",lettersArray[i])
    i=i+1
i=0
for letter in text:
    if letter.isalpha():
        inorder[i]=lettersArray[i]
        i=i+1
print(inorder)
        
