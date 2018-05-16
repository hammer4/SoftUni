budget = float(input())
season = input()

destination = ""
moneySpent = 0
place = ""

if budget > 1000:
    destination = "Europe"
    moneySpent = budget * 0.9
    place = "Hotel"
elif budget > 100:
    destination = "Balkans"
    if season == "summer":
        moneySpent = 0.4 * budget
        place = "Camp"
    elif season == "winter":
        moneySpent = 0.8 * budget
        place = "Hotel"
else:
    destination = "Bulgaria"
    if season == "summer":
        moneySpent = 0.3 * budget
        place = "Camp"
    elif season == "winter":
        moneySpent = 0.7 * budget
        place = "Hotel"

print(f"Somewhere in {destination}")
print(f"{place} - {moneySpent:.2f}")