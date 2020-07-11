using UnityEngine;

public class ObstalcleBase : MonoBehaviour
{
    public bool IsObjectBall(GameObject objectToTest)
    {
        return objectToTest.layer == LayerMask.NameToLayer("Ball");
    }

    public Rigidbody2D GetBallRigidBody(GameObject ballObject)
    {
        return ballObject.GetComponent<Rigidbody2D>();
    }

    public Ball GetBallComponent(GameObject ballObject)
    {
        return ballObject.GetComponent<Ball>();
    }
}