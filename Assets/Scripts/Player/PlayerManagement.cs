using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    public static PlayerManagement Instance { get; private set; }
    public CharState PlayerState = CharState.RUN;
    public Rigidbody2D rb;
    protected Animator ani;
    [Header("Run")]
    [SerializeField] protected float moveSpeed = 10;
    [Header("Jumpping")]
    readonly float jumpHigh = 15;

    protected SpriteRenderer spriteRd;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else Instance = this;
    }


    void Start()
    {
        PlayerState = CharState.RUN;
        rb = GetComponent<Rigidbody2D>();
        spriteRd = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
        UpdateStateAndAnimation();
    }
    void Move()
    {
        // move
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.transform.position += moveSpeed * Time.deltaTime * new Vector3(moveInput, 0);
        // flip
        if (moveInput < 0) spriteRd.flipX = true;
        else if (moveInput > 0) spriteRd.flipX = false;
    }
    void Jump()
    {
        // jump
        if (Input.GetKey(KeyCode.W)
        && PlayerState != CharState.JUMP
        && PlayerState != CharState.FALL)
        {
            rb.AddForce(Vector2.up * jumpHigh, ForceMode2D.Impulse);
            Debug.Log("Player jump");
        }
    }

    void UpdateStateAndAnimation()
    {
        if (rb.velocity.y < 0)
            PlayerState = CharState.FALL;
        else if (rb.velocity.y > 0)
            PlayerState = CharState.JUMP;
        else if (Input.GetAxisRaw("Horizontal") == 0)
            PlayerState = CharState.IDLE;
        else
            PlayerState = CharState.RUN;

        ani.SetInteger("State", (int)PlayerState);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            rb.velocity = new Vector2(-GameManager.Instance.speed, 0);
        }
    }
}
