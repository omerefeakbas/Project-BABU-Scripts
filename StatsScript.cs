using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatsScript : MonoBehaviour
{
    public TextMeshProUGUI ownedSkinsText;
    public TextMeshProUGUI gamesPlayedText;
    public TextMeshProUGUI pTokensSoFarText;
    public TextMeshProUGUI highScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        ownedSkinsText.text = PlayerPrefs.GetInt("ownedSkins",0).ToString() + "/" + FindObjectOfType<SkinShopAndChanger>().GetComponent<SkinShopAndChanger>().keys.Length;
        gamesPlayedText.text = PlayerPrefs.GetInt("gamesPlayed",0).ToString();
        pTokensSoFarText.text = PlayerPrefs.GetInt("coinsSofar",0).ToString();
        highScoreText.text = PlayerPrefs.GetFloat("highScore",0).ToString("0.00");
    }

}
