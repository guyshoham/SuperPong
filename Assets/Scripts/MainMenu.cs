﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public static int modePick = 0; // 0 - soccer, 1 - tennis, 2 - AR
    public TextMeshProUGUI soccerModeText, tennisModeText, arModeText;
    public TMP_ColorGradient red, green;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Intro");
    }

    public void PlayGame()
    {
        if (modePick == 0)
        {
            SceneManager.LoadScene("Soccer");
        }
        else if (modePick == 1)
        {
            SceneManager.LoadScene("Tennis");
        }
        else if (modePick == 2)
        {
            SceneManager.LoadScene("AR");
        }
        PlayMenuSound();
    }

    public void ModesGame()
    {
        PlayMenuSound();
        setModesColors();
    }

    public void InstructionsGame()
    {
        PlayMenuSound();
    }

    public void PlayMenuSound()
    {
        FindObjectOfType<AudioManager>().Play("MenuButton");
    }

    public void pickSoccer()
    {
        modePick = 0;
        PlayMenuSound();
        setModesColors();
    }

    public void pickTennis()
    {
        modePick = 1;
        PlayMenuSound();
        setModesColors();
    }

    public void pickAR()
    {
        modePick = 2;
        PlayMenuSound();
        setModesColors();
    }

    public void setModesColors()
    {
        if (modePick == 0)
        {
            soccerModeText.colorGradientPreset = green;
            tennisModeText.colorGradientPreset = red;
            arModeText.colorGradientPreset = red;

        }
        else if (modePick == 1)
        {
            tennisModeText.colorGradientPreset = green;
            soccerModeText.colorGradientPreset = red;
            arModeText.colorGradientPreset = red;

        }
        else if (modePick == 2)
        {
            arModeText.colorGradientPreset = green;
            soccerModeText.colorGradientPreset = red;
            tennisModeText.colorGradientPreset = red;
        }
    }
}
