using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI pTokenCountText;

    [SerializeField] private GameCanvas gameCanvas;
    [SerializeField] private TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        pTokenCountText.text = gameManager.PTokensThisGame.ToString();
        highScoreText.text = gameCanvas.timer.ToString("0.00");
    }
}
