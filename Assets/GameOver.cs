using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

    public int Min;
    public int Max;
    public int Amount;

    public int ID;

    private void Start() {
        StartCoroutine(Blink());
    }

    IEnumerator Blink() {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Image>().enabled = true;
        StartCoroutine(Blink());
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            var pos = transform.position;

            if (transform.position.y < Max) {
                transform.position = new Vector2(pos.x, pos.y += Amount);
                ID--;
            }
            else
                return;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            var pos = transform.position;

            if (transform.position.y > Min) {
                transform.position = new Vector2(pos.x, pos.y -= Amount);
                ID++;
            }
            else
                return;
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            switch (ID) {
                case 0:
                    Application.OpenURL("https://youtube.com/c/indieeclipse");
                    break;
                case 1:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                    break;
                case 2:
                    Application.Quit();
                    break;
            }
        }
    }
}
