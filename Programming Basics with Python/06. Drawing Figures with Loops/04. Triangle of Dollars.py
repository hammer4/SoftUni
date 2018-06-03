count = int(input())

for i in range(count):
    print("$", end="")
    for j in range(i):
        print(" $", end="")
    print()