count = int(input())

print(f"{'*' * (count * 2)}{' ' * count}{'*' * (count * 2)}")

for i in range(count - 2):
    if i == (count - 1) // 2 - 1 :
        print(f"*{'/' * (count * 2 - 2)}*{'|' * count}*{'/' * (count * 2 - 2)}*")
    else:
        print(f"*{'/' * (count * 2 - 2)}*{' ' * count}*{'/' * (count * 2 - 2)}*")

print(f"{'*' * (count * 2)}{' ' * count}{'*' * (count * 2)}")