name = input("Enter your name: ")
watts = float(input("How many Watt/hr you have in your bill: "))

price = 50

if watts < 100 and watts > 0:
    price *= 1.2
elif watts > 99 and watts < 200:
    price *= 1.3
elif watts > 199 and watts < 300:
    price *= 1.3
elif watts >= 400:
    price *= 1.5
else:
    pass

print(f'{name} you have to pay {price}')
