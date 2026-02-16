using UnityEngine;

public class ObjectParallax : MonoBehaviour
{
    public float speed = 2f;
    public float screenEdgeLeft = -15f;
    public float screenEdgeRight = 15f;

    void Update()
    {
        // Physically move the planet to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // If it goes off the left edge, teleport it to the right edge
        if (transform.position.x < screenEdgeLeft)
        {
            float randomY = Random.Range(-4f, 4f); // Randomize height for variety
            transform.position = new Vector3(screenEdgeRight, randomY, transform.position.z);
        }
    }
}