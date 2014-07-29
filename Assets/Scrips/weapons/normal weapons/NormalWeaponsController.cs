using UnityEngine;
using System.Collections;

public class NormalWeaponsController : MonoBehaviour {

    GameObject[] _normalWeapons;
    public bool[] _normalWeaponsUsed;
    Vector3[] _positionNormalWeapons;
    GameObject[] _currentNormalWeapons;
    GameObject _barra;
	// Use this for initialization

    void Start()
    {
        _normalWeapons = Resources.LoadAll<GameObject>("Prefabs/Weapons/Normal weapons");
        _normalWeaponsUsed = new bool[3];
        _positionNormalWeapons = new Vector3[4];
        _currentNormalWeapons = new GameObject[4];
        _barra = FindObjectOfType<BarraLWF>().gameObject;
        

        for (int i = 0; i < 3; i++)
        {
            GameObject weapon = ChooseWeapon();
            weapon.transform.parent = _barra.transform;
            weapon.GetComponent<WeaponAbstractLWF>().Position = i;
            weapon.GetComponent<WeaponAbstractLWF>().PositionVector = _positionNormalWeapons[i];
            _normalWeaponsUsed[i] = true;
            _currentNormalWeapons[i] = weapon;
        }
        _currentNormalWeapons[3] = ChooseWeapon();
        _currentNormalWeapons[3].transform.parent = _barra.transform;
        _currentNormalWeapons[3].transform.localPosition = _positionNormalWeapons[3];
        _currentNormalWeapons[3].GetComponent<WeaponAbstractLWF>().PositionVector = _positionNormalWeapons[3];
        _currentNormalWeapons[3].collider2D.enabled = false;
        _currentNormalWeapons[3].GetComponent<WeaponAbstractLWF>().SetAlpha(0.5f);
		StartCoroutine(_Start());
    }
	IEnumerator _Start ()
	{
		yield return new WaitForSeconds(0f);
        float offset;
        for (int i = 0; i < 4; i++)
        {
            offset = i * 120f;
            _positionNormalWeapons[i] = new Vector3(80f + offset - _currentNormalWeapons[i].GetComponent<WeaponAbstractLWF>()._width/2, 15f, -5);
            _currentNormalWeapons[i].transform.localPosition = _positionNormalWeapons[i];
            _currentNormalWeapons[i].GetComponent<WeaponAbstractLWF>().Position = i;
            _currentNormalWeapons[i].GetComponent<WeaponAbstractLWF>().PositionVector = _positionNormalWeapons[i];
        }
        
	}

    void Update()
    {
        for (int i = 0; i < _normalWeaponsUsed.Length; i++)
        {
            if (!_normalWeaponsUsed[i])
            {
                _currentNormalWeapons[i] = null;
                ReordenateWeapons(i);
                _normalWeaponsUsed[i] = true;
            }
        }
        for (int j = 0; j < _currentNormalWeapons.Length; j++)
        {
            _currentNormalWeapons[j].transform.localPosition = Vector3.Lerp(_currentNormalWeapons[j].transform.localPosition, _currentNormalWeapons[j].GetComponent<WeaponAbstractLWF>().PositionVector, 0.1f);
        }
    }

    void ReordenateWeapons(int j)
    {
        for (int i = j; i < _currentNormalWeapons.Length - 1; i++)
            _currentNormalWeapons[i] = _currentNormalWeapons[i + 1];
        _currentNormalWeapons[3] = ChooseWeapon();
        _currentNormalWeapons[3].transform.parent = _barra.transform;
        _currentNormalWeapons[3].collider2D.enabled = false;
        _currentNormalWeapons[3].GetComponent<WeaponAbstractLWF>().SetAlpha(0.5f);
		_currentNormalWeapons[2].GetComponent<WeaponAbstractLWF>().SetAlpha(1);
		Invoke("_ReordenateVector",0.2f);
        
    }

	void _ReordenateVector()
	{
		for (int i = 0; i < this._currentNormalWeapons.Length; i++)
		{
			_currentNormalWeapons[i].GetComponent<WeaponAbstractLWF>().Position = i;
			Vector3 vector = _positionNormalWeapons[i];
			vector.x -= _currentNormalWeapons[i].GetComponent<WeaponAbstractLWF>().lwf.width / 2;
			_currentNormalWeapons[i].GetComponent<WeaponAbstractLWF>().PositionVector = vector;
			if (i == 2)
				_currentNormalWeapons[i].collider2D.enabled = true;
			
		}
	}
	
	GameObject ChooseWeapon()
	{
		return Instantiate(_normalWeapons[Random.Range(0, _normalWeapons.Length)]) as GameObject;
    }
}
