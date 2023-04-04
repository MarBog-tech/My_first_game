using System;
using Animation;
using UnityEngine;

namespace Core.Movement.Data
{
    [Serializable]
    public class DirectionalMoverData
    {
        [field:SerializeField] public AnimationController Animation { get; private set; }
        
    }
}