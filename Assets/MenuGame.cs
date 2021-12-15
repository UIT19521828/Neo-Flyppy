using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;


public class MenuGame : MonoBehaviour
{
    public GameObject lo;
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Shop()
    {
        SceneManager.LoadScene(3);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        SceneManager.LoadScene(4);
    }
    public void LogOut()
    {
        Music.nhac.Destroythis();
        BGround.instance.Destroythis();
        SceneManager.LoadScene(0);       
    }
    public void ChangeMusic(int which)
    {
        Music.nhac.ChangeMusic(which);
    }
    public void ChangeBG(int which)
    {
        BGround.instance.ChangeBG(which);
    }
    public void Thoat()
    {
        Application.Quit();
    }
    public void ShowLogOut()
    {
        lo.SetActive(true);
    }
    public void HideLogOut()
    {
        lo.SetActive(false);
    }
}
