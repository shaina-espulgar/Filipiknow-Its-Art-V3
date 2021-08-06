using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSV_Questionnaire_Classifyart
{
    public string Topics
    {
        get;
        set;
    }

    public string Answers
    {
        get;
        set;
    }

    public CSV_Questionnaire_Classifyart(string answer, string topic)
    {
        this.Topics = topic;
        this.Answers = answer;
    }
}
