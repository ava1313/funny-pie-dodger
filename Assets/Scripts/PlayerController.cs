using UnityEngine;

/// <summary>
/// Moves the player left and right and triggers game over when colliding with an obstacle.
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Horizontal movement speed in units per second
    public float moveSpeed = 8f;

    // Boundary limits along the x-axis to keep the player on screen
    public float xBound = 8f;

    void Update()
    {
        // Read horizontal input (A/D or left/right arrow keys)
        float horizontal = Input.GetAxis("Horizontal");

        // Move the player
        Vector3 pos = transform.position;
        pos.x += horizontal * moveSpeed * Time.deltaTime;

        // Clamp the x-position so the player stays within screen bounds
        pos.x = Mathf.Clamp(pos.x, -xBound, xBound);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // When colliding with an obstacle, end the game
        if (other.CompareTag("Obstacle"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
