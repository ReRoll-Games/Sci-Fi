using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    [SerializeField] private Window _window;

    private bool _playerInsideArea = false;

    private const float windowTriggerRadius = 2.3f;


    private void Start() => AttachWindowTrigger();

    private void AttachWindowTrigger()
    {
        var collider = gameObject.AddComponent<CapsuleCollider>();
        collider.radius = windowTriggerRadius;
        collider.height = 20f;
        collider.includeLayers = 1 << LayerMask.NameToLayer("Player");
        collider.isTrigger = true;

        var areaTrigger = gameObject.AddComponent<AreaTrigger>();
        areaTrigger.onEnter += OnAreaEnter;
        areaTrigger.onExit += OnAreaExit;
    }

    private void OnAreaExit()
    {
        if (!_playerInsideArea) return;

        _playerInsideArea = false;
        _window.Close();
    }

    private void OnAreaEnter()
    {
        if (_playerInsideArea) return;

        _playerInsideArea = true;
        Building.SetInteractableBuilding(_window.Building);
        _window.Open();
    }



}
