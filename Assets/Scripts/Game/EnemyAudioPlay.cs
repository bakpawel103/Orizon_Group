using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioPlay : MonoBehaviour
{
    [SerializeField]
    private AudioClip crashAudioClip;

    [SerializeField]
    private AudioSource audioSource;

    public void PlayCrash()
    {
        audioSource.clip = crashAudioClip;

        audioSource.Play();
    }
}
