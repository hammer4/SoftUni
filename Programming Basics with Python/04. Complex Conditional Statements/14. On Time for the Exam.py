import math

examHour = int(input())
examMinute = int(input())
studentHour = int(input())
studentMinute = int(input())

examMinutes = examHour * 60 + examMinute
studentMinutes = studentHour * 60 + studentMinute

difference = examMinutes - studentMinutes

minutes = abs(difference) % 60
if minutes < 10 and abs(difference) >= 60:
    minutes = f"0{minutes}"

hours = abs(difference) // 60

if 0 <= difference <= 30:
    print("On time")
    if difference != 0:
        print(f"{minutes} minutes before the start")
elif 30 < difference < 60:
    print("Early")
    print(f"{minutes} minutes before the start")
elif 60 <= difference:
    print("Early")
    print(f"{hours}:{minutes} hours before the start")
elif 0 > difference > -60:
    print("Late")
    print(f"{minutes} minutes after the start")
elif -60 >= difference:
    print("Late")
    print(f"{hours}:{minutes} hours after the start")