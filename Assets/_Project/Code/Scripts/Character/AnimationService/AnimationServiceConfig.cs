using UnityEngine;

namespace Project.Scripts
{
    [CreateAssetMenu(fileName = nameof(AnimationServiceConfig), menuName = "Configs/Services/Animation")]
    public class AnimationServiceConfig : ScriptableObject
    {
        public int IsRun => Animator.StringToHash("isRun");
        public int MoveRange => Animator.StringToHash("MoveRange");
        public int Dead => Animator.StringToHash("Dead");
    }
}