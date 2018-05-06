import math

vineyardArea = int(input())
grapesPerSqM = float(input())
wineLitersNeeded = int(input())
workersCount = int(input())

grapesForWineAmount = vineyardArea * 0.4 * grapesPerSqM
producedWineAmount = grapesForWineAmount / 2.5

if producedWineAmount < wineLitersNeeded:
    print(f"It will be a tough winter! More {math.floor(wineLitersNeeded - producedWineAmount)} liters wine needed.")
else:
    print(f"Good harvest this year! Total wine: {math.floor(producedWineAmount)} liters.")
    print(f"{math.ceil(producedWineAmount - wineLitersNeeded)} liters left -> {math.ceil((producedWineAmount - wineLitersNeeded) / workersCount)} liters per person.")