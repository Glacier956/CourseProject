using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FPSController : MonoBehaviour {

	[Header("Скорость перемещения")]
	[Range(1.0f,10.0f)]
	public float speedMove;

	[Header("Чувствительность мыши")]
	[Range(1.0f,10.0f)]
	public float sensivity;

	[Header("Сила прыжка")]
	[Range(1.0f,20.0f)]
	public float jump;

	[Header("Гравитация в воздухе")]
	[Range(1.0f,30.0f)]
	public float airGravity;

	[Header("Гравитация на земле")]
	[Range(1.0f,100.0f)]
	public float groundGravity;

	[Header("Ограничитель поворота")]
	public Vector2 clampAngle;
	//Кэш трансформа
	private Transform _transform;
	//Вектор вращения
	private Vector2 _angle;
	//Вектор направления движения
	private Vector3 _dir;
	//Мышь
	private float _mouseX;
	private float _mouseY;
	//Клавиши
	private float _vertical;
	private float _horizontal;
	//Компонент для перемещения
	private CharacterController _controller;
	//Компонент аниматора камеры
	private Animator _camAnimator;
	//Компонент аудио
	private AudioSource _source;
	//Компонент джостика
	private MobileInput _input;
	//Компонент тача
	private TouchField _field;
	//Текущая гравитация
	private float _gravity;
	//Прыжок
	private bool _isJumping;

	void Start () 
	{
		_controller = GetComponent<CharacterController> ();
		_camAnimator = Camera.main.GetComponent<Animator> ();
		_source = GetComponent<AudioSource> ();

		_input = GameObject.FindGameObjectWithTag ("MobileJoystick").GetComponent<MobileInput> ();
		_field = GameObject.FindGameObjectWithTag ("TouchField").GetComponent<TouchField> ();

		_transform = transform;
		Time.timeScale = 1;
	}
	void Update () 
	{
	
		//Если игрок на земле
		if (_controller.isGrounded) 
		{
			//Записываем значения нажатых клавиш
			_vertical = _input.Vertical();
			_horizontal = _input.Horizontal();
			//Текущая гравитация - земля
			_gravity = groundGravity;
			//Направление движения
			_dir = _transform.TransformDirection (_horizontal, 0.0f, _vertical);
			_dir *= speedMove;
			//Если нажаты кнопки перемещения
			if (_vertical != 0.0f || _horizontal != 0.0f) 
			{
				//Если звук не играет
				if (!_source.isPlaying) 
				{
					//Проигрываем аудио
					_source.Play ();
				}
				//Включение анимации ходьбы у камеры
				_camAnimator.SetBool ("Moving", true);
			} 
			else 
			{
				//Выключение анимации ходьбы у камеры
				_camAnimator.SetBool ("Moving", false);
			}
			//Прыжок
			if (_isJumping==true) 
			{
				_dir.y = jump;
				_camAnimator.SetBool ("Moving", false);
				_isJumping = false;
			}
		} 
		else 
		{
			//Если не на земле тогда текущая гравитация - в воздухе
			_gravity = airGravity;
		}
		//Переещение персонажа
		_dir.y -= _gravity * Time.deltaTime;
		_controller.Move (_dir * Time.deltaTime);
	}


	void LateUpdate () 
	{
		//Записываем значение мыши
		_mouseX = Input.GetAxis ("Mouse X");
		_mouseY = Input.GetAxis ("Mouse Y");
		_angle.x -= _field.TouchDist.y * sensivity*Time.deltaTime;
		_angle.y += _field.TouchDist.x * sensivity*Time.deltaTime;
		//Ограничение поворота
		_angle.x = Mathf.Clamp (_angle.x, -clampAngle.x, clampAngle.y);
		//Поворот
		Quaternion rot = Quaternion.Euler (_angle.x, _angle.y, 0.0f);
		_transform.rotation = rot;
	}
	//Включение прыжка
	public void Jumping()
	{
		if (_controller.isGrounded) 
		{
			_isJumping = true;
		}
	}
	//Удаление объекта при контакте игрока с буквой
	void OnTriggerEnter (Collider collider)
	{
		Score.scoreAmount += 1;
		Destroy (collider.gameObject);
	}
}
