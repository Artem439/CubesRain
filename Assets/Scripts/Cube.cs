using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(ColorChanger), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private const float MinDelay = 2f;
    private const float MaxDelay = 5f;
    
    private ColorChanger _colorChanger;
    
    private Rigidbody _rigidbody;
    
    private bool _isTouched = false;
    
    public event Action<Cube> Released;

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform _) == false)
            return;
        
        if (_isTouched)
            return;
        
        _isTouched = true;
        
        _colorChanger.Change();
        
        StartCoroutine(CountToDestroyRoutine());
    }

    public void Reset(Vector3 position)
    {
        _isTouched = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.position = position;
        _colorChanger.Reset();
    }
    
    private void Release()
    {
        Released?.Invoke(this);
    }
    
    private IEnumerator CountToDestroyRoutine()
    {
        float randomDelay = Random.Range(MinDelay, MaxDelay);
        
        yield return new WaitForSeconds(randomDelay);
        
        Release();
    }
}