using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game_Grabart : MonoBehaviour
{
    [Header("Quizloader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Quiz Game Initializer")]
    [SerializeField] private QuizGameInitializer quizGameInitializer;

    [Header("PlayerScore")]
    [SerializeField] private Player_Score player_score;

    [Header("Gameobjects")]
    [SerializeField] private GameObject grabartPanel;
    [SerializeField] private GameObject quizInitializerPanel;

    [Header("Countdown")]
    [SerializeField] private TMP_Text countDown;

    [Header("Question Display")]
    [SerializeField] private TMP_Text questionDisplay;

    [Header("Choices Button")]
    [SerializeField] private Button[] choicesButton;
    [SerializeField] private TMP_Text[] choicesText;

    [Header("Rounds")]
    [SerializeField] private TMP_Text roundCounter;

    private string question;
    private string[] choices;
    private string[] answers;

    // Modify this part for the mechanics....
    private float currentTime = 0f;
    private float startingTime = 30f;
    private int round;
    private readonly int roundLimit = 2;

    private int selected;
    private int selectedLimit = 5;

    void OnEnable()
    {
        currentTime = startingTime;

        round = 1;
        roundCounter.text = round.ToString();

        quizLoader.LoadCSV(QuizGameInitializer.typeOfQuestion, QuizGameInitializer.typeOfSubject);
        // quizLoader.LoadCSV("Grabart", "National Artists");
        QuestionDisplay();
    }

    void Update()
    {
        QuestionTimer();
        if (currentTime == 0)
        {
            NextQuestion();
        }
    }

    void QuestionRandom()
    {
        List<int> randomNumberInterval = new List<int>();
        for (int i = 0; i < quizLoader.data_questionSet.Count; i++)
        {
            if (i % 2 == 0)
            {
                randomNumberInterval.Add(i);
            }
        }

        quizLoader.indexQuestion = randomNumberInterval[Random.Range(0, randomNumberInterval.Count)];
        quizLoader.LoadCSV(QuizGameInitializer.typeOfQuestion, QuizGameInitializer.typeOfSubject);
        // quizLoader.LoadCSV("Grabart", "National Artists");
    }

    void QuestionDisplay()
    {
        QuestionRandom();

        question = quizLoader.Question;
        choices = quizLoader.Choices;
        answers = quizLoader.Answers;

        questionDisplay.text = question;
        for (int i = 0; i < choicesText.Length; i++)
        {
            choicesText[i].text = choices[i];
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

    public void ButtonResponse(int buttonIndex)
    {
        selected++;
        if (selected == selectedLimit)
        {
            for (int i = 0; i < choicesButton.Length; i++)
            {
                choicesButton[i].interactable = false;
            }
            currentTime = 3;
        }

        if (answers[buttonIndex] == "TRUE")
        {
            Debug.Log("Correct!");
            choicesButton[buttonIndex].GetComponent<Image>().color = Color.green;
            player_score.ChangeScore();
        }
        else if (answers[buttonIndex] == "FALSE")
        {
            Debug.Log("Wrong!");
            choicesButton[buttonIndex].GetComponent<Image>().color = Color.red;
        }
    }

    void NextQuestion()
    {
        if (round == roundLimit)
        {
            quizGameInitializer.QuizCounter++;
            grabartPanel.SetActive(false);
            quizInitializerPanel.SetActive(true);
        }

        for (int i = 0; i < choicesButton.Length; i++)
        {
            choicesButton[i].interactable = true;
            choicesButton[i].image.color = new Color(1f, 1f, 1f, 0.22f);
        }

        selected = 0;
        currentTime = startingTime;
        QuestionDisplay();

        round++;
        roundCounter.text = round.ToString();
    }
}
