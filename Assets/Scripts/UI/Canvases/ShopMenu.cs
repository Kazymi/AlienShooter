using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private Button nextWeaponButton;
    [SerializeField] private Button pastWeaponButton;
    [SerializeField] private Button buyWeaponButton;
    [SerializeField] private Button initializeButton;
    
    [SerializeField] private TMP_Text buyText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text moneyText;

    [SerializeField] private Shop shop;

    [SerializeField] private Slider damageSlider;
    [SerializeField] private Slider ammoSlider;
    [SerializeField] private Slider fireRateSlider;
    [SerializeField] private Slider speedAmmoSlider;
    [SerializeField] private Slider reloadedSlider;

    private MoneySave _moneySave;

    private const string BuyKey = "Buy";
    private const string EquipKey = "Equip";

    private void Initialize()
    {
        shop.Initialize();
        StartCoroutine(ShopStateUpdate());
        moneyText.text = _moneySave.Money.ToString();
    }

    private void OnEnable()
    {
        nextWeaponButton.onClick.AddListener(NextWeapon);
        pastWeaponButton.onClick.AddListener(PreviousWeapon);
        buyWeaponButton.onClick.AddListener(BuyWeapon);
        initializeButton.onClick.AddListener(Initialize);
    }

    private void OnDisable()
    {
        nextWeaponButton.onClick.RemoveListener(NextWeapon);
        pastWeaponButton.onClick.RemoveListener(PreviousWeapon);
        buyWeaponButton.onClick.RemoveListener(BuyWeapon);
        initializeButton.onClick.RemoveListener(Initialize);
    }

    private void UpdateShopState()
    {
        priceText.text = shop.Price.ToString();

        if (shop.UnlockBuy == false && shop.CheckBoughtWeapon())
        {
            buyWeaponButton.interactable = true;
            buyText.text = EquipKey;
        }
        else
        {
            buyText.text = BuyKey;
            buyWeaponButton.interactable = shop.UnlockBuy;
        }

        var i = shop.WeaponCharacteristics;
        damageSlider.value = i.Damage/100;
        ammoSlider.value = i.CountAmmo/100;
        speedAmmoSlider.value = i.SpeedAmmo/100;
        reloadedSlider.value = i.SpeedReloaded/3;
        fireRateSlider.value = i.FireRate/1;
    }

    private void NextWeapon()
    {
        shop.NextWeapon();
        UpdateShopState();
    }

    private void PreviousWeapon()
    {
        shop.PastWeapon();
        UpdateShopState();
    }

    private void BuyWeapon()
    {
        if (shop.CheckBoughtWeapon()) shop.EquipWeapon();
        else shop.Buy();
        moneyText.text = _moneySave.Money.ToString();
        shop.UpdateWeaponState();
        UpdateShopState();
    }

    private IEnumerator ShopStateUpdate()
    {
        yield return new WaitForEndOfFrame();
        UpdateShopState();
    }

    [Inject]
    private void Construct(SaveDataManager saveDataManager)
    {
        _moneySave = saveDataManager.MoneySave;
        moneyText.text = _moneySave.Money.ToString();
    }
}