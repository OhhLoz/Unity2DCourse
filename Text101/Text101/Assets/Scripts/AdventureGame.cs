using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdventureGame : MonoBehaviour
{ 
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    State currState;

	// Use this for initialization
	void Start ()
    {
        currState = startingState;
        textComponent.text = currState.GetStateStory();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ManageState();
	}

    private void ManageState()
    {
        var nextStates = currState.GetNextStates();

        for (int i = 0; i < nextStates.Length; i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                currState = nextStates[i];
            }
        }

        textComponent.text = currState.GetStateStory();
    }
}
