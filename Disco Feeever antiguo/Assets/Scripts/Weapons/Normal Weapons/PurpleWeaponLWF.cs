using UnityEngine;
using System.Collections;

public class PurpleWeaponLWF : WeaponAbstractLWF {
	public override void LoadOnHitMosconState(MosconAbstractLWF moscon)
	{
		moscon.LoadState(1);//Para recibir daño normal
	}
}
