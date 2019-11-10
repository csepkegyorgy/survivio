namespace Survivio.GameObjects.Item.Base
{
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Mechanisms.Controller;

    public interface IInteractable
    {
        void Interact(Avatar gameObject);
    }
}
