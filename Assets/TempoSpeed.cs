using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TempoSpeed : MonoBehaviour
{
    private AudioSource _source;
    private AudioMixer _mixer;
    public float closeTempo;
    public float speedUpDistance;

    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _mixer = _source.outputAudioMixerGroup.audioMixer;
    }

    // Update is called once per frame
    void Update()
    {
        float tempo = GetTempo();
        _source.pitch = tempo;
        _mixer.SetFloat("pitchBend", 1f / tempo);
    }

    float GetTempo()
    {
        GhostMovement ghost = GameObject.FindObjectOfType<GhostMovement>();
        if (ghost)
        {
            PlayerMovement player = PlayerMovement.instance;
            float distance = Vector2.Distance(player.transform.position, ghost.transform.position);
            float ratio = distance / speedUpDistance;
            if (ratio < 1 && !ghost.Blocked)
            {
                return (1 - ratio) * closeTempo + ratio; // linearly interpolate
            }
        }
        return 1f;
    }
}
