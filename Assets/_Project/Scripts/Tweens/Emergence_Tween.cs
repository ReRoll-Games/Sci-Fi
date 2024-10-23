using DG.Tweening;
using UnityEngine;

public class Emergence_Tween : MonoBehaviour
{
    [SerializeField] private float _fromScale;
    [SerializeField] private float _toScale;
    [SerializeField] private float _duration;


    private Sequence _currentSequence;


    private void OnEnable()
    {
        transform.localScale = Vector3.one * _fromScale;

        _currentSequence = DOTween.Sequence()
            .Append(transform.DOScale(_toScale, _duration).SetEase(Ease.OutFlash));
    }

    private void OnDisable()
    {
        _currentSequence.Kill();
    }



}
