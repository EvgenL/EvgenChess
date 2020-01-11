using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudionManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioBonk;
    [SerializeField] private AudioSource _audioNo;
    [SerializeField] private AudioSource _audioTake;

    public void PlayNo()
    {
        _audioNo.Play();
    }
    public void PlayBonk()
    {
        _audioBonk.Play();
    }
    public void PlayTake()
    {
        _audioTake.Play();
    }
}
