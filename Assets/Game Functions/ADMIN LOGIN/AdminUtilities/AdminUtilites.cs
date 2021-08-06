using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdminUtilites : MonoBehaviour
{
    // Lists all of the Quiz Databases
    [Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Download Quiz Database")]
    [SerializeField] private DownloadQuizDatabase downloadQuizDatabase;

    [Header("Debug Text")]
    [SerializeField] private DebugMessage debugMessage;

    [Header("Admin Utility Button")]
    [SerializeField] Button[] adminButton;

    [Header("Account Name")]
    [SerializeField] private TMP_Text accountName;

    // GameObjects that will be presented inside the ScrollView
    [Header("GameObjects")]
    public GameObject UI_Classicart;
    public GameObject UI_Matchart;
    public GameObject UI_Switchart;
    public GameObject UI_Grabart;
    public GameObject UI_Nameart;
    public GameObject UI_Classifyart;
    public GameObject UI_TicTacToe;
    public GameObject UI_Maze;

    [Header("Dropdown")]
    [SerializeField] private Dropdown dropDownQuizList;
    [SerializeField] public Dropdown dropDownSubjectList;

    [Header("Classes")]
    [SerializeField] private Class_Classicart class_Classicart;
    [SerializeField] private Class_Matchart class_Matchart;
    [SerializeField] private Class_Switchart class_Switchart;
    [SerializeField] private Class_Grabart class_Grabart;
    [SerializeField] private Class_Classifyart class_Classifyart;
    [SerializeField] private Class_TicTacToe class_TicTacToe;
    [SerializeField] private Class_Maze class_Maze;

    [Header("Question Number")]
    [SerializeField] private TMP_Text questionNumber;

    [Header("Prompt Warning if Empty")]
    [SerializeField] private GameObject emptyCaution;

    [Header("Utilities Buttons")]
    [SerializeField] private Button[] utilitiesButton; 

    // private GameObject permissionWindow = null;

    string currentPanel;
    string currentSubject;

    void Start()
    {
        downloadQuizDatabase.DownloadQuizzes();

        AccountName(PlayfabManager.EmailAccount);

        // For Dropdown Options
        for (int i = 0; i < quizLoader.TextAssetData.Length; i++)
        {
            dropDownQuizList.options.Add(new Dropdown.OptionData() { text = quizLoader.TextAssetData[i].name });
        }

        OpenPanel(dropDownQuizList, dropDownSubjectList);

        dropDownQuizList.onValueChanged.AddListener(delegate {

            UI_Classicart.SetActive(false);
            UI_Matchart.SetActive(false);
            UI_Switchart.SetActive(false);
            UI_Grabart.SetActive(false);
            // UI_Nameart.SetActive(false);
            UI_Classifyart.SetActive(false);
            UI_TicTacToe.SetActive(false);
            UI_Maze.SetActive(false);

            OpenPanel(dropDownQuizList, dropDownSubjectList);
            quizLoader.indexQuestion = 0;
        });

        dropDownSubjectList.onValueChanged.AddListener(delegate
        {

            UI_Classicart.SetActive(false);
            UI_Matchart.SetActive(false);
            UI_Switchart.SetActive(false);
            UI_Grabart.SetActive(false);
            // UI_Nameart.SetActive(false);
            UI_Classifyart.SetActive(false);
            UI_TicTacToe.SetActive(false);
            UI_Maze.SetActive(false);

            OpenPanel(dropDownQuizList, dropDownSubjectList);
            quizLoader.indexQuestion = 0;
        });
    }

    public void OpenPanel(Dropdown dropDownQuizList, Dropdown dropDownSubjectList)
    {
        int index_dropDownQuizList = dropDownQuizList.value;
        int index_dropDownSubjectList = dropDownSubjectList.value;

        currentPanel = dropDownQuizList.options[index_dropDownQuizList].text;
        currentSubject = dropDownSubjectList.options[index_dropDownSubjectList].text;

        quizLoader.LoadCSV(currentPanel, currentSubject);

        if (dropDownQuizList.options[index_dropDownQuizList].text == "Grabart" || dropDownQuizList.options[index_dropDownQuizList].text == "Matchart")
        {
            questionNumber.text = Convert.ToString((quizLoader.indexQuestion + 1) - (quizLoader.indexQuestion)) + "/" +
            Convert.ToString(quizLoader.data_questionSet.Count / 2);
        }
        else
        {
            questionNumber.text = Convert.ToString(quizLoader.indexQuestion + 1) + "/" + Convert.ToString(quizLoader.data_questionSet.Count);
        }

        // The game will prompt the admin if that specific type of question was empty
        if (quizLoader.data_questionSet.Any() == true)
        {
            emptyCaution.SetActive(false);

            switch (dropDownQuizList.options[index_dropDownQuizList].text)
            {
                case "Classicart": Panel_Classicart(); break;
                case "Matchart": Panel_Matchart(); break;
                case "Switchart": Panel_Switchart(); break;
                case "Grabart": Panel_Grabart(); break;
                // case "Nameart": Panel_Nameart(); break;
                case "Classifyart": Panel_Classifyart(); break;
                case "TicTacToe": Panel_TicTacToe(); break;
                case "Maze": Panel_Maze(); break;
                default: return;
            }
        }
        else
        {
            emptyCaution.SetActive(true);

            UI_Classicart.SetActive(false);
            UI_Matchart.SetActive(false);
            UI_Switchart.SetActive(false);
            UI_Grabart.SetActive(false);
            UI_Classifyart.SetActive(false);
            UI_TicTacToe.SetActive(false);
            UI_Maze.SetActive(false);
        }
    }

    public void EditCSV()
    {
        int index = dropDownQuizList.value;
        switch (dropDownQuizList.options[index].text)
        {
            case "Classicart": class_Classicart.Modify("edit"); break;
            case "Matchart": class_Matchart.Modify("edit"); break;
            case "Switchart": class_Switchart.Modify("edit"); break;
            case "Grabart": class_Grabart.Modify("edit"); break;
            // case "Nameart": class_Nameart.Modify("edit"); break;
            case "Classifyart": class_Classifyart.Modify("edit"); break;
            case "TicTacToe": class_TicTacToe.Modify("edit"); break;
            case "Maze": class_Maze.Modify("edit"); break;
        }
    }

    public void AccountName(string name)
    {

        if (name == null)
        {
            accountName.text = "adminAccount";
        }
        else
        {
            string[] email = name.Split('@');
            accountName.text = email[0];
        }

    }

    public void CreateNew()
    {
        int index = dropDownQuizList.value;
        switch (dropDownQuizList.options[index].text)
        {
            case "Classicart": class_Classicart.Modify("add"); break;
            case "Matchart": class_Matchart.Modify("add"); break;
            case "Switchart": class_Switchart.Modify("add"); break;
            case "Grabart": class_Grabart.Modify("add"); break;
            // case "Nameart": class_Nameart.Modify("add"); break;
            case "Classifyart": class_Classifyart.Modify("add"); break;
            case "TicTacToe": class_TicTacToe.Modify("add"); break;
            case "Maze": class_Maze.Modify("add"); break;
        }
    }

    public void DeleteQuestion()
    {
        int indexToRemove = quizLoader.indexQuestion + 1;
        string[] arrline = File.ReadAllLines(quizLoader.filepath);

        int index = dropDownQuizList.value;
        if (dropDownQuizList.options[index].text == "Matchart" || dropDownQuizList.options[index].text == "Grabart")
        {
            for (int i = indexToRemove + (1 * 2); i < arrline.Length / 2; i++)
            {
                arrline[i] = arrline[i + 2];
            }
            Array.Resize(ref arrline, arrline.Length - 2);  
        }
        else
        {
            for (int i = indexToRemove; i < arrline.Length - 1; i++)
            {
                arrline[i] = arrline[i + 1];
            }
            Array.Resize(ref arrline, arrline.Length - 1);
        }

        File.WriteAllLines(quizLoader.filepath, arrline);
        debugMessage.OnDeleteQuestionStatus(currentPanel, currentSubject);
    }

    public void Previous()
    {
        int index = dropDownQuizList.value;
        if (dropDownQuizList.options[index].text == "Grabart" || dropDownQuizList.options[index].text == "Matchart")
        {
            quizLoader.indexQuestion-= 2;
        }
        else
        {
            quizLoader.indexQuestion--;
        }

        if (quizLoader.indexQuestion < 0)
        {
            quizLoader.indexQuestion = quizLoader.data_questionSet.Count - 1;
        }
        OpenPanel(dropDownQuizList, dropDownSubjectList);
    }

    public void Next()
    {
        int index = dropDownQuizList.value;
        if (dropDownQuizList.options[index].text == "Grabart" || dropDownQuizList.options[index].text == "Matchart")
        {
            quizLoader.indexQuestion+=2;
        }
        else
        {
            quizLoader.indexQuestion++;
        }

        if (quizLoader.indexQuestion > quizLoader.data_questionSet.Count - 1)
        {
            quizLoader.indexQuestion = 0;
        }
        OpenPanel(dropDownQuizList, dropDownSubjectList);
    }

    public void Panel_Classicart()
    {
        UI_Classicart.SetActive(true);
        class_Classicart.Display(true);
    }

    public void Panel_Matchart()
    {
        UI_Matchart.SetActive(true);
        class_Matchart.Display(true);
    }

    public void Panel_Switchart()
    {
        UI_Switchart.SetActive(true);
        class_Switchart.Display(true);
    }

    public void Panel_Grabart()
    {
        UI_Grabart.SetActive(true);
        class_Grabart.Display(true);
    }
    
    public void Panel_Nameart()
    {
        UI_Nameart.SetActive(true);
        // class_Nameart.Display();
    }

    public void Panel_Classifyart()
    {
        UI_Classifyart.SetActive(true);
        class_Classifyart.Display(true);
    }

    public void Panel_TicTacToe()
    {
        UI_TicTacToe.SetActive(true);
        class_TicTacToe.Display(true);
    }

    public void Panel_Maze()
    {
        UI_Maze.SetActive(true);
        class_Maze.Display(true);
    }
}
