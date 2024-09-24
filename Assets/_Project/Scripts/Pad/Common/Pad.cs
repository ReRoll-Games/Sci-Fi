using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pad : MonoBehaviour
{
    [System.Serializable]
    private struct Page
    {
        public PadPageType padPageType;
        public GameObject prefab;
    }



    private static Pad _instance;
    public static PadPageType CurrentPanel {  get; private set; }

    [SerializeField] private Transform _contentContainer;
    [SerializeField] private List<Page> _pages;

    private RectTransform _rectTransform;
    private bool _padOpened = false;
    private Tween _currentTween;

    private const float closedPositionY = 2000f;
    private const float interactDuration = 0.4f;

    private void Awake()
    {
        _instance = this;
        _rectTransform = GetComponent<RectTransform>();
    }

    public static void OpenPage(PadPageType padPageType)
    {
        if (!_instance._padOpened)
            _instance.Animate(open: true);

        foreach (Transform child in _instance._contentContainer)
            Destroy(child.gameObject);

        var prefab = _instance._pages.Find((page) => page.padPageType == padPageType).prefab;
        Instantiate(prefab, _instance._contentContainer);
    }

    public static void Close()
    {
        foreach (Transform child in _instance._contentContainer)
            Destroy(child.gameObject);

        _instance.Animate(open: false);
    }


    private void Animate(bool open)
    {
        float y = open ? 0f : closedPositionY;

        _currentTween?.Kill();
        _currentTween = _rectTransform.DOAnchorPosY(y, interactDuration).SetEase(Ease.InQuad);
        _padOpened = open;
    }



}
