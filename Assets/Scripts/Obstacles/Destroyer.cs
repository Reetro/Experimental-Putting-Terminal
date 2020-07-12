using UnityEngine;

public class Destroyer : ObstalcleBase
{
    [SerializeField] AudioClip[] blockSounds = null;
    private AudioSource myAudioSorce;

    private void Awake()
    {
        myAudioSorce = GetComponent<AudioSource>();
    }

    private void PlaySound()
    {
        AudioClip clip = blockSounds[Random.Range(0, blockSounds.Length)];

        myAudioSorce.PlayOneShot(clip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsObjectBall(collision.gameObject))
        {
            PlaySound();

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
