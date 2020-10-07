using UnityEngine;

namespace Meta
{
    [CreateAssetMenu(menuName = "CharacterMeta", fileName = "NewCharacterMeta", order = 2)]
    public class CharacterMeta : ScriptableObject
    {
        [SerializeField] private int health;
        [SerializeField] private int hitPower;

        public int Health => health;
        public int HitPower => hitPower;
    }
}