//using System.Collections;
//using System.Collections.Generic;
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
