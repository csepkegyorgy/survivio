namespace Survivio.GameObjects.Item
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Item.Ammunitions;
    using Survivio.GameObjects.Item.Base;
    using System;
    using System.Collections.Generic;

    public class Loot : GameObject, IInteractable
    {
        public Item Item { get; set; }

        public override DrawMethod DrawMethod => GetDrawMethod();

        private DrawMethod GetDrawMethod()
        {
            if (Item != null)
            {
                if (Item is GunWeaponItem || Item is MeleeWeaponItem)
                {
                    List<Texture2D> textures = new List<Texture2D>();
                    List<Rectangle> rectangles = new List<Rectangle>();

                    Rectangle lootCircleBody = this.Body.Rectangle;
                    textures.Add(ContentAccessor.LootCircleOuter01);
                    rectangles.Add(lootCircleBody);

                    Rectangle weaponBody = GameConfig.GameObjectStandards.LootStandards.GetStandardLootBodyForWeapon();
                    textures.Add(Item.LootTexture);
                    rectangles.Add(new Rectangle(
                        (lootCircleBody.X + (lootCircleBody.Width / 2)) - (weaponBody.Width / 2),
                        (lootCircleBody.Y + (lootCircleBody.Height / 2)) - (weaponBody.Height / 2),
                        weaponBody.Width,
                        weaponBody.Height));

                    return new DrawMethod(textures, rectangles);
                }

                return base.DrawMethod;
            }
            else
            {
                return null;
            }
        }

        public Loot(Item item, int x = 0, int y = 0)
            : base(item.LootTexture, GameConfig.GameObjectStandards.LootStandards.GetStandardLootBody(item, x, y))
        {
            this.Item = item;
            this.DrawPriority = DrawPriority.Medium;
        }

        public void Interact(Avatar avatar)
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
                Item = null;
                this.Remove();

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
                    Item = null;

                    if (remainder != 0)
                    {
                        Blue762Ammunition newAmmo = new Blue762Ammunition(remainder);
                        Item = newAmmo;
                    }
                    else
                    {
                        this.Remove();
                    }
                }
            }
        }

        public override bool Collide(GameObject gameObject)
        {
            if (gameObject is Avatar)
            {
                if (this.CollidesWith(gameObject.Body.Center))
                {
                    var avatar = gameObject as Avatar;
                    if (!avatar.InteractableGameObjects.Contains(this))
                    {
                        avatar.AddInteractableGameObject(this);
                    }
                }
            }

            return false;
        }
    }
}
