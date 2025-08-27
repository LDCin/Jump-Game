using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource _BGM;
    [SerializeField] private AudioSource _SFX;

    [SerializeField] private AudioClip _defaultSFX;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _breakSound;

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
        if (_BGM == null)
        {
            Debug.Log("Not Found: BGM");
        }
        _BGM.loop = true;
        _BGM.Play();
    }
    public void StopBGM()
    {
        _BGM.Stop();
    }
    public void PlayClickSound()
    {
        if (_clickSound == null)
        {
            Debug.Log("Not Found: Click Sound");
        }
        _SFX.PlayOneShot(_clickSound);
    }
    public void TurnOffSFX()
    {
        _SFX.mute = true;
    }
    public void TurnOnSFX()
    {
        _SFX.mute = false;
    }
    public void PlayJumpSound()
    {
        _SFX.PlayOneShot(_jumpSound);
    }
    public void PlayBreakSound()
    {
        _SFX.PlayOneShot(_breakSound);
    }
    public void PlayGameOverSound()
    {
        _SFX.PlayOneShot(_gameOverSound);
    }
}
