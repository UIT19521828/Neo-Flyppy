using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayFabUI : MonoBehaviour
{
    [SerializeField] Text errorText;
    string username, email, pass;

    public void UpdateUsername(string a)
    {
        username = a;
    }
    public void UpdateEmail(string b)
    {
        email = b;
    }
    public void UpdatePass(string c)
    {
        pass = c;
    }
    public void CreateAccount()
    {
        UserAccount.Instance.CreateAccount(username, email, pass);
    }
    public void SignIn()
    {
        UserAccount.Instance.SignIn(username, pass);
    }
    void OnEnable()
    {
        UserAccount.onCreateFail.AddListener(OnCreateFail);
        UserAccount.onLoginFail.AddListener(OnLoginFail);
        UserAccount.onLoginSuccess.AddListener(OnLoginSuccess);
    }
    void OnDisable()
    {
        UserAccount.onCreateFail.RemoveListener(OnCreateFail);
        UserAccount.onLoginFail.RemoveListener(OnLoginFail);
        UserAccount.onLoginSuccess.RemoveListener(OnLoginSuccess);
    }
    void OnCreateFail(string error)
    {
        errorText.text = error;
    }
    void OnLoginFail(string error)
    {
        errorText.text = error;
    }
    void OnLoginSuccess()
    {
        SceneManager.LoadScene(1);
    }
    
}
