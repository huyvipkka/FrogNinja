using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    protected Rigidbody2D rg;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.velocity = Vector3.left * GameManager.instance.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (rg.position.x <= -20)
        {
            rg.position = new Vector2(20, 0);
        }
    }
}
