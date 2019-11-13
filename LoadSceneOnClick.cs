using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{

    // TODO: Go into each Button -> Button Component -> OnClick -> 
    // Edit the sceneIndex parameter from within Unity to be the right scene
    // So, make a new scene for each of Rectangle, Circle, Triangle at least for now
    public void LoadByIndex(int sceneIndex)
    {
        // Load scene using SceneManager
        SceneManager.LoadScene(sceneIndex);
        // May be a way to pass parameter to a scene? That way could use the same scene
    }
}
