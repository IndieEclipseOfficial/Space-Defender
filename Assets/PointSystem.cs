using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour {

    public static int points;
    public TMPro.TMP_Text pointsText;

    private void Start() {
        points = 0;
    }

    private void Update() {
        pointsText.text = points + " pts";
    }
}
