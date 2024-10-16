using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VG;

public class TechnologyDescription : MonoBehaviour
{
    private static TechnologyDescription _instance;

    public static TechnologyType TechnologyType {  get; private set; }
    public static int Level { get; private set; }


    [SerializeField] private GameObject _panel;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private List<ItemIcon> _requiredItemIcons;


    private void Awake() => _instance = this;


    public static void Open(TechnologyType technologyType, int level)
    {
        TechnologyType = technologyType;
        Level = level;

        var technologyConfig = GameResources.GetTecnhologyConfig(technologyType, level);

        _instance._panel.SetActive(true);
        _instance._icon.sprite = technologyConfig.IconSprite;
        _instance._titleText.text = technologyConfig.Title;
        _instance._descriptionText.text = technologyConfig.Description;

        var requiredItems = technologyConfig.RequiredItems;
        for (int i = 0; i < requiredItems.Count; i++)
        {
            var itemIcon = _instance._requiredItemIcons[i];

            itemIcon.gameObject.SetActive(true);
            itemIcon.SetItemType(requiredItems[i].itemType);

            int hasItems = Saves.Int[Key_Save.item_amount(requiredItems[i].itemType)].Value;
            itemIcon.SetAmount(hasItems, requiredItems[i].amount);

        }
        for (int i = requiredItems.Count; i < 3; i++)
            _instance._requiredItemIcons[i].gameObject.SetActive(false);

        ClosePadButton.AddAction(() => _instance._panel.SetActive(false));
    }

    public static void Close() => _instance._panel.SetActive(false);


}
