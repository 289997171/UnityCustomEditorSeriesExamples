using UnityEditor;
using UnityEngine;

/// <summary>
/// 自定义属性绘画器，对应BoolVector3序列化属性类
/// </summary>
[CustomPropertyDrawer(typeof(BoolVector3))]
public class BoolVector3Drawer 
    : PropertyDrawer    // 继承属性绘画器
{

    /// <summary>
    /// 覆盖OnGUI方式，将使得BoolVector3的默认Inspector显示方式失效，采用自定义的显示方式
    /// </summary>
    /// <param name="position"></param>
    /// <param name="property"></param>
    /// <param name="label"></param>
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // 默认显示方式
        // base.OnGUI(position, property, label);

        // 自定义
        {
            // 1.获得自定义属性类中，我们需要绘制的属性
            SerializedProperty x = property.FindPropertyRelative("x");
            SerializedProperty y = property.FindPropertyRelative("y");
            SerializedProperty z = property.FindPropertyRelative("z");

            float propWidth = position.width / 6.0f;

            // 2.创建对应属性的文本描述
            EditorGUI.LabelField(new Rect(position.x, position.y, propWidth, position.height), "X");
            // 3.创建对应属性的实际控制组件（如 bool，我们使用Toggle）
            x.boolValue = EditorGUI.Toggle(new Rect(position.x + propWidth * 1, position.y, propWidth, position.height), x.boolValue);

            EditorGUI.LabelField(new Rect(position.x + propWidth * 2, position.y, propWidth, position.height), "Y");
            y.boolValue = EditorGUI.Toggle(new Rect(position.x + propWidth * 3, position.y, propWidth, position.height), y.boolValue);

            EditorGUI.LabelField(new Rect(position.x + propWidth * 4, position.y, propWidth, position.height), "Z");
            z.boolValue = EditorGUI.Toggle(new Rect(position.x + propWidth * 5, position.y, propWidth, position.height), z.boolValue);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }
}
