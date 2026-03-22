using UnityEngine;

public class QuadScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private MeshRenderer meshRenderer;
    private float offset = 0f;

    public static bool canScroll = true; 

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        canScroll = true; // Reset when you press play
    }

    void Update()
    {
        if (canScroll)
        {
            // Manual offset only grows when canScroll is true
            offset += Time.deltaTime * scrollSpeed;
            meshRenderer.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}