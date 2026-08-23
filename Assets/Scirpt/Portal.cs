using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PortalType
{
    Enter,
    Exit
}
public class Portal : MonoBehaviour
{
    public PortalType PortalType;
    [Tooltip("If PortalType: Enter")] public Transform OutPos;
    public GameObject portalEffect;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (PortalType == PortalType.Exit)
        {
            return;
        }
        
        if (coll.gameObject.tag == "Player")
        {
            coll.transform.position = OutPos.position;
            if (portalEffect != null)
                Instantiate(portalEffect, coll.transform.position, Quaternion.identity);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (PortalType == PortalType.Enter) PortalType = PortalType.Exit;
    //    else PortalType = PortalType.Enter;
    //}
}
