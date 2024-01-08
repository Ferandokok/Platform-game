using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text test;
    public int score;

    void Update()
    {
        test.text = "kill count: " + score.ToString();
    }

    public void scoreAdd()
    {
        score++;
    }
}