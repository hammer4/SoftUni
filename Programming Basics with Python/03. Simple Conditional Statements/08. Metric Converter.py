distance = float(input())
inputUnit = input()
outputUnit = input()

mm = 1000
cm = 100
mi = 0.000621371192
inches = 39.3700787
km = 0.001
ft = 3.2808399
yd = 1.0936133

distanceInMeters = 0

if inputUnit == "mm":
    distanceInMeters = distance / mm
elif inputUnit == "cm":
    distanceInMeters = distance / cm
elif inputUnit == "mi":
    distanceInMeters = distance / mi
elif inputUnit == "in":
    distanceInMeters = distance / inches
elif inputUnit == "km":
    distanceInMeters = distance / km
elif inputUnit == "ft":
    distanceInMeters = distance / ft
elif inputUnit == "yd":
    distanceInMeters = distance / yd
elif inputUnit == "m":
    distanceInMeters = distance

distanceOutput = 0

if outputUnit == "mm":
    distanceOutput = distanceInMeters * mm
elif outputUnit == "cm":
    distanceOutput = distanceInMeters * cm
elif outputUnit == "mi":
    distanceOutput = distanceInMeters * mi
elif outputUnit == "in":
    distanceOutput = distanceInMeters * inches
elif outputUnit == "km":
    distanceOutput = distanceInMeters * km
elif outputUnit == "ft":
    distanceOutput = distanceInMeters * ft
elif outputUnit == "yd":
    distanceOutput = distanceInMeters * yd
elif outputUnit == "m":
    distanceOutput = distanceInMeters

print(f"{distanceOutput} {outputUnit}")