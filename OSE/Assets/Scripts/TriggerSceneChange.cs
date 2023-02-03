/**
 * TriggerSceneChange.cs
 * Authors: Christiaan Molier
 * Date: January 2023
 * Description: This script is used to change the scene when the player enters a trigger zone.
 */
using UnityEngine;

public class TriggerSceneChange : MonoBehaviour
{
    public SceneTransitionManager sceneTransitionManager;
    public int sceneIndex;

    private void OnTriggerEnter(Collider col)
    {
        sceneTransitionManager.GoToScene(sceneIndex);
    }
}
