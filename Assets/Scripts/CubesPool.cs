using UnityEngine;
using UnityEngine.Pool;

public class CubesPool : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private float _repeatRate;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;
    
    private ObjectPool<GameObject> _cubesPool;

    private void Awake()
    {
        _cubesPool = new ObjectPool<GameObject>(
            createFunc: () => _cubeSpawner.Spawn(),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void ActionOnGet(GameObject cube)
    {
        //cube.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cube.SetActive(true);
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetCube), 0.0f, _repeatRate);
    }

    private void GetCube()
    {
        _cubesPool.Get();
    }

    public void Release(Collider other)
    {
        _cubesPool.Release(other.gameObject);
    }
}