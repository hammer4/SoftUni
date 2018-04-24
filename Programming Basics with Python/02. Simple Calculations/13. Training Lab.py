length = float(input()) * 100
width = float(input()) * 100

rows = length // 120
rowCapacity = (width - 100) // 70

places = int(rows * rowCapacity - 3)

print(places)