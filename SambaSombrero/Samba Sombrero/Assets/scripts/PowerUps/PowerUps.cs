using UnityEngine;

public abstract class PowerUps : MonoBehaviour
{

    public abstract void Activate();
    public virtual void DeActivate()
    {
        PowerUpsManager.Instance.RemovePowerUps(this);
    }
}
