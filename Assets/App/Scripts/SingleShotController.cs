using UnityEngine;

public class SingleShotController : MonoBehaviour
{
    [SerializeField]
    private Color _activatedColor = Color.green;

    [SerializeField]
    private float _resetTime = 0.5f;

    private Color _originalColor;

    private Material _material;

    private float _timeActivated = float.MinValue;

    public void ShowActivated()
    {
        _timeActivated = Time.time;
    }

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
        _originalColor = _material.color;
    }

    void Update()
    {
        var desiredColor = Time.time - _timeActivated > _resetTime ? 
            _originalColor : _activatedColor;
        if (_material.color != desiredColor)
        {
            _material.color = desiredColor;
        }
    }
}
