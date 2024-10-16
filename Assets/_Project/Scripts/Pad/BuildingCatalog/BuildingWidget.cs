using TMPro;
using UnityEngine;
using VG;

public class BuildingWidget : MonoBehaviour
{
    [field: SerializeField] public BuildingType BuildingType { get; private set; }
    [SerializeField] private TechnologyType _requiredTechnology;
    [SerializeField] private TextMeshProUGUI _buildPrice;


    private void Start()
    {
        bool available = Saves.GetTechnologyLevel(_requiredTechnology) > 0;
        gameObject.SetActive(available);

        int buildingAmount = Saves.GetBuildingAmount(BuildingType);

        int price = GameResources.GetBuildingConfig(BuildingType).GetCurrentPrice();

        _buildPrice.text = $"${price}";
    }

}
