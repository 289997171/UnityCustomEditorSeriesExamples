using UnityEngine;
using System.Collections;


/// <summary>
/// 自定义增量范围值注解 [Incrementable(float)]
/// </summary>
public class IncrementableAttribute : PropertyAttribute
{
    public readonly float incrementBy;

    public IncrementableAttribute(float increment = 1.0f)
    {
        this.incrementBy = increment;
    }
}
