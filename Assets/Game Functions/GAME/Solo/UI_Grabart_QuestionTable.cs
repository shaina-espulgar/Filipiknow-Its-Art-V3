using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UI_Grabart_QuestionTable : MonoBehaviour
{
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
    [SerializeField] private Button choiceIButton; public TextMeshProUGUI choiceI;
    [SerializeField] private Button choiceJButton; public TextMeshProUGUI choiceJ;
    [SerializeField] private Button choiceKButton; public TextMeshProUGUI choiceK;
    [SerializeField] private Button choiceLButton; public TextMeshProUGUI choiceL;


    public string playerInput; 
    public int indexNumber;
    public int indexNumber_;//[BAGARES] int var for changing the indexer variable from quizloader
    public TextMeshProUGUI QuestionText; //[BAGARES] Reference for the Text in QUestion UI
    bool inputFinish;
    int indexForAnswer;
    public int questionNumber;
    System.Random random = new System.Random();

    float currentTime = 0f; //[BAGARES] float var, for the Timer 
    float startingTime = 10f;


    void Start()
    {
        inputFinish = false;
        randomizingFunction();
        questionNumber = 0;
        quizLoader.indexQuestion = indexNumber_;
        currentTime = startingTime;
        UI_changeToWhiteButton();

    }


    //--- BELOW HERE will eventually be the product ---
    void Update()
    {
        //== Then assign a Question Type...
        quizLoader.LoadCSV("Grabart", "National Artists");

        choices = quizLoader.Choices;
        answers = quizLoader.Answers;
        question = quizLoader.Question;

        showTextInQuestionUI();
        showTextInChoiceUI();

        UI_Timer(); // Shows the UI for the Timer
        checkingTheInput();
        Next();

    }

    public void Next()
    {
        if (currentTime == 0)
        {
           
            disableEnableButton();
            UI_changeToWhiteButton();

            randomizingFunction();
            questionNumber += 1; 
            quizLoader.indexQuestion = indexNumber_;
            Debug.Log(choiceA.text + " is the new text");

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
            else if (i == 8)
            {
                choiceI.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 9)
            {
                choiceJ.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 10)
            {
                choiceK.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 11)
            {
                choiceL.text = choices[i];
                //Debug.Log(i + " is choice B");
            }

            else
            {
                Debug.Log("ERROR");
            }
        }
    }

    void showTextInQuestionUI()
    {
        QuestionText.text = question;
    }

    public void choiceButtonA_Input()
    {
        playerInput = choiceA.text;
        Debug.Log("Choice A: " + playerInput);
        choiceAButton.GetComponent<Image>().color = Color.red;

        disableEnableButton();
        Debug.Log("Choice Buttons are set to !interactable");
        indexForAnswer = 0;
        inputFinish = true;
    }
    public void choiceButtonB_Input()
    {
        playerInput = choiceB.text;
        choiceBButton.GetComponent<Image>().color = Color.red;

        disableEnableButton();
        Debug.Log("Choice Buttons are set to !interactable");
        indexForAnswer = 1;
        inputFinish = true;
    }
    public void choiceButtonC_Input()
    {
        playerInput = choiceC.text;
        choiceCButton.GetComponent<Image>().color = Color.red;

        disableEnableButton();
        Debug.Log("Choice Buttons are set to !interactable");
        indexForAnswer = 2;
        inputFinish = true;
    }
    public void choiceButtonD_Input()
    {
        playerInput = choiceD.text;
        choiceDButton.GetComponent<Image>().color = Color.red;

        disableEnableButton();
        Debug.Log("Choice Buttons are set to !interactable");
        indexForAnswer = 3;
        inputFinish = true;
    }
    public void choiceButtonE_Input()
    {
        playerInput = choiceE.text;
        choiceEButton.GetComponent<Image>().color = Color.red;

        disableEnableButton();
        Debug.Log("Choice Buttons are set to !interactable");
        indexForAnswer = 4;
        inputFinish = true;
    }
    public void choiceButtonF_Input()
    {
        playerInput = choiceF.text;
        choiceFButton.GetComponent<Image>().color = Color.red;

        disableEnableButton();
        Debug.Log("Choice Buttons are set to !interactable");
        indexForAnswer = 5;
        inputFinish = true;
    }
    public void choiceButtonG_Input()
    {
        playerInput = choiceG.text;
        choiceGButton.GetComponent<Image>().color = Color.red;

        disableEnableButton();
        Debug.Log("Choice Buttons are set to !interactable");
        indexForAnswer = 6;
        inputFinish = true;
    }
    public void choiceButtonH_Input()
    {
        playerInput = choiceH.text;
        choiceHButton.GetComponent<Image>().color = Color.red;

        disableEnableButton();
        Debug.Log("Choice Buttons are set to !interactable");
        indexForAnswer = 7;
        inputFinish = true;
    }
    public void choiceButtonI_Input()
    {
        playerInput = choiceI.text;
        choiceIButton.GetComponent<Image>().color = Color.red;

        disableEnableButton();
        Debug.Log("Choice Buttons are set to !interactable");
        indexForAnswer = 8;
        inputFinish = true;
    }
    public void choiceButtonJ_Input()
    {
        playerInput = choiceJ.text;
        choiceJButton.GetComponent<Image>().color = Color.red;

        disableEnableButton();
        Debug.Log("Choice Buttons are set to !interactable");
        indexForAnswer = 9;
        inputFinish = true;
    }
    public void choiceButtonK_Input()
    {
        playerInput = choiceK.text;
        choiceKButton.GetComponent<Image>().color = Color.red;

        disableEnableButton();
        Debug.Log("Choice Buttons are set to !interactable");
        indexForAnswer = 10;
        inputFinish = true;
    }
    public void choiceButtonL_Input()
    {
        playerInput = choiceL.text;
        choiceLButton.GetComponent<Image>().color = Color.red;

        disableEnableButton();
        Debug.Log("Choice Buttons are set to !interactable");
        indexForAnswer = 11;
        inputFinish = true;
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
        choiceIButton.interactable = !choiceIButton.interactable;
        choiceJButton.interactable = !choiceJButton.interactable;
        choiceKButton.interactable = !choiceKButton.interactable;
        choiceLButton.interactable = !choiceLButton.interactable;
        
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
        choiceIButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceJButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceKButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceLButton.image.color = new Color(1f, 1f, 1f, 0.22f);

    }
    void checkingTheInput()
    {
        if (inputFinish == true)
        {
            if (answers[indexForAnswer] == "TRUE")
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
        while (indexNumber % 2 == 0)
        {
            indexNumber = random.Next(0, 10);

        }
        indexNumber_ = indexNumber + 1;
        Debug.Log("The index Number is: " + indexNumber_);
    }
}
