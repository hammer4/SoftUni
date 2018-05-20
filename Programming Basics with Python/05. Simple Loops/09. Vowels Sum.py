string = input()
sum = 0

for i in range(len(string)):
    if string[i] == "a":
        sum += 1
    elif string[i] == "e":
        sum += 2
    elif string[i] == "i":
        sum += 3
    elif string[i] == "o":
        sum += 4
    elif string[i] == "u":
        sum += 5

print(sum)