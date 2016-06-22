using UnityEngine;
using System;


/// <summary>
/// 使用自定义序列化类
/// </summary>
[Serializable]
public class PlayerStats
{
	public float moveSpeed = 1.0f;
	public float turnSpeed = 90.0f;
}

public class ExampleOnePlayer : MonoBehaviour {

	// 常规方式，使用一般属性配置，不使用序列化类 Not Using Serializable Class
    /*
	public float moveSpeed = 1.0f;
	public float turnSpeed = 90.0f;

	private float MoveSpeed { get { return moveSpeed;} }
	private float TurnSpeed { get { return turnSpeed;} }
     */


	 // 使用序列化类 Using Serializable Class 
     ///*
	 public PlayerStats stats = new PlayerStats();

	 private float MoveSpeed { get { return stats.moveSpeed;} }
	 private float TurnSpeed { get { return stats.turnSpeed;} }
      
     //*/
	
	// Update is called once per frame
	void Update () {
		HandleMovement();	
	}

	void HandleMovement()
	{
		Vector3 position = transform.position;
		Vector3 rotation = transform.eulerAngles;

		if(Input.GetKey(KeyCode.D))
		{
			rotation.z -= TurnSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A))
		{
			rotation.z += TurnSpeed * Time.deltaTime;
		}

		transform.eulerAngles = rotation;

		if(Input.GetKey(KeyCode.W))
		{
			position += MoveSpeed * transform.up * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.S))
		{
			position -= MoveSpeed * transform.up * Time.deltaTime;
		}

		transform.position = position;
	}
}
