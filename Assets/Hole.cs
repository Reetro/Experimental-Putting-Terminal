using UnityEngine;

public class Hole : MonoBehaviour
{
    public LevelLoader levelLoader = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsObjectBall(collision.gameObject))
        {
            // TODO MAKE UI FOR LOAD NEXT LEVEL
            levelLoader.StartLevelLoad();
        }
    }

    public bool IsObjectBall(GameObject objectToTest)
    {
        return objectToTest.layer == LayerMask.NameToLayer("Ball");
    }
}
