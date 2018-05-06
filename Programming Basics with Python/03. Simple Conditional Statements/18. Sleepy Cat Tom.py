holidaysCount = int(input())

playTime = (365 - holidaysCount) * 63 + holidaysCount * 127

if playTime >= 30000:
    totalMinutes = playTime - 30000
    hours = totalMinutes // 60
    minutes = totalMinutes % 60
    print("Tom will run away")
    print(f"{hours} hours and {minutes} minutes more for play")
else:
    totalMinutes = 30000 - playTime
    hours = totalMinutes // 60
    minutes = totalMinutes % 60
    print("Tom sleeps well")
    print(f"{hours} hours and {minutes} minutes less for play")