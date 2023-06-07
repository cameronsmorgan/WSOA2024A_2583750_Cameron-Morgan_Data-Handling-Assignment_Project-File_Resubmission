using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

    public float currentTime =0f;
    public float startingTime = 10f;

    public List<WorkerScript> workerScript = new List<WorkerScript>();
    WorkerScript worker;
    public Text Timer;

    private bool isWorkerDisabled = false;
    private float disableDuration = 3f;
    private float disableTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        Timer.text = currentTime.ToString("0");

        if(currentTime <= 0 )
        {
            currentTime= 0;
            ResetTimer();

            
            DisableWorker();
            disableTimer = disableDuration;

            EnableOtherWorkers();
            
            

       
        }

        if(isWorkerDisabled)
        {
            disableTimer -= Time.deltaTime;
            if(disableTimer <= 0)
            {
                EnableWorker();
             
            }
        }
    }

    void ResetTimer()
    {
        currentTime = startingTime;
    }

    void DisableWorker()
    {
        foreach(WorkerScript workerScript in workerScript)
        {
            if(workerScript.Selected)
            {
                workerScript.Disable();
                isWorkerDisabled = true;
                workerScript.ResetPosition();
            }
        }
    }

    void EnableWorker()
    {
        foreach(WorkerScript workerScript in workerScript)
        {
            if(workerScript.Selected)
            {
                workerScript.Enable();
                isWorkerDisabled = false;
                workerScript.ResetPosition();
            }
        }
    }

    void EnableOtherWorkers()
    {
        foreach (WorkerScript workerScript in workerScript)
        {
            if (!workerScript.Selected)
            {
                workerScript.Enable();

            }
        }
    }
}
