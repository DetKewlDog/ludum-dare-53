using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public string SceneName;
    public void Load() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneName);
    }
}
