using System;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 自定义 EditorWindow “编辑窗口” 来编辑瓦片地图
/// </summary>
public class GameBoardEditorWindow : EditorWindow {

    private static GUIStyle _selectedButton = null;

    private static GUIStyle selectedButton
    {
        get
        {
            if (_selectedButton == null)
            {
                _selectedButton = new GUIStyle(GUI.skin.button);
                _selectedButton.normal.background = _selectedButton.active.background;
                _selectedButton.normal.textColor = _selectedButton.active.textColor;
            }
            return _selectedButton;
        }
    }

    // 当前编辑的瓦片地图数据
    private GameBoardData currentData = new GameBoardData();

    // 当前选择额瓦片块类型
    private GameBoardTile selectedTile;


    /// <summary>
    /// 在主菜单Window下创建GameBoard Editor来打开GameBoardEditorWindow编辑器窗口
    /// </summary>
    [MenuItem("Window/GameBoard Editor &g")]
    static void CreateWindow()
    {
        // Get existing open window or if none, make a new one:
        GameBoardEditorWindow window = 
            (GameBoardEditorWindow)EditorWindow.GetWindow(typeof(GameBoardEditorWindow));
    }


    /// <summary>
    /// 自定义编辑窗口核心工具类
    /// </summary>
    void OnGUI()
    {
        // 获得当前选择的对象
        GameBoard selectedObjectBoard = null;
        if (Selection.activeGameObject != null)
        {
            selectedObjectBoard = Selection.activeGameObject.GetComponent<GameBoard>();
        }

        {
            EditorGUILayout.BeginHorizontal(); // 开始绘制窗口 BEGIN Whole Window
        
            //Sidebar
            EditorGUILayout.BeginVertical(GUILayout.Width(200)); // BEGIN Sidebar

            EditorGUILayout.BeginHorizontal(); // BEGIN Board Size

            currentData.SizeX = EditorGUILayout.IntField("Size X", currentData.SizeX);
            currentData.SizeY = EditorGUILayout.IntField("Size Y", currentData.SizeY);
        
            EditorGUILayout.EndHorizontal(); // END Board Size
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Fill"))
        {
            currentData.Fill(selectedTile);
        }

        if (GUILayout.Button("Clear"))
        {
            currentData.Clear();
        }

        bool guiEnabled = GUI.enabled;
        GUI.enabled = selectedObjectBoard != null;

        // 将当前编辑器的内容写入选择的瓦片地图
        if (GUILayout.Button("Save to Object"))
        {
            selectedObjectBoard.Load(currentData);
        }

        // 从当前选择的瓦片地图读取数据加载到编辑器
        if (GUILayout.Button("Load From Object"))
        {
            currentData.Load(selectedObjectBoard);
        }

        GUI.enabled = guiEnabled;

        EditorGUILayout.EndVertical(); // END Sidebar

        //Board Editor
        EditorGUILayout.BeginVertical(); // BEGIN Board Editor

        EditorGUILayout.BeginHorizontal(); // BEGIN selectedTile Menu
        foreach (GameBoardTile tile in Enum.GetValues(typeof(GameBoardTile)))
        {
            if (GUILayout.Button(tile.ToString(), (tile == selectedTile ? selectedButton : GUI.skin.button)))
            {
                selectedTile = tile;
            }
        }
        EditorGUILayout.EndHorizontal(); // END selectedTile Menu

        EditorGUILayout.BeginHorizontal(); // BEGIN Board Layout

        #region V2 Code
        
        EditorGUILayout.BeginVertical(); // BEGIN Row Fill Column
        GUILayout.Space(20);
        for (int y = 0; y < currentData.SizeY; y++)
        {
            if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(50)))
            {
                currentData.FillRow(y, selectedTile);
            }
        }
        EditorGUILayout.EndVertical(); // END Row Fill Column
         
        #endregion

        for (int x = 0; x < currentData.SizeX; x++)
        {

            EditorGUILayout.BeginVertical(); // BEGIN Sub-Board Layout

            #region V2 Code
            
            if (GUILayout.Button("v", GUILayout.Width(50), GUILayout.Height(20)))
            {
                currentData.FillColumn(x, selectedTile);
            }
            
            #endregion

            for (int y = 0; y < currentData.SizeY; y++)
            {
                if (GUILayout.Button(currentData.GetTileValue(x, y).ToString(), GUILayout.Width(50), GUILayout.Height(50)))
                {
                    currentData.SetTileValue(x, y, selectedTile);
                }
            }
            EditorGUILayout.EndVertical(); // END Sub-Board Layout
        }
        EditorGUILayout.EndHorizontal(); // END Board Layout

        EditorGUILayout.EndVertical(); //END Board Editor

        EditorGUILayout.EndHorizontal(); //END Whole Window
    }



}
