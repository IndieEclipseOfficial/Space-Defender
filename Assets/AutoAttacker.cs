using UnityEngine;
using System.Collections;

public class AutoAttacker : MonoBehaviour {

    public GameObject bullet;
    public GameObject Particle;
    public float fireRate = 1f;
    public GameObject Shoot;
    public Transform fireport;

    private void Start() {
        fireRate = GameObject.FindGameObjectWithTag("Ships").GetComponent<AutoAttacker>().fireRate;
        StartCoroutine(spawn());
    }

    IEnumerator spawn() {
        yield return new WaitForSeconds(fireRate);
        SpawnBullet();
        StartCoroutine(spawn());
    }

    private void SpawnBullet() {
        var obj = Instantiate(bullet, transform.position, transform.rotation);
        var obj2 = Instantiate(Shoot, fireport.position, Quaternion.identity);
        Destroy(obj2, 1f);
        Destroy(obj, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            var obj = Instantiate(Particle, transform.position, Quaternion.identity);
            Destroy(obj, 3f);
            FindObjectOfType<AudioManager>().Play("Explosion");
            StartCoroutine(collision.gameObject.GetComponent<EnemyAI>().DestroyProcedure());
            Destroy(gameObject);
        }
    }
}
