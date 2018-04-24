bitcoins = int(input())
iuans = float(input())
comission = float(input())

amountInLeva = bitcoins * 1168 + iuans * 0.15 * 1.76
amountInEvro = amountInLeva / 1.95

totalAmount = amountInEvro - amountInEvro * comission / 100

print(f"{totalAmount:.2f}")
