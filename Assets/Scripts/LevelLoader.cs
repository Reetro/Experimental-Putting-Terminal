using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    public float transitionTime = 1f;

    private void Update()
    {
        // Debug code
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(SceneManager.GetActiveScene().buildIndex + 1);

            StartLevelLoad();
        }
    }

    /// <summary>
    /// Will load the next level in build index
    /// </summary>
    public void StartLevelLoad()
    {
        StartCoroutine(LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadStart()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadNextLevel(int levelIndex)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
