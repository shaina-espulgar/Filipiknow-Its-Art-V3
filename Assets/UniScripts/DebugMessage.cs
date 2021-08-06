using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugMessage : MonoBehaviour
{
    [Header("Debug Text")]
    [SerializeField] private TMP_Text debugText;

    public void OnIndexError()
    {
        debugText.text = "Quiz Index Error";
    }

    public void OnQuestionEmpty (string typeOfQuestion, string typeOfSubject)
    {
        debugText.text = "Question Empty in " + typeOfQuestion + " and " + typeOfSubject + " , add some.";
    }

    public void OnDownloadComplete(string typeOfQuestion)
    {
        debugText.text = typeOfQuestion + " Replaced";
    }

    public void OnUploadComplete(string typeOfQuestion)
    {
        debugText.text = typeOfQuestion + "Uploaded";
    }

    public void OnEditQuestionStatus(string typeOfQuestion)
    {
        debugText.text = "Question edited on " + typeOfQuestion;
    }

    public void OnAddQuestionStatus(string typeOfQuestion)
    {
        debugText.text = "Question added on " + typeOfQuestion;
    }

    public void OnDeleteQuestionStatus(string typeOfQuestion, string typeOfSubject)
    {
        debugText.text = "Question deleted on " + typeOfQuestion + " in " + typeOfSubject + " subject";
    }
}
