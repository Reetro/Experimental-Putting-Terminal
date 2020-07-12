using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        int playerNum = FindObjectsOfType<MusicPlayer>().Length;

        if (playerNum > 1)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }
}
