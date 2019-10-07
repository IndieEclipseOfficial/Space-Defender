using UnityEngine;

public class Selector : MonoBehaviour {

    public GameObject AutoAttacker;
    public GameObject Particle;

    public void DestroyAll() {
        if (PointSystem.points >= 100) {
            var allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in allEnemies) {
                var obj = Instantiate(Particle, enemy.transform.position, Quaternion.identity);
                Destroy(obj, 3f);
                FindObjectOfType<AudioManager>().Play("Explosion");
                StartCoroutine(enemy.GetComponent<EnemyAI>().DestroyProcedure());
            }
            PointSystem.points -= 100;
        }
    }

    public void CreateNew() {
        if (PointSystem.points >= 150) {
            var obj = Instantiate(AutoAttacker, new Vector3(0, 1.5f, 0), Quaternion.identity);
            PointSystem.points -= 150;
        }
    }

    public void IncreaseFireRate() {
        if (PointSystem.points >= 50) {
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
    }
}
