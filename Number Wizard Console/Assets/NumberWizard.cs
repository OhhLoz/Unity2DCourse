using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int guess;
    int maxNumber;
    int minNumber;
    // Use this for initialization
    void Start ()
    {
        minNumber = 1;
        maxNumber = 1000;
        calculateGuess(minNumber, maxNumber);

        Debug.Log("Welcome to Number Wizard!");
        Debug.Log("Pick a number");
        Debug.Log("Lower number is: " + minNumber);
        Debug.Log("Higher number is: " + maxNumber);
        Debug.Log("Tell me if your number is higher or lower than " + guess);
        Debug.Log("Push Up = Higher, Push Down = Lower, Enter = Correct");
        maxNumber++;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Your guess is higher");
            minNumber = guess;
            calculateGuess(guess, maxNumber);
            Debug.Log(guess);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Your guess is lower");
            maxNumber = guess;
            calculateGuess(minNumber, maxNumber);
            Debug.Log(guess);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("We guessed correctly!");
            Start();
        }
    }

    void calculateGuess(int min, int max)
    {
        guess = ((min + max) / 2);
    }

}
