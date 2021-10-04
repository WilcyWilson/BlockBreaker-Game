using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    //parameters
    [SerializeField] int breakableBlocks=default;

    //cached reference
    SceneLoader sceneLoader;

    public void CountBlocks()
    {
        breakableBlocks++;
    }
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        FindObjectOfType<Text>().text = gameObject.scene.name;
        Destroy(FindObjectOfType<Text>(), 1f);
    }
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks==0)
        {
            sceneLoader.LoadNextScene();
        }
    }
  
}
