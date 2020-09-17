using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource music;
    private void Start()
    {
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        GameObject.Find("MusicCoolio").GetComponent<AudioSource>().mute = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        GameObject.Find("MusicCoolio").GetComponent<AudioSource>().mute = false;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
        GameObject.Find("MusicCoolio").GetComponent<AudioSource>().mute = false;
    }
    public void toggleMusic()
    {
        music.mute = !music.mute;
    }

}
