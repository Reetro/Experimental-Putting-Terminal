using UnityEngine;

public class Destroyer : ObstalcleBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsObjectBall(collision.gameObject))
        {
            Destroy(collision.gameObject);
        }
    }
}
