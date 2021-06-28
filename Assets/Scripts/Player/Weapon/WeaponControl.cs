using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

// TODO: Looks like WeaponControl and Weapon can be merged. All you really need is to pickup/switch weapon and shoot it. Any other parameter or visual can be found in WeaponConfig
// TODO: at the same time it will be to long
// TODO: **Let's discuss it on Monday**
public class WeaponControl : MonoBehaviour
{
    [SerializeField] private WeaponConfiguration startWeapon;
    [SerializeField] private Transform positionWeapon;
    [SerializeField] private Transform ammoParant;
    
    private Weapon _currentWeapon;
    private InputHandler _inputHandler;
    private List<WeaponConfiguration> _spawnedWeapon = new List<WeaponConfiguration>(){null,null};
    private WeaponManager _weaponManager;
    private int _idCurrentGun;
    private SignalBus _signalBus;

    private void Start()
    {
        StartCoroutine(SpawnStartGun());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextWeapon();
        }

        if (_currentWeapon == null) return;
        if (!_inputHandler.Fire) return;
        _currentWeapon.Fire();
    }

    [Inject]
    public void Construct(WeaponManager weaponManager,InputHandler inputHandler, SignalBus signalBus)
    {
        _weaponManager = weaponManager;
        _inputHandler = inputHandler;
        _signalBus = signalBus;
    }
    public void NewWeapon(WeaponConfiguration weaponConfiguration)
    {
        for (var i = 0; i < _spawnedWeapon.Count; i++)
        {
            if (_spawnedWeapon[i] != null) continue;
            SetWeapon(weaponConfiguration,i);
            return;
        }
        SetWeapon(weaponConfiguration, _idCurrentGun);
    }
    
    private void NextWeapon()
    {
        if(_spawnedWeapon[0] == null && _spawnedWeapon[1] == null) return;
        _idCurrentGun = _idCurrentGun == 0 ? 1 : 0;
        if(_spawnedWeapon[_idCurrentGun] == null) return;
        SpawnGun(_idCurrentGun);
    }

    private IEnumerator SpawnStartGun()
    {
        yield return new WaitForEndOfFrame();
        if (startWeapon != null)
        {
            NewWeapon(startWeapon);
        }
    }
    private void OffAllGun()
    {
        foreach (var i in _spawnedWeapon.Where(i => i!=null))
        {
            _weaponManager.GetWeaponByName(i.Name).gameObject.SetActive(false);
        }
    }
    private void SpawnGun(int idWeapon)
    {
        OffAllGun();
        _currentWeapon = _weaponManager.GetWeaponByName(_spawnedWeapon[idWeapon].Name);
        _currentWeapon.transform.parent = positionWeapon;
        _currentWeapon.transform.localRotation = Quaternion.identity;
        _currentWeapon.Initialize(_spawnedWeapon[idWeapon],ammoParant, _signalBus);
        _currentWeapon.gameObject.SetActive(true);
    }

    private void SetWeapon(WeaponConfiguration weaponConfiguration, int id)
    {
        OffAllGun();
        if(_spawnedWeapon[id] != null)
            _weaponManager.GetWeaponByName(_spawnedWeapon[id].Name).transform.parent = _weaponManager.transform;
        _spawnedWeapon[id] = weaponConfiguration;
        SpawnGun(id);
    }
}
