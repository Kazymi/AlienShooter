using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private Button nextWeaponButton;
    [SerializeField] private Button pastWeaponButton;
    [SerializeField] private Button buyWeaponButton;
    [SerializeField] private TMP_Text buyText;
    [SerializeField] private Shop shop;

    private SaveData _saveData = new SaveData();
    private SignalBus _signalBus;
    private const string _buy = "Buy";
    private const string _equip = "Equip";

    private void Start()
    {
        nextWeaponButton.onClick.AddListener(NextWeapon);
        pastWeaponButton.onClick.AddListener(PastWeapon);
        buyWeaponButton.onClick.AddListener(BuyWeapon);
        StartCoroutine(ShopStateUpdate());
        moneyText.text = _saveData.Money.ToString();
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<LoadedSignal>(OnLoaded);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<LoadedSignal>(OnLoaded);
    }

    private void UpdateShopState()
    {
        priceText.text = shop.Price.ToString();

        if (!shop.UnlockBuy && shop.CheckBoughtWeapon())
        {
            buyWeaponButton.interactable = true;
            buyText.text = _equip;
            return;
        }
        else
        {
            buyText.text = _buy;
        }

        buyWeaponButton.interactable = shop.UnlockBuy;
    }

    private void NextWeapon()
    {
        shop.NextWeapon();
        UpdateShopState();
    }

    private void PastWeapon()
    {
        shop.PastWeapon();
        UpdateShopState();
    }

    private void BuyWeapon()
    {
        if (shop.CheckBoughtWeapon()) shop.EquipWeapon();
        else shop.Buy();
        moneyText.text = _saveData.Money.ToString();
        shop.UpdateWeaponState();
        UpdateShopState();
    }

    private void OnLoaded(LoadedSignal loadedSignal)
    {
        _saveData = loadedSignal.saveData;
    }

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private IEnumerator ShopStateUpdate()
    {
        yield return new WaitForEndOfFrame();
        UpdateShopState();
    }
}