using UnityEngine;

public class Fan : ObstalcleBase
{
    public float fanForce = 2;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsObjectBall(collision.gameObject))
        {
            var ball = GetBallComponent(collision.gameObject);

            if (ball)
            {
                PlaySound();

                Vector2 dir = collision.contacts[0].point - (Vector2)transform.position;
                
                var ballRigidBody = GetBallRigidBody(collision.gameObject);

                ballRigidBody.AddForce(dir * fanForce, ForceMode2D.Impulse);
            }
        }
    }
}
