using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PurpleWeaponLWF : WeaponAbstractLWF {


    public override void _Start()
    {
        base.Color = "Purple";
    }
    public override void LoadOnHitMosconState(MosconAbstractLWF moscon)
    { }
}
