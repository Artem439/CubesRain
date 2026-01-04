using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubesPool _cubesPool;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    
    private IEnumerator SpawnRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            yield return delay;
            
            Vector3 spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
            
            Cube cube = _cubesPool.Get();
            
            cube.Reset(spawnPosition);
            
            cube.Released += OnReleased;
        }
    }

    private void OnReleased(Cube cube)
    {
        cube.Released -= OnReleased;
        
        _cubesPool.Release(cube);
    }
}