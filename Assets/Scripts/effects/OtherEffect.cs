using System.Collections;
using UnityEngine;

public class OtherEffect : MonoBehaviour
{
        [SerializeField] private float lifetime;
        
        private Factory _factory;
        
        public void Initialize(Factory factory)
        {
                _factory = factory;
                StartCoroutine(Destroy());
        }

        private IEnumerator Destroy()
        {
                yield return new WaitForSeconds(lifetime);
                _factory.Destroy(gameObject);
        }
}