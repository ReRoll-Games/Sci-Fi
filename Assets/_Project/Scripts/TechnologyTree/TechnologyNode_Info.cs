using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VG;

public class TechnologyNode_Info : Info
{
    [field: SerializeField] public TechnologyType technologyType { get; private set; }
    [field: SerializeField] public int level { get; private set; }
    [SerializeField] private Button _getButton;
    [SerializeField] private TextMeshProUGUI _priceText;



    protected override void Subscribe()
    {
        Saves.String[Key_Save.technologies_data].onChanged += UpdateValue;
    }
    
    protected override void Unsubscribe()
    {
        Saves.String[Key_Save.technologies_data].onChanged -= UpdateValue;
    }
    
    protected override void UpdateValue()
    {
        var level = Saves.GetTechnologyLevel(technologyType);

        if (level >= this.level) _getButton.interactable = false;
        else _getButton.interactable = true;


        _priceText.text = GameResources.GetTecnhologyConfig(technologyType).
            price.ToString();

    }
    
}