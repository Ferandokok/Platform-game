using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
public class Scores : MonoBehaviour
{
    public TextMeshProUGUI test;
    public int score;

    public AudioSource EnemyDie;

    void Update()
    {
        test.text = score.ToString();
    }

    public void scoreAdd()
    {
        EnemyDie.Play();
        score++;
    }
}