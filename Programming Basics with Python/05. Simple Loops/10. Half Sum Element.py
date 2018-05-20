count = int(input())
maxElement = int(input())
sum = maxElement

for i in range(count - 1):
    current = int(input())
    sum += current
    if current > maxElement:
        maxElement = current

sum -= maxElement

if sum == maxElement:
    print(f"Yes Sum = {sum}")
else:
    print(f"No Diff = {abs(sum - maxElement)}")