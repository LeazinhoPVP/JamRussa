using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;

    public FMODUnity.EventReference musica;

    public FMODUnity.EditorParamRef teste;

    public string parameterName;
    public float parameterValue;

    // Start is called before the first frame update
    void Start()
    {
        RuntimeManager.PlayOneShot(musica);
    }

    // Update is called once per frame
    void Update()
    {
        RuntimeManager.StudioSystem.setParameterByName(parameterName, parameterValue);
    }
}
