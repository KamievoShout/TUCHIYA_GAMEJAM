using UnityEngine;

namespace Players
{
    public class Test_Ichinose_PlayerChargeEffect : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _particle;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _particle.gameObject.SetActive(true);
                _particle.Play();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                _particle.gameObject.SetActive(false);
            }
        }
    }
}
