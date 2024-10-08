using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Game
{
    public class PlayerHealthController : HealthController
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Slider _healthBar;

        private void Awake()
        {
            this._canvas.worldCamera = CameraHandler.Instance.MainCamera;
            base.HealthRecoverListener += this.OnHealthRecover;
            base.HealthLoseListener += this.OnHealthLose;
        }

        private void OnDisable()
        {
            CameraHandler.Instance.StopShake();
        }

        public override void OnDeath()
        {
            base.OnDeath();
            // TODO Game over
        }

        private void OnHealthRecover(float amount, float currentHealth, float maxHealth)
        {
            this._healthBar.value = currentHealth / maxHealth;
        }

        private void OnHealthLose(float amount, float currentHealth, float maxHealth)
        {
            this._healthBar.value = currentHealth / maxHealth;

            if (base.gameObject.activeSelf)
                base.StartCoroutine(CameraHandler.Instance.Shake());
        }
    }
}