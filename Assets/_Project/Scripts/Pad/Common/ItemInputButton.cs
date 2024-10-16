using TMPro;
using UnityEngine;
using VG;

public abstract class ItemInputButton : PressedButtonHandler
{
    [SerializeField] private TextMeshProUGUI _putItemAmountText;
    [SerializeField] private RectTransform _frameRect;

    private ItemPack _itemRequire;
    private float _currentInterpolation;

    private const float putDuration = 0.7f;
    private const float addFrameScale = 0.3f;
    
    public void SetItemRequire(ItemPack itemPack) => _itemRequire = itemPack;


    protected override void OnPressFinish()
    {
        _putItemAmountText.gameObject.SetActive(false);
        _frameRect.localScale = Vector3.one;

        int putItemAmount = GetCurrentItemPutAmount();

        Saves.Int[Key_Save.item_amount(_itemRequire.itemType)].Value -= putItemAmount;

        OnItemInput(new ItemPack { 
            itemType = _itemRequire.itemType, 
            amount = putItemAmount
        });

    }

    protected override void OnPressStart()
    {
        _currentInterpolation = 0f;
        _putItemAmountText.gameObject.SetActive(true);
        _putItemAmountText.text = "+0";
    }

    protected override void PressedUpdate()
    {
        _currentInterpolation += Time.deltaTime / putDuration;
        _currentInterpolation = Mathf.Min(1f, _currentInterpolation);

        _putItemAmountText.text = $"+{GetCurrentItemPutAmount()}";
        _frameRect.localScale = Vector3.one * (1f + _currentInterpolation * addFrameScale);

    }


    private int GetCurrentItemPutAmount()
    {
        int inventoryItems = Saves.Int[Key_Save.item_amount(_itemRequire.itemType)].Value;

        int maxItems = inventoryItems > _itemRequire.amount ?
            _itemRequire.amount : inventoryItems;

        return (int)(maxItems * _currentInterpolation);
    }


    public abstract void OnItemInput(ItemPack itemPack);



}
