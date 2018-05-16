fruit = input()
day = input()
quantity = float(input())

if day == "Monday" or day == "Tuesday" or day == "Wednesday" or day == "Thursday" or day == "Friday":
    if fruit == "banana":
        print(2.50 * quantity)
    elif fruit == "apple":
        print(1.20 * quantity)
    elif fruit == "orange":
        print(0.85 * quantity)
    elif fruit == "grapefruit":
        print(1.45 * quantity)
    elif fruit == "kiwi":
        print(2.70 * quantity)
    elif fruit == "pineapple":
        print(5.50 * quantity)
    elif fruit == "grapes":
        print(3.85 * quantity)
    else:
        print("Error")
elif day == "Saturday" or day == "Sunday":
    if fruit == "banana":
        print(2.70 * quantity)
    elif fruit == "apple":
        print(1.25 * quantity)
    elif fruit == "orange":
        print(0.90 * quantity)
    elif fruit == "grapefruit":
        print(1.60 * quantity)
    elif fruit == "kiwi":
        print(3.00 * quantity)
    elif fruit == "pineapple":
        print(5.60 * quantity)
    elif fruit == "grapes":
        print(4.20 * quantity)
    else:
        print("Error")
else:
    print("Error")