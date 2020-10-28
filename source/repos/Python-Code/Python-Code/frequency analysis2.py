
def freq_analysis(message):
    message=input("Enter a message")
    alphabet = ['a','b','c','d','e','f','g','h','i','j','k','l','m',
                'n','o','p','q','r','s','t','u','v','w','x','y','z']
    # builds empty count_list ([0,0,0...0,0])
    count_list = []
    i = 0
    while i < 26:
        count_list.append(0)
        i += 1
    # converts message string to array
    array = []
    for i in message:
        array.append(i)
    n = len(array) + 0.0
    # counts occurences of each letter
    for x in array:
        i = 0
        while i < 26:
            if x == alphabet[i]:
                count_list[i] += 1
            i += 1
    # normalizes frequencies
    freq_list = []
    for x in count_list:
        freq_list.append(x/n)
    return freq_list



#Tests

print freq_analysis("abcd")
#>>> [0.25, 0.25, 0.25, 0.25, 0.0, ..., 0.0]

print freq_analysis("adca")
#>>> [0.5, 0.0, 0.25, 0.25, 0.0, ..., 0.0]

print freq_analysis('bewarethebunnies')
#>>> [0.0625, 0.125, 0.0, 0.0, ..., 0.0]
