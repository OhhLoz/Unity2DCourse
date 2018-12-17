using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    int guess;
    [SerializeField] int maxNumber;
    [SerializeField] int minNumber;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    // Use this for initialization
    void Start ()
    {
        calculateGuess(minNumber, maxNumber);
        maxNumber++;

        //Debug.Log("Welcome to Number Wizard!");
        //Debug.Log("Pick a number");
        //Debug.Log("Lower number is: " + minNumber);
        //Debug.Log("Higher number is: " + maxNumber);
        //Debug.Log("Tell me if your number is higher or lower than " + guess);
        //Debug.Log("Push Up = Higher, Push Down = Lower, Enter = Correct");
    }

    void calculateGuess(int min, int max)
    {
        //guess = ((min + max) / 2);
        guess = Random.Range(min, max + 1);
        textMeshProUGUI.text = guess.ToString();
    }

    public void onPressHigher()
    {
        maxNumber = guess - 1;
        calculateGuess(minNumber, maxNumber);
    }

    public void onPressCorrect()
    {

    }

    public void onPressLower()
    {
        minNumber = guess + 1;
        calculateGuess(guess, maxNumber);
    }
}
