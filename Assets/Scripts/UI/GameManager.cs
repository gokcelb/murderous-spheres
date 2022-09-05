using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI gameOver;

    private void Update()
    {
        score.text = "Score: " + Models.Score.TotalPoints;
    }

    public void GameOver()
    {
        gameOver.text = "Game Over";
    }
}
