donors = {}
n = int(input("Ingrese la cantidad de donadores: "))

for i in range(n):
    name = input(f"Ingrese el nombre del donador {i+1}: ")
    age = int(input(f"Ingrese la edad de {name}: "))
    donation = float(input(f"Ingrese la cantidad donada por {name}: "))

    if age < 18:
        charity_donation = 600
    elif age < 60:
        charity_donation = 500
    elif age < 80:
        charity_donation = 300
    else:
        charity_donation = 800

    total_donation = donation + charity_donation
    donors[name] = {"Edad": age, "Donación": donation,
                    "Donación ONG": charity_donation, "Total donado": total_donation}

total_raised = sum(d["Total donado"] for d in donors.values())
avg_donation = total_raised / n

print("\n=== LISTA DE DONADORES ===")
for name, data in donors.items():
    print(f"{name} ({data['Edad']} años):")
    print(f" - Donación: ${data['Donación']}")
    print(f" - Donación ONG: ${data['Donación ONG']}")
    print(f" - Total donado: ${data['Total donado']}\n")

print(f"Total recaudado: ${total_raised}")
print(f"Promedio por donador: ${avg_donation:.2f}")

max_donation = max(donors.values(), key=lambda d: d["Total donado"])
print(f"Donador con mayor donación: {max_donation}")
