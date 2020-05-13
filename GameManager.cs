using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public MusicManager musicManager;
    public int PTokensThisGame = 0;
    [SerializeField] private TextMeshProUGUI pTokensText;


    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameCanvas gameCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.T)){
            Time.timeScale = Time.timeScale + 0.2F;
        }
        /*
        if(Time.timeScale < 1 && Time.timeScale > 0.01f){
            Time.timeScale += Time.unscaledDeltaTime;
        }
        else if(Time.timeScale > 1){
            Time.timeScale = 1;
        }
        */
    }
    
    public void Pause(){
        Time.timeScale = 0;
        musicManager.EnterLowPass();
    }
    public void Resume(){
        Time.timeScale = 1;
        musicManager.ExitLowPass();
    }
    public void ReturnToMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void HandleGameOver(){
        gameOverPanel.SetActive(true);
        musicManager.EnterLowPass();
        PlayerPrefs.SetInt("gamesPlayed",PlayerPrefs.GetInt("gamesPlayed",0) + 1);
        PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins",0) + PTokensThisGame);
        PlayerPrefs.SetInt("coinsSofar",PlayerPrefs.GetInt("coinsSofar",0) + PTokensThisGame);


        if(PlayerPrefs.GetFloat("highScore",0)<gameCanvas.timer)
            PlayerPrefs.SetFloat("highScore",gameCanvas.timer);
        //Time.timeScale = 0.2f;
    }
    public void CollectPToken(){
        PTokensThisGame++;
        pTokensText.text = PTokensThisGame.ToString();

    }
}
