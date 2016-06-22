using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary>
/// 自定义编辑器 对应GameBoard类
/// </summary>
[CustomEditor(typeof(GameBoard))]
public class GameBoardEditor : Editor
{

    private static GUIStyle _selectedButton = null;

    private static GUIStyle selectedButton
    {
        get
        {
            if (_selectedButton == null)
            {
                // 设置GUI风格
                _selectedButton = new GUIStyle(GUI.skin.button);
                _selectedButton.normal.background = _selectedButton.active.background;
                _selectedButton.normal.textColor = _selectedButton.active.textColor;
            }
            return _selectedButton;
        }
    }

    protected GameBoardTile selectedTile = GameBoardTile.EMPTY;


    /// <summary>
    /// Ediotr核心类
    /// </summary>
    public override void OnInspectorGUI()
    {
        // 获得要编辑的MB对象
        GameBoard boardTarget = (GameBoard) target;

        #region 初始化MB对象 Target Initialization

        if (boardTarget.tiles == null)
        {
            // 调用支持ExecuteInEditMode 的函数
            boardTarget.ResizeTilesArray(0, 0);
        }

        if (boardTarget.tilePrefabs == null)
        {
            boardTarget.tilePrefabs = new List<TilePrefab>();
        }

        List<GameBoardTile> addTiles = new List<GameBoardTile>();
        foreach (GameBoardTile tile in Enum.GetValues(typeof (GameBoardTile)))
        {
            bool addTile = !boardTarget.tilePrefabs.Exists(o => o.Key == tile);
            if (addTile)
            {
                // 添加瓦片预制体
                boardTarget.tilePrefabs.Add(new TilePrefab(tile, null));
            }
        }

        #endregion

        // 创建GameObject的编辑器  Player 对应 boardTarget.playerObject
        boardTarget.playerObject = EditorGUILayout.ObjectField("Player", boardTarget.playerObject, typeof(GameObject), true) as GameObject;

        #region Board Parameters

        EditorGUILayout.BeginHorizontal();

        // 设置boardTarget.SizeX boardTarget.SizeY
        boardTarget.SizeX = EditorGUILayout.IntField("Size X", boardTarget.SizeX);
        boardTarget.SizeY = EditorGUILayout.IntField("Size Y", boardTarget.SizeY);

        EditorGUILayout.EndHorizontal();

        // 瓦片大小
        boardTarget.tileSize = EditorGUILayout.Vector2Field("Tile Size", boardTarget.tileSize);

        //Prefab List
        foreach (TilePrefab pair in boardTarget.tilePrefabs)
        {
            // 设置Game Object
            pair.Value = EditorGUILayout.ObjectField(pair.Key.ToString(), pair.Value, typeof (GameObject)) as GameObject;
        }

        #endregion


        #region Board

        // 4种类型的按钮
        EditorGUILayout.BeginHorizontal();
        foreach (GameBoardTile tile in Enum.GetValues(typeof (GameBoardTile)))
        {
            if (GUILayout.Button(tile.ToString(), (tile == selectedTile ? selectedButton : GUI.skin.button)))
            {
                selectedTile = tile;
            }
        }
        EditorGUILayout.EndHorizontal();


        // 创建对应瓦片面板的按钮
        EditorGUILayout.BeginHorizontal();
        for(int x = 0; x < boardTarget.SizeX; x++)
        {
            EditorGUILayout.BeginVertical();
            for (int y = 0; y < boardTarget.SizeY; y++)
            {
                if (GUILayout.Button(boardTarget.GetTileValue(x, y).ToString(), GUILayout.Width(50), GUILayout.Height(50)))
                {
                    boardTarget.SetTileValue(x, y, selectedTile);
                }
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndHorizontal();

        #endregion

        if (GUILayout.Button("Generate"))
        {
            // 生成瓦片地图
            boardTarget.GenerateBoard();
        }

    }
}
