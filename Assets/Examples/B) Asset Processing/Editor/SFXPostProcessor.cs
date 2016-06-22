using UnityEditor;
using UnityEngine;


/// <summary>
/// 资源处理器
/// 让你钩进导入管线，在运行脚本之前或导入资源之后。
/// 这样你可以在导入的设置中重载默认值或修改导入的数据，如纹理，网格，音效。
/// </summary>
public class SFXPostProcessor : AssetPostprocessor {


    /// <summary>
    /// 处理音效
    /// </summary>
    void OnPreprocessAudio()
    {
        AssetImporter importer = assetImporter;
        AudioImporter audioImporter = (AudioImporter)assetImporter;
        if (audioImporter != null)
        {
            if (assetPath.Contains("Music"))
            {
                audioImporter.threeD = false;
            }
            if (assetPath.Contains("SFX"))
            {
                AudioClipLoadType audioClipLoadType = audioImporter.defaultSampleSettings.loadType;
                // audioImporter.loadType = AudioClipLoadType.DecompressOnLoad;
            }
        }
    }

}
