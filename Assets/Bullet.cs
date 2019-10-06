using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public GameObject Particle;

    private void Update() {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            var obj = Instantiate(Particle, transform.position, Quaternion.identity);
            Destroy(obj, 3f);
            FindObjectOfType<AudioManager>().Play("Explosion");
            StartCoroutine(collision.GetComponent<EnemyAI>().DestroyProcedure());
            PointSystem.points += 5;
            Destroy(gameObject);
        }
    }
}
