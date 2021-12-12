using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMenu : MonoBehaviour
{
    public GameObject login;
    public GameObject register;
    public GameObject forgot;
    public void OpenRegister()
    {
        login.SetActive(false);
        register.SetActive(true);
    }
    public void ReturnLogin()
    {
        register.SetActive(false);
        login.SetActive(true);       
    }
}
