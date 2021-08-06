using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game_Classicart : MonoBehaviour
{
    [Header("Quizloader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Quiz Game Initializer")]
    [SerializeField] private QuizGameInitializer quizGameInitializer;

    [Header("PlayerScore")]
    [SerializeField] private Player_Score player_score;

    [Header("Player")]
    [SerializeField] private Image playerAvatar;
    [SerializeField] private TMP_Text displayScore;
    [SerializeField] private TMP_Text playerName;

    [Header("Gameobjects")]
    [SerializeField] private GameObject classicartPanel;
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
    private float startingTime = 10f;
    private int round;
    private readonly int roundLimit = 3;

    void OnEnable()
    {
        currentTime = startingTime;

        round = 1;
        roundCounter.text = round.ToString();

        quizLoader.LoadCSV(QuizGameInitializer.typeOfQuestion, QuizGameInitializer.typeOfSubject);
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
        quizLoader.indexQuestion = Random.Range(0, quizLoader.data_questionSet.Count - 1);
        quizLoader.LoadCSV(QuizGameInitializer.typeOfQuestion, QuizGameInitializer.typeOfSubject);
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
        for (int i = 0; i < choicesButton.Length; i++)
        {
            choicesButton[i].interactable = false;
        }

        if (choices[buttonIndex] == answers[0])
        {
            Debug.Log("Correct!");
            choicesButton[buttonIndex].GetComponent<Image>().color = Color.green;

            player_score.ChangeScore();
            currentTime = 3;
        }
        else
        {
            Debug.Log("Wrong!");
            choicesButton[buttonIndex].GetComponent<Image>().color = Color.red;
            currentTime = 3;
        }
    }

    void NextQuestion()
    {
        if (round == roundLimit)
        {
            quizGameInitializer.QuizCounter++;

            classicartPanel.SetActive(false);
            quizInitializerPanel.SetActive(true);
        }

        for (int i = 0; i < choicesButton.Length; i++)
        {
            choicesButton[i].interactable = true;
            choicesButton[i].image.color = new Color(1f, 1f, 1f, 0.22f);
        }

        QuestionDisplay();
        currentTime = startingTime;

        round++;
        roundCounter.text = round.ToString();
    }
}
