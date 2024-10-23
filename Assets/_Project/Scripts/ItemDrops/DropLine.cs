using UnityEngine;

public class DropLine : MonoBehaviour
{
    [SerializeField] private float _startVelocity;

    private ItemPack _itemPack;
    private Vector3 _currentVelocity;

    private const float gravity = 20f;
    private const float startAngle = 75f;
    public const float floorPositionY = 0.5f;


    public void SetItemPack(ItemPack itemPack) => _itemPack = itemPack;


    private void OnEnable()
    {
        float azimutAngle = Random.Range(0f, 360f);

        Vector3 startDirection = Quaternion.Euler(startAngle, azimutAngle, 0f) * Vector3.forward;
        startDirection.y = Mathf.Abs(startDirection.y);
        _currentVelocity = startDirection * _startVelocity;
    }


    private void Update()
    {
        _currentVelocity.y -= gravity * Time.deltaTime;
        transform.Translate(_currentVelocity * Time.deltaTime);

        if (transform.position.y < floorPositionY)
            OnDrop();
    }


    private void OnDrop()
    {
        var itemDrop = GameResources.GetItemConfig(_itemPack.itemType).ItemDropPrefab;

        var spawnPosition = transform.position;
        spawnPosition.y = 0f;

        var instance = Instantiate(itemDrop, spawnPosition, Quaternion.identity);
        instance.SetAmount(_itemPack.amount);

        Destroy(gameObject);
    }


}
