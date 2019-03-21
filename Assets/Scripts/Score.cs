using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public GameObject Win;
	public GameObject Lose;
	public GameObject Pause;
	public GameObject Joystick;
	public GameObject Jump;
	public GameObject Timer;
	//Значение для таймера
	public float timer = 300f;
	//Значение для максимального получения очков
	public float score = 20;
	//Переменная содержащая кол-во очков
	public static int scoreAmount;
	// Ссылка на компонент текст игрового объекта
	Text scoreText;
	// Устанавливаем кол-во очков на 0
	void Start ()
	{
		scoreText = GetComponent<Text> ();
		scoreAmount = 0;
	}
	//Устанавливаем значение текствого поля как Score + значение кол-ва набранных очков
	void Update ()
	{
		scoreText.text = "" + scoreAmount;
		//Если набрано необходимое кол-во очков, выводим окно выигрыша
		if (scoreAmount == 20)
		{
			GameWin();
		}
		//Если таймер закончился, выводим окно проигрыша
		if (timer > 0) 
		{
        	timer -= Time.deltaTime;
    	}
    	if (timer < 0) 
		{
        	GameOver();
    	}
	}
	//Окно выигрыша
	void GameWin ()
	{
		//Включение объекта Win
		Win.SetActive(true);
		//Отключение кнопки паузы
		Pause.SetActive(false);
		//Отключение кнопки джойстика
		Joystick.SetActive(false);
		//Отключение кнопки прыжка
		Jump.SetActive(false);
		//Отключение таймера
		Timer.SetActive(false);
		//Замарозка времени
		Time.timeScale = 0;
	}
	//Окно проигрыша
	void GameOver()
	{
		//Включение объекта Lose
		Lose.SetActive(true);
		//Отключение кнопки паузы
		Pause.SetActive(false);
		//Отключение кнопки джойстика
		Joystick.SetActive(false);
		//Отключение кнопки прыжка
		Jump.SetActive(false);
		//Отключение таймера
		Timer.SetActive(false);
		//Замарозка времени
		Time.timeScale = 0;
	}
}
