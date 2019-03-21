using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	// Ссылка на компонент текст игрового объекта
	Text timerText;
	public float timer = 300f;
	//Выводим в текст значение таймера
	void Start ()
	{
		timerText = GetComponent<Text> ();
	}

	//Устанавливаем значение текствого поля для таймера
	void Update ()
	{
		timerText.text = "" + timer;

		if (timer > 0)
		{
        	timer -= Time.deltaTime;
    	}
    	if (timer < 0)
		{
			//
    	}
	}
}
