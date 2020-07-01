using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public AudioClip[] audioClips;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AudioManager.Instance.PlaySFX(audioClips[0], 1.0f, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.Instance.PlayLoopSource1(audioClips[1], 1.0f, true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //AudioManager.Instance.StopMusic();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            //AudioManager.Instance.PauseMusic();
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            AudioManager.Instance.LoopSrc1Vol(0f);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            AudioManager.Instance.LoopSrc1Vol(1.0f);
        }
    }
}
