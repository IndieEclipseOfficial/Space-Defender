using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    private Vector2 MousePos;
    private RaycastHit2D Hit;
    public LayerMask enemyMask;
    public GameObject Particle;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (GetHit().collider != null) {
                if (GetHit().collider.CompareTag("Enemy")) {
                    var obj = Instantiate(Particle, GetHit().collider.gameObject.transform.position, Quaternion.identity);
                    Destroy(obj, 3f);
                    FindObjectOfType<AudioManager>().Play("Explosion");
                    StartCoroutine(GetHit().collider.GetComponent<EnemyAI>().DestroyProcedure());
                    PointSystem.points += 10;
                    print("took damage");
                }
            }
        }
    }

    private RaycastHit2D GetHit() {
        Hit = Physics2D.Raycast(GetMousePos(), Vector2.zero, Mathf.Infinity, enemyMask);
        return Hit;
    }

    private Vector2 GetMousePos() {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return MousePos;
    }
}
