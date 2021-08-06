using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminMenu : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReturnToAdminMenu()
    {
        SceneManager.LoadScene("AdminMenu");
    }

    public void GoToAdminUtilities()
    {
        SceneManager.LoadScene("AdminUtilities");
    }
}
