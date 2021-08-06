using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AvatarDisplay : MonoBehaviour
{
    [Header("Avatar Images")]
    [SerializeField] private Image selectedAvatar;
    [SerializeField] public Sprite[] avatarImage;
    private int avatarIndex = 0;

    public static int AvatarProfileIndex { get; private set; }

    public void PreviousAvatar()
    {
        avatarIndex--;
        if (avatarIndex < 0)
        {
            avatarIndex = avatarImage.Length - 1;
        }
        selectedAvatar.sprite = avatarImage[avatarIndex];
    }

    public void NextAvatar()
    {
        avatarIndex++;
        if (avatarIndex > avatarImage.Length - 1)
        {
            avatarIndex = 0;
        }
        selectedAvatar.sprite = avatarImage[avatarIndex];
    }

    public void SaveAvatarProfile()
    {
        AvatarProfileIndex = avatarIndex;
    }
}
