using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

/// <summary>
/// Tools����g�p�ł���^�O��ϐ��ɂ��Ďg���₷������
/// </summary>
public class TagNameCreator : MonoBehaviour
{
    // �����ȕ������Ǘ�����z��
    private static readonly string[] INVALUD_CHARS =
    {
        " ", "!", "\"", "#", "$",
        "%", "&", "\'", "(", ")",
        "-", "=", "^",  "~", "\\",
        "|", "[", "{",  "@", "`",
        "]", "}", ":",  "*", ";",
        "+", "/", "?",  ".", ">",
        ",", "<"
    };

    private const string ITEM_NAME = "Tools/Create/Tag Name";  // �R�}���h��
    private const string PATH = "Assets/Tag/TagName.cs";      // �t�@�C���p�X

    private static readonly string FILENAME = Path.GetFileName(PATH);                   // �t�@�C����(�g���q����)
    private static readonly string FILENAME_WITHOUT_EXTENSION = Path.GetFileNameWithoutExtension(PATH);   // �t�@�C����(�g���q�Ȃ�)

    /// <summary>
    /// �^�O����萔�ŊǗ�����N���X���쐬���܂�
    /// </summary>
    [MenuItem(ITEM_NAME)]
    public static void Create()
    {
        if (!CanCreate())
        {
            return;
        }

        CreateScript();

        EditorUtility.DisplayDialog(FILENAME, "�쐬���������܂���", "OK");
    }

    /// <summary>
    /// �X�N���v�g���쐬���܂�
    /// 
    /// ����Ă邱��
    /// �ŏ��ɐ����ƃN���X����builder�ɒǉ����A
    /// foreach�Ń^�O�̐�����const��string�̃^�O�̖��O�̕ϐ���ǉ�
    /// �w�肵���p�X��UTF�W�Ńt�@�C����ǉ�
    /// 
    /// </summary>
    public static void CreateScript()
    {
        var builder = new StringBuilder();

        builder.AppendLine("/// <summary>");
        builder.AppendLine("/// �^�O����萔�ŊǗ�����N���X");
        builder.AppendLine("/// </summary>");
        builder.AppendFormat("public static class {0}", FILENAME_WITHOUT_EXTENSION).AppendLine();
        builder.AppendLine("{");

        foreach (var n in InternalEditorUtility.tags.
            Select(c => new { var = RemoveInvalidChars(c), val = c }))
        {
            builder.Append("\t").AppendFormat(@"public const string {0} = ""{1}"";", n.var, n.val).AppendLine();
        }

        builder.AppendLine("}");

        var directoryName = Path.GetDirectoryName(PATH);
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }

        File.WriteAllText(PATH, builder.ToString(), Encoding.UTF8);
        AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
    }

    /// <summary>
    /// �^�O����萔�ŊǗ�����N���X���쐬�ł��邩�ǂ������擾���܂�
    /// </summary>
    [MenuItem(ITEM_NAME, true)]
    public static bool CanCreate()
    {
        return !EditorApplication.isPlaying && !Application.isPlaying && !EditorApplication.isCompiling;
    }

    /// <summary>
    /// �����ȕ������폜���܂�
    /// </summary>
    public static string RemoveInvalidChars(string str)
    {
        Array.ForEach(INVALUD_CHARS, c => str = str.Replace(c, string.Empty));
        return str;
    }
}
