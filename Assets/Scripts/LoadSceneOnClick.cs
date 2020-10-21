using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Allows the script to interact with the Unity Scence Manager.

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex) //Function that takes an integer called sceneIndex.                                                                                    
    {
        SceneManager.LoadScene(sceneIndex); //Tells the Scene Manager to load a new scene which has an index equal to sceneIndex.        
    }    
}

