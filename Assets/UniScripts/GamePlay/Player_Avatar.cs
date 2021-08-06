using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Avatar : MonoBehaviour
{
    [Header("Avatar Images")]
    [SerializeField] private Sprite[] avatarImages;
    [SerializeField] private Image[] selectedAvatar;

    [Header("Avatar Name")]
    [SerializeField] private TMP_Text[] avatarName;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < selectedAvatar.Length; i++)
        {
            selectedAvatar[i].sprite = avatarImages[AvatarDisplay.AvatarProfileIndex];
        }

        for (int i = 0; i < avatarName.Length; i++)
        {
            avatarName[i].text = PlayerInputName.DisplayName;
        }
    }
}
