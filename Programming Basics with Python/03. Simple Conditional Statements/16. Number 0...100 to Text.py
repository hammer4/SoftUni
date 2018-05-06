List_of_numbers1to19 = ['one', 'two', 'three', 'four', 'five', 'six', 'seven',
                        'eight', 'nine', 'ten', 'eleven', 'twelve', 'thirteen',
                        'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen',
                        'nineteen']
List_of_numberstens = ['twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy',
                       'eighty', 'ninety']

number = int(input())

if number == 0:
    print("zero")
elif number == 100:
    print("one hundred")
elif number < 0 or number > 100:
    print("invalid number")

counter = 0

for i in range(19):
    counter += 1
    if counter == number:
        print(List_of_numbers1to19[i])

for i in range(20, 100):
    counter += 1

    if counter == number:
        if i%10 == 0:
            print(List_of_numberstens[i//10-2])
        else:
            print(List_of_numberstens[i//10-2] + ' ' + List_of_numbers1to19[i%10-1])