using UnityEngine;
using System.Collections;

public class Playlist : MonoBehaviour
{
    public AudioClip[] soundtrack;
    AudioSource AS;
    public bool danger;
    int index = 1;
    // Use this for initialization
    void Start()
    {
        AS = this.GetComponent<AudioSource>();
        if (!AS.playOnAwake)
        {
            AS.clip = soundtrack[0];
            AS.Play();
        }
    }
    void Update()
    {
        if (!AS.isPlaying)
            index = 1 + (index%2);

        if (danger && AS.clip != soundtrack[index])
        {
            AS.clip = soundtrack[index];
            AS.Play();
        }

        if (!danger && AS.clip != soundtrack[0])
        {
            AS.clip = soundtrack[0];
            AS.Play();
        }
    }
}