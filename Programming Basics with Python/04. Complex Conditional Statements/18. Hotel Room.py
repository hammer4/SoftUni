month = input()
nightsCount = int(input())

apartmentPrice = 0
studioPrice = 0

if month == "May" or month == "October":
    apartmentPrice = nightsCount * 65
    studioPrice = nightsCount * 50
elif month == "June" or month == "September":
    apartmentPrice = nightsCount * 68.70
    studioPrice = nightsCount * 75.20
elif month == "July" or month == "August":
    apartmentPrice = nightsCount * 77
    studioPrice = nightsCount * 76

if nightsCount > 14 and (month == "May" or month == "October"):
    studioPrice *= 0.70
elif nightsCount > 7 and (month == "May" or month == "October"):
    studioPrice *= 0.95
elif nightsCount > 14 and (month == "June" or month == "September"):
    studioPrice *= 0.80

if nightsCount > 14:
    apartmentPrice *= 0.90

print(f"Apartment: {apartmentPrice:.2f} lv.")
print(f"Studio: {studioPrice:.2f} lv.")