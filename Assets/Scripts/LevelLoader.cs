using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public GameObject Pause;
	public GameObject ButtonPause;
	//Переход в сцену Game
	public void Game()
	{
		//Размарозка времени
		Time.timeScale = 1;
		//Перезапуск сцены Game
		SceneManager.LoadScene("Game");
	}
	//Выход из игры
	public void Exit ()
	{
		Application.Quit();
	}
	//Вызов паузы
	public void CallPause ()
	{
		//Замарозка времени
		Time.timeScale = 0;
		//Включение окна паузы
		Pause.SetActive(true);
		//Отключение кнопки паузы
		ButtonPause.SetActive(false);
	}
	//Продолжение игры
	public void ContinueGame ()
	{
		//Отключение окна паузы
		Pause.SetActive(false);
		//Включение кнопки паузы
		ButtonPause.SetActive(true);
		//Размарозка времени
		Time.timeScale = 1;
	}
	//Перезапуск уровня
	public void RestartGame ()
	{
		//Вызов метода Game, который перезапускает уровень
		Game();
		//Размарозка времени
		Time.timeScale = 1;
	}
}
