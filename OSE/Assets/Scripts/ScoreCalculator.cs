using TMPro;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshPro scoreText;
    void Start()
    {
        scoreText.text = $"Score:\n Brandalarm geactiveerd: {StateManager.instance.score}\n Brand geblust: {StateManager.instance.score2}\n Correct Gebruik brandblusser: {StateManager.instance.score3}";
    }
}
