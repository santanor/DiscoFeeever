using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BrownWeaponLWF : WeaponAbstractLWF {
	public override void LoadOnHitMosconState(MosconAbstractLWF moscon)
	{
		moscon.LoadState(1);//Para recibir daño normal
	}
}
