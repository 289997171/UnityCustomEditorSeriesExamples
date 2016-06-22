using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 自定义序列化类
/// </summary>
[Serializable]
public class DialogueElement
{
    public string Speaker = "";
    public string Text = "";
    public GameObject obj = null;
}


/// <summary>
/// 自定义ScriptableObject
/// 允许你存储大量用于公用的数据，可以理解成是Uinty的一个串行化工具，但要和SerializableObject区分开来（只能在Editor下使用）。
/// 例如，一个游戏中的配置表数据，这些数据一般都是由策划在Excel等工具上配置，要运用到游戏中时，一般都需要做一个转换，
/// 以适应程序中的访问。这时可以使用ScriptableObject，将数据预先处理成我们需要访问的数据结构，存储在ScriptableObject中，
/// 然后打包成一个外部文件，这样在游戏运行的时候就不用做解析和组装了。这个功能对大批量的公用数据尤其有用！！ 
/// ScriptableObject支持所有原子的类型，也支持strings，arrays，lists还有Unity的Vector3等都支持，而且还支持自定义的类，但需要有一个串行的属性。举个例子：
/// 
/// 1、定义一个要打包的类，这个类必须要继承自ScriptableObject：
/// DesignerData必须继承自ScriptableObject
//public class DesignerData : ScriptableObject
//{
//
//    // 这个属性的必须的，因为DesignerData类中的data是SubClass类型
//    // 必须序列化后才能打包
//    [System.Serializable]
//    public class SubClass
//    {
//
//        [System.Serializable] // 这个属性的必须的，解析同上
//        public class Item
//        {
//            public string c;
//            public float d;
//        }
//
//        public Item item;
//        public int a;
//    }
//
//    public List<int> lst1;
//    public List<SubClass> lst2;
//    public SubClass data;
//    public Vector3 vec;
//}
/// 
/// 2、上面的是要打包的数据结构，在打包前可以先将数据填充，DesignerData里面应该有一个初始化数据的方法。如下图 
/// 
//public void init()
//{
//    // 初始化lst1
//    lst1 = new List<int>();
//    lst1.Add(1);
//    lst1.Add(2);
//    lst1.Add(3);
//
//    // 初始化data
//    data = new SubClass();
//    data.a = 101;
//    data.item = new SubClass.Item();
//    data.item.c = "world";
//    data.item.d = 99;
//
//    // 初始化lst2
//    lst2 = new List<SubClass>();
//    data = new SubClass();
//    data.a = 1012;
//    data.item = new SubClass.Item();
//    data.item.c = "world2";
//    data.item.d = 992f;
//    lst2.Add(data);
//
//    data = new SubClass();
//    data.a = 1011;
//    data.item = new SubClass.Item();
//    data.item.c = "world1";
//    data.item.d = 991f;
//    lst2.Add(data);
//
//    // 初始化vec
//    vec = new Vector3(1f, 2f, 3f);
//}
///
/// 
/// 3打包数据（需要Unity Pro版） 
/// [MenuItem("example/load/ScriptableObjectTest/pack Asset Data")]
//private static void exportDesignerAssetData()
//{
//    string path = "Assets/load/ScriptableObjectTest";
//    string name = "DesignerData";
//
//    DirectoryInfo dirInfo = new DirectoryInfo(path);
//    if (!dirInfo.Exists)
//    {
//        Debug.LogError(string.Format("can found path={0}", path));
//        return;
//    }
//
//    // ScriptableObject对象要用ScriptableObject.CreateInstance创建
//    DesignerData ddata = ScriptableObject.CreateInstance<DesignerData>();
//    ddata.init();
//
//    // 创建一个asset文件
//    string assetPath = string.Format("{0}/{1}.asset", path, name);
//    AssetDatabase.CreateAsset(ddata, assetPath);
//
//    // 创建一个assetbundle文件
//    string assetbundlePath = string.Format("{0}/{1}.assetbundle", path, name);
//    BuildPipeline.BuildAssetBundle(ddata, null, assetbundlePath);
//
//    Debug.Log("Finish!");
//}
/// 
///   
/// </summary>
public class DialogueConversation : ScriptableObject
{
    public List<DialogueElement> Lines;

    [MenuItem("Dialogue/New Dialogue")]
    public static void NewDialogue()
    {
        AssetHelper.NewAsset<DialogueConversation>("Assets/Dialogue", "NewDialogue", ".asset", (o => o.Lines = new List<DialogueElement>()));
    }
}
