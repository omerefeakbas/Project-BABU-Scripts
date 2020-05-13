using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float timer = 0;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("0.00");
    }
}
