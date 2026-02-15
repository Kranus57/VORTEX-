using UnityEngine;

public class QuadScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // This slides the texture, not the object!
        float xOffset = Time.time * scrollSpeed;
        meshRenderer.material.mainTextureOffset = new Vector2(xOffset, 0);
    }
}