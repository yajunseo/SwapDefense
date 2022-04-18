using UnityEngine;

namespace InGame
{
    public class Entity : MonoBehaviour
    {
        public virtual void ReadyToStartGame() { }

        public virtual void UpdateInGame() { }
        public virtual void EndOfStage() { }

    }
}
