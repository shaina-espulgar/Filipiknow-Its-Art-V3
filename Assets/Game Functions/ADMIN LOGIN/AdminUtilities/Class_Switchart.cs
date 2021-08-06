using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Class_Switchart : MonoBehaviour
{
    [Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Debug Message")]
    [SerializeField] private DebugMessage debugMessage;

    [Header("Inputs")]
    [SerializeField] private TMP_InputField input_Question;
    [SerializeField] private TMP_InputField[] arrChoices;
    [SerializeField] private TMP_InputField input_Answer;

    [Header("Dropdown")]
    [SerializeField] public Dropdown dropDownSubjectList;

    public void Display(bool display)
    {
        if (display == true)
        {
            string question = quizLoader.Question;
            string[] choices = quizLoader.Choices;
            string[] answers = quizLoader.Answers;

            input_Question.text = question;
            int index = 0;
            foreach (string text in choices)
            {
                arrChoices[index].text = text;
                index++;
            }
            input_Answer.text = answers[0];
        }
        else
        {
            return;
        }

    }

    public void Modify(string operation)
    {
        int index = dropDownSubjectList.value;
        string subject = dropDownSubjectList.options[index].text;

        string combine = string.Empty;
        string reserve = string.Empty;
        string final = string.Empty;

        reserve = input_Question.text + "|";
        for (int i = 0; i < arrChoices.Length; i++)
        {
            combine = reserve + arrChoices[i].text + "|";
            reserve = combine;
        }
        final = combine + input_Answer.text + "|" + subject;

        if (operation == "add")
        {
            string[] arrline = File.ReadAllLines(quizLoader.filepath);
            arrline = arrline.Concat(new string[] { final }).ToArray();
            File.WriteAllLines(quizLoader.filepath, arrline);
            debugMessage.OnAddQuestionStatus(dropDownSubjectList.options[index].text);
        }
        if (operation == "edit")
        {
            string[] arrline = File.ReadAllLines(quizLoader.filepath);
            arrline[quizLoader.indexQuestion + 1] = final;
            File.WriteAllLines(quizLoader.filepath, arrline);
            debugMessage.OnEditQuestionStatus(dropDownSubjectList.options[index].text);
        }
    }

}
