import math

figureType = input()

area = 0

if figureType == "square":
    side = float(input())
    area = math.pow(side, 2)
elif figureType == "rectangle":
    sideA = float(input())
    sideB = float(input())
    area = sideA * sideB
elif figureType == "circle":
    radius = float(input())
    area = math.pi * math.pow(radius, 2)
elif figureType == "triangle":
    side = float(input())
    height = float(input())
    area = side * height / 2

if area % 1 == 0:
    print(f"{int(area)}")
else:
    areaStr = f"{area:.3f}"
    print(f"{float(areaStr)}")