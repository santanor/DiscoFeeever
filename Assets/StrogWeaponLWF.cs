using UnityEngine;
using System.Collections;

public class StrogWeaponLWF : WeaponAbstractLWF {

	public override void LoadOnHitMosconState(MosconAbstractLWF moscon)
	{
		moscon.LoadState(0);//Para recibir ponerse a ligar
	}

}
