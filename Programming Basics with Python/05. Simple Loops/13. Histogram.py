count = int(input())

count1 = 0
count2 = 0
count3 = 0
count4 = 0
count5 = 0

for i in range(count):
    currentNum = int(input())

    if currentNum >= 800:
        count5 += 1
    elif currentNum >= 600:
        count4 += 1
    elif currentNum >= 400:
        count3 += 1
    elif currentNum >= 200:
        count2 += 1
    else:
         count1 += 1

print(f"{(count1 / count * 100):.2f}%")
print(f"{(count2 / count * 100):.2f}%")
print(f"{(count3 / count * 100):.2f}%")
print(f"{(count4 / count * 100):.2f}%")
print(f"{(count5 / count * 100):.2f}%")