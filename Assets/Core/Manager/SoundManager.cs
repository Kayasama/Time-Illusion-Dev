using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private Dictionary<string, AudioClip> _soundDictionary;
    private AudioSource[] audioSources;

    private AudioSource bgAudioSource;
    private AudioSource audioSourceEffect;

    // 初始化音乐管理
    public void Init()
    {
        _soundDictionary = new Dictionary<string, AudioClip>();

        AudioClip[] audios = Resources.LoadAll<AudioClip>("AudioClip");

        // TODO
        // 创建一个存放音效和BGM的Clip容器，便于更换audioclip
        bgAudioSource = audioSources[0];
        audioSourceEffect = audioSources[1];

        foreach (AudioClip ac in audios)
        {
            _soundDictionary.Add(ac.name, ac);
        }
    }

    public void GetAudioSource(AudioSource[] _audioSources)
    {
        audioSources = _audioSources;
    }

    // 播放背景音
    public void PlayBgAudio(string BgName)
    {
        if(_soundDictionary.ContainsKey(BgName))
        {
            bgAudioSource.clip = _soundDictionary[BgName];
            
            bgAudioSource.loop = true;
            bgAudioSource.Play();
        }
    }

    // 播放效果音
    public void PlayEffectAudio(string EffectName)
    {
        if (_soundDictionary.ContainsKey(EffectName))
        {
            audioSourceEffect.clip = _soundDictionary[EffectName];
            audioSourceEffect.Play();
        }
    }
}
