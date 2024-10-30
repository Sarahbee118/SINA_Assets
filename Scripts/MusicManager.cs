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
        if (Instance != null)
        {
         //   Debug.Log(screenMusic.name);
           // Debug.Log(MusicManager.Instance.screenMusic.name);
            if (MusicManager.Instance.musicPlayer.clip.name == musicPlayer.clip.name)
            {
                Debug.Log("the same song");
                //Destroy(gameObject);

                return;
            }
            else
            {
                Debug.Log("not the same song");
                MusicManager.Instance.musicPlayer.Stop();
                // MusicManager.Instance = this;
                //Destroy(MusicManager.Instance);
                //Instance = this;
                //DontDestroyOnLoad(gameObject);
                MusicManager.Instance.musicPlayer.clip = musicPlayer.clip;
                MusicManager.Instance.musicPlayer.clip.name = musicPlayer.clip.name;
                MusicManager.Instance.musicPlayer.Play();
               // Destroy(gameObject);
                return;

            }
        
        }
        else
        {
            Instance = this;
            MusicManager.Instance.musicPlayer.Play();
            DontDestroyOnLoad(gameObject);
        }
        // end of new code

        
    }
}
