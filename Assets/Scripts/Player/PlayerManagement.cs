using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    public static PlayerManagement Instance { get; private set; }
    public float acceleration = 10;
    public float deceleration = 3;

    public CharState PlayerState = CharState.RUN;
    public Rigidbody2D rb;
    protected Animator ani;
    [Header("Run")]
    [SerializeField] protected float moveSpeed = 10;
    [Header("Jumpping")]
    readonly float jumpHigh = 15;
    float moveInput;
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
        Flip();
        UpdateStateAndAnimation();
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        float targetSpeed = moveInput * moveSpeed;
        float speedDif = targetSpeed - rb.velocity.x;
        float accelRate = Mathf.Abs(targetSpeed) > 0.1f ? acceleration : deceleration;

        float movement = speedDif * accelRate;
        rb.AddForce(movement * Vector2.right);
    }
    void Flip()
    {
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
}
