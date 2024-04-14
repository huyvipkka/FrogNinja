using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.Log("Game mng err");
        speed = 3;
    }
    public float speed = 3;
    //GameState gameState = GameState.PLAY;

}
