using System;
using System.Collections;
//using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.Weapon
{
    public class Bullet : PoolObject
    {
        public float BulletSpeed;
        public GameObject ImpactPrefab;
        private string nameImpact;
        public ImpactAudioData ImpactAudioData;
        private Transform bulletTransform;
        private Vector3 prevPosition;
        [Header("轨道组件的开始时间")] public float startlifeTime = 0.1f;
        private TrailRenderer trailRenderer;
        public override void OnEnable()
        {
            base.OnEnable();
            trailRenderer = GetComponent<TrailRenderer>();
            trailRenderer.enabled = false;
            StartCoroutine(DelayEnableComm());
        }
        private void Start()
        {
            bulletTransform = transform;
            prevPosition = bulletTransform.position;
            nameImpact = ImpactPrefab.name;
        }

        private void Update()
        {
            prevPosition = bulletTransform.position;

            bulletTransform.Translate(0, 0, BulletSpeed * Time.deltaTime);

            if (!Physics.Raycast(prevPosition, (bulletTransform.position - prevPosition).normalized,
            out RaycastHit tmp_Hit, (bulletTransform.position - prevPosition).magnitude)) return;
            if (tmp_Hit.collider.tag != "Detection")
            {
                var tmp_BulletEffect =
                      GameObjectPool.Instance.GetGameObject(
                        nameImpact, tmp_Hit.point,
                        Quaternion.LookRotation(tmp_Hit.normal, Vector3.up));//创建击中特效
                                                                             //GameObjectPool.Instance.SetGameObject(this.gameObject);
                                                                             //销毁子弹
                StartCoroutine(DelayEnterPool(this.gameObject, 1f));
                // FSM tmp_FSM = tmp_Hit.transform.GetComponent<FSM>();
                // tmp_FSM.parameter.isGetHit = true;
                // tmp_Hit.transform.GetComponent<FSM>().parameter.isGetHit = true;
                if (tmp_Hit.transform.TryGetComponent<FSM>(out FSM fsm))
                {
                    FSM tmp_FSM = tmp_Hit.transform.GetComponent<FSM>();
                    tmp_FSM.parameter.isGetHit = true;
                    tmp_FSM.parameter.Health--;
                }
            }

            // var tmp_BulletEffect =
            //     Instantiate(ImpactPrefab,
            //         tmp_Hit.point,
            //         Quaternion.LookRotation(tmp_Hit.normal, Vector3.up));


            //StartCoroutine(DelayEnterPool(tmp_BulletEffect));
            //Destroy(tmp_BulletEffect, 3f);
            //For Audio
            var tmp_TagsWithAudio =
                ImpactAudioData.ImpactTagsWithAudios.Find((_audioData) => _audioData.Tag.Equals(tmp_Hit.collider.tag));
            if (tmp_TagsWithAudio == null) return;
            int tmp_Length = tmp_TagsWithAudio.ImpactAudioClips.Count;
            AudioClip tmp_AudioClip = tmp_TagsWithAudio.ImpactAudioClips[Random.Range(0, tmp_Length)];
            AudioSource.PlayClipAtPoint(tmp_AudioClip, tmp_Hit.point);
        }
        private IEnumerator DelayEnterPool(GameObject obj, float time)
        {
            yield return new WaitForSeconds(time);
            //进入对象池
            GameObjectPool.Instance.SetGameObject(obj);
        }
        private IEnumerator DelayEnableComm()
        {
            yield return new WaitForSeconds(startlifeTime);
            trailRenderer.enabled = true;
        }
        // private void OnTriggerEnter(Collider other)
        // {
        //     if (other.CompareTag("Untagged") || other.CompareTag("Rock") || other.CompareTag("Enemy"))
        //     {
        //         GameObjectPool.Instance.SetGameObject(this.gameObject);
        //     }
        // }

    }
}