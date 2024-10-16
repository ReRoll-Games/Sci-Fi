using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IdleShine_Tween : MonoBehaviour
{
    [SerializeField] private Image _image;
    [Space(10)]
    [SerializeField] private float _duration;
    [SerializeField] private float _fromAlpha;
    [SerializeField] private float _toAlpha;


    private Sequence _currentSequence;


    private void OnEnable()
    {
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _fromAlpha);

        _currentSequence = DOTween.Sequence()
            .Append(_image.DOFade(_toAlpha, _duration).SetEase(Ease.Linear))
            .Append(_image.DOFade(_fromAlpha, _duration).SetEase(Ease.Linear))
            .SetLoops(-1);
    }

    private void OnDisable()
    {
        _currentSequence.Kill();
    }


}
