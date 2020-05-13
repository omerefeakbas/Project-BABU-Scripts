using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static AudioClip sound1, sound2, sound3, sound4, sound5, sound6;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        sound1 = Resources.Load<AudioClip>("CoinCollect_1"); 
        sound2 = Resources.Load<AudioClip>("CoinCollect_2");
        sound3 = Resources.Load<AudioClip>("CoinCollect_3");
        sound4 = Resources.Load<AudioClip>("Player_Jump_1");
        sound5 = Resources.Load<AudioClip>("Player_Jump_2");
        sound6 = Resources.Load<AudioClip>("Player_Die_1");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string soundClip){
        switch(soundClip){
        case "CoinCollect_1":
            audioSrc.PlayOneShot(sound1);
            break;
        case "CoinCollect_2":
            audioSrc.PlayOneShot(sound2);
            break;
        case "CoinCollect_3":
            audioSrc.PlayOneShot(sound3);
            break;
        case "Player_Jump_1":
            audioSrc.PlayOneShot(sound4);
            break;
        case "Player_Jump_2":
            audioSrc.PlayOneShot(sound5);
            break;
        case "Player_Die_1":
            audioSrc.PlayOneShot(sound6,0.5f);
            break;
        }
        
    }
}
