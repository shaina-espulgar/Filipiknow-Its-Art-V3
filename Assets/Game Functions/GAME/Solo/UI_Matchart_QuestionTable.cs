using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UI_Matchart_QuestionTable : MonoBehaviour
{
    [Header("QuizLoader")] 
    [SerializeField] private QuizLoader quizLoader;
    [SerializeField] TextMeshProUGUI UI_CountDown; //[BAGARES] UI Object for the timer

    string question; //{BAGARES] MAybe reference for an array of questions, answers and choices saved in Quizloader.cs
    string[] choices;
    string[] answers;


    [SerializeField] private Button choiceAButton; public TextMeshProUGUI choiceA;
    [SerializeField] private Button choiceBButton; public TextMeshProUGUI choiceB;
    [SerializeField] private Button choiceCButton; public TextMeshProUGUI choiceC;
    [SerializeField] private Button choiceDButton; public TextMeshProUGUI choiceD;
    [SerializeField] private Button choiceEButton; public TextMeshProUGUI choiceE;
    [SerializeField] private Button choiceFButton; public TextMeshProUGUI choiceF;
    [SerializeField] private Button choiceGButton; public TextMeshProUGUI choiceG;
    [SerializeField] private Button choiceHButton; public TextMeshProUGUI choiceH;


    public string firstInput; //[BAGARES] Since MAtchart is a game that will match two words related, we need 2 variables for the input
    public string secondInput;
    bool isAtSecondOption;
    bool inputFinish;
    int indexForAnswer, indexForAnswer2;


    public int indexNumber;
    public int indexNumber_;
    System.Random random = new System.Random();

    public int questionNumber;

    float currentTime = 0f; //[BAGARES] float var, for the Timer 
    float startingTime = 10f;


    void Start()
    {
        questionNumber = 0;
        randomizingFunction();
        quizLoader.indexQuestion = indexNumber_;
        isAtSecondOption = false;
        inputFinish = false;
        currentTime = startingTime;
        UI_changeToWhiteButton();
    }


    //--- BELOW HERE will eventually be the product ---
    void Update()
    {
        //== Then assign a Question Type...

        quizLoader.LoadCSV("Matchart", "National Artist");
        choices = quizLoader.Choices;
        answers = quizLoader.Answers;
        question = quizLoader.Question;

        showTextInChoiceUI();
        checkingTheInput();

        UI_Timer(); // Shows the UI for the Timer
        Next();

    }

    void Previous()
    {
        quizLoader.indexQuestion--;
    }

    public void Next()
    {
        
        if (currentTime == 0)
        {
            randomizingFunction();

            disableEnableButton();
            Debug.Log("Buttons are now set to interactable");
            UI_changeToWhiteButton();

            isAtSecondOption = false;
            inputFinish = false;
            questionNumber += 1;

            quizLoader.indexQuestion = indexNumber_;

            currentTime = startingTime;
        }

    }

    //-- Need some code for not overpassing the value of indexQuestion to the no.of questions

    void Clear()
    {
        //---CLEAR THE LIST IF THE ROUND ENDED ---
        question = null;
        Array.Clear(choices, 0, choices.Length);
        Array.Clear(answers, 0, answers.Length);
    }

    void showTextInChoiceUI()
    {
        for (int i = 0; i != choices.Length; i++) //For showing the text asset from text Meshes in choice UI
        {
            if (i == 0)
            {
                choiceA.text = choices[i];
                //Debug.Log(i + " is choice A");
            }
            else if (i == 1)
            {
                choiceB.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 2)
            {
                choiceC.text = choices[i];
                //Debug.Log(i + " is choice Bc");
            }
            else if (i == 3)
            {
                choiceD.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 4)
            {
                choiceE.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 5)
            {
                choiceF.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 6)
            {
                choiceG.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 7)
            {
                choiceH.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else
            {
                Debug.Log("ERROR");
            }
        }
    }


    public void choiceButtonA_Input()
    {
        if(isAtSecondOption == false)
        {
            firstInput = choiceA.text;
            indexForAnswer = 0;
            isAtSecondOption = true;
            
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceA.text;
            indexForAnswer2 = 0;
            inputFinish = true;
            disableEnableButton();

        }
        
        

    }
    public void choiceButtonB_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceB.text;
            indexForAnswer = 1;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceB.text;
            indexForAnswer2 = 1;
            inputFinish = true;
            disableEnableButton();

        }
    }
    public void choiceButtonC_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceC.text;
            indexForAnswer = 2;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceC.text;
            indexForAnswer2 = 2;
            inputFinish = true;
            disableEnableButton();

        }
    }
    public void choiceButtonD_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceD.text;
            indexForAnswer = 3;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceD.text;
            indexForAnswer2 = 3;
            inputFinish = true;
            disableEnableButton();

        }
    }
    public void choiceButtonE_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceE.text;
            indexForAnswer = 4;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceE.text;
            indexForAnswer2 = 4;
            inputFinish = true;
            disableEnableButton();

        }
    }
    public void choiceButtonF_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceF.text;
            indexForAnswer = 5;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceF.text;
            indexForAnswer2 = 5;
            inputFinish = true;
            disableEnableButton();

        }
    }
    public void choiceButtonG_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceG.text;
            indexForAnswer = 6;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceG.text;
            indexForAnswer2 = 6;
            inputFinish = true;
            disableEnableButton();

        }
    }
    public void choiceButtonH_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceH.text;
            indexForAnswer = 7;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceH.text;
            indexForAnswer2 = 7;
            inputFinish = true;
            disableEnableButton();

        }
    }

    void UI_changeToWhiteButton()
    {
        choiceAButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceBButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceCButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceDButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceEButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceFButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceGButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceHButton.image.color = new Color(1f, 1f, 1f, 0.22f);

    }

    void UI_Timer() //[BAGARES] Function for the UI Timer in game (some errors exist when in separate script)
    {
        currentTime -= 1 * Time.deltaTime;
        UI_CountDown.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    void disableEnableButton()
    {
        choiceAButton.interactable = !choiceAButton.interactable;
        choiceBButton.interactable = !choiceBButton.interactable;
        choiceCButton.interactable = !choiceCButton.interactable;
        choiceDButton.interactable = !choiceDButton.interactable;
        choiceEButton.interactable = !choiceEButton.interactable;
        choiceFButton.interactable = !choiceFButton.interactable;
        choiceGButton.interactable = !choiceGButton.interactable;
        choiceHButton.interactable = !choiceHButton.interactable;

    }

    void checkingTheInput()
    {
        if (inputFinish == true)
        {
            if (answers[indexForAnswer] == "TRUE" && answers[indexForAnswer2] == "TRUE")
            {
                Debug.Log("PLAYER SCORE");
                inputFinish = false;

            }
            else
            {
                Debug.Log("Player not Score");
                inputFinish = false;
            }
        }
    }

    void randomizingFunction()
    {
        indexNumber = random.Next(0, 10);
        while(indexNumber % 2 == 0)
        {
            indexNumber = random.Next(0, 10);
            
        }
        indexNumber_ = indexNumber + 1;
        Debug.Log("The index Number is: " + indexNumber_);
    }
}
