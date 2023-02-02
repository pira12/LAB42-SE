using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager instance;

    public bool alarmGeactiveert;
    public bool brandGeblust;
    public bool correcteBrandblusserGebruikt;
    public float tijd;

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
