using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    private Renderer _renderer;

    private Color _defaultColor;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }
    
    public void Change()
    {
        _renderer.material.color = GetRandomColor();
    }

    public void Reset()
    {
        _renderer.material.color = _defaultColor;
    }
    
    private Color GetRandomColor(
        float minSaturation = 0.8f,
        float maxSaturation = 1f,
        float minValue = 0.8f,
        float maxValue = 1f)
    {
        return Random.ColorHSV(0f, 1f, minSaturation, maxSaturation, minValue, maxValue);
    }
}