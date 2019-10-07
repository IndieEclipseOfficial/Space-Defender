using UnityEngine;

public class GameOver : MonoBehaviour {

    public void OpenYoutube() {
        Application.OpenURL("https://youtube.com/c/indieeclipse");
    }

    public void Restart() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
