type = input()
rows = int(input())
columns = int(input())

totalPlaces = rows * columns
totalAmount = 0

if type == "Premiere":
    totalAmount = totalPlaces * 12
elif type == "Normal":
    totalAmount = totalPlaces * 7.50
elif type == "Discount":
    totalAmount = totalPlaces * 5

print(f"{totalAmount:.2f} leva")