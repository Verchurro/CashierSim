using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBarreScore : MonoBehaviour
{
    public int score = 0;
    private int maxScore = 1;

    private void OnTriggerEnter(Collider objet)
    {
        //tagBox
        if (objet.tag == "Caisse")
        {
            if(score == maxScore)
            {
                score = maxScore;
            }
            else
            {
                score++;
            }
            
            Debug.Log("Score: " + score);
        }
    }
}
