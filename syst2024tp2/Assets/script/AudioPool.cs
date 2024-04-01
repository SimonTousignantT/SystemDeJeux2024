using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPool : MonoBehaviour
{
    private List<AudioSource> m_AudioPool = new List<AudioSource>();
    public void PlayMusicPool(AudioClip Sound)
    {
        if(m_AudioPool.Count == 0)
        {
            AudioSource myNewAudio = gameObject.AddComponent<AudioSource>();
            m_AudioPool.Add(myNewAudio);
        }
        foreach(AudioSource source in m_AudioPool)
        {
            if (!source.isPlaying)
            {
                source.clip = Sound;
                source.Play();
                return;
            }
        }
        AudioSource NewAudio = gameObject.AddComponent<AudioSource>();
        m_AudioPool.Add(NewAudio);
        NewAudio.clip = Sound;
        NewAudio.Play();

    }
   
}
