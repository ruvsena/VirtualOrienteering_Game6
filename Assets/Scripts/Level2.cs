using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2 : MonoBehaviour
{
    public AudioSource aud;
    public void Play()
    {
        aud.time = .8f;
        aud.Play();
        SceneManager.LoadScene("Scene2");
    }

    public Canvas cv;

    public void Credits()
    {
        aud.time = .8f;
        aud.Play();
        cv.enabled = false;
    }

    public void backcredits()
    {
        aud.time = .8f;
        aud.Play();
        cv.enabled = true;
    }

    public void exitt()
    {
        aud.time = .8f;
        aud.Play();
        Application.Quit();
    }
}
