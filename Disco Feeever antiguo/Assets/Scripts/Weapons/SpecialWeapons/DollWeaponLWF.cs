using UnityEngine;
using System.Collections;

public class DollWeaponLWF : WeaponAbstractLWF {


	public override void LoadOnHitMosconState(MosconAbstractLWF moscon)
	{
		moscon.LoadState(2);//Para recibir ponerse a ligar
	}

}
