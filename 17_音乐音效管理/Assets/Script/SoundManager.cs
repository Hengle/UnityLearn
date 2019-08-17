using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private SoundManager()
    { }

    private Dictionary<string, AudioClip> _soundDictionary;

    private AudioSource[] audioSources;

    /// <summary>
    /// 背景音乐
    /// </summary>
    private AudioSource bgAudioSource;  

    /// <summary>
    /// 音效
    /// </summary>
    private AudioSource audioSourceEffect;


    private void Awake()
    {
        instance = this;

        _soundDictionary = new Dictionary<string, AudioClip>();

        //本地加载
        AudioClip[] audioArry = Resources.LoadAll<AudioClip>("Music");

        audioSources = GetComponents<AudioSource>();

        bgAudioSource = audioSources[0];
        audioSourceEffect = audioSources[1];

        //将音效存放到字典
        foreach (AudioClip item in audioArry)
        {
            _soundDictionary.Add(item.name, item);
        }
    }


    //播放背景音乐
    public void PlayBgaudio(string audioName)
    {
        if (_soundDictionary.ContainsKey(audioName))
        {
            bgAudioSource.clip = _soundDictionary[audioName];
            bgAudioSource.Play();
        }
    }

    //播放音效
    public void PlayAudioEffect(string audioEffectName)
    {
        if (_soundDictionary.ContainsKey(audioEffectName))
        {
            audioSourceEffect.clip = _soundDictionary[audioEffectName];
            audioSourceEffect.Play();
        }
    }
}
