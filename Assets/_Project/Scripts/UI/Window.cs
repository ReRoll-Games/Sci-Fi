using UnityEngine;
using DG.Tweening;
using System;

public class Window : MonoBehaviour
{
    public event Action onOpened;

    [field: SerializeField] public Building Building { get; private set; }

    private Tween _currentTween;

    private const float originScale = 0.01f;
    private const float showDuration = 0.4f;
    private const float rotationX = 50f;
    private const float positionY = 3.2f;




    private void Start()
    {
        transform.localScale = Vector3.zero;
        transform.rotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.localPosition = new Vector3(0f, positionY, 0f);
    }

    public void Open()
    {
        _currentTween?.Kill();
        _currentTween = transform.DOScale(originScale, showDuration).SetEase(Ease.OutQuad);
        onOpened?.Invoke();
    }

    public void Close()
    {
        _currentTween?.Kill();
        _currentTween = transform.DOScale(0f, showDuration).SetEase(Ease.OutQuad);
    }






}
