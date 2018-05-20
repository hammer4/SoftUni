count = int(input())
oddSum = 0
evenSum = 0

if count == 0:
    print(f"OddSum={oddSum}, OddMin=No, OddMax=No, EvenSum={evenSum}, EvenMin=No, EvenMax=No")
elif count == 1:
    first = float(input())
    print(f"OddSum={first:g}, OddMin={first:g}, OddMax={first:g}, EvenSum={evenSum}, EvenMin=No, EvenMax=No")
else:
    first = float(input())
    oddMin = first
    oddMax = first
    oddSum += first

    second = float(input())
    evenMin = second
    evenMax = second
    evenSum += second

    for i in range(count - 2):
        current = float(input())
        if i % 2 == 0:
            oddSum += current
            if current > oddMax:
                oddMax = current
            if current < oddMin:
                oddMin = current
        else:
            evenSum += current
            if current > evenMax:
                evenMax = current
            if current < evenMin:
                evenMin = current

    print(f"OddSum={oddSum:g}, OddMin={oddMin:g}, OddMax={oddMax:g}, EvenSum={evenSum:g}, EvenMin={evenMin:g}, EvenMax={evenMax:g}")