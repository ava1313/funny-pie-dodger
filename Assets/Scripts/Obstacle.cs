using UnityEngine;

/// <summary>
/// Handles obstacle movement and resets once off-screen.
/// </summary>
public class Obstacle : MonoBehaviour
{
    public float fallSpeed = 4f;

    void Update()
    {
        // Move downward
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Destroy the obstacle when it goes off-screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
