using UnityEngine;

public class BgrMove : MonoBehaviour
{
    protected Rigidbody2D rg;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.velocity = Vector3.left * (GameManager.instance.speed - 1.5f);
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
