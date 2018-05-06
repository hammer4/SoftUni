import math

projectHours = int(input())
daysCount = int(input())
workersCount = int(input())

hoursCount = daysCount * 0.9 * 8
overtime = workersCount * daysCount * 2

totalHours = math.floor(hoursCount + overtime)

if totalHours < projectHours:
    print(f"Not enough time!{projectHours - totalHours} hours needed.")
else:
    print(f"Yes!{totalHours - projectHours} hours left.")