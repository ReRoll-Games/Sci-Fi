using UnityEngine;
using DG.Tweening;
using System;

public class Window : MonoBehaviour
{
    public event Action onOpened;

    private Tween _currentTween;
    [SerializeField] private float _originScale;

    private const float showDuration = 0.4f;


    private Building _building;
    public Building building => _building == null ? Building.currentBuilding : _building;



    private void Start()
    {
        transform.localScale = Vector3.zero;
        _building = Building.currentBuilding;
    }



    public void Open()
    {
        _currentTween?.Kill();
        _currentTween = transform.DOScale(_originScale, showDuration).SetEase(Ease.OutQuad);
        onOpened?.Invoke();
    }

    public void Close()
    {
        _currentTween?.Kill();
        _currentTween = transform.DOScale(0f, showDuration).SetEase(Ease.OutQuad);
        _currentTween.onComplete += () => Destroy(gameObject);
    }






}
