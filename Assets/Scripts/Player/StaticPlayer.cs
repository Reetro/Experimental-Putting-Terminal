using UnityEngine;

public class StaticPlayer : MonoBehaviour
{
    Camera mainCam;
    Vector2 mousePosition = Vector2.zero;

    public GameObject ballPrefab;
    public Transform spawnTransform;
    public int playerBallCount = 1;
    public float ballSpeed = 2;

    void Awake()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.GetChild(0).up = direction;

        if (Input.GetButtonDown("Fire1"))
        {
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        bool cantSpawn = playerBallCount <= 0;

        if (!cantSpawn)
        {
            var ball = Instantiate(ballPrefab, (Vector2)spawnTransform.position, spawnTransform.rotation);

            ball.GetComponent<Ball>().ThrowBall(ballSpeed, this);

            playerBallCount--;
        }
    }
}
