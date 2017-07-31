using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    public int maxArmor;
    public int currentArmor;

    public bool destroyed;

    void start() {
        currentHealth = maxHealth;
        currentArmor = maxArmor;
    }

    public void TakeDamage(int damage) {
        if (damage < 1) {
            return;
        }
        if (currentArmor > 0) {
            if (currentArmor - damage > 0) {
                currentArmor -= damage;
            } else {
                currentArmor = 0;
            }
        } else {
            if (currentHealth - damage > 0) {
                currentHealth -= damage;
            } else {
                currentHealth = 0;
                destroyed = true;
            }
        }
    }

    public void Repair(int points) {
        if (points < 1) {
            if (currentHealth + points >= maxHealth) {
                currentHealth = maxHealth;
            } else {
                currentHealth += points;
            }
        }
    }
}
