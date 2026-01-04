using UnityEngine;

[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(ColorChanger))]
public class Cube : MonoBehaviour
{
    private GroundChecker _groundChecker;
    private ColorChanger _colorChanger;

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
        _groundChecker = GetComponent<GroundChecker>();
    }
    
    private void OnEnable()
    {
        _groundChecker.FeelOnPlatform += HandleInput;
    }

    private void OnDisable()
    {
        _groundChecker.FeelOnPlatform -= HandleInput;
    }

    private void HandleInput()
    {
        _groundChecker.TryGetComponent(out Platform platform);
        _colorChanger.Change();
    }
}