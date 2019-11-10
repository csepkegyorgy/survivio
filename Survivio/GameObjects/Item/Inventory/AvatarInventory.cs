namespace Survivio.GameObjects.Item.Inventory
{
    using Survivio.GameObjects.Item.Base;
    using Survivio.GameObjects.Item.Inventory.Consumables;
    using Survivio.GameObjects.Mechanisms.Controller;

    public class AvatarInventory
    {
        public Avatar Avatar { get; private set; }

        public BackpackType BackpackLevel { get; private set; }

        public AmmunitionInventory AmmunitionInventoryYellow { get; private set; }
        public AmmunitionInventory AmmunitionInventoryBlue { get; private set; }
        public AmmunitionInventory AmmunitionInventoryGreen { get; private set; }
        public AmmunitionInventory AmmunitionInventoryRed { get; private set; }
        public BandageInventory BandageInventory { get; private set; }
        public MedKitInventory MedKitInventory { get; private set; }
        public SodaInventory SodaInventory { get; private set; }
        public PillsInventory PillsInventory { get; private set; }

        public GunWeaponItem PrimaryHandSlot { get; private set; }
        public GunWeaponItem SecondaryHandSlot { get; private set; }
        public MeleeWeaponItem MeleeHandSlot { get; private set; }
        public ThrowableWeaponItem ThrowableHandSlot { get; private set; }
        public int SelectedHandSlot { get; private set; }

        public AvatarInventory(Avatar avatar)
        {
            this.Avatar = avatar;

            AmmunitionInventoryYellow = new AmmunitionInventory(this, AmmunitionType.Yellow9mm);
            AmmunitionInventoryBlue = new AmmunitionInventory(this, AmmunitionType.Blue762mm);
            AmmunitionInventoryGreen = new AmmunitionInventory(this, AmmunitionType.Green556mm);
            AmmunitionInventoryRed = new AmmunitionInventory(this, AmmunitionType.Red12Gauge);
            BandageInventory = new BandageInventory(this);
            MedKitInventory = new MedKitInventory(this);
            SodaInventory = new SodaInventory(this);
            PillsInventory = new PillsInventory(this);
        }

        public void SelectHandSlot(int handSlot)
        {
            if (handSlot >= 0 && handSlot <= 3)
            {
                SelectedHandSlot = handSlot;
            }
        }

        public void EquipToPrimaryHandSlot(GunWeaponItem item, bool switchSelectedHandSlot = false)
        {
            PrimaryHandSlot = item;
            if (switchSelectedHandSlot)
            {
                SelectedHandSlot = 0;
            }
        }

        public void EquipToSecondaryHandSlot(GunWeaponItem item, bool switchSelectedHandSlot = false)
        {
            SecondaryHandSlot = item;
            if (switchSelectedHandSlot)
            {
                SelectedHandSlot = 1;
            }
        }

        public void EquipToMeleeHandSlot(MeleeWeaponItem item, bool switchSelectedHandSlot = false)
        {
            MeleeHandSlot = item;
            if (switchSelectedHandSlot)
            {
                SelectedHandSlot = 2;
            }
        }

        public void EquipToThrowableHandSlot(ThrowableWeaponItem item, bool switchSelectedHandSlot = false)
        {
            ThrowableHandSlot = item;
            if (switchSelectedHandSlot)
            {
                SelectedHandSlot = 3;
            }
        }
    }
}
