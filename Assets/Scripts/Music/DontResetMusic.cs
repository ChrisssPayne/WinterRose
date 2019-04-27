using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontResetMusic : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    static bool AudioBegin = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!AudioBegin)
        {
            //Fetch the AudioSource from the GameObject
            m_MyAudioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.m_MyAudioSource);
    }
}
