pricePerKgVegetable = float(input())
pricePerKgFruit = float(input())
vegetableAmount = float(input())
fruitAmount = float(input())

exchangeRate = 1.94

print((vegetableAmount * pricePerKgVegetable + fruitAmount * pricePerKgFruit) / exchangeRate)