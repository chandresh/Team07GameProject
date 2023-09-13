using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float verticalSpeed = 1.0f;
    float horizontalSpeed = 0.5f;
    float verticalRange = 2.0f;
    float horizontalRange = 1.0f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        verticalSpeed = (1 + GameManager.CurrentLevel) * 0.5f;
        horizontalSpeed = (1 + GameManager.CurrentLevel) * 0.25f;
        verticalRange = 1 + GameManager.CurrentLevel;
        horizontalRange = (1 + GameManager.CurrentLevel) * 0.5f;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * verticalSpeed) * verticalRange;
        float newX = Mathf.Cos(Time.time * horizontalSpeed) * horizontalRange;

        transform.position = new Vector3(startPosition.x + newX, startPosition.y + newY, startPosition.z);
    }
}
