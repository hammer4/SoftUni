import math

yearType = input()
holidaysInSofia = int(input())
weekendsInHomeTown = int(input())

totalWeekends = 48
totalGames = 0

weekendsInSofia = totalWeekends - weekendsInHomeTown
totalGames += weekendsInSofia * 3/4
totalGames += weekendsInHomeTown
totalGames += holidaysInSofia * 2/3

if yearType == "leap":
    totalGames *= 1.15

print(math.floor(totalGames))