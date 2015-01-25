﻿using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	private float timer = 0;
	private bool counting = false;
    [SerializeField]
    private int startValue = 20;
    private int currentGUIValue = 0;

	void Start() 
	{
        //GameObject.FindGameObjectWithTag("Container").GetComponent<UpdateManager>().OnUpdate += DoUpdate;
        StartTimerCounting();
	}

	public void TransfareToPoints()
	{
        counting = false;
        Points.Instance.AddPoints((int)timer);
	}

	public void StartTimerCounting()
	{
        ChangeGUI(startValue);
        timer = startValue;
        counting = true;
	}

	public void StopTimerCounting()
	{
		counting = false;
		ChangeGUI((int)timer);
	}

	void Update() 
	{
		if(counting)
		{
			timer -= Time.deltaTime;
			int timerSec = (int)timer;
			if(timerSec != currentGUIValue)
			{
				ChangeGUI(timerSec);
			}
			if(timer < 0)
			{
				GameManager.SetGameOver();
			}
		}
	}

    private void ChangeGUI(int sec)
    {
        if (sec < 0)
            sec = 0;
        currentGUIValue = sec;
        this.GetComponent<GUIText>().text = sec.ToString();
    }

}
