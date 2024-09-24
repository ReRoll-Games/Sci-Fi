using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TechnologyDescription : MonoBehaviour
{
    private static TechnologyDescription _instance;

    public static TechnologyType TechnologyType {  get; private set; }
    public static int Level { get; private set; }


    [SerializeField] private GameObject _panel;
    [SerializeField] private ItemWidget _itemWidget;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;



    private void Awake() => _instance = this;


    public static void Open(TechnologyType technologyType, int level)
    {
        TechnologyType = technologyType;
        Level = level;

        var technologyConfig = GameResources.GetTecnhologyConfig(technologyType);

        _instance._panel.SetActive(true);
        //_instance._itemWidget.SetItems(technologyConfig.GetRequiredItems(level));
        _instance._icon.sprite = technologyConfig.GetIconSprite(level);
        _instance._titleText.text = technologyConfig.GetTitle(level);
        _instance._descriptionText.text = technologyConfig.GetDescription(level);

    }

    public static void Close() => _instance._panel.SetActive(false);


}
