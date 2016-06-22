using UnityEditor;
using UnityEngine;


/// <summary>
/// 对边对应绘画器 对应 注解类型。 这里是对自定义的 [Angle[bool]] 添加对应的显示方式，以及功能
/// </summary>
[CustomPropertyDrawer(typeof(AngleAttribute))]
public class AngleAttributeDrawer : PropertyDrawer
{

    private AngleAttribute _attributeValue = null;
    private AngleAttribute attributeValue
    {
        get
        {
            if (_attributeValue == null)
            {
                // 获得注解信息
                _attributeValue = (AngleAttribute) attribute;
            }
            return _attributeValue;
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // 1.获得自定义属性编辑器
        SerializedProperty angle = property;

        // 2.使用默认方式显示属性
        EditorGUI.PropertyField(position, angle);

        // 3.其他扩展（计算角度范围值）
        clampAngle(angle);
    }

    private void clampAngle(SerializedProperty angle)
    {
        if (angle == null)
        {
            return;
        }

        // 根据是否是弧度来返回角度的值范围
        float fullRotation = (attributeValue.radians ? Mathf.PI * 2 : 360.0f);
        while (angle.floatValue < 0.0f)
        {
            angle.floatValue += fullRotation;
        }

        while (angle.floatValue > fullRotation)
        {
            angle.floatValue -= fullRotation;
        }
    }
}
