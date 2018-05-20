count = int(input())
evenSum = 0
oddSum = 0

for i in range(count):
    if i % 2 == 0:
        evenSum += int(input())
    else:
        oddSum += int(input())

if evenSum == oddSum:
    print(f"Yes Sum = {evenSum}")
else:
    print(f"No Diff = {abs(evenSum - oddSum)}")