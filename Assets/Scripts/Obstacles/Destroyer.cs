using UnityEngine;

public class Destroyer : ObstalcleBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsObjectBall(collision.gameObject))
        {
            var ball = GetBallComponent(collision.gameObject);

            ball.UpdateSlider(true);

            Destroy(collision.gameObject);

            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            if (player)
            {
                player.addToPlayerBallCount();
            }
        }
    }
}
