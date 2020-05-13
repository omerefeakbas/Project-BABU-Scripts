using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MusicManager : MonoBehaviour
{

    public AudioMixerSnapshot snapshotPaused;
    public AudioMixerSnapshot snapshotUnpaused;
    private AudioSource music;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    public Image musicIcon;
    public float transitionDuration;
    
    void Start(){
        music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        if(PlayerPrefs.GetInt("isMusicMuted",0)==1){
            music.mute = true;
            musicIcon.sprite = musicOffSprite;
        }
            
    }
    public void ToggleMusic(){
        if(PlayerPrefs.GetInt("isMusicMuted",0)==0){
            PlayerPrefs.SetInt("isMusicMuted",1);
            music.mute = true;
            musicIcon.sprite = musicOffSprite;
        }
        else{
            PlayerPrefs.SetInt("isMusicMuted",0);
            musicIcon.sprite = musicOnSprite;
            music.mute = false;
        }
    }
    
    public void EnterLowPass(){
        snapshotPaused.TransitionTo(transitionDuration);
    }
    public void ExitLowPass(){
        snapshotUnpaused.TransitionTo(transitionDuration);
    }
}
