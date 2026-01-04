using UnityEngine;
using UnityEngine.Pool;

public class CubesPool : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _capacity;
    [SerializeField] private int _maxSize;
    
    private ObjectPool<Cube> _cubesPool;
    
    private void Awake()
    {
        _cubesPool = new ObjectPool<Cube>(
            createFunc: () => CreateObject(),
            actionOnGet: (obj) => OnGetObject(obj),
            actionOnRelease: (obj) => OnReleaseObject(obj),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _capacity,
            maxSize: _maxSize);
    }
    
    public Cube Get()
    {
        return _cubesPool.Get();
    }

    public void Release(Cube cube)
    {
        _cubesPool.Release(cube);
    }

    private Cube CreateObject()
    {
        return Instantiate(_cubePrefab);
    }

    private void OnGetObject(Cube cube)
    {
        cube.gameObject.SetActive(true);
    }
    
    private void OnReleaseObject(Cube cube)
    {
        cube.gameObject.SetActive(false);
    }
}