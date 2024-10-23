using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VG;

public class HealthBar : Info
{
    [SerializeField] private Health _health;
    [SerializeField] private GameObject _bar;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _valueText;


    private void Start()
    {
        _bar.SetActive(false);
    }


    protected override void Subscribe()
    {
        _health.onChanged += UpdateValue;
    }

    protected override void Unsubscribe()
    {
        _health.onChanged -= UpdateValue;
    }

    protected override void UpdateValue()
    {
        _bar.SetActive(_health.Current != _health.Max);

        _slider.value = (float)_health.Current / (float)_health.Max;
        _valueText.text = _health.Current.ToString();
    }
}
