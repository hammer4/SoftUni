count = int(input())

print(f"+{' -' * (count - 2)} +")

for i in range(count - 2):
    print(f"|{' -' * (count - 2)} |")

print(f"+{' -' * (count - 2)} +")