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
        string alarm = StateManager.instance.alarmGeactiveert ? "V" : "X";
        string brand = StateManager.instance.brandGeblust ? "V" : "X";
        string brandblusser = StateManager.instance.correcteBrandblusserGebruikt ? "V" : "X";

        int total_score = 0;
        
        if (StateManager.instance.alarmGeactiveert)
        {
            total_score += 1;
        }
        
        if (StateManager.instance.brandGeblust)
        {
            total_score += 1;
        }
        
        if (StateManager.instance.correcteBrandblusserGebruikt)
        {
            total_score += 1;
        }
        
        scoreText.text =
            $"Tijd: {StateManager.instance.tijd}s\n Brandalarm geactiveerd: {alarm}\n Brand geblust: {brand}\n Correcte brandblusser: {brandblusser}\n Score: {total_score}/3";
    }
}
