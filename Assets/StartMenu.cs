using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    private void Start() {
        Time.timeScale = 0;
    }

    public void Resume() {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Restart() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Quit() {
        Application.Quit();
    }
}
