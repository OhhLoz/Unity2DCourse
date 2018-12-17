using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    [SerializeField] int noOfBlocks;

    public void Start()
    {
        //countBlocks();
    }

    public void countBlocks()
    {
        noOfBlocks = FindObjectsOfType<Block>().Length;
    }

    public void blockAdded()
    {
        noOfBlocks++;
    }

    public void blockDestroyed()
    {
        noOfBlocks--;
        if (noOfBlocks <= 0)
            FindObjectOfType<SceneLoader>().loadNextScene();
    }
}
