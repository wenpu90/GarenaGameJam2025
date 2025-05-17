using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoNextAfterSec : MonoBehaviour
{
    public UnityEvent goNextEvent;

    public float delayTime;


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delayTime);
        goNextEvent?.Invoke();
    }
}
