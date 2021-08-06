using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game_Classifyart : MonoBehaviour
{
    [Header("Quizloader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Quiz Game Initializer")]
    [SerializeField] private QuizGameInitializer quizGameInitializer;

    [Header("Player Score")]
    [SerializeField] private Player_Score player_score;

    [Header("Player")]
    [SerializeField] private Image playerAvatar;
    [SerializeField] private TMP_Text displayScore;
    [SerializeField] private TMP_Text playerName;

    [Header("Gameobjects")]
    [SerializeField] private GameObject classifyartPanel;
    [SerializeField] private GameObject quizInitializerPanel;

    [Header("Countdown")]
    [SerializeField] private TMP_Text countDown;

    [Header("Choices Button")]
    [SerializeField] private Button[] choicesButton;
    [SerializeField] private TMP_Text[] choicesText;

    [Header("Answers Button")]
    [SerializeField] private Button[] answersButton;
    [SerializeField] private TMP_Text[] answersText;

    [Header("Rounds")]
    [SerializeField] private TMP_Text roundCounter;

    private string question;
    private string[] choices;
    private string[] answers;

    // Modify this part for the mechanics....
    private float currentTime = 0f;
    private float startingTime = 20f;

    private int round = 1;
    private readonly int roundLimit = 1;

    private int clickedButton;
    private Dictionary<string, string> questionDict = new Dictionary<string, string>();


    void OnEnable()
    {
        doFixedUpdate = true;
        currentTime = startingTime;

        round = 1;
        roundCounter.text = round.ToString();

        quizLoader.LoadCSV(QuizGameInitializer.typeOfQuestion, QuizGameInitializer.typeOfSubject);
    }

    void Update()
    {
        QuestionTimer();

        if (currentTime == 0)
        {
            NextQuestion();
        }
    }

    // Button Randomizer
    List<int> indexedChoices = new List<int>();
    int randomNumber;
    bool doFixedUpdate = true;
    private void FixedUpdate()
    {
        if (doFixedUpdate == true)
        {
            randomNumber = Random.Range(0, choicesText.Length);
            if (indexedChoices.Contains(randomNumber) == false)
            {
                indexedChoices.Add(randomNumber);
                Debug.Log("Index Added");
            }

            if (indexedChoices.Count >= choicesText.Length)
            {
                doFixedUpdate = false;

                QuestionDisplay();
                Debug.Log("List Passed");

                // Answer Patterns
                Debug.Log(indexedChoices[0] + " " + indexedChoices[1] + " " + indexedChoices[2] + " " + indexedChoices[3]);
            }
        }
    }

    void QuestionRandom()
    {
        quizLoader.indexQuestion = Random.Range(0, quizLoader.data_questionSet.Count - 1);

        quizLoader.LoadCSV(QuizGameInitializer.typeOfQuestion, QuizGameInitializer.typeOfSubject);
    }

    void QuestionDisplay()
    {
        QuestionRandom();

        choices = quizLoader.Choices;
        answers = quizLoader.Answers;

        questionDict.Add(choices[0], answers[0]);
        questionDict.Add(choices[1], answers[0]);
        questionDict.Add(choices[2], answers[1]);
        questionDict.Add(choices[3], answers[1]);

        
        for (int i = 0; i < choicesText.Length; i++)
        {
            choicesText[indexedChoices[i]].text = choices[i];
        }

        for (int i = 0; i < answersText.Length; i++)
        {
            answersText[i].text = answers[i];
        }
    }

    void QuestionTimer()
    {
        currentTime -= 1 * Time.deltaTime;
        countDown.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    int indexChoice;
    public void ChoicesButtonResponse(int buttonIndex)
    {
        indexChoice = buttonIndex;

        for (int i = 0; i < choicesButton.Length; i++)
        {
            if (i == buttonIndex)
            {
                choicesButton[buttonIndex].GetComponent<Image>().color = Color.white;
            }
            else
            {
                choicesButton[i].interactable = false;
            }
        }
        clickedButton++;
        if (clickedButton == 2)
        {
            CheckResponse();
        }
    }

    int indexAnswer;
    public void AnswersButtonResponse(int buttonIndex)
    {
        indexAnswer = buttonIndex;

        for (int i = 0; i < answersButton.Length; i++)
        {
            if (i == buttonIndex)
            {
                answersButton[buttonIndex].GetComponent<Image>().color = Color.white;
            }
            else
            {
                answersButton[i].interactable = false;
            }
        }

        clickedButton++;
        if (clickedButton == 2)
        {
            CheckResponse();
        }
    }

    void CheckResponse()
    {
        if (questionDict[choicesText[indexChoice].text] == answersText[indexAnswer].text)
        {
            Debug.Log("Correct!");
            choicesButton[indexChoice].GetComponent<Image>().color = Color.green;
            answersButton[indexAnswer].GetComponent<Image>().color = Color.green;

            player_score.ChangeScore();
            currentTime = 3;
        }
        else
        {
            Debug.Log("Wrong!");
            choicesButton[indexChoice].GetComponent<Image>().color = Color.red;
            answersButton[indexAnswer].GetComponent<Image>().color = Color.red;
            currentTime = 3;
        }
    }

    void NextQuestion()
    {
        if (round == roundLimit)
        {
            quizGameInitializer.QuizCounter++;

            classifyartPanel.SetActive(false);
            quizInitializerPanel.SetActive(true);
        }

        for (int i = 0; i < choicesButton.Length; i++)
        {
            choicesButton[i].interactable = true;
            choicesButton[i].image.color = new Color(1f, 1f, 1f, 0.22f);
        }
        for (int i = 0; i < answersButton.Length; i++)
        {
            answersButton[i].interactable = true;
            answersButton[i].image.color = new Color(1f, 1f, 1f, 0.22f);
        }

        indexedChoices.Clear();
        questionDict.Clear();

        doFixedUpdate = true;
        clickedButton = 0;

        currentTime = startingTime;

        round++;
        roundCounter.text = round.ToString();
    }
}
