﻿using UnityEngine;
using System.Collections;

/* Usage example:

public class MyClass : MonoBehaviour {
	
	private Timer myTimer;

	void Awake() {
		myTimer = gameObject.AddComponent<Timer>();
		myTimer.Trigger += TriggerFunction;
	}
	
	void Update() {
		if (Input.GetButtonDown("MyButton"))
			myTimer.Go(timerDuration);
	}
	
	void TriggerFunction {
		//Do something
	}
 
 }
 */


public class Timer : MonoBehaviour {

    public delegate void ManageTimer();
    public event ManageTimer Trigger;

    private bool running = false;
    public bool Running {
        get { return running; }
    }
    private float duration;
    private int repeat;
    private int iteration;

    public int Iteration {
        get {
            return iteration;
        }
    }

    //Starts a timer that lasts for @dur and sends out the Trigger event when finished
    public void Go(float dur) {
        duration = dur;
        repeat = 1;
        iteration = 0;
        StartCoroutine("RunTimer");
    }

    //Starts a timer that lasts for @dur and repeats @rep times, sending out a Trigger event each time
    public void Go(float dur, int rep) {
        duration = dur;
        repeat = rep;
        iteration = 0;
        StartCoroutine("RunTimer");
    }

    //Stops the timer completely
    public void Cancel() {
        StopAllCoroutines();
        running = false;
    }

    //Restarts the timer with the same settings
    public void Reset() {
        StopAllCoroutines();
        running = false;
        iteration = 0;
        StartCoroutine("RunTimer");
    }

    IEnumerator RunTimer() {
        running = true;
        yield return new WaitForSeconds(duration);
        Trigger();
        running = false;
        iteration++;
        if (iteration < repeat)
            StartCoroutine("RunTimer");
    }

}