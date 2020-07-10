using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    public float transitionTime = 1f;

    /// <summary>
    /// Will load the next level in build index
    /// </summary>
    public void StartLevelLoad()
    {
        StartCoroutine(LoadNextLevel());
    }
    /// <summary>
    /// TODO CREATE A GAMEOVER SCREEN WHEN PLAYER REACHES THE LAST LEVEL
    /// </summary>
    public void LoadGameOver()
    {
        Debug.LogWarning("Need an end level screen");
    }

    private IEnumerator LoadNextLevel()
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        int nextLevelIndex = SceneManager.sceneCount + 1;

        if (nextLevelIndex >= SceneManager.sceneCountInBuildSettings)
        {
            LoadGameOver();
        }
        else
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
    }
}
