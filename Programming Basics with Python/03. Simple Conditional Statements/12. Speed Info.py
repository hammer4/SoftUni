speed = float(input())

if speed > 1000:
    print("extremely fast")
elif speed > 150:
    print("ultra fast")
elif speed > 50:
    print("fast")
elif speed > 10:
    print("average")
else:
    print("slow")