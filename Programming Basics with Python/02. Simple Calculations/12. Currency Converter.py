amount = float(input())
currencyFrom = input()
currencyTo = input()

amountInLeva = amount

if(currencyFrom == "USD"):
    amountInLeva *= 1.79549
elif(currencyFrom == "EUR"):
    amountInLeva *= 1.95583
elif(currencyFrom == "GBP"):
    amountInLeva *= 2.53405

output = amountInLeva

if(currencyTo == "USD"):
    output /= 1.79549
elif(currencyTo == "EUR"):
    output /= 1.95583
elif(currencyTo == "GBP"):
    output /= 2.53405

print(f"{output:.2f} {currencyTo}")

