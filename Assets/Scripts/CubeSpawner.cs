using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionZ;
    [SerializeField] private float _minPositionZ;
    [SerializeField] private float _spawnRangeY;

    private void OnValidate()
    {
        if (_maxPositionX <= _minPositionX)
            _maxPositionX = _minPositionX + 1;
        
        if (_maxPositionZ <= _minPositionZ)
            _maxPositionZ = _minPositionZ + 1;
    }

    public GameObject Spawn()
    {
        GameObject newCube = Instantiate(_cubePrefab);
        
        newCube.transform.position = GetRandomSpawnPosition();

        return newCube;
    }
    
    private Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(_minPositionX, _maxPositionX);
        float z = Random.Range(_minPositionZ, _maxPositionZ);
        return new Vector3(x, _spawnRangeY, z);
    }
}