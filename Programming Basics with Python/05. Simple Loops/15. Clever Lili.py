years = int(input())
washingMachinePrice = float(input())
toyPrice = int(input())

savedMoney = 0

for i in range(1, years + 1):
    if i % 2 == 1:
        savedMoney += toyPrice
    else:
        savedMoney += i // 2 * 10 - 1

if savedMoney >= washingMachinePrice:
    print(f"Yes! {(savedMoney - washingMachinePrice):.2f}")
else:
    print(f"No! {(washingMachinePrice - savedMoney):.2f}")