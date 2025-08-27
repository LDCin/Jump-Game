using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : Panel
{
    [SerializeField] private Image _BGMButtonIcon;
    [SerializeField] private Image _SFXButtonIcon;
    [SerializeField] private Sprite _offIcon;
    [SerializeField] private Sprite _onIcon;
    public bool _isOnBGM = true;
    public bool _isOnSFX = true;
    public void Awake()
    {
        _BGMButtonIcon.sprite = _onIcon;
        _SFXButtonIcon.sprite = _onIcon;
    }
    public void Update()
    {
        if (_isOnBGM) TurnOnBGM();
        else TurnOffBGM();
        if (_isOnSFX) TurnOnSFX();
        else TurnOffSFX();
    }
    public void ChangeBGMState()
    {
        _isOnBGM = !_isOnBGM;
    }
    public void ChangeSFXState()
    {
        _isOnSFX = !_isOnSFX;
    }
    public void BackToMenu()
    {
        Close();
    }
    public void TurnOnBGM()
    {
        SoundManager.Instance.PlayBGM();
        _BGMButtonIcon.sprite = _onIcon;
    }
    public void TurnOffBGM()
    {
        SoundManager.Instance.StopBGM();
        _BGMButtonIcon.sprite = _offIcon;
    }
    public void TurnOnSFX()
    {
        SoundManager.Instance.TurnOnSFX();
        _SFXButtonIcon.sprite = _onIcon;
    }
    public void TurnOffSFX()
    {
        SoundManager.Instance.TurnOffSFX();
        _SFXButtonIcon.sprite = _offIcon;
    }
    public void Credit()
    {
        Application.OpenURL(GameConfig.CREDIT_URL);
    }
}