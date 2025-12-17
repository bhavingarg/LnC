def isArmstrong(number):
    # Initializing Sum and Number of Digits
    armstrongSum = 0
    numberOfDigits = 0

    # Calculating Number of individual digits
    tempNumber = number
    while tempNumber > 0:
        numberOfDigits = numberOfDigits + 1
        tempNumber = tempNumber // 10

    # Finding Armstrong Number
    tempNumber = number
    for i in range(1, tempNumber + 1):
        remainder = tempNumber % 10
        armstrongSum = armstrongSum + (remainder ** numberOfDigits)
        tempNumber //= 10
    return armstrongSum


# End of Function

# User Input
inputNumber = int(input("\nPlease Enter the Number to Check for Armstrong: "))

if (inputNumber == isArmstrong(inputNumber)):
    print("\n %d is Armstrong Number.\n" % inputNumber)
else:
    print("\n %d is Not a Armstrong Number.\n" % inputNumber)