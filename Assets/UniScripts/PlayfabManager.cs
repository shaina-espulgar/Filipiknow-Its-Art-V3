using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
    [Header("Login/register box")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;

    public static string EmailAccount { get; private set; }

    // Registering
    public void RegisterButton() {
        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageText.text = "Registered!";
    }

    // Logging in
    public void LoginButton() {
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result) {
        messageText.text = "Logged in!";

        SceneManager.LoadScene("AdminUtilities");
    }

    // Forgot password
    public void ResetPasswordButton() {
        var request = new SendAccountRecoveryEmailRequest {
            Email = emailInput.text,
            TitleId = PlayFabSettings.staticSettings.TitleId
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnForgotPasswordSuccess, OnError);
    }
    void OnForgotPasswordSuccess(SendAccountRecoveryEmailResult result) {
        messageText.text = "Sent password recovery link!";
    }

    void OnError(PlayFabError error) {
        messageText.text = "Error: " + error.ErrorMessage;
    }

    public void SaveEmail()
    {
        EmailAccount = emailInput.text;
    }
}
