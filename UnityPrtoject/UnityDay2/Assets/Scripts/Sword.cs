using UnityEngine;

public class Sword : MonoBehaviour
{
    private float _yTop;
    private float _yBottom;
    private float _speed;
    private bool _isGoingDown;

    private Transform _transform;

    public void Awake()
    {
        _transform = transform;

        var localPosition = _transform.localPosition;
        _yTop = localPosition.y + 0.05f;
        _yBottom = localPosition.y - 0.05f;

        _speed = 0.25f;
    }

    public void Start()
    {
        _isGoingDown = true;
    }

    public void Update()
    {
        var localPosition = _transform.localPosition;

        if (_isGoingDown && localPosition.y <= _yBottom)
        {
            _isGoingDown = false;
            localPosition.y = _yBottom;
        }
        else if (!_isGoingDown && localPosition.y >= _yTop)
        {
            _isGoingDown = true;
            localPosition.y = _yTop;
        }

        localPosition.y += _speed * Time.deltaTime * (_isGoingDown ? -1 : 1);

        _transform.localPosition = localPosition;
    }
}
