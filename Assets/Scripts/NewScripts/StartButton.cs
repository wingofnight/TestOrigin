
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [Header("Set in Inspector")]
    public string Scene;

    public void LoadScene()
    {
        SceneManager.LoadScene(Scene);
    }
}
