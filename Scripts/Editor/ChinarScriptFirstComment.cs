
using System.IO;
using UnityEngine;

public class ChinarScriptFirstComment : UnityEditor.AssetModificationProcessor {
    /// <summary>
    /// 在资源创建时调用
    /// </summary>
    /// <param name="path">自动传入资源路径</param>
    public static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        if (!path.EndsWith(".cs")) return;
        string allText = "// ========================================================\r\n"
                         + "// Describe：\r\n"
                         + "// Author：慕飞 \r\n"
                         + "// Time：#CreateTime#\r\n"
                         + "// UnityVersion：" + Application.unityVersion+ "\r\n"
                         + "// Version：" + Application.version + "\r\n"
                          + "// ========================================================\r\n";
        allText += File.ReadAllText(path);
        allText = allText.Replace("#CreateTime#", System.DateTime.Now.ToString("yyyy-MM-dd"));
        File.WriteAllText(path, allText);
    }
}
