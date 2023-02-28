using UnityEngine;

public class GroundState : MonoBehaviour
{
    [SerializeField] public enum PlayersGroundState
    {
        AboveGround,
        BelowGround
    }

    public PlayersGroundState playersGroundState;

    private void Start()
    {
        playersGroundState = PlayersGroundState.AboveGround;
    }

    public PlayersGroundState GetGroundState()
    {
        return playersGroundState;
    }

    public void ChangeState()
    {
        if(playersGroundState == PlayersGroundState.AboveGround)
        {
            playersGroundState = PlayersGroundState.BelowGround;

        }else if (playersGroundState == PlayersGroundState.BelowGround)
        {
            playersGroundState = PlayersGroundState.AboveGround;
        }
    }
}
