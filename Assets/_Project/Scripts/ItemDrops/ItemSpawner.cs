using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private ItemDrop _itemPrefab;
    [SerializeField] private Vector2 _spawnAreaSize;
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private int _maxAmount;

    private int _spawnedItemAmount = 0;
    private float _timeToCooldown;


    private void Start()
    {
        _timeToCooldown = _spawnCooldown;

        for (int i = 0; i < _maxAmount; i++)
            Spawn();
    }


    private void Update()
    {
        _timeToCooldown -= Time.deltaTime;
        if (_timeToCooldown < 0f)
        {
            _timeToCooldown = _spawnCooldown;
            if (_spawnedItemAmount < _maxAmount) Spawn();
        }
    }


    private void Spawn()
    {
        float x = Random.Range(transform.position.x - _spawnAreaSize.x / 2,
            transform.position.x + _spawnAreaSize.x / 2);

        float z = Random.Range(transform.position.z - _spawnAreaSize.y / 2,
            transform.position.z + _spawnAreaSize.y / 2);

        Vector3 randomPosition = new Vector3(x, 0f, z);

        Instantiate(_itemPrefab, randomPosition, Quaternion.identity)
            .onCollected += () => _spawnedItemAmount--;

        _spawnedItemAmount++;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(_spawnAreaSize.x, 0f, _spawnAreaSize.y));
    }


}
