using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Score : MonoBehaviour
{
    [Header("Player Score")]
    public static int PlayerScore;

    [Header("Quiz Score Text")]
    [SerializeField] private TMP_Text[] quizzesScoreDisplay;
 
    void Start()
    {
        Display();
    }

    void Display()
    {
        for (int i = 0; i < quizzesScoreDisplay.Length; i++)
        {
            quizzesScoreDisplay[i].text = PlayerScore.ToString();
        }    
    }

    public void ChangeScore()
    {
        switch (QuizGameInitializer.typeOfQuestion)
        {
            case "Classicart":
                PlayerScore += 200;
                break;

            case "Grabart":
                PlayerScore += 100;
                break;

            case "Matchart":
                PlayerScore += 100;
                break;

            case "Classifyart":
                PlayerScore += 200;
                break;
        }

        Display();
    }

}

