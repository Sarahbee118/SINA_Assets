using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
   // public AudioClip screenMusic;
    public AudioSource musicPlayer;
    private void Awake()
    {
       // Debug.Log(screenMusic.name);
        // start of new code
        if (Instance != null) //if music is already playing
        {
         //   Debug.Log(screenMusic.name);
           // Debug.Log(MusicManager.Instance.screenMusic.name);
            if (MusicManager.Instance.musicPlayer.clip.name == musicPlayer.clip.name) //if the songs are the same
            {
                //do nothing (aka keep the music playing)
                Debug.Log("the same song");
                //Destroy(gameObject);

                return;
            }
            else
            {
                //stops, changes, starts new music
                Debug.Log("not the same song");
                MusicManager.Instance.musicPlayer.Stop();
                MusicManager.Instance.musicPlayer.clip = musicPlayer.clip;
                MusicManager.Instance.musicPlayer.clip.name = musicPlayer.clip.name;
                MusicManager.Instance.musicPlayer.Play();
                return;

            }
        
        }
        else
        {
            Instance = this;
            MusicManager.Instance.musicPlayer.Play();
            DontDestroyOnLoad(gameObject); //keeps music playing between scenes
        }
        // end of new code

        
    }
}
