using UnityEngine;

public class PlattformScript : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float speed;
    private Vector3 _originalPosition;

    private bool _goRight = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= distance + _originalPosition.x)
        {
            _goRight = false;
        }

        if (transform.position.x <= _originalPosition.x - distance)
        {
            _goRight = true;
        }

        if (_goRight)
        {
            transform.position += Vector3.right * (speed * Time.deltaTime);
        }
        else
        {
            transform.position += Vector3.left * (speed * Time.deltaTime);
        }
        
    }
}
