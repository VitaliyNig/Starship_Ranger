using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> audioList;
    [SerializeField]
    private List<int> indexList;
    private AudioSource audioSource;
    private int random;

    private void Awake()
    {
        GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("Audio");
        if (audioObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        AudioGenerator();
    }

    private void FixedUpdate()
    {
        if (!audioSource.isPlaying)
        {
            AudioGenerator();
        }
    }

    private void AudioGenerator()
    {
        do
        {
            random = Random.Range(0, audioList.Count);
            if (!indexList.Contains(random))
            {
                break;
            }
        } while (true);
        indexList.Add(random);
        audioSource.clip = audioList[random];
        audioSource.Play();
        if (indexList.Count == audioList.Count)
        {
            indexList.Clear();
        }
    }
}