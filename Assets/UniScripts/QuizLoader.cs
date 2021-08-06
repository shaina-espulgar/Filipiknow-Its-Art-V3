using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


// Note: PARTIALLY COMPLETE. 95% - Nameart is still not being worked on

// Note: You might have to prompt the user first if that type of question and/or subject is empty for FAIL SAFE purposes (optional if that's the case) 
public class QuizLoader : MonoBehaviour
{
    // This will load every CSV files when placed in the game
    public TextAsset[] TextAssetData;

    // Will get its specific filepath
    [HideInInspector] public string filepath = string.Empty;

    [HideInInspector] public int indexQuestion;
    // Note: these are lists now instead of arrays before
    [HideInInspector] public List<string> data_questionSet = new List<string>();
    [HideInInspector] public List<string> data_display = new List<string>();

    public void LoadCSV(string typeOfQuestion, string typeOfSubject)
    {
        filepath = Application.persistentDataPath + "/" + typeOfQuestion + ".csv";

        // Clear the Question Set first before proceeding
        data_questionSet.Clear();

        // List<string> txt_file = new List<string>(File.ReadLines(filepath));
        string[] txt_file = File.ReadAllLines(filepath);

        // Will use the try... except code for catching the IndexOutOfRange Exception which will 
        // happen if the program didn't found a specific criteria in its txt_file variable
        try
        {
            for (int i = 0; i < txt_file.Length; i++)
            {
                // Sending the string to data_questionSet if it has a specific type of subject
                // "Classifyart" is an exclusion for this because it uses the subjects as part of its quiz
                if (txt_file[i].Contains(typeOfSubject))
                {
                    if (typeOfQuestion == "Grabart" || typeOfQuestion == "Matchart")
                    {
                        // Erasing the first row of the CSV
                        if (i != txt_file.Length - 1)
                        {
                            data_questionSet.Add(txt_file[i]);
                            data_questionSet.Add(txt_file[i + 1]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        data_questionSet.Add(txt_file[i]);
                    }
                }

                /*
                else if (typeOfQuestion == "Classifyart")
                {
                    if (i != txt_file.Length - 1)
                    {
                        data_questionSet.Add(txt_file[i + 1]);
                    }
                    else
                    {
                        break;
                    }
                }
                */

            }

            // Spliting the data_questionSet into columns or pieces
            data_display = data_questionSet[indexQuestion].Split(new string[] { "|" }, StringSplitOptions.None).ToList();
        }
        catch (ArgumentOutOfRangeException)
        {
            Debug.Log("LoadCSV cancelled!!! Input some questions");
            return;
        }

        // Perform separation of Questions, Choices, Answers from data_display
        switch (typeOfQuestion)
        {
            case "Classicart": Classicart(); break;
            case "Matchart": Matchart(); break;
            case "Switchart": Switchart(); break;
            case "Grabart": Grabart(); break;
            case "Nameart": Nameart(); break;
            case "Classifyart": Classifyart(); break;
            case "TicTacToe": TicTacToe(); break;
            case "Maze": Maze(); break;
        }
    }

    // Use Getter and Setter so we can get the variable of these stuffs or modify it even from the outside
    private string _question;
    public string Question
    {
        get { return _question; }
        set { _question = value; }
    }

    private List<string> _subjects = new List<string>();
    public List<string> Subjects
    {
        get { return _subjects; }
        set { _subjects = value; }
    }

    private int choicesLength;
    private string[] _choices;
    public string[] Choices
    {
        get { return _choices; }
        set { _choices = value; }
    }

    private int answersLength;
    private string[] _answers;
    public string[] Answers
    {
        get { return _answers; }
        set { _answers = value; }
    }

    public void Classicart()
    {
        choicesLength = 4; answersLength = 1;
        _choices = new string[choicesLength];
        _answers = new string[answersLength];

        _question = data_display[0];
        for (int i = 1; i <= choicesLength; i++)
        {
            _choices[i - 1] = data_display[i];
        }
        _answers[0] = data_display[5];
    }

    public void Matchart()
    {
        // These three first lines were redundant anyway but Im trying to come up with an alternative
        // choicesLength = 6; answersLength = 6;
        // _choices = new string[choicesLength];
        // _answers = new string[answersLength];

        _choices = data_questionSet[indexQuestion].Split('|');
        _answers = data_questionSet[indexQuestion + 1].Split('|');

        // Decrease the size of an array by 1 (first column) since that column is composed of a question with corresponding empty block below it as always 
        for (int i = 0; i < _choices.Length - 1; i++)
        {
            _choices[i] = _choices[i + 1];
            _answers[i] = _answers[i + 1];
        }
        Array.Resize(ref _choices, _choices.Length - 1);
        Array.Resize(ref _answers, _answers.Length - 1);
    }

    public void Switchart()
    {
        choicesLength = 4; answersLength = 1;
        _choices = new string[choicesLength];
        _answers = new string[answersLength];

        _question = data_display[0];
        for (int i = 1; i <= choicesLength; i++)
        {
            _choices[i - 1] = data_display[i];
        }
        _answers[0] = data_display[5];
    }

    public void Grabart()
    {
        // These three first lines were redundant anyway but Im trying to come up with an alternative
        // choicesLength = 15; answersLength = 15;
        // _choices = new string[choicesLength];
        // _answers = new string[answersLength];

        _choices = data_questionSet[indexQuestion].Split('|');
        _answers = data_questionSet[indexQuestion + 1].Split('|');
        _question = _choices[0];

        // Decrease the size of an array by 1 (first column) since that column is composed of a question with corresponding empty block below it as always
        for (int i = 0; i < _choices.Length - 2; i++)
        {
            _choices[i] = _choices[i + 1];
            _answers[i] = _answers[i + 1];
        }
        Array.Resize(ref _choices, _choices.Length - 2);
        Array.Resize(ref _answers, _answers.Length - 1);
    }

    public void Nameart()
    {
        choicesLength = 4; answersLength = 1;
        _choices = new string[choicesLength];
        _answers = new string[answersLength];

        _question = data_display[0];
        for (int i = 1; i <= choicesLength; i++)
        {
            _choices[i - 1] = data_display[i];
        }
        _answers[0] = data_display[5];
    }

    // Classifyart has a different characteristics compared to the other quizzes that I loaded in here

    // Since this quiz uses the type of subjects in its game, I belong it to the _answers and Answers variable since the typeOfQuestion was used to get an answer
    // and an input from the user
    public void Classifyart()
    {
        choicesLength = 4; answersLength = 2;
        _choices = new string[choicesLength];
        _answers = new string[answersLength];

        int index1 = 0; int index2 = 0;
        for (int i = 0; i < data_display.Count - 1; i++)
        {
            if (i == 2 || i == 5)
            {
                _answers[index1] = data_display[i];
                index1++;
            }
            else
            {
                _choices[index2] = data_display[i];
                index2++;
            }
        }
    }

    public void TicTacToe()
    {
        _question = data_display[0];
        _answers[0] = data_display[1];
    }

    public void Maze()
    {
        _question = data_display[0];
        _answers[0] = data_display[1];
    }
}

/* 
    Planned format when used in the GamePlay
    [SerializeField] private QuizLoader quizLoader;
    void Start()
    {
        string question = quizLoader.Question;
        list<string> choices = quizloader.Choices;
        list<string> answers = quizLoader.Answers;
        
        == Then assign a Question Type...
        quizLoader.LoadCSV("Grabart", "National Artists");
    }
    --- BELOW HERE will eventually be the product ---
    void Game()
    {
        if (choices[input] == answers)
        {
            return TRUE;
        }
        else
        {
            return FALSE;
        }
    }
    void PreviousQuestion()
    {
        quizLoader.indexQuestion--;
        
        -- If it is Grabart or Matchart we will decrement the indexQuestion by 2 since each questions consume 2 rows in there.
        quizLoader.indexQuestion-=2
    }
    void NextQuestion()
    {
        quizLoader.indexQuestion++;
        -- If it is Grabart or Matchart we will increment the indexQuestion by 2 since each questions consume 2 rows in there.
        quizLoader.indexQuestion+=2
    }
    -- Need some code for not overpassing the value of indexQuestion to the no. of questions
    void Clear()
    {
        --- CLEAR THE LIST IF THE ROUND ENDED 
        --- However this part is just my theory that the code will not erase the former values of these.
        question = string.Empty;
        Array.Clear(choices, 0, choices.Length)
        Array.Clear(answers, 0, answers.Length)
    }
*/
