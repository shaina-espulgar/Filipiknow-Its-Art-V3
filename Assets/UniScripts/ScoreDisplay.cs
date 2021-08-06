using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private GameObject scoreDisplay;

    [Header("Text")]
    [SerializeField] private TMP_Text txt_Player;
    [SerializeField] private TMP_Text txt_Score;

    [Header("Avatar")]
    [SerializeField] private Image image_Avatar;
    [SerializeField] private Sprite[] sprite_Avatar;

    // Start is called before the first frame update
    void Start()
    {
        CurrentName(PlayerInputName.DisplayName);
        CurrentAvatar(AvatarDisplay.AvatarProfileIndex);
        CurrentScore(Player_Score.PlayerScore);
    }

    void CurrentName(string name)
    {
        txt_Player.text = name;
    }

    void CurrentAvatar(int index)
    {
        image_Avatar.sprite = sprite_Avatar[index];
    }

    void CurrentScore(int score)
    {
        txt_Score.text = score.ToString();
    }

    public void GoToLeaderboards()
    {
        SceneManager.LoadScene("LeaderBoards");
    }

    // For the share function
    public void ShareScore()
    {
        StartCoroutine("TakeScreenShotandShare");
    }

    IEnumerator TakeScreenShotandShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D tx = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        tx.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        tx.Apply();

        string path = Path.Combine(Application.temporaryCachePath, "sharedImage.png");
        File.WriteAllBytes(path, tx.EncodeToPNG());

        Destroy(tx);

        new NativeShare()
            .AddFile(path)
            .SetSubject("This is my score")
            .SetText("share your score with your friends")
            .Share();
    }
}
