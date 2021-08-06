using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DummyCode : MonoBehaviour
{
    [SerializeField] private QuizLoader quizLoader;
    [SerializeField] private TMP_Text displayText;

    // Start is called before the first frame update
    void OnEnable()
    {
        quizLoader.LoadCSV(QuizGameInitializer.typeOfQuestion, QuizGameInitializer.typeOfSubject);

        string former = "";
        foreach (var text in quizLoader.data_questionSet)
        {
            displayText.text = former + text + "\n";
            former = displayText.text;
        }
    }
}
