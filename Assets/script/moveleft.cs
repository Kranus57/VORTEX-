using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 6f;   // ← Change this number in Inspector (try 5-10)

    void Update()
    {
        // Move left smoothly
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destroy when far off left screen
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}