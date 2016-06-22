using UnityEngine;
using System.Collections;

public class AttributeExampleObject : MonoBehaviour
{
    // 使用弧度制
    [Angle(true)] public float AngleRadians = 0.0f;
    // 使用角度制
    [Angle(false)] public float AngleDegrees = 0.0f;

    // 使用增量为1
    [Incrementable] public int IncrementableInt = 0;
    // 使用增量为1
    [Incrementable] public float IncrementableFloat = 0.0f;
    // 使用增量为3
    [Incrementable(3.0f)] public int IncrementableIntByThree = 0;
    // 使用增量为4.5
    [Incrementable(4.5f)] public float IncrementableFloatByFourPointFive = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
