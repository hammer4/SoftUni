fieldLength = int(input())
tileWidth = float(input())
tileLength = float(input())
benchWidth = int(input())
benchLength = int(input())

fieldArea = fieldLength * fieldLength
tileArea = tileLength * tileWidth
benchArea = benchLength * benchWidth

areaToCover = fieldArea - benchArea
countOfTiles = areaToCover / tileArea
totalTime = countOfTiles * 0.2

print(f"{countOfTiles:.2f}")
print(f"{totalTime:.2f}")