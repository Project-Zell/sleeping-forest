using UnityEngine;

public class PlayerDeathPauseRequester : GameStateRequester
{
    public void PauseOnDeath()
    {
        RequestPause();
        print("Puased when ded");
    }
}
