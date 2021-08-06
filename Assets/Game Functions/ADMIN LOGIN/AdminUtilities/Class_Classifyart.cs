using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Class_Classifyart : MonoBehaviour
{
    [Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Debug Message")]
    [SerializeField] private DebugMessage debugMessage;

    [Header("Inputs")]
    [SerializeField] private TMP_InputField[] arrChoices;
    [SerializeField] private TMP_InputField[] arrAnswers;

    [Header("Dropdown")]
    [SerializeField] public Dropdown dropDownSubjectList;

    public void Display(bool display)
    {
        if (display == true)
        {
            string[] answers = quizLoader.Answers;
            string[] choices = quizLoader.Choices;

            for (int i = 0; i < arrChoices.Length; i++)
            {
                arrChoices[i].text = choices[i];
            }

            for (int i = 0; i < arrAnswers.Length; i++)
            {
                arrAnswers[i].text = answers[i];
            }
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

        string final = string.Empty;

        for (int i = 0; i < arrChoices.Length; i++)
        {
            if (i == 1 || i == 3)
            {
                index = 0;
                final = final + arrAnswers[i].text;
                index++;
            }
            else
            {
                final = final + arrChoices[i];
            }
        }

        final = final + "|" + subject;

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
