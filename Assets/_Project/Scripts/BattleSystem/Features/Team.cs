using UnityEngine;

public class Team : MonoBehaviour
{
    [field: SerializeField] public TeamType TeamType { get; private set; }


    public TeamType RivalTeam
    {
        get
        {
            if (TeamType == TeamType.Player) return TeamType.Enemy;
            else if (TeamType == TeamType.Enemy) return TeamType.Player;

            throw new System.Exception($"Wrong team: {TeamType}");
        }
    }

}
