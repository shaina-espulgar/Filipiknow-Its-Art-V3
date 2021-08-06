using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_SwitchArt_QuestionTable : MonoBehaviour
{
    //[Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader; //[BAGARES] Reference for the quizloader script 
    [SerializeField] TextMeshProUGUI UI_CountDown; //[BAGARES] UI Object for the timer

    string question; //{BAGARES] MAybe reference for an array of questions, answers and choices saved in Quizloader.cs
    string[] choices;
    string[] answers;

    float isItNextQuestion; //[BAGARES] bool var for checking to change to another question (unused for now)


    [SerializeField] private Button choiceAButton; public TextMeshProUGUI choiceA;
    [SerializeField] private Button choiceBButton; public TextMeshProUGUI choiceB;
    [SerializeField] private Button choiceCButton; public TextMeshProUGUI choiceC;
    [SerializeField] private Button choiceDButton; public TextMeshProUGUI choiceD;

    public string playerInput;
    public int indexNumber; // [BAGARES] int var for changing the indexer variable from quizloader
    public TextMeshProUGUI QuestionText; //[BAGARES] Reference for the Text in Question UI

    float currentTime = 0f; //[BAGARES] float var, for the Timer 
    float startingTime = 10f;

    void Start()
    {
        currentTime = startingTime;
        UI_changeToWhiteButton();
    }


    //--- BELOW HERE will eventually be the product ---
    void Update()
    {
        //== Then assign a Question Type...
        quizLoader.LoadCSV("Switchart", "National Artist");

        choices = quizLoader.Choices;
        answers = quizLoader.Answers;
        question = quizLoader.Question;

        showTextInQuestionUI();
        showTextInChoiceUI();

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

            choiceAButton.interactable = !choiceAButton.interactable;
            choiceBButton.interactable = !choiceBButton.interactable;
            choiceCButton.interactable = !choiceCButton.interactable;
            choiceDButton.interactable = !choiceDButton.interactable;
            UI_changeToWhiteButton();

            indexNumber += 1;
            quizLoader.indexQuestion = indexNumber;

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
        choiceAButton.interactable = !choiceAButton.interactable;
        choiceBButton.interactable = !choiceBButton.interactable;
        choiceCButton.interactable = !choiceCButton.interactable;
        choiceDButton.interactable = !choiceDButton.interactable;
        Debug.Log("Choice Buttons are set to !interactable");
    }
    public void choiceButtonB_Input()
    {
        playerInput = choiceB.text;
        Debug.Log("Choice B");
        choiceBButton.GetComponent<Image>().color = Color.red;
        choiceAButton.interactable = !choiceAButton.interactable;
        choiceBButton.interactable = !choiceBButton.interactable;
        choiceCButton.interactable = !choiceCButton.interactable;
        choiceDButton.interactable = !choiceDButton.interactable;
        Debug.Log("Choice Buttons are set to !interactable");
    }
    public void choiceButtonC_Input()
    {
        playerInput = choiceC.text;
        Debug.Log("Choice C");
        choiceCButton.GetComponent<Image>().color = Color.red;
        choiceAButton.interactable = !choiceAButton.interactable;
        choiceBButton.interactable = !choiceBButton.interactable;
        choiceCButton.interactable = !choiceCButton.interactable;
        choiceDButton.interactable = !choiceDButton.interactable;
        Debug.Log("Choice Buttons are set to !interactable");
    }
    public void choiceButtonD_Input()
    {
        playerInput = choiceD.text;
        Debug.Log("Choice D");
        choiceDButton.GetComponent<Image>().color = Color.red;
        choiceAButton.interactable = !choiceAButton.interactable;
        choiceBButton.interactable = !choiceBButton.interactable;
        choiceCButton.interactable = !choiceCButton.interactable;
        choiceDButton.interactable = !choiceDButton.interactable;
        Debug.Log("Choice Buttons are set to !interactable");
    }

    void UI_changeToWhiteButton()
    {
        choiceAButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceBButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceCButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceDButton.image.color = new Color(1f, 1f, 1f, 0.22f);

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
}
