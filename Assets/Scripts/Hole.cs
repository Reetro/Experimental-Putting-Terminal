using UnityEngine;

public class Hole : MonoBehaviour
{
    public LevelLoader levelLoader = null;
    [SerializeField] AudioClip[] ballSounds = null;
    private AudioSource myAudioSorce;

    private void Awake()
    {
        myAudioSorce = GetComponent<AudioSource>();
    }

    private void PlaySound()
    {
        AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];

        myAudioSorce.PlayOneShot(clip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsObjectBall(collision.gameObject))
        {
            PlaySound();

            Destroy(collision.gameObject);

            levelLoader.StartLevelLoad();
        }
    }

    public bool IsObjectBall(GameObject objectToTest)
    {
        return objectToTest.layer == LayerMask.NameToLayer("Ball");
    }
}
