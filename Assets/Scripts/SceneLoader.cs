using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const int StartScreenSceneIndex = 0;
    private const int Level1SceneIndex = 1;
    private const int GameOverScreenIndex = 2;

    public static void LoadStartScreen()
    {
        SceneManager.LoadScene(StartScreenSceneIndex);
    }
    public static void LoadLevel1()
    {
        SceneManager.LoadScene(Level1SceneIndex);
    }

    public static void LoadGameOverScreen()
    {
        SceneManager.LoadScene(GameOverScreenIndex);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
    
}
