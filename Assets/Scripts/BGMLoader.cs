using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] audioClips;  
    private AudioSource audioSource;
    private int currentClipIndex = 0;
    void PlayNextClip()
    {
        if (audioClips.Length == 0) return;  
        audioSource.clip = audioClips[currentClipIndex];  
        audioSource.Play();  
        Invoke(nameof(PlayNextClip), audioSource.clip.length);  
        currentClipIndex = (currentClipIndex + 1) % audioClips.Length;  
    }
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        PlayNextClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
