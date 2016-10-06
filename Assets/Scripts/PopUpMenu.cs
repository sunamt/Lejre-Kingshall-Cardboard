using UnityEngine;
using System.Collections;

public class PopUpMenu : MonoBehaviour
{
    [SerializeField]
    private float m_FadeDuration = 0.5f;
    [SerializeField]
    private float m_ShowAngle = 0.75f;
    [SerializeField]
    private float m_TurnAngle = 50f;
    [SerializeField]
    private Transform m_DesiredDirection;
    [SerializeField]
    private Transform m_Camera;
    [SerializeField]
    private Renderer[] m_ArrowRenderers;


    private float m_CurrentAlpha;
    private float m_TargetAlpha;
    private float m_FadeSpeed;
    private const string k_MaterialPropertyName = "_Alpha";

    bool waitBetweenScenes = true;

    private void Start()
    {
        m_FadeSpeed = 1f / m_FadeDuration;
    }


    private void Update()
    {
        Vector3 desiredForward = m_DesiredDirection == null ? Vector3.forward : m_DesiredDirection.forward;
        Vector3 flatCamHoriz = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
        float angleDeltaHoriz = Vector3.Angle(desiredForward, flatCamHoriz);
        if (angleDeltaHoriz > m_TurnAngle)
        {
            Vector3 camLook = m_Camera.transform.forward;
            camLook.y = 0f;
            Quaternion camQuat = Quaternion.LookRotation(camLook);
            transform.rotation = Quaternion.Slerp(transform.rotation, camQuat, Time.deltaTime);
        }

        m_TargetAlpha = Mathf.Abs(m_DesiredDirection.forward.y) > m_ShowAngle ? 1f : 0f; // "New" stuff
        m_CurrentAlpha = Mathf.MoveTowards(m_CurrentAlpha, m_TargetAlpha, m_FadeSpeed * Time.deltaTime);
        for (int i = 0; i < m_ArrowRenderers.Length; i++)
        {
            m_ArrowRenderers[i].material.SetFloat(k_MaterialPropertyName, m_CurrentAlpha);
        }
    }
}