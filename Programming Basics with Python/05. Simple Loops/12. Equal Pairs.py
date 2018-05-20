count = int(input())
previousSum = int(input()) + int(input())
maxDifference = 0

for i in range(count - 1):
    currentSum = int(input()) + int(input())

    if abs(previousSum - currentSum) > maxDifference:
        maxDifference = abs(previousSum - currentSum)

    previousSum = currentSum

if maxDifference == 0:
    print(f"Yes, value={previousSum}")
else:
    print(f"No, maxdiff={maxDifference}")