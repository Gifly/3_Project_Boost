using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float Period = 2f;

    [Range(0,1)] [SerializeField] float movementFactor;
    Vector3 startingPosition; 

    void Start()
    {
        startingPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Period <= Mathf.Epsilon) { return; } //Protect against NaN

        float cycles = Time.time / Period; //grows continually from 0

        const float tau = Mathf.PI * 2f; //about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); //goes from -1 to +1

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPosition + offset;
    }
}
