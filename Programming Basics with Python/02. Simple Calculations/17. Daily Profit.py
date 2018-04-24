workDaysInMonth = int(input())
dailyEarnings = float(input())
exchangeRate = float(input())

monthlyEarnings = workDaysInMonth * dailyEarnings
yearlyEarnings = monthlyEarnings * 12 + monthlyEarnings * 2.5
tax = yearlyEarnings * 0.25
netIncomeUsd = yearlyEarnings - tax
netIncomeBgn = netIncomeUsd * exchangeRate

dailyProfit = netIncomeBgn / 365
print(f"{dailyProfit:.2f}")