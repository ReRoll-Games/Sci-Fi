using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;


public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image _iconImage;


    public ItemType type { get; private set; }

    private RectTransform _rectTransform;

    private const float moveDuration = 1f;
    private const float rotationDeviationAngle = 50f;
    private const float positionDeviation = 15f;


    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void SetType(ItemType type)
    {
        this.type = type;
        _iconImage.sprite = Configs.GetItem(type).IconSprite;
    }


    public void MoveToSlot(RectTransform slot, Action onCompleted)
    {
        transform.SetParent(slot);
        Vector2 targetPosition = new Vector2(
            UnityEngine.Random.Range(-positionDeviation, positionDeviation),
            UnityEngine.Random.Range(-positionDeviation, positionDeviation));

        _rectTransform.localScale = Vector3.zero;
        _rectTransform.rotation = Quaternion.Euler(0f, 0f ,
            UnityEngine.Random.Range(-rotationDeviationAngle, rotationDeviationAngle));

        _rectTransform.DOScale(1f, moveDuration / 2f).SetEase(Ease.OutExpo);
        _rectTransform.DOAnchorPos(targetPosition, moveDuration).SetEase(Ease.OutFlash)
            .onComplete += () => onCompleted?.Invoke();
    }


    public void MoveToDrop(Vector3 worldPosition, Action onCompleted)
    {
        Vector2 canvasPosition = Camera.main.WorldToScreenPoint(worldPosition);

        _rectTransform.SetParent(UI.main);
        _rectTransform.DOScale(0f, moveDuration).SetEase(Ease.InQuad);
        _rectTransform.DOMove(canvasPosition, moveDuration).SetEase(Ease.InQuad)
            .onComplete += () => onCompleted?.Invoke();

    }
       


}
