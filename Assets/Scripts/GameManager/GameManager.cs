using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else Instance = this;
        speed = 3;
    }
    public float speed = 3;
    //GameState gameState = GameState.PLAY;

}
