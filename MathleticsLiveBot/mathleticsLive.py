from selenium import webdriver
#from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.firefox.options import Options
import time

def select_diffculty():
    while (True):
        try:
            diffculty = int(input("Enter Mathletics Live Diffculty Here: "))
            if(diffculty >= 1 and diffculty <= 4):
                return diffculty
            else:
                print("[ERROR]: Please enter a number between 1 & 4")
        except:
            print("[ERROR]: An exception has occured, please enter a number between 1 & 4")

def number_of_questions():
    while (True):
        try:
            numberOfQuestions = int(input("Enter Number Of Questions To Solve Here: "))
            if(numberOfQuestions >= 0):
                return  numberOfQuestions
        except:
            print("[ERROR]: An exception has occured, please enter a number greater than or equal to 0")

def eval_question(driver):
    questionString = driver.find_element_by_xpath("//div[@class='questions-text-alignment whiteTextWithShadow question-size-v4']").text
    questionString = questionString.replace('×', '*').replace('÷', '/')
    questionArray = questionString.split(' ')
    returnEval = 0
    questionAssembled = ""

    #Is either fill in the blanks or evaluate question try does fill in blank whilst catch does evaluation based on last value.
    try:
        int(questionArray[len(questionArray) - 1])
        for i in reversed(questionArray):
            if(i == "*" or i == "/" or i == "+" or i == "-"):
                if(i == "*"):
                    questionAssembled += "/"
                elif(i == "/"):
                    questionAssembled += "*"
                elif(i == "+"):
                    questionAssembled += "-"
                elif(i == "-"):
                    questionAssembled += "+"
                else:
                    questionAssembled += ""
            else:
                questionAssembled += i

        questionAssembled = questionAssembled.replace('=', '')
        print("[QUESTION]: {0}".format(questionAssembled))
        returnEval = eval(questionAssembled)
    except:
        questionAssembled = questionString.replace('=', '')

        #Level 4 mathletics live adds worded half number questions
        if(questionArray[0] == "Half" and questionArray[1] == "of"):
            questionAssembled = "{0} / 2".format(questionArray[2])

        print("[QUESTION]: {0}".format(questionAssembled))
        returnEval = eval(questionAssembled)

    return str(returnEval)

def main():
    options = Options()
    options.headless = False

    print("[INFO]: Running")

    userName = input("Enter Mathletics Username Here: ")
    password = input("Enter Mathletics Password Here: ")
    diffculty = select_diffculty()
    numberOfQuestions = number_of_questions()

    driver = webdriver.Firefox(options=options)
    driver.get("https://login.mathletics.com/")

    usr = driver.find_element_by_id("username")
    passwd = driver.find_element_by_id("password")
    usr.send_keys(userName)
    passwd.send_keys(password)
    time.sleep(0.5)

    login_form = driver.find_element_by_xpath("//button[text()='Sign In']")
    login_form.click()

    time.sleep(10) #Got to find way to wait for website to load instead of sleep
    playMathleticsLive = driver.find_element_by_xpath("//div[@title='Play Live Mathletics']")
    playMathleticsLive.click()

    time.sleep(5) #Got to find way to wait for website to load instead of sleep
    openMathleticsLive = driver.find_element_by_xpath("//img[@class='game-thumbnail']")
    openMathleticsLive.click()

    time.sleep(3)
    try:
        diffcultyButton = driver.find_element_by_xpath("//button[@ng-class='levelItem.buttonStyle' and text()='{0}']".format(" " + str(diffculty) + " ")) #Finish way to fix
        diffcultyButton.click()
    except:
        print("[INFO]: Level Already Chosen")

    time.sleep(0.5) #Got to find way to wait for website to load instead of sleep
    goMathleticsLive = driver.find_element_by_xpath("//button[@quick-touch='goBtnClick()']")
    goMathleticsLive.click()

    time.sleep(6)

    for i in range(0, numberOfQuestions):
        questionString = driver.find_element_by_xpath("//div[@class='questions-text-alignment whiteTextWithShadow question-size-v4']")
        inputBox = driver.find_element_by_xpath("//input[@ng-model='innerAnswerInput']")

        inputBox.send_keys(eval_question(driver))
        time.sleep(0.1)
        inputBox.send_keys(Keys.ENTER)

    print("[INFO]: Those kids got wrecked... lol")
    time.sleep(20)
    driver.close()

if(__name__ == "__main__"):
    main()
