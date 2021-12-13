using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseCanvas;
    public AudioMixer audioMixer;

    public void Update()
    {
        if (Input.GetKey("escape"))
        {
            StopGame();
        }
    }
    public void StopGame()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }
    public void ResumeGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("MasterVol", vol);
    }
    public void GetData()
    {
        Debug.Log("two: " + PlayerData.pd.Money + " " + PlayerData.pd.HighScore);
    }
}
