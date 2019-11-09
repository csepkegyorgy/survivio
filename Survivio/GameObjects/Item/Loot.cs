namespace Survivio.GameObjects.Item
{
    using Microsoft.Xna.Framework;
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Item.Ammunitions;
    using Survivio.GameObjects.Item.Base;
    using Survivio.GameObjects.Mechanisms.Controller;
    using System;
    using System.Collections.Generic;

    public class Loot : GameObject, IInteractable
    {
        public Item Item { get; set; }

        public Loot(Item item)
            : base(item.Texture, item.Body.Rectangle)
        {
            this.Item = item;
        }

        public void Interact(Avatar<IController> avatar)
        {
            if (Item is GunWeaponItem)
            {
                if (avatar.Inventory.SelectedHandSlot == 0)
                {
                    avatar.Inventory.EquipToPrimaryHandSlot(Item as GunWeaponItem, true);
                }
                else if (avatar.Inventory.SelectedHandSlot == 1)
                {
                    avatar.Inventory.EquipToSecondaryHandSlot(Item as GunWeaponItem, true);
                }
                else if (avatar.Inventory.SelectedHandSlot == 2 && avatar.Inventory.PrimaryHandSlot == null)
                {
                    avatar.Inventory.EquipToPrimaryHandSlot(Item as GunWeaponItem, true);
                }
                else if (avatar.Inventory.SelectedHandSlot == 2 && avatar.Inventory.SecondaryHandSlot == null)
                {
                    avatar.Inventory.EquipToSecondaryHandSlot(Item as GunWeaponItem, true);
                }
                else if (avatar.Inventory.SelectedHandSlot == 3 && avatar.Inventory.PrimaryHandSlot == null)
                {
                    avatar.Inventory.EquipToSecondaryHandSlot(Item as GunWeaponItem);
                }
                else if (avatar.Inventory.SelectedHandSlot == 3 && avatar.Inventory.SecondaryHandSlot == null)
                {
                    avatar.Inventory.EquipToSecondaryHandSlot(Item as GunWeaponItem);
                }
            }
            else if (Item is MeleeWeaponItem)
            {
                throw new NotImplementedException();
            }
            else if (Item is ThrowableWeaponItem)
            {
                throw new NotImplementedException();
            }
            else if (Item is AmmunitionItem)
            {
                if (Item is Blue762Ammunition)
                {
                    int remainder = avatar.Inventory.AmmunitionInventoryBlue.AddAmount((Item as Blue762Ammunition).Amount);
                    Item.Remove();
                    Item = null;

                    if (remainder != 0)
                    {
                        var newAmmo = new Blue762Ammunition(remainder);
                        avatar.GameWorld.AddNewGameObject(newAmmo);
                        newAmmo.Move(avatar.Body.Center);
                        Item = newAmmo;
                    }
                    else
                    {
                        this.Remove();
                    }
                }
            }
            // check if avatar has enough space to pick the item up
            // y: add item to avatar's inventory
            // if item was for eg bandage ammo or something that has a count number, then check if there is a remainder
            // y: reposition loot instance with the remainder
        }

        public override List<Rectangle> CollisionRectangles
        {
            get
            {
                Rectangle itemBody = Item.Body.Rectangle;
                if (Item is AmmunitionItem)
                {
                    Rectangle rectangle = new Rectangle(itemBody.Location, itemBody.Size);
                    rectangle.Inflate((float)itemBody.Width, (int)itemBody.Height);
                    return new List<Rectangle>()
                    {
                        rectangle
                    };
                }
                else
                {
                    return base.CollisionRectangles;
                }
            }
        }

        public override bool Collide(GameObject gameObject)
        {
            if (gameObject is Avatar<IController>)
            {
                var avatar = gameObject as Avatar<IController>;
                if (!avatar.InteractableLoots.Contains(this))
                {
                    avatar.InteractableLoots.Add(this);
                }
            }

            return false;
        }
    }
}
