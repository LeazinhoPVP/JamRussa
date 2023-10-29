using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;

    public FMODUnity.EventReference fmodEvent;

    [SerializeField]
    [Range(0f, 1f)]
    private float CombateType, InCombat;

    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
    }

    void Update()
    {
        instance.setParameterByName("CombateType", CombateType);
        instance.setParameterByName("InCombat", InCombat);
    }
}