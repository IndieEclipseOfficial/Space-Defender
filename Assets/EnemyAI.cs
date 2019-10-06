using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float speed;
    public Transform target;
    public float offset;
    public GameObject Particle;
    public float angleFinal;

    private void Start() {
        target = GameObject.FindGameObjectWithTag("Planet").transform;

        var targetPos = target.position;
        var thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        var angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        angleFinal = angle;
    }

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        var targetPos = target.position;
        var thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        var angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

        if(transform.position == target.position) {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleFinal + offset));
        }
    }

    public IEnumerator DestroyProcedure() {
        GetComponent<SpriteRenderer>().sprite = null;
        GetComponent<PolygonCollider2D>().enabled = false;
        Particle.GetComponent<Animator>().SetBool("Died", true);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
