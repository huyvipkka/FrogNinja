using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    protected Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.left * GameManager.Instance.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x <= -20)
        {
            rb.position = new Vector2(20, 0);
        }
    }
}
