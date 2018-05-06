distance = int(input())
period = input()

taxiInitialPrice = 0.7
taxiDayTariff = 0.79
taxiNightTariff = 0.9
busPricePerKm = 0.09
trainPricePerKm = 0.06

if distance >= 100:
    print(trainPricePerKm * distance)
elif distance >= 20:
    print(busPricePerKm * distance)
else:
    if period == "day":
        print(taxiInitialPrice + taxiDayTariff * distance)
    else:
        print(taxiInitialPrice + taxiNightTariff * distance)