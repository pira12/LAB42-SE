/**
 * ScoreCalculator.cs
 * Authors: Christiaan Molier
 * Date: January 2023
 * Description: This script is used to calculate the score of the player.
 * It uses the StateManager to check if the player has completed the level.
 */
using TMPro;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshPro scoreText;


    void Start()
    {
        string alarm = StateManager.instance.alarmGeactiveert ? "v" : "x";
        string brand = StateManager.instance.brandGeblust ? "v" : "x";
        string brandblusser = StateManager.instance.correcteBrandblusserGebruikt ? "v" : "x";
        scoreText.text =
            $"Tijd: {StateManager.instance.tijd}s\n Brandalarm geactiveerd: {alarm}\n Brand geblust: {brand}\n Correcte brandblusser gebruikt: {brandblusser}";
    }
}
