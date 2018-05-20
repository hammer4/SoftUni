count = int(input())
max = int(input())

for i in range(count - 1):
    current = int(input())
    if current > max:
        max = current

print(max)