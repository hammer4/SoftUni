time1 = int(input())
time2 = int(input())
time3 = int(input())

sum = time1 + time2 + time3

minutes = 0

if sum >= 120:
    minutes = 2
elif sum >= 60:
    minutes = 1

seconds = sum % 60

if seconds < 10:
    print(f"{minutes}:0{seconds}")
else:
    print(f"{minutes}:{seconds}")