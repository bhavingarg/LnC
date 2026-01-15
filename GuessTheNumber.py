import random

MIN_NUMBER = 1
MAX_NUMBER = 100


def isValidNumber(number):
    return number.isdigit() and MIN_NUMBER <= int(number) <= MAX_NUMBER

def main():
    randomNumber = random.randint(1,100)
    correctAnswer = False
    userGuess = input("Guess a number between 1 and 100:")
    numberOfGuesses = 0
    while not correctAnswer:
        if not isValidNumber(userGuess):
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