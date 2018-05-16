budget = float(input())
type = input()
groupSize = int(input())

balance = budget

if groupSize >= 50:
    balance *= 0.75
elif groupSize >= 25:
    balance *= 0.60
elif groupSize >= 10:
    balance *= 0.50
elif groupSize >= 5:
    balance *= 0.40
elif groupSize >= 1:
    balance *= 0.25

if type == "Normal":
    balance -= groupSize * 249.99
elif type == "VIP":
    balance -= groupSize * 499.99

if balance >= 0:
    print(f"Yes! You have {balance:.2f} leva left.")
else:
    print(f"Not enough money! You need {abs(balance):.2f} leva.")