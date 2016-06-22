using UnityEngine;


/// <summary>
/// 创建自定义序列化属性类
/// </summary>
[System.Serializable]
public class BoolVector3
{
    public bool x;
    public bool y;
    public bool z;
       
    public BoolVector3()
    {
        x = false;
        y = false;
        z = false;
    }

    public BoolVector3(bool gX, bool gY, bool gZ)
    {
        x = gX;
        y = gY;
        z = gZ;
    }
}

public class BoolVectorTestComponent : MonoBehaviour
{
    // 使用自定义属性类，在默认情况下，会以一般模式在Inspector显示该自定义属性类的属性
    // 可以通过编写对应序列化属性类的Drawer“绘画器”来不使用默认的显示方式，而采用自定义的显示方式
    public BoolVector3 vec;
}
