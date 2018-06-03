count = int(input())

for i in range(count + 1):
    print(f"{' ' * (count - i)}{'*' * i} | {'*' * i}")