using System;
using System.Collections.Generic;
using Project.Scripts.UI.Views;
using UnityEngine;

namespace Project.Scripts.UI
{
    [CreateAssetMenu(fileName = nameof(ViewServiceConfig), menuName = "Configs/Services/View")]
    public class ViewServiceConfig : ScriptableObject
    {
        [field: SerializeField] public List<ViewData> DefaultViews { get; private set; }
        [field: SerializeField] public Transform ViewParentPrefab { get; private set; }
    }

    [Serializable]
    public struct ViewData
    {
        public ViewType Type;
        public BaseView ViewPrefab;
    }
    
    public enum ViewType : byte
    {
        Joystick = 0
    }
}