using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayGame : MonoBehaviour
{
    [Header("Download Quiz Database")]
    [SerializeField] private DownloadQuizDatabase downloadQuizDatabase;

    [Header("Number of Players")]
    [SerializeField] private Button[] playerNumber;

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToGamePlay()
    {
        downloadQuizDatabase.DownloadQuizzes();
            
        SceneManager.LoadScene("GamePlay");
    }

    public void GoToAvatarChangeScene()
    {
        SceneManager.LoadScene("AvatarMenu");
    }
   
}
