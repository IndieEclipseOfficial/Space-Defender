using UnityEngine;

public class AutoRotate : MonoBehaviour {

    public float speed;

    private Transform target;

    private void Start() {
        target = GameObject.FindGameObjectWithTag("Planet").transform;
    }

    private void Update() {
        transform.RotateAround(target.position, Vector3.back, speed * Time.deltaTime);
    }
}
