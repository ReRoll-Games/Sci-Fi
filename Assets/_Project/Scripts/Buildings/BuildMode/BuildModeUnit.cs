using UnityEngine;
using UnityEngine.UI;


public class BuildModeUnit : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _availableMaterial;
    [SerializeField] private Material _notAvailableMaterial;
    [SerializeField] private Button _applyButton;


    public void SetAvailable(bool value)
    {
        _renderer.material = value ? _availableMaterial : _notAvailableMaterial;
        _applyButton.gameObject.SetActive(value);
    }




}
