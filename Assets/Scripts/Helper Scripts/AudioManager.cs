using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip pickup_sound, dead_sound;
    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
    }

    // Update is called once per frame
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Play_PickupSound() {
        AudioSource.PlayClipAtPoint(pickup_sound, transform.position);
    }
    public void Play_DeadSound()
    {
        AudioSource.PlayClipAtPoint(dead_sound, transform.position);
    }
}
