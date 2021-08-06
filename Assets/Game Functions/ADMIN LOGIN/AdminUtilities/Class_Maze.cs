using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Class_Maze : MonoBehaviour
{
    [Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Debug Message")]
    [SerializeField] private DebugMessage debugMessage;

    [Header("Inputs")]
    [SerializeField] private TMP_InputField input_Question;

    [Header("Toggle")]
    [SerializeField] private Toggle toggle_True;
    [SerializeField] private Toggle toggle_False;

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
            if (answers[0] == "TRUE")
            {
                toggle_True.isOn = true;
            }
            else
            {
                toggle_False.isOn = true;
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
        string combine = string.Empty;

        combine = input_Question.text + "|";
        if (toggle_True.isOn == true)
        {
            combine = combine + "TRUE";
        }
        if (toggle_False.isOn == true)
        {
            combine = combine + "FALSE";
        }
        final = combine + "|" + subject;

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
