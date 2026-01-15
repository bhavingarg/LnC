import random
def rollDice(faces):
    rolledNumber = random.randint(1, faces)
    return rolledNumber


def main():
    faces = 6
    isRolling = True
    while isRolling:
        userInput =input("Ready to roll? Enter Q to Quit")
        if userInput.lower() !="q":
            rolledNumber = rollDice(faces)
            print("You have rolled a",rolledNumber)
        else:
            isRolling = False