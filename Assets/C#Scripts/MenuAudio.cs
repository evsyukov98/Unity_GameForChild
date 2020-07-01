using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudio : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("MainMusic");
        if ( scene.name == "Levels")
        {

        }
        else if (scene.name == "Menu")
        {
            for (int i = 1; i < audioObjects.Length; i++)
            {
                Destroy(audioObjects[i]);
            }
        }
        else
        {
            for (int i = 0; i < audioObjects.Length; i++)
            {
                Destroy(audioObjects[i]);
            }
        }
    }

   


}
