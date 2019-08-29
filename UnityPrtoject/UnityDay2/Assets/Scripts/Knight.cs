using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField]
    private float _xLeft;
    private float _xRight;
    private float _distance;
    private float _speed;
    private float _totalTime;
    private float _accumulatedTime;
    private bool _isGoingRight;

    private Transform _transform;

    public void Awake()
    {
        _xLeft = -2;
        _xRight = 2;
        _distance = _xRight - _xLeft;
        _speed = 1;
        _totalTime = _distance / _speed;
        _transform = transform;
    }

    public void Start()
    {
        var position = _transform.position;
        position.x = _xLeft;
        _transform.position = position;

        _isGoingRight = true;
        _accumulatedTime = 0;
    }

    public void Update()
    {
        var position = _transform.position;

        _accumulatedTime += Time.deltaTime;
        if (_accumulatedTime >= _totalTime)
        {
            _accumulatedTime = 0;
            _isGoingRight = !_isGoingRight;

            var scale = _transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (_isGoingRight ? 1 : -1);
            _transform.localScale = scale;
        }
        else
        {
            float orgX = _isGoingRight ? _xLeft : _xRight;
            float ratio = _accumulatedTime / _totalTime;
            ratio = outQuadratic(ratio);
            if (!_isGoingRight) ratio = -ratio;
            position.x = orgX + ratio * _distance;
        }

        _transform.position = position;
    }

    // following are some easing functions

    private static float outLinear(float t)
    {
        return t;
    }

    private static float outQuadratic(float t)
    {
        return t * (2 - t);
    }

    private static float outCubic(float t)
    {
        return (--t) * t * t + 1;
    }
}
