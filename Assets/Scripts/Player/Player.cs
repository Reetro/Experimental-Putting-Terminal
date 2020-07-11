using UnityEngine;

public class Player : MonoBehaviour
{
    Camera mainCam;
    Vector2 mousePosition = Vector2.zero;

    public GameObject ballPrefab;
    public Transform spawnTransform;
    [SerializeField] private int playerBallCount = 1;
    [SerializeField] private float ballSpeed = 2;
    [SerializeField] private float ballLifeTime = 3f;
    [SerializeField] private float ballMaxSpeed = 10f;

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

    public void addToPlayerBallCount()
    {
        playerBallCount = Mathf.Clamp(playerBallCount + 1, 0, 1);
    }

    public void SpawnBall()
    {
        bool cantSpawn = playerBallCount <= 0;

        if (!cantSpawn)
        {
            var ball = Instantiate(ballPrefab, (Vector2)spawnTransform.position, spawnTransform.rotation);

            ball.GetComponent<Ball>().ThrowBall(ballSpeed, this, ballLifeTime, ballMaxSpeed);

            playerBallCount--;
        }
    }
}
