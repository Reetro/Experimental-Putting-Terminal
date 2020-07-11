using UnityEngine;

public class SpeedPad : ObstalcleBase
{
    [SerializeField] private float speedMultiplier = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsObjectBall(collision.gameObject))
        {
            var ball = GetBallComponent(collision.gameObject);
            
            if (ball)
            {
                ball.IncreaseSpeed(speedMultiplier);
            }
        }
    }
}
