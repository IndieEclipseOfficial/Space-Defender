using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public float Min;
    public float Max;
    public float Amount;

    public int ID;

    private void Start() {
        Invoke("Delay", 1.5f);
    }

    public void Delay() {
        Time.timeScale = 0;
    }

    IEnumerator Blink() {
        yield return new WaitForSecondsRealtime(0.5f);
        GetComponent<Image>().enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        GetComponent<Image>().enabled = true;
        StartCoroutine(Blink());
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (transform.position.x > Min) {
                var pos = transform.position;
                transform.position = new Vector2(pos.x - Amount, pos.y);
                ID--;
            }
            else {
                return;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if(transform.position.x < Max) {
                var pos = transform.position;
                transform.position = new Vector2(pos.x + Amount, pos.y);
                ID++;
            }
            else {
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            switch (ID) {
                case 0:
                    Time.timeScale = 1;
                    transform.parent.gameObject.SetActive(false);
                    break;
                case 1:
                    SceneManager.LoadScene(0);
                    Time.timeScale = 1;
                    transform.parent.gameObject.SetActive(false);
                    break;
                case 2:
                    Application.Quit();
                    break;
            }
        }
    }
}
