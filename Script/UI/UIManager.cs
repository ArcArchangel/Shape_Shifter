using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    [Header ("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    #region  Game Over
    //Activate game over screen
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    //Game over functions
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

        public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

        public void Quit()
    {
        Application.Quit(); //Quits the game (only works on build)

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
        #endif
    }
    #endregion

    #region Sound
    //public void SoundVolume()
    //{
    //    SoundManager.instance.ChangeSoundVolume(0.2f);
    //}

    //public void MusicVolume()
    //{
    //    SoundManager.instance.ChangeMusicVolume(0.2f);
    //}
    #endregion
}
