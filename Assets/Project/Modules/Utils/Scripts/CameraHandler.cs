using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

namespace Utils
{
    public class CameraHandler
    {
        private const float SHAKE_DURATION = 0.2f;

        public Camera MainCamera { get; private set; }
        public CinemachineBrain Brain { get; private set; }

        private CinemachineBasicMultiChannelPerlin _perlinNoise;

        public static CameraHandler Instance { get; private set; }

        public static void Load(Camera mainCamera, CinemachineBrain brain)
        {
            Instance = new CameraHandler
            {
                MainCamera = mainCamera,
                Brain = brain
            };
        }

        public IEnumerator Shake()
        {
            if (this._perlinNoise == null)
                this._perlinNoise = ((CinemachineCamera)this.Brain.ActiveVirtualCamera).GetComponent<CinemachineBasicMultiChannelPerlin>();

            this._perlinNoise.enabled = true;

            yield return new WaitForSeconds(SHAKE_DURATION);

            this.StopShake();
        }

        public void StopShake()
        {
            if (this._perlinNoise != null)
                this._perlinNoise.enabled = false;
        }
    }
}