using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradeShopMenu : MonoBehaviour
{
    [SerializeField] private UpgradeShop upgradeShop;

    [SerializeField] private Button initializeButton;
    [SerializeField] private Button buyDamageButton;
    [SerializeField] private Button buyAmmoButton;
    [SerializeField] private Button buyReduceFireRateButton;
    [SerializeField] private Button buyReduceTimeReloadedButton;

    [SerializeField] private TMP_Text priceDamageText;
    [SerializeField] private TMP_Text priceAmmoText;
    [SerializeField] private TMP_Text priceFireRateText;
    [SerializeField] private TMP_Text priceTimeReloadedText;
    [SerializeField] private TMP_Text playerMoneyText;

    [SerializeField] private Slider lvlBarDamage;
    [SerializeField] private Slider lvlBarAmmo;
    [SerializeField] private Slider lvlBarFireRate;
    [SerializeField] private Slider lvlBarReloaded;

    private MoneySave _moneySave;

    private void OnEnable()
    {
        initializeButton.onClick.AddListener(Initialize);
        buyAmmoButton.onClick.AddListener(BuyAmmo);
        buyDamageButton.onClick.AddListener(BuyDamage);
        buyReduceFireRateButton.onClick.AddListener(BuyReduceFireRate);
        buyReduceTimeReloadedButton.onClick.AddListener(BuyReduceTimeReloaded);
    }

    private void OnDisable()
    {
        initializeButton.onClick.RemoveListener(Initialize);
        buyAmmoButton.onClick.RemoveListener(BuyAmmo);
        buyDamageButton.onClick.RemoveListener(BuyDamage);
        buyReduceFireRateButton.onClick.RemoveListener(BuyReduceFireRate);
        buyReduceTimeReloadedButton.onClick.RemoveListener(BuyReduceTimeReloaded);
    }

    private void Initialize()
    {
        if(upgradeShop.WeaponSelected() == false) return;
        upgradeShop.Initialize();
        UpdateState();
    }

    private void UpdateState()
    {
        var priceList = upgradeShop.UpgradePriceList;
        buyAmmoButton.interactable = priceList.UnlockBuyAmmo;
        buyDamageButton.interactable = priceList.UnlockBuyDamage;
        buyReduceFireRateButton.interactable = priceList.UnlockBuyReduceFireRate;
        buyReduceTimeReloadedButton.interactable = priceList.UnlockBuyReduceTimeReloaded;

        playerMoneyText.text = _moneySave.Money.ToString();
        priceAmmoText.text = priceList.PriceAmmo.ToString();
        priceDamageText.text = priceList.PriceDamage.ToString();
        priceFireRateText.text = priceList.PriceReduceFireRate.ToString();
        priceTimeReloadedText.text = priceList.PriceReduceTimeReloaded.ToString();

        lvlBarAmmo.value = upgradeShop.AmmoSliderValue;
        lvlBarDamage.value = upgradeShop.DamageSliderValue;
        lvlBarReloaded.value = upgradeShop.TimeReloadedSliderValue;
        lvlBarFireRate.value = upgradeShop.FireRateSliderValue;
    }

    [Inject]
    private void Construct(SaveDataManager saveDataManager)
    {
        _moneySave = saveDataManager.MoneySave;
    }

    private void BuyDamage()
    {
        upgradeShop.AddDamage();
        UpdateState();
    }

    private void BuyAmmo()
    {
        upgradeShop.AddAmmo();
        UpdateState();
    }

    private void BuyReduceFireRate()
    {
        upgradeShop.ReduceFireRate();
        UpdateState();
    }

    private void BuyReduceTimeReloaded()
    {
        upgradeShop.ReduceTimeReloaded();
        UpdateState();
    }
}