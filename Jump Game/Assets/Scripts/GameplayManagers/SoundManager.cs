using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource _BGM;
    [SerializeField] private AudioSource _SFX;
    [SerializeField] private AudioClip _defaultSFX;
    [SerializeField] private AudioClip _clickSound;
    public override void Awake()
    {
        base.Awake();

    }
    private void Start()
    {
        PlayBGM();
    }
    public void PlayBGM()
    {
        _BGM.loop = true;
        _BGM.Play();
    }
    public void StopBGM()
    {
        _BGM.Stop();
    }
    public void PlayClickSound()
    {
        _SFX.PlayOneShot(_clickSound);
    }
}
