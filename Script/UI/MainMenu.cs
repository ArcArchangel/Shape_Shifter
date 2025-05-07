using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;

    private void Awake()
    {
        mainMenuScreen.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }



    public void Quit()
    {
        Application.Quit(); //Quits the game (only works on build)

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
        #endif
    }
}
