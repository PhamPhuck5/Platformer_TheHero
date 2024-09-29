using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : Singleton<AudioControler>
{
    public AudioSource EffectAudio;
    public AudioSource BackgroundSoundAudio;


    public void SetEffectVoice(string filename)
    {
        EffectAudio.clip = (AudioClip)Resources.Load("Sound/" + filename);
        if(EffectAudio.clip != null)
        {
        EffectAudio.Play();
        }
    }
    public void ChangeBackgroundVolume(float Value)
    {
        BackgroundSoundAudio.volume = Value;
    }
    public void ChangeEffectVolume(float Value)
    {
        EffectAudio.volume = Value;
    }
}
