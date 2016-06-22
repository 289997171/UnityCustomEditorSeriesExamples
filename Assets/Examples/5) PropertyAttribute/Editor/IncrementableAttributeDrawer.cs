using UnityEditor;
using UnityEngine;

/// <summary>
/// 对边对应绘画器 对应 注解类型  这里是对自定义的 [Incrementable[floot]] 添加对应的显示方式，以及功能
/// </summary>
[CustomPropertyDrawer(typeof(IncrementableAttribute))]
public class IncrementableAttributeDrawer : PropertyDrawer
{

    private IncrementableAttribute _attributeValue = null;
    private IncrementableAttribute attributeValue
    {
        get
        {
            if (_attributeValue == null)
            {
                _attributeValue = (IncrementableAttribute)attribute;
            }
            return _attributeValue;
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty value = property;


        int incrementDirection = 0;

        int buttonWidth = 40;

        // 绘制减法按钮
        if (GUI.Button(new Rect(position.x, position.y, buttonWidth, position.height), ("-" + attributeValue.incrementBy)))
        {
            incrementDirection = -1;
        }

        // 绘制加法按钮
        if (GUI.Button(new Rect(position.width - buttonWidth, position.y, buttonWidth, position.height), ("+" + attributeValue.incrementBy)))
        {
            incrementDirection = 1;
        }

        string valueString = "";

        // 根据注解对应属性的数据类型来转换增量值
        if (property.propertyType == SerializedPropertyType.Float)
        {
            property.floatValue += attributeValue.incrementBy * incrementDirection;
            valueString = property.floatValue.ToString();
        }
        else if (property.propertyType == SerializedPropertyType.Integer)
        {
            property.intValue += (int)attributeValue.incrementBy * incrementDirection;
            valueString = property.intValue.ToString();
        }

        // 绘制文字描述
        EditorGUI.LabelField(new Rect(position.x + buttonWidth + 40, position.y, position.width - (buttonWidth * 2 + 80), position.height), property.name + ": " + valueString);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }
}
