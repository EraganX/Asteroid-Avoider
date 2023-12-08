using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultilier;

    private float score;
    private bool isCounting = true;

    private void Update()
    {
        if (!isCounting) { return; }
        score += Time.deltaTime * scoreMultilier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public int EndTimer()
    {
        isCounting = false;

        scoreText.text = string.Empty;

        return Mathf.FloorToInt(score);
    }
}
