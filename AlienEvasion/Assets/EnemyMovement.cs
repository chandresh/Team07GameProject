using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float verticalSpeed = 0.0f;
    float horizontalSpeed = 0.0f;
    float verticalRange = 0.0f;
    float horizontalRange = 0.0f;

    [SerializeField] bool allowVerticalMovement = true;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

        if (allowVerticalMovement)
        {
            verticalSpeed = (1 + GameManager.CurrentLevel) * 0.5f;
            verticalRange = 1 + GameManager.CurrentLevel;
        }

        horizontalSpeed = (1 + GameManager.CurrentLevel) * 0.25f;
        horizontalRange = (1 + GameManager.CurrentLevel) * 0.5f;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * verticalSpeed) * verticalRange;
        float newX = Mathf.Cos(Time.time * horizontalSpeed) * horizontalRange;

        transform.position = new Vector3(startPosition.x + newX, startPosition.y + newY, startPosition.z);
    }
}
