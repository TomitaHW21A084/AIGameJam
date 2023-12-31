using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class StartButton : MonoBehaviour
{
    [SerializeField] TweenButton tweenButton;
    [SerializeField] CanvasGroup StartBoard;
    [SerializeField] TextMeshProUGUI ReadyGo;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip BGM;

    [SerializeField] AudioSource seAudioSource;
    [SerializeField] AudioClip SE1;
    [SerializeField] AudioClip SE2;

    void Start()
    {
        if (tweenButton != null)
        {
            tweenButton.onClickCallback = StartButtonCallBack; 
        }
        else tweenButton.onClickCallback = () => StartCoroutine("LoadYourAsyncScene");

    }


    void StartButtonCallBack()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(StartBoard.DOFade(0, 1.0f).SetLink(gameObject).SetUpdate(true).SetEase(Ease.OutQuad).SetDelay(0.5f)
            .OnComplete(() => { StartBoard.gameObject.SetActive(false); ReadyGo.gameObject.SetActive(true);seAudioSource.PlayOneShot(SE1); }))

                .Append(ReadyGo.DOFade(0, 2.0f).SetLink(gameObject).SetUpdate(true).SetEase(Ease.OutQuad).SetDelay(1.0f)
            .OnComplete(() => ReadyGo.text = "Go!!"))

                .Append(ReadyGo.DOFade(1.0f, 0.3f).SetLink(gameObject).SetUpdate(true).SetEase(Ease.OutQuad).OnComplete(() => { audioSource.PlayOneShot(BGM); seAudioSource.PlayOneShot(SE2); }))

                .Append(ReadyGo.DOFade(0f, 0.2f).SetLink(gameObject).SetUpdate(true).SetEase(Ease.OutQuad).SetDelay(0.5f)
                .OnComplete(() => {
                    ReadyGo.gameObject.SetActive(false);
                    StartGame.shouldStartingGame = true;
                    Time.timeScale = 1.0f;
                }));
    }
}


