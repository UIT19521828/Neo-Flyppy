using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;


public class MenuGame : MonoBehaviour
{
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
    public void ChangeMusic(int which)
    {
        Music.nhac.ChangeMusic(which);
    }
    public void ChangeBG(int which)
    {
        BGround.instance.ChangeBG(which);
    }
}
