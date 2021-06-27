using System.Collections;
using UnityEngine;

public class VisualEffect : MonoBehaviour
{
    [SerializeField] private float startScale;
    [Range(0,1)][SerializeField] private float extinctionScale;
    [SerializeField] private float extinctionSpeed;
    private Factory _factory;

    public void InitializeFactory(Factory factory)
    {
        _factory = factory;
        transform.localScale = new Vector3(startScale, 1, startScale);
    }

    public void InitializeEffect(Effect effect)
    {
        StartCoroutine(StartEffect(effect));
    }

    public void DestoryEffect()
    {
        _factory.Destroy(gameObject);
    }
    IEnumerator StartEffect(Effect effect)
    {
        while (true)
        {
            yield return null;
            if(effect == null) break;
            if (effect.Timer <= 1) break;
        }

        StartCoroutine(DestroyEffect());
    }

    IEnumerator DestroyEffect()
    {
        // TODO: DOTween can be used for simple animations
        while (transform.localScale.x > extinctionScale || transform.localScale.z > extinctionScale)
        {
            yield return null;
            transform.localScale -= new Vector3(extinctionSpeed * Time.deltaTime, extinctionSpeed * Time.deltaTime, extinctionSpeed * Time.deltaTime);
        }

        transform.parent = null;
        DestoryEffect();
    }
}
