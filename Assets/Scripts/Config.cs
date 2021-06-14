using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Config : MonoBehaviour
{
    public Toggle debugToggle;
    public GameObject debug;
    public GameObject fpsCounter;
    public Toggle showFps;
    public MonoBehaviour playerController;
    public Toggle fullscreen;
    public Text fpsLimit;
    public Slider limiter;
    public string GitHub_link;
    public GameObject main;
    private void Start()
    {
        playerController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
    public void SetFpsLimit()
    {
        float i = limiter.value;
        if(i != limiter.maxValue)
        {
            fpsLimit.text = ("FPS Limit - " + i.ToString());
            Application.targetFrameRate = (int)i;
            QualitySettings.vSyncCount = 0;
        }
        else
        {
            fpsLimit.text = ("FPS Limit - VSYNC");
            QualitySettings.vSyncCount = 1;
        }


    }
    public void ToggleFullScreen()
    {
        if(fullscreen.isOn)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            playerController.enabled = false;
            main.SetActive(true);
        }
        if(Input.GetKeyUp("enter"))
        {
            ToGitHub();
        }
    }
    public void ToggleDebug()
    {
        if (debugToggle.isOn)
        {
            debug.SetActive(true);
        }
        else
        {
            debug.SetActive(false);
        }
    }
    public void ToggleFPS()
    {
        if(showFps.isOn)
        {
            fpsCounter.SetActive(true);
        }
        else
        {
            fpsCounter.SetActive(false);
        }
    }
    public void Resume()
    {
        playerController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        main.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ToGitHub()
    {
        Application.OpenURL(GitHub_link);
    }
}
