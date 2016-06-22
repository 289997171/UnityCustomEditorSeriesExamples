using UnityEngine;
using System.Collections;

public class ExampleTwoScript : MonoBehaviour {

    // 即便是public的，但因为HideInInspector修饰，不在Inspector视图中显示
    [HideInInspector] public float hiddenVariable = 1.0f;

    // 即便是private，但因为SerializeField修饰，所以，在Inspector视图中显示
    [SerializeField] private float serializedPrivateVariable = 2.0f;

    // 使用Space修饰，影响属性在Inspector视图中显示的高度（默认为30）
    [Space(80.0f)] public float spacedFloat = 10.0f;

    // Range修饰数字的范围 最小3.0f 最大 4.0f
    [Range(3.0f, 4.0f)] public float rangeFloat = 3.5f;

    // Header修饰为属性添加一个标题栏
    [Header("Text Attributes")]
	public string headeredString = "headeredString";

    //TextArea创建针对string字段的文本区域，设置最小行数和最大行数
    [TextArea(3, 6)] public string textArea =
		"Here is some text\nin a\ntext area";

    //Multiline基本同于TextArea,也是多行显示string字段
    [Multiline(4)] public string multilineText = "Mult\ni\nline\ntext\nscroll\nto\nthis\ntext";

    //Tooltip为属性添加描述信息（当鼠标在属性上，将显示描述）
    [Tooltip("This variable is an integer!")] public int tooltippedInteger = 9;

    //ContextMenuItem为属性添加右键按钮，点击后执行对应的方法，如右键Context Float,后会有Output Value按钮生成，点击后，执行FieldContextFunction函数
    [ContextMenuItem("Output Value", "FieldContextFunction")]
    public float ContextFloat = 0.0f;

    void FieldContextFunction()
    {
        Debug.Log(ContextFloat);
    }

    // 为脚本添加右键按钮，如在Example Two Script（Script）上点击右键，最底部会有一个Context Function按钮，点击执行ContextFunction方法
    [ContextMenu("Context Function")]
    public void ContextFunction()
    {
        Debug.Log("Context Function Activated!");
    }
}
