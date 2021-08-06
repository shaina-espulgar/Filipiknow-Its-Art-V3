using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class main : MonoBehaviour
{
    [SerializeField] private UI_PauseMenu PauseMenu;

    private GameObject CategoryMenu;

    private void Awake()
    {
        transform.Find("UI-Button-Pause").GetComponent<Button_UI>().ClickFunc = PauseMenu.PauseGame;

    }

}
