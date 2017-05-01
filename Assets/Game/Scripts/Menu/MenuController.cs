using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlayMenuMusic();
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("TestScene");
    }
}
