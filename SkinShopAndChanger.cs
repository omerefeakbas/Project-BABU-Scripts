using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;



public class SkinShopAndChanger : MonoBehaviour
{

    //Property array for the skins

    

    [SerializeField] Sprite[] heads;
    [SerializeField] Sprite[] arms;
    [SerializeField] Sprite[] handsClosed;
    [SerializeField] Sprite[] handsOpened;
    [SerializeField] Sprite[] handsClick;

    [Header("Attributes:")]
    [SerializeField] string[] names;
    [Header("Keys: 0-Common , 1-Rare , 2-Epic , 3-Legendary")]
    [SerializeField] int[] rarity;
    [SerializeField] int[] prices;
    [SerializeField] bool[] isCurrencyTypeGem;
    
    
    [Header("Keys: 5-Common , 6-Rare , 7-Epic , 8-Legendary")]
    public int[] keys;

    [SerializeField] TextMeshProUGUI charNameText;
    [SerializeField] TextMeshProUGUI priceText;

    public Sprite gemIcon;
    public Sprite coinIcon;
    public Image currencyTypeIcon;

    public Button purchaseButton;

    //Refferance to the skin
    [SerializeField] SpriteRenderer head, arm, handClosed, handOpened, handClick;
    private int currentSkinNumber = 0;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI gemText;

    public TextMeshProUGUI purchasedSkinsText;
    public GameObject purchasedSkinsGO;

    public GameObject commonParticule, rareParticule, epicParticule, legendaryParticule; //Particule systems to Instanciate when the player purchases a skin
    private int[] tempKeys;

    void Start()
    {     
        PlayerPrefs.SetInt("isSkinBABUpurchased",1);
        SortArrays();

        //Initianlize the current charracter at start
        currentSkinNumber = PlayerPrefs.GetInt("selectedSkin",0);
        InitializeSkin();
        
        goldText.text = PlayerPrefs.GetInt("coins",0).ToString();
        gemText.text = PlayerPrefs.GetInt("gem",300).ToString();

        //Handle purchase button at start
        if(PlayerPrefs.GetInt("isSkin"+names[currentSkinNumber].ToString()+"purchased",0) == 0){
            if(isCurrencyTypeGem[currentSkinNumber] == false){
                currencyTypeIcon.sprite = coinIcon;
                if(prices[currentSkinNumber] <= PlayerPrefs.GetInt("coins",0)){
                    
                    purchaseButton.gameObject.SetActive(true);
                    purchaseButton.interactable = true;
                }
                else{
                    purchaseButton.gameObject.SetActive(true);
                    purchaseButton.interactable = false;
                }
            }
            else{
                currencyTypeIcon.sprite = gemIcon;
                if(prices[currentSkinNumber] <= PlayerPrefs.GetInt("gem",300)){
                    
                    purchaseButton.gameObject.SetActive(true);
                    purchaseButton.interactable = true;
                }
                else{
                    purchaseButton.gameObject.SetActive(true);
                    purchaseButton.interactable = false;
                }
            }               
        }
        else{
            purchaseButton.gameObject.SetActive(false);
        }
    }
    
    public void ChangeSkin(int x){
        // +1 / -1 selected skin number than handle actions with this number
        if(x == -1){
            if(currentSkinNumber == 0){
                currentSkinNumber = heads.Length - 1;
            }
            else{
                currentSkinNumber = currentSkinNumber - 1;
            }
        }
        else if (x == 1){
            if(currentSkinNumber == heads.Length - 1){
                currentSkinNumber = 0;
            }
            else{
                currentSkinNumber = currentSkinNumber + 1;
            }
        }

        if(PlayerPrefs.GetInt("isSkin"+names[currentSkinNumber].ToString()+"purchased",0) == 0){
            if(isCurrencyTypeGem[currentSkinNumber] == false){
                currencyTypeIcon.sprite = coinIcon;
                if(prices[currentSkinNumber] <= PlayerPrefs.GetInt("coins",0)){
                    purchaseButton.gameObject.SetActive(true);
                    purchaseButton.interactable = true;
                }
                else{
                    purchaseButton.gameObject.SetActive(true);
                    purchaseButton.interactable = false;
                }
            }
            else{
                currencyTypeIcon.sprite = gemIcon;
                if(prices[currentSkinNumber] <= PlayerPrefs.GetInt("gem",300)){
                    purchaseButton.gameObject.SetActive(true);
                    purchaseButton.interactable = true;
                }
                else{
                    purchaseButton.gameObject.SetActive(true);
                    purchaseButton.interactable = false;
                }
            }               
        }
        else{
            purchaseButton.gameObject.SetActive(false);
        }

        //Change the skin
        head.sprite = heads[currentSkinNumber];
        arm.sprite = arms[currentSkinNumber];
        handClosed.sprite = handsClosed[currentSkinNumber];
        handOpened.sprite = handsOpened[currentSkinNumber];
        handClick.sprite = handsClick[currentSkinNumber];
        charNameText.text = names[currentSkinNumber];
        priceText.text = prices[currentSkinNumber].ToString();

        //Change color due to the rarity

        if(rarity[currentSkinNumber]==0) {
            charNameText.color = Color.white; 
        }    //Common
            
        else if(rarity[currentSkinNumber]==1){
            charNameText.color = new Color(0,128,254);
        } //Rare
            
        else if(rarity[currentSkinNumber]==2) //Epic
            charNameText.color = new Color(128,0,128);
        else                                  //Legendary
            charNameText.color = new Color(254,128,0);

        //If the skin purchased: Select as current skin
        if(PlayerPrefs.GetInt("isSkin"+names[currentSkinNumber].ToString()+"purchased",0) == 1)
            PlayerPrefs.SetInt("selectedSkin",currentSkinNumber);

    }



    public void PurchaseSkin(){

        PlayerPrefs.SetInt("isSkin"+names[currentSkinNumber].ToString()+"purchased",1);

        if(isCurrencyTypeGem[currentSkinNumber]==false)
            PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins",0) - prices[currentSkinNumber]);
        else
            PlayerPrefs.SetInt("gems",PlayerPrefs.GetInt("gems",300) - prices[currentSkinNumber]);
        goldText.text = PlayerPrefs.GetInt("coins",0).ToString();
        gemText.text = PlayerPrefs.GetInt("gems",0).ToString();
        purchaseButton.gameObject.SetActive(false);

        if(rarity[currentSkinNumber]==0)
            Instantiate(commonParticule,new Vector3(0,0,0),Quaternion.identity);
        else if(rarity[currentSkinNumber]==1)
            Instantiate(rareParticule,new Vector3(0,0,0),Quaternion.identity);
        else if(rarity[currentSkinNumber]==2)
            Instantiate(epicParticule,new Vector3(0,0,0),Quaternion.identity);
        else if(rarity[currentSkinNumber]==3)
            Instantiate(legendaryParticule,new Vector3(0,0,0),Quaternion.identity);

        PlayerPrefs.SetInt("ownedSkins",PlayerPrefs.GetInt("ownedSkins",0)+1);
        purchasedSkinsText.text = "Purchased Skins: " + PlayerPrefs.GetInt("ownedSkins",0).ToString() + "/" + keys.Length.ToString();
        purchasedSkinsGO.SetActive(true);

    }

    public void ResetPlayerPrefs(){
        PlayerPrefs.DeleteAll();
    }

    public void Add1000Coins(){
        PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins",0)+1000);
        goldText.text = PlayerPrefs.GetInt("coins",0).ToString();
    }

    private void SortArrays(){

        InitializeKeys();
        int[] tempKeys = new int[keys.Length];

        Array.Copy(keys, tempKeys, keys.Length);
        Array.Sort(tempKeys,heads);

        Array.Copy(keys,tempKeys,keys.Length);
        Array.Sort(tempKeys,arms);

        Array.Copy(keys,tempKeys,keys.Length);
        Array.Sort(tempKeys,handsClosed);

        Array.Copy(keys,tempKeys,keys.Length);
        Array.Sort(tempKeys,handsOpened);

        Array.Copy(keys,tempKeys,keys.Length);
        Array.Sort(tempKeys,handsClick);

        Array.Copy(keys,tempKeys,keys.Length);
        Array.Sort(tempKeys,names);

        Array.Copy(keys,tempKeys,keys.Length);
        Array.Sort(tempKeys,rarity);

        Array.Copy(keys,tempKeys,keys.Length);
        Array.Sort(tempKeys,isCurrencyTypeGem);

        Array.Copy(keys,tempKeys,keys.Length);
        Array.Sort(tempKeys,prices);

    }

    private void InitializeKeys(){
        
        for(int i = 0; i < keys.Length ; i++){
            if(PlayerPrefs.GetInt("isSkin"+names[i].ToString()+"purchased",0) == 1){
                keys[i] -= 4;    
            }  
        }
        
    }
    
    private void InitializeSkin(){

        head.sprite = heads[PlayerPrefs.GetInt("selectedSkin",0)];
        arm.sprite = arms[PlayerPrefs.GetInt("selectedSkin",0)];
        handClosed.sprite = handsClosed[PlayerPrefs.GetInt("selectedSkin",0)];
        handOpened.sprite = handsOpened[PlayerPrefs.GetInt("selectedSkin",0)];
        handClick.sprite = handsClick[PlayerPrefs.GetInt("selectedSkin",0)];
        charNameText.text = names[PlayerPrefs.GetInt("selectedSkin",0)];

        if(rarity[currentSkinNumber]==0)                //Common
            charNameText.color = Color.white;
        else if(rarity[currentSkinNumber]==1)           //Rare
            charNameText.color = new Color(0,128,255);
        else if(rarity[currentSkinNumber]==2)           //Epic
            charNameText.color = new Color(128,0,128);
        else                                            //Legendary
            charNameText.color = new Color(255,128,0);
    }
}
