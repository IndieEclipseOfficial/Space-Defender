using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {

    public Image[] HealthBarImages;

    private void Update() {
        var health = Mathf.Round(PlayerHealth.instance.health);

        if (health <= 100 && health >= 91) {
            EnableAll();
            ChangeColor(Color.green);
        }
        else if (health <= 90 && health >= 81) {
            EnableAll();
            HealthBarImages[9].enabled = false;
            ChangeColor(Color.green);
        }
        else if (health <= 80 && health >= 71) {
            EnableAll();
            HealthBarImages[9].enabled = false;
            HealthBarImages[8].enabled = false;
            ChangeColor(Color.green);
        }
        else if (health <= 70 && health >= 61) {
            EnableAll();
            HealthBarImages[9].enabled = false;
            HealthBarImages[8].enabled = false;
            HealthBarImages[7].enabled = false;
            ChangeColor(Color.yellow);
        }
        else if (health <= 60 && health >= 51) {
            EnableAll();
            HealthBarImages[9].enabled = false;
            HealthBarImages[8].enabled = false;
            HealthBarImages[7].enabled = false;
            HealthBarImages[6].enabled = false;
            ChangeColor(Color.yellow);
        }
        else if (health <= 50 && health >= 41) {
            EnableAll();
            HealthBarImages[9].enabled = false;
            HealthBarImages[8].enabled = false;
            HealthBarImages[7].enabled = false;
            HealthBarImages[6].enabled = false;
            HealthBarImages[5].enabled = false;
            ChangeColor(Color.yellow);
        }
        else if (health <= 40 && health >= 31) {
            EnableAll();
            HealthBarImages[9].enabled = false;
            HealthBarImages[8].enabled = false;
            HealthBarImages[7].enabled = false;
            HealthBarImages[6].enabled = false;
            HealthBarImages[5].enabled = false;
            HealthBarImages[4].enabled = false;
            ChangeColor(Color.yellow);
        }
        else if(health <= 30 && health >= 21) {
            EnableAll();
            HealthBarImages[9].enabled = false;
            HealthBarImages[8].enabled = false;
            HealthBarImages[7].enabled = false;
            HealthBarImages[6].enabled = false;
            HealthBarImages[5].enabled = false;
            HealthBarImages[4].enabled = false;
            HealthBarImages[3].enabled = false;
            ChangeColor(Color.red);
        }
        else if(health <= 20 && health >= 11) {
            EnableAll();
            HealthBarImages[9].enabled = false;
            HealthBarImages[8].enabled = false;
            HealthBarImages[7].enabled = false;
            HealthBarImages[6].enabled = false;
            HealthBarImages[5].enabled = false;
            HealthBarImages[4].enabled = false;
            HealthBarImages[3].enabled = false;
            HealthBarImages[2].enabled = false;
            ChangeColor(Color.red);
        }
        else if(health <= 10 && health <= 1) {
            EnableAll();
            HealthBarImages[9].enabled = false;
            HealthBarImages[8].enabled = false;
            HealthBarImages[7].enabled = false;
            HealthBarImages[6].enabled = false;
            HealthBarImages[5].enabled = false;
            HealthBarImages[4].enabled = false;
            HealthBarImages[3].enabled = false;
            HealthBarImages[2].enabled = false;
            HealthBarImages[1].enabled = false;
            ChangeColor(Color.red);
        }
        else if(health <= 0) {
            foreach (var healthi in HealthBarImages) {
                healthi.enabled = false;
            }

            print("Game over");
        }
    }

    private void ChangeColor(Color color) {
        foreach (var healthi in HealthBarImages) {
            healthi.color = color;
        }
    }

    private void EnableAll() {
        foreach (var Health in HealthBarImages) {
            Health.enabled = true;
        }
    }
}
