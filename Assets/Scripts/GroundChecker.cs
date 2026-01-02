using UnityEngine;

[RequireComponent(typeof(ColorChanger))]
public class GroundChecker : MonoBehaviour
{
    private Platform _currentPlatform;
    
    private ColorChanger _colorChanger;

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Platform platform) != true)
            return;

        if (_currentPlatform == platform)
            return;

        _currentPlatform = platform;
        _colorChanger.Change();
    }
}