using UnityEditor;
using UnityEngine;
using System.Collections;

public class SFXPostProcessor : AssetPostprocessor {

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
