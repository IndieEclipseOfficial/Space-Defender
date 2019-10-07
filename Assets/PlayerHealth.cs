using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public float health;
    public static PlayerHealth instance;
    public GameObject Particle;
    public GameObject Menu;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else {
            return;
        }
    }

    private void Start() {
        Menu.SetActive(true);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            print("Here!");
            Menu.SetActive(true);
        }

        if(health < 0) {
            print("Game Over!");
            SceneManager.LoadScene(1);
        }
        else {
            if (health != 100)
                health += 0.001f;
            else
                return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            health -= 10;
            var obj = Instantiate(Particle, collision.transform.position, Quaternion.identity);
            Destroy(obj, 3f);
            FindObjectOfType<AudioManager>().Play("Explosion");
            StartCoroutine(collision.gameObject.GetComponent<EnemyAI>().DestroyProcedure());
        }
    }
}
