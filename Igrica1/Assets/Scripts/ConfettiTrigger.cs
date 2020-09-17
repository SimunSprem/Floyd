using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiTrigger : MonoBehaviour
{
    public GameObject confettiFx1;
    public GameObject confettiFx2;
    public void CreateConfetti()
    {
        confettiFx1.SetActive(false);
        confettiFx2.SetActive(false);
        confettiFx1.SetActive(true);
        confettiFx2.SetActive(true);
    }
}
