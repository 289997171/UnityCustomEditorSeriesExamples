using UnityEngine;

/// <summary>
/// 自定义限制角度类型的注解： [Angle]
/// </summary>
public class AngleAttribute : PropertyAttribute
{
    /// <summary>
    /// 是否是用弧度
    /// </summary>
    public readonly bool radians;

    /// <summary>
    /// 对比使用对应的构造函数: [Angle(bool)]
    /// </summary>
    /// <param name="radians"></param>
    public AngleAttribute(bool radians)
    {
        this.radians = radians;
    }
}
