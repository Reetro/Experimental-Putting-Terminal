using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        int playerNum = FindObjectsOfType<MusicPlayer>().Length;

        print(playerNum);

        if (playerNum > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }
}
