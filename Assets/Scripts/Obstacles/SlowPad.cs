using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPad : ObstalcleBase
{
    [SerializeField] private float speedDivder = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsObjectBall(collision.gameObject))
        {
            var ball = GetBallComponent(collision.gameObject);

            if (ball)
            {
                ball.DecreaseSpeed(speedDivder);
            }
        }
    }
}
