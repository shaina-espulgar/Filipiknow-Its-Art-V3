using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//HOPE THAT IT WILL NOT REMOVED

public class nameHandling : MonoBehaviour
{
    public Text playerNameShowUI; //[BAGARES] handles name showing in the UI
    
    private string _nameShow;
    public string nameOfPlayer
    {
        get { return _nameShow; }
        set{
            _nameShow = value;

            playerNameShowUI.text = nameOfPlayer.ToString();
        }
    }
    public string DEFAULT_NAME;
    

    public void nameDefaultRandomization() //[BAGARES] RAndomization Function for a default name. (can add more names if necessary) 
    {
        string[] DEFAULT_NAMES_INDEX = { "Aron", "Rapiest", "Terrier", "Nosferatu" };
        DEFAULT_NAME = DEFAULT_NAMES_INDEX[Random.Range(0, DEFAULT_NAMES_INDEX.Length - 1)];
    }

    public void showInputUI() //[BAGARES] function used for showing/hiding the Input UI
    {
        gameObject.SetActive(true);
    }

    public void hideInputUI()
    {
        gameObject.SetActive(false);
    }
    
    private void Awake()
    {
        hideInputUI();
        nameDefaultRandomization();
        Debug.Log(DEFAULT_NAME + " is your name");
    }

    
}
