using UnityEngine;

public class MothershipMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float stopAtX = 5f; // The X position where the mothership stops moving
    
    void Update()
    {
        // Move left until it hits the 'stopAtX' point
        if (transform.position.x > stopAtX)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player touches the mothership, the level is officially won
        if (other.CompareTag("Player"))
        {
            Debug.Log("Mission Accomplished! You reached the Mothership.");
            Time.timeScale = 0f; // Optional: Freeze the game
            // You can call a Win UI here later
        }
    }
}