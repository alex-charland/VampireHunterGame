using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    [SerializeField] private float restartDelay = 5f;
    [SerializeField] public GameObject clearUI;
    [SerializeField] public GameObject gameOverUI;
    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            gameOverUI.SetActive(true);
            Invoke("RestartGame",restartDelay);
        }
    }

    public void CompleteLevel()
    {
        clearUI.SetActive(true);
    }
    public void WinGame()
    {
        Debug.Log("Stage Cleared!");
        CompleteLevel();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameHasEnded = false;
        gameOverUI.SetActive(false);
    }
}
