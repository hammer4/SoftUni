count = int(input())
leftSum = 0
rightSum = 0

for i in range(count):
    leftSum += int(input())

for i in range(count):
    rightSum += int(input())

if leftSum == rightSum:
    print(f"Yes, sum = {leftSum}")
else:
    print(f"No, diff = {abs(leftSum - rightSum)}")