using UnityEditor;
using UnityEngine;
using System.Collections;

/// <summary>
/// 编辑器的继承
/// </summary>
[CustomEditor(typeof(GameBoardHandles))]
public class GameBoardHandlesEditor : GameBoardEditor {

    /// <summary>
    /// 在以前的基础上添加了按键快速切换当前选择瓦片类型的功能
    /// </summary>
    public override void OnInspectorGUI()
    {
        //Swap selectedTile with hotkeys
        if (Event.current.type == EventType.KeyUp)
        {
            switch (Event.current.keyCode)
            {
                case KeyCode.O:
                    selectedTile = GameBoardTile.EMPTY;
                    break;
                case KeyCode.P:
                    selectedTile = GameBoardTile.FULL;
                    break;
                case KeyCode.LeftBracket:
                    selectedTile = GameBoardTile.GOAL;
                    break;
                case KeyCode.RightBracket:
                    selectedTile = GameBoardTile.START;
                    break;
            }
            this.Repaint();
        }

        base.OnInspectorGUI();
    }

    /// <summary>
    /// 场景直接编辑
    /// </summary>
    void OnSceneGUI()
    {
        // 获得当前编辑的对象
        GameBoard targetBoard = (GameBoard) target;
        float buttonSize = Mathf.Min(targetBoard.tileSize.x, targetBoard.tileSize.y)/2;

        Color handlesColor = Handles.color;

        // Handles 控制柄
        // 场景视图样式的3D GUI控制。
        // Setting up 设置 你必须以DrawCamera调用开始以设置当前摄像机。DrawCamera使用相机之后所有3D东西完成被渲染。
        // Drawing stuff 绘制东西 可以绘制3D gizmo一样的东西。参见：DrawCube、DrawLine。用设置Handles.color它们的颜色。
        // Traditional 2D GUI 传统的 2D GUI  已经制作了一个DrawCamera调用之后，必须包裹在传统GUI调用Handles.BeginGUI / EndGUI 对之中。
        // Converting coordinate systems 转换坐标系统  使用HandleUtility.GUIPointToWorldRay 和 HandleUtility.WorldToGUIPoint 来转换2D GUI 和3D世界坐标之间的坐标。

        Handles.color = new Color(0.3f, 0.3f, 0.3f, 0.5f);

        for (int x = 0; x < targetBoard.SizeX; x++)
        {
            for (int y = 0; y < targetBoard.SizeY; y++)
            {
                Vector3 position = targetBoard.transform.position + targetBoard.getLocalPosition(x, y);
                if(Handles.Button(position, Quaternion.identity, buttonSize, buttonSize,
                    Handles.SelectionFrame))
                {
                    targetBoard.SetTileValue(x, y, selectedTile);
                }
            }
        }

        Handles.color = handlesColor;
    }
}
