using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
public class StoryTextUIScene : MonoBehaviour
{
    //[Header("Components")]
    //[Header("References")]

    [Header("Settings")]
    [SerializeField] private TMP_FontAsset _font;
}
public class StoryTextUISceneController : MonoBehaviour
{    
    [FoldoutGroup("Controller")]
    [Button]
    private void Start()
    {

    }
}