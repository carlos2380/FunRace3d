using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlGame : MonoBehaviour
{
    public CtrlCanvas ctrlCanvas;
    public Player player;
    public CtrlCamera ctrlCamera;


    public void win()
    {
        player.enabled = false;
        ctrlCanvas.win();
    }

    public void start()
    {
        player.enabled = true;
        ctrlCanvas.play();
    }

    public void restart()
    {
        player.enabled = true;
        ctrlCanvas.play();
        player.restart();
        ctrlCamera.restart();
    }
}
