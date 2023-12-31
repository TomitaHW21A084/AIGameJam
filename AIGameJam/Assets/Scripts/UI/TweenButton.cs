using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class TweenButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] float ScaleMin = 0.9f;
    [SerializeField] float ScaleMax = 1.0f;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip SE;

    public bool OnceClick = true;

    public System.Action onClickCallback;

    [SerializeField] public CanvasGroup _canvasGroup;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnceClick)
        {
            OnceClick = false;
            onClickCallback?.Invoke();
            audioSource.PlayOneShot(SE);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(ScaleMin, 0.24f).SetEase(Ease.OutCubic).SetUpdate(true).SetLink(gameObject);
        _canvasGroup.DOFade(0.8f, 0.24f).SetEase(Ease.OutCubic).SetUpdate(true).SetLink(gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(ScaleMax, 0.24f).SetEase(Ease.OutCubic).SetUpdate(true).SetLink(gameObject);
        _canvasGroup.DOFade(1f, 0.24f).SetEase(Ease.OutCubic).SetUpdate(true).SetLink(gameObject);
    }
}
