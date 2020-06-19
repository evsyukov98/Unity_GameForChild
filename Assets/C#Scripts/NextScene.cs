using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public int NumberOfScene;

    public void Next()
    {
        SceneManager.LoadScene(NumberOfScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
