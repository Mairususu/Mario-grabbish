using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist : MonoBehaviour
{
    [SerializeField] List<AudioClip> clips;
    public AudioSource Source;
    void Start()
    {
        Source.clip=clips[Random.Range(0,clips.Count)];
        Source.Play();
    }
    
    
}
