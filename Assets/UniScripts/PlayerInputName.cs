using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInputName : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField playerName;

    public static string DisplayName { get; private set; }

    private void Start() => SetUpInputField();

    private void SetUpInputField()
    {
        string defaultName = "Player";

        playerName.text = defaultName;
    }

    public void SavePlayerName()
    {
        DisplayName = playerName.text;
    }
}
