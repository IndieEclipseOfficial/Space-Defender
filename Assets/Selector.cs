using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selector : MonoBehaviour {

    public int Min;
    public int Max;
    public int Amount;

    public int ID;
    public GameObject AutoAttacker;
    public GameObject Particle;
    public Image selector;

    private void Start() {
        StartCoroutine(Blink());
    }

    IEnumerator Blink() {
        yield return new WaitForSeconds(0.5f);
        selector.enabled = false;
        yield return new WaitForSeconds(0.5f);
        selector.enabled = true;
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
                    if(PointSystem.points >= 100) {
                        var allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
                        foreach (var enemy in allEnemies) {
                            var obj = Instantiate(Particle, enemy.transform.position, Quaternion.identity);
                            Destroy(obj, 3f);
                            FindObjectOfType<AudioManager>().Play("Explosion");
                            StartCoroutine(enemy.GetComponent<EnemyAI>().DestroyProcedure());
                        }
                        PointSystem.points -= 100;
                    }
                    break;
                case 1:
                    if(PointSystem.points >= 150) {
                        var obj = Instantiate(AutoAttacker, new Vector3(0, 1.5f, 0), Quaternion.identity);
                        PointSystem.points -= 150;
                    }
                    break;
                case 2:
                    if(PointSystem.points >= 50) {
                        var allShips = GameObject.FindGameObjectsWithTag("Ships");

                        foreach (var ship in allShips) {
                            if (ship.GetComponent<AutoAttacker>().fireRate <= 0.3)
                                return;
                            else {
                                ship.GetComponent<AutoAttacker>().fireRate -= 0.1f;
                                PointSystem.points -= 50;
                            }
                        }

                    }
                    break;
            }

            FindObjectOfType<AudioManager>().Play("Click");
        }
    }
}
