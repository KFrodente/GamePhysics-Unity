using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    public float score;

    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        scoreText.text = $"Score: {score}";
    }
}
