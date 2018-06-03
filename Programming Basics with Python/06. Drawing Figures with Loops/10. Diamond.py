count = int(input())

for i in range(1, (count + 3) // 2):
    if (count + 1) // 2 >= i:
        if i == 1:
            if count % 2 == 0:
                print(f"{'-' * ((count - 2) // 2)}**{'-' * ((count - 2) // 2)}")
            else:
                print(f"{'-' * ((count - 1) // 2)}*{'-' * ((count - 1) // 2)}")
        else:
            if count % 2 == 0:
                print(f"{'-' * ((count - (i - 1) * 2 - 2) // 2)}*{'-' * ((i - 1) * 2)}*{'-' * ((count - (i - 1) * 2 - 2) // 2)}")
            else:
                print(f"{'-' * ((count - (i - 1) * 2 - 1) // 2)}*{'-' * ((i - 1) * 2 - 1)}*{'-' * ((count - (i - 1) * 2 - 1) // 2)}")

for i in range((count - 1) // 2, 0, -1):
    if (count + 1) // 2 >= i:
        if i == 1:
            if count % 2 == 0:
                print(f"{'-' * ((count - 2) // 2)}**{'-' * ((count - 2) // 2)}")
            else:
                print(f"{'-' * ((count - 1) // 2)}*{'-' * ((count - 1) // 2)}")
        else:
            if count % 2 == 0:
                print(f"{'-' * ((count - (i - 1) * 2 - 2) // 2)}*{'-' * ((i - 1) * 2)}*{'-' * ((count - (i - 1) * 2 - 2) // 2)}")
            else:
                print(f"{'-' * ((count - (i - 1) * 2 - 1) // 2)}*{'-' * ((i - 1) * 2 - 1)}*{'-' * ((count - (i - 1) * 2 - 1) // 2)}")