using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager instance;

    public int score;
    public int score2;
    public int score3;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
