using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;
using TMPro;

public class UI_Classifyart_QuestionTable : MonoBehaviour
{
    //[Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader; //[BAGARES] Reference for the quizloader script 
    [SerializeField] private CSV_Questionnaire_Classifyart CLASSIFY_ART;
    [SerializeField] TextMeshProUGUI UI_CountDown; //[BAGARES] UI Object for the timer

    string question; //{BAGARES] MAybe reference for an array of questions, answers and choices saved in Quizloader.
    string[] choices;
    string[] answers;

    bool inputFinish;
    bool addToDictionary;

    [SerializeField] private Button choiceAButton; public TextMeshProUGUI choiceA; 
    [SerializeField] private Button choiceBButton; public TextMeshProUGUI choiceB; 
    [SerializeField] private Button choiceCButton; public TextMeshProUGUI choiceC;
    [SerializeField] private Button choiceDButton; public TextMeshProUGUI choiceD;
    [SerializeField] private Button topicAButton; public TextMeshProUGUI topicA;
    [SerializeField] private Button topicBButton; public TextMeshProUGUI topicB;
    

    public string playerInput; //variable for First Chocie of the player to get the key.
    public string playerInput2; // Second choice of the player to get the string.
    public int indexNumber; // [BAGARES] int var for changing the indexer variable from quizloader
    public int questionNumber;


    public Dictionary<string, CSV_Questionnaire_Classifyart> ChoicesAnswersDictionary 
            = new Dictionary<string, CSV_Questionnaire_Classifyart>();

    float currentTime = 0f; //[BAGARES] float var, for the Timer 
    float startingTime = 10f;

    int randomNumForChoiceText;

    void Start()
    {
        questionNumber = 0;

        System.Random random = new System.Random();
        currentTime = startingTime;
        randomNumForChoiceText = random.Next(0,2);
        UI_changeToWhiteButton();

        disableEnableTopicButton();

        addToDictionary = true;
        inputFinish = false;

        Debug.Log("Random number for text is: " + randomNumForChoiceText);
    }
    //--- BELOW HERE will eventually be the product ---
    private void Update()
    {
        quizLoader.LoadCSV("Classifyart", "National Artist");
        choices = quizLoader.Choices; //<choices>
        answers = quizLoader.Answers; //<topics>

        Add_Array_In_Dictionary();
        showTextInChoiceUI();
        showTextInTopicUI();
        checkingTheInput();
        UI_Timer();

        Next();



    }
    void Add_Array_In_Dictionary()
    {
        if(addToDictionary == true)
        {

            CSV_Questionnaire_Classifyart[] classifyart = {
            new CSV_Questionnaire_Classifyart(choices[0], answers[0]), // The Key should be the answer and the string should be the topic thar refers to answer.
            new CSV_Questionnaire_Classifyart(choices[1], answers[0]),
            new CSV_Questionnaire_Classifyart(choices[2], answers[1]),
            new CSV_Questionnaire_Classifyart(choices[3], answers[1])
            };



            foreach (CSV_Questionnaire_Classifyart x in classifyart)
            {
                ChoicesAnswersDictionary.Add(x.Answers, x); //x.Answers here are the choices[x]

            }
            //CSV_Questionnaire_Classifyart csv_data = ChoicesAnswersDictionary[choices[0]]; //This could be a potential variable for the player input
            //Debug.Log(csv_data.Topics);

            addToDictionary = false;
        }
    }

    public void Next()
    {
        if (currentTime == 0)
        {
            /*Format for the Dictionary<string, string>
        * Dictionary<choices, answers> Tkey, Tstring
        */

            questionNumber += 1;

            disableEnableChoiceButton();
            UI_changeToWhiteButton();

            indexNumber += 1;
            inputFinish = false;
            quizLoader.indexQuestion = indexNumber;

            currentTime = startingTime;

            ChoicesAnswersDictionary.Clear();
            addToDictionary = true;
            Add_Array_In_Dictionary();
        }

    }

    void showTextInChoiceUI()
    {
        if(randomNumForChoiceText == 0)
        {
            choiceA.text = choices[0];
            choiceB.text = choices[2];
            choiceC.text = choices[1];
            choiceD.text = choices[3];
        }
        else if(randomNumForChoiceText == 1)
        {
            choiceA.text = choices[3];
            choiceB.text = choices[1];
            choiceC.text = choices[0];
            choiceD.text = choices[2];
        }
        else
        {
            Debug.Log("ERROR in Randomization of text in choice button");
        }
        

    }
    void showTextInTopicUI()
    {
        for (int i = 0; i != answers.Length; i++) //For showing the text asset from text Meshes in choice UI
        {
            if (i == 0)
            {
                topicA.text = answers[i];
                //Debug.Log(i + " is choice A");
            }
            else if (i == 1)
            {
                topicB.text = answers[i];
                //Debug.Log(i + " is choice B");
            }
            else
            {
                Debug.Log("ERROR");
            }
        }
    }
    //##PUBLIC FUNCTIONS IN WHICH THE BUTTONS WILL BE REFERENCED TO, THROUGH INSPECTOR
    public void choiceButtonA_Input()
    {
        playerInput = choiceA.text;
        Debug.Log("Choice A: " + playerInput);
        choiceAButton.GetComponent<Image>().color = Color.red;
        disableEnableChoiceButton();
        disableEnableTopicButton();
        Debug.Log("Choice Buttons are set to !interactable, choose a topic");
    }
    public void choiceButtonB_Input()
    {
        playerInput = choiceB.text;
        Debug.Log("Choice B: " + playerInput);
        choiceBButton.GetComponent<Image>().color = Color.red;
        disableEnableChoiceButton();
        disableEnableTopicButton();
        Debug.Log("Choice Buttons are set to !interactable, choose a topic");
    }
    public void choiceButtonC_Input()
    {
        playerInput = choiceC.text;
        Debug.Log("Choice C: " + playerInput);
        choiceCButton.GetComponent<Image>().color = Color.red;
        disableEnableChoiceButton();
        disableEnableTopicButton();
        Debug.Log("Choice Buttons are set to !interactable, choose a topic");
    }
    public void choiceButtonD_Input()
    {
        playerInput = choiceD.text;
        Debug.Log("Choice D: " + playerInput);
        choiceDButton.GetComponent<Image>().color = Color.red;
        disableEnableChoiceButton();
        disableEnableTopicButton();
        Debug.Log("Choice Buttons are set to !interactable, choose a topic");
    }

    public void topicButtonA_Input()
    {
        playerInput2 = topicA.text;
        Debug.Log("Topic " + playerInput2 + " is chosen");
        topicAButton.GetComponent<Image>().color = Color.red;
        disableEnableTopicButton();
        Debug.Log("Topic Buttons are set to !interactable.");
        inputFinish = true;
    }
    public void topicButtonB_Input()
    {
        playerInput2 = topicB.text;
        Debug.Log("Topic " + playerInput2 + " is chosen");
        topicBButton.GetComponent<Image>().color = Color.red;
        disableEnableTopicButton();
        Debug.Log("Topic Buttons are set to !interactable.");
        inputFinish = true;
    }


    //###THIS ARE THE FUNCTION FOR Disable Enable the Buttons
    void disableEnableChoiceButton()
    {
        choiceAButton.interactable = !choiceAButton.interactable;
        choiceBButton.interactable = !choiceBButton.interactable;
        choiceCButton.interactable = !choiceCButton.interactable;
        choiceDButton.interactable = !choiceDButton.interactable;
    }

    void disableEnableTopicButton()
    {
        topicAButton.interactable = !topicAButton.interactable;
        topicBButton.interactable = !topicBButton.interactable;
    }
    //###SOME FUNCTION FOR UI
    void UI_Timer() //[BAGARES] Function for the UI Timer in game (some errors exist when in separate script)
    {
        currentTime -= 1 * Time.deltaTime;
        UI_CountDown.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
    void UI_changeToWhiteButton()
    {
        choiceAButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceBButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceCButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceDButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        topicAButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        topicBButton.image.color = new Color(1f, 1f, 1f, 0.22f);
    }

    //###Some Function for processing Input data
    void checkingTheInput()
    {
        if(inputFinish == true)
        {
            CSV_Questionnaire_Classifyart csv_data = ChoicesAnswersDictionary[playerInput];
            if(csv_data.Topics == playerInput2)
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


}
