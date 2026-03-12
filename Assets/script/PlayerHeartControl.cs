using UnityEngine;

public class PlayerHeartController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public int maxHealth = 3;
    private int currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }

    void Update() {
        // Get mouse position and convert to world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; 

        // Smoothly move the craft toward the cursor
        transform.position = Vector3.MoveTowards(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }

    public void TakeDamage() {
        currentHealth--;
        Debug.Log("Hearts remaining: " + currentHealth);
        if (currentHealth <= 0) {
            Debug.Log("Spacecraft Destroyed!");
            // Add game over logic here
        }
    }
}