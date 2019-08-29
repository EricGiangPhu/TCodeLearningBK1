using UnityEngine;

public class Traveller : MonoBehaviour
{
    private enum Direction
    {
        Top,
        Bottom,
        Left,
        Right
    }

    private float _width;
    private float _height;
    private float _speed;
    private Vector3 _topLeft;
    private Vector3 _topRight;
    private Vector3 _bottomLeft;
    private Vector3 _bottomRight;
    private Direction _direction;

    private Transform _transform;

    public void Awake()
    {
        _width = 5;
        _height = 8;
        _speed = 3;
        _topLeft = new Vector3(-_width / 2, _height / 2, 0);
        _topRight = new Vector3(_width / 2, _height / 2, 0);
        _bottomLeft = new Vector3(-_width / 2, -_height / 2, 0);
        _bottomRight = new Vector3(_width / 2, -_height / 2, 0);
        _transform = transform;
    }

    public void Start()
    {
        _transform.position = _topLeft;
        _direction = Direction.Right;
    }

    public void Update()
    {
        var position = _transform.position;
        updateDirection(ref position);
        updatePosition(ref position);
        _transform.position = position;
    }

    private void updateDirection(ref Vector3 position)
    {
        // topLeft -> topRight -> bottomRight -> bottomLeft
        switch (_direction)
        {
            case Direction.Top:
                if (position.y >= _topLeft.y)
                {
                    position.y = _topLeft.y;
                    _direction = Direction.Right;
                }
                break;
            case Direction.Bottom:
                if (position.y <= _bottomRight.y)
                {
                    position.y = _bottomRight.y;
                    _direction = Direction.Left;
                }
                break;
            case Direction.Left:
                if (position.x <= _bottomLeft.x)
                {
                    position.x = _bottomLeft.x;
                    _direction = Direction.Top;
                }
                break;
            case Direction.Right:
                if (position.x >= _topRight.x)
                {
                    position.x = _topRight.x;
                    _direction = Direction.Bottom;
                }
                break;
        }
    }

    private void updatePosition(ref Vector3 position)
    {
        switch (_direction)
        {
            case Direction.Top:
                position.y += _speed * Time.deltaTime;
                break;
            case Direction.Bottom:
                position.y -= _speed * Time.deltaTime;
                break;
            case Direction.Left:
                position.x -= _speed * Time.deltaTime;
                break;
            case Direction.Right:
                position.x += _speed * Time.deltaTime;
                break;
        }
    }
}
