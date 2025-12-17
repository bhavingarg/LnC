import random

def isNumber(number):
    if number.isdigit() and 1<= int(number) <=100:
        return True
    else:
        return False

def main():
    randomNumber = random.randint(1,100)
    correctAnswer = False
    userGuess = input("Guess a number between 1 and 100:")
    numberOfGuesses = 0
    while not correctAnswer:
        if not isNumber(userGuess):
            userGuess = input("I wont count this one Please enter a number between 1 to 100")
            continue
        else:
            numberOfGuesses += 1
            userGuess = int(userGuess)

        if userGuess < randomNumber:
            userGuess = input("Too low. Guess again")
        elif userGuess > randomNumber:
            userGuess = input("Too High. Guess again")
        else:
            print("You guessed it in",numberOfGuesses,"guesses!")
            correctAnswer = True


main()