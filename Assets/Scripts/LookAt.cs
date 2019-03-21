using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	//Объект на который смотрят буквы (камера игрока)
	private Transform target;
	//Выключаем скрипт и находим камеру
	void Start ()
	{
		enabled = false;
		target = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	//Сама функция, которая смотрит на игрока
	void Update ()
	{
		transform.LookAt(target);
	}
	//Включаем скрипт, если буква попадает в камеру
	void OnBecameVisible()
	{
		enabled = true;
	}
	//Выключаем скрипт, когда буква не попадает в камеру
	void OnBecameInvisible()
	{
		enabled = false;
	}
}