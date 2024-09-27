using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitZone : MonoBehaviour
{
    [SerializeField] public string correctFruitTag;
    [SerializeField] public AudioClip positiveSound;
    [SerializeField] public AudioClip negativeSound;
    [SerializeField]public AudioSource globalAudioSource; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(correctFruitTag))
        {
            globalAudioSource.PlayOneShot(positiveSound);
            ScoreManager.Instance.AddScore(10);
        }
        else
        {
            globalAudioSource.PlayOneShot(negativeSound);
            ScoreManager.Instance.AddScore(-5);
        }
    }
}

