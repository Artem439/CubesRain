using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private bool _landed = false;
    private Platform _currentPlatform;
    
    public event Action FeelOnPlatform;
    
    private void Update(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Platform platform))
        {
            FeelOnPlatform?.Invoke();
            
            _landed = true;
            _currentPlatform = platform;
        }
    }
}