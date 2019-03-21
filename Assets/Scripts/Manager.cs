using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	//Компонент букв
	public GameObject A;
	public GameObject CH;
	public GameObject E;
	public GameObject G;
	public GameObject I1;
	public GameObject I2;
	public GameObject I3;
	public GameObject I4;
	public GameObject K;
	public GameObject N;
	public GameObject O1;
	public GameObject O2;
	public GameObject O3;
	public GameObject P1;
	public GameObject P2;
	public GameObject T;
	public GameObject V1;
	public GameObject V2;
	public GameObject V3;
	public GameObject V4;
	//Вызываем метод Generator
	void Awake () 
	{
		Generator();
	}
	//Спавн букв по координатам из префабов
	void Generator()
	{
		{
			Instantiate(A, new Vector3(25, 15, 75), transform.rotation);
			Instantiate(CH, new Vector3(35, 15, 100), transform.rotation);
			Instantiate(E, new Vector3(55, 15, 145), transform.rotation);
			Instantiate(G, new Vector3(90, 15, 170), transform.rotation);
			Instantiate(I1, new Vector3(100, 15, 130), transform.rotation);
			Instantiate(I2, new Vector3(120, 15, 80), transform.rotation);
			Instantiate(I3, new Vector3(160, 15, 30), transform.rotation);
			Instantiate(I4, new Vector3(175, 15, 70), transform.rotation);
			Instantiate(K, new Vector3(205, 15, 95), transform.rotation);
			Instantiate(N, new Vector3(190, 15, 130), transform.rotation);
			Instantiate(O1, new Vector3(215, 15, 160), transform.rotation);
			Instantiate(O2, new Vector3(170, 15, 180), transform.rotation);
			Instantiate(O3, new Vector3(140, 15, 170), transform.rotation);
			Instantiate(P1, new Vector3(140, 15, 125), transform.rotation);
			Instantiate(P2, new Vector3(95, 15, 90), transform.rotation);
			Instantiate(T, new Vector3(250, 15, 85), transform.rotation);
			Instantiate(V1, new Vector3(95, 15, 45), transform.rotation);
			Instantiate(V2, new Vector3(30, 15, 150), transform.rotation);
			Instantiate(V3, new Vector3(140, 15, 210), transform.rotation);
			Instantiate(V4, new Vector3(155, 15, 120), transform.rotation);
		}
	}
}
