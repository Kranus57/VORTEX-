using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float width;

    void Start()
    {
        // Automatically get the width of the sprite
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Move the object to the left
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // If the object has moved completely off-screen to the left
        if (transform.position.x < -width)
        {
            // Snap it to the right of the other background piece
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}