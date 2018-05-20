count = int(input())
min = int(input())

for i in range(count - 1):
    current = int(input())
    if current < min:
        min = current

print(min)