using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvtMan : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    private void Start()
    {
        playerController = transform.parent.GetComponent<PlayerController>();
    }
    void GetUp()
    {
        //playerController.GetUp();
    }
}
