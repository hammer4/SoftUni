count = int(input())

divisible2 = 0
divisible3 = 0
divisible4 = 0

for i in range(count):
    currentNum = int(input())

    if currentNum % 2 == 0:
        divisible2 += 1
    if currentNum % 3 == 0:
        divisible3 += 1
    if currentNum % 4 == 0:
        divisible4 += 1

print(f"{(divisible2 / count * 100):.2f}%")
print(f"{(divisible3 / count * 100):.2f}%")
print(f"{(divisible4 / count * 100):.2f}%")