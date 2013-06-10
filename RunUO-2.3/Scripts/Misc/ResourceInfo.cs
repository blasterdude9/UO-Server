using System;
using System.Collections;

//Added ore resource Added tons off ore: "06/02/2013" -Giel

namespace Server.Items
{
	public enum CraftResource
	{
		None = 0,
		Iron = 1,
		DullCopper,
		ShadowIron,
		Copper,
		Bronze,
		Gold,
		Agapite,
		Verite,
		Valorite,
		Rusty,
		Silver,
		PureCopper,
		BronzeAlloy,
		Shadow,
		Rose,
		Lime,
		Fuscia,
		Bloodrock,
		ChromeBlue,
		ChromeCopper,
		Pansy,
		Stinger,
		Royal,
		BlueSteel,
		Ice,
		Lemon,
		Blackrock,
		RoseQuartz,
		Mint,
		Aqua,
		Daemon,
		Mythril,
		Titanium,
		Kryptonite,
		Diamond,
		Jolt,
		Uranium,
		Opiate,
		Negative,
		Deus,
		DarkDeus,
		

		RegularLeather = 101,
		SpinedLeather,
		HornedLeather,
		BarbedLeather,

		RedScales = 201,
		YellowScales,
		BlackScales,
		GreenScales,
		WhiteScales,
		BlueScales,

		RegularWood = 301,
		OakWood,
		AshWood,
		YewWood,
		Heartwood,
		Bloodwood,
		Frostwood
	}

	public enum CraftResourceType
	{
		None,
		Metal,
		Leather,
		Scales,
		Wood
	}

	public class CraftAttributeInfo
	{
		private int m_WeaponFireDamage;
		private int m_WeaponColdDamage;
		private int m_WeaponPoisonDamage;
		private int m_WeaponEnergyDamage;
		private int m_WeaponChaosDamage;
		private int m_WeaponDirectDamage;
		private int m_WeaponDurability;
		private int m_WeaponLuck;
		private int m_WeaponGoldIncrease;
		private int m_WeaponLowerRequirements;

		private int m_ArmorPhysicalResist;
		private int m_ArmorFireResist;
		private int m_ArmorColdResist;
		private int m_ArmorPoisonResist;
		private int m_ArmorEnergyResist;
		private int m_ArmorDurability;
		private int m_ArmorLuck;
		private int m_ArmorGoldIncrease;
		private int m_ArmorLowerRequirements;

		private int m_RunicMinAttributes;
		private int m_RunicMaxAttributes;
		private int m_RunicMinIntensity;
		private int m_RunicMaxIntensity;

		public int WeaponFireDamage{ get{ return m_WeaponFireDamage; } set{ m_WeaponFireDamage = value; } }
		public int WeaponColdDamage{ get{ return m_WeaponColdDamage; } set{ m_WeaponColdDamage = value; } }
		public int WeaponPoisonDamage{ get{ return m_WeaponPoisonDamage; } set{ m_WeaponPoisonDamage = value; } }
		public int WeaponEnergyDamage{ get{ return m_WeaponEnergyDamage; } set{ m_WeaponEnergyDamage = value; } }
		public int WeaponChaosDamage{ get{ return m_WeaponChaosDamage; } set{ m_WeaponChaosDamage = value; } }
		public int WeaponDirectDamage{ get{ return m_WeaponDirectDamage; } set{ m_WeaponDirectDamage = value; } }
		public int WeaponDurability{ get{ return m_WeaponDurability; } set{ m_WeaponDurability = value; } }
		public int WeaponLuck{ get{ return m_WeaponLuck; } set{ m_WeaponLuck = value; } }
		public int WeaponGoldIncrease{ get{ return m_WeaponGoldIncrease; } set{ m_WeaponGoldIncrease = value; } }
		public int WeaponLowerRequirements{ get{ return m_WeaponLowerRequirements; } set{ m_WeaponLowerRequirements = value; } }

		public int ArmorPhysicalResist{ get{ return m_ArmorPhysicalResist; } set{ m_ArmorPhysicalResist = value; } }
		public int ArmorFireResist{ get{ return m_ArmorFireResist; } set{ m_ArmorFireResist = value; } }
		public int ArmorColdResist{ get{ return m_ArmorColdResist; } set{ m_ArmorColdResist = value; } }
		public int ArmorPoisonResist{ get{ return m_ArmorPoisonResist; } set{ m_ArmorPoisonResist = value; } }
		public int ArmorEnergyResist{ get{ return m_ArmorEnergyResist; } set{ m_ArmorEnergyResist = value; } }
		public int ArmorDurability{ get{ return m_ArmorDurability; } set{ m_ArmorDurability = value; } }
		public int ArmorLuck{ get{ return m_ArmorLuck; } set{ m_ArmorLuck = value; } }
		public int ArmorGoldIncrease{ get{ return m_ArmorGoldIncrease; } set{ m_ArmorGoldIncrease = value; } }
		public int ArmorLowerRequirements{ get{ return m_ArmorLowerRequirements; } set{ m_ArmorLowerRequirements = value; } }

		public int RunicMinAttributes{ get{ return m_RunicMinAttributes; } set{ m_RunicMinAttributes = value; } }
		public int RunicMaxAttributes{ get{ return m_RunicMaxAttributes; } set{ m_RunicMaxAttributes = value; } }
		public int RunicMinIntensity{ get{ return m_RunicMinIntensity; } set{ m_RunicMinIntensity = value; } }
		public int RunicMaxIntensity{ get{ return m_RunicMaxIntensity; } set{ m_RunicMaxIntensity = value; } }

		public CraftAttributeInfo()
		{
		}

		public static readonly CraftAttributeInfo Blank;
		public static readonly CraftAttributeInfo DullCopper, ShadowIron, Copper, Bronze, Golden, Agapite, Verite,
		Valorite, Rusty, Silver, PureCopper, BronzeAlloy, Shadow, Rose, Lime, Fuscia, Bloodrock, ChromeBlue,
		ChromeCopper, Pansy, Stinger, Royal, BlueSteel, Ice, Lemon, Blackrock, RoseQuartz, Mint, Aqua,
		Daemon, Mythril, Titanium, Kryptonite, Diamond, Jolt, Uranium, Opiate, Negative, Deus, DarkDeus;
		public static readonly CraftAttributeInfo Spined, Horned, Barbed;
		public static readonly CraftAttributeInfo RedScales, YellowScales, BlackScales, GreenScales, WhiteScales, BlueScales;
		public static readonly CraftAttributeInfo OakWood, AshWood, YewWood, Heartwood, Bloodwood, Frostwood;

		static CraftAttributeInfo()
		{
			Blank = new CraftAttributeInfo();

			CraftAttributeInfo dullCopper = DullCopper = new CraftAttributeInfo();

			dullCopper.ArmorPhysicalResist = 6;
			dullCopper.ArmorDurability = 50;
			dullCopper.ArmorLowerRequirements = 20;
			dullCopper.WeaponDurability = 100;
			dullCopper.WeaponLowerRequirements = 50;
			dullCopper.RunicMinAttributes = 1;
			dullCopper.RunicMaxAttributes = 2;
			if ( Core.ML )
			{
				dullCopper.RunicMinIntensity = 40;
				dullCopper.RunicMaxIntensity = 100;
			}
			else
			{
				dullCopper.RunicMinIntensity = 10;
				dullCopper.RunicMaxIntensity = 35;
			}

			CraftAttributeInfo shadowIron = ShadowIron = new CraftAttributeInfo();

			shadowIron.ArmorPhysicalResist = 2;
			shadowIron.ArmorFireResist = 1;
			shadowIron.ArmorEnergyResist = 5;
			shadowIron.ArmorDurability = 100;
			shadowIron.WeaponColdDamage = 20;
			shadowIron.WeaponDurability = 50;
			shadowIron.RunicMinAttributes = 2;
			shadowIron.RunicMaxAttributes = 2;
			if ( Core.ML )
			{
				shadowIron.RunicMinIntensity = 45;
				shadowIron.RunicMaxIntensity = 100;
			}
			else
			{
				shadowIron.RunicMinIntensity = 20;
				shadowIron.RunicMaxIntensity = 45;
			}

			CraftAttributeInfo copper = Copper = new CraftAttributeInfo();

			copper.ArmorPhysicalResist = 1;
			copper.ArmorFireResist = 1;
			copper.ArmorPoisonResist = 5;
			copper.ArmorEnergyResist = 2;
			copper.WeaponPoisonDamage = 10;
			copper.WeaponEnergyDamage = 20;
			copper.RunicMinAttributes = 2;
			copper.RunicMaxAttributes = 3;
			if ( Core.ML )
			{
				copper.RunicMinIntensity = 50;
				copper.RunicMaxIntensity = 100;
			}
			else
			{
				copper.RunicMinIntensity = 25;
				copper.RunicMaxIntensity = 50;
			}

			CraftAttributeInfo bronze = Bronze = new CraftAttributeInfo();

			bronze.ArmorPhysicalResist = 3;
			bronze.ArmorColdResist = 5;
			bronze.ArmorPoisonResist = 1;
			bronze.ArmorEnergyResist = 1;
			bronze.WeaponFireDamage = 40;
			bronze.RunicMinAttributes = 3;
			bronze.RunicMaxAttributes = 3;
			if ( Core.ML )
			{
				bronze.RunicMinIntensity = 55;
				bronze.RunicMaxIntensity = 100;
			}
			else
			{
				bronze.RunicMinIntensity = 30;
				bronze.RunicMaxIntensity = 65;
			}

			CraftAttributeInfo golden = Golden = new CraftAttributeInfo();

			golden.ArmorPhysicalResist = 1;
			golden.ArmorFireResist = 1;
			golden.ArmorColdResist = 2;
			golden.ArmorEnergyResist = 2;
			golden.ArmorLuck = 40;
			golden.ArmorLowerRequirements = 30;
			golden.WeaponLuck = 40;
			golden.WeaponLowerRequirements = 50;
			golden.RunicMinAttributes = 3;
			golden.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				golden.RunicMinIntensity = 60;
				golden.RunicMaxIntensity = 100;
			}
			else
			{
				golden.RunicMinIntensity = 35;
				golden.RunicMaxIntensity = 75;
			}

			CraftAttributeInfo agapite = Agapite = new CraftAttributeInfo();

			agapite.ArmorPhysicalResist = 2;
			agapite.ArmorFireResist = 3;
			agapite.ArmorColdResist = 2;
			agapite.ArmorPoisonResist = 2;
			agapite.ArmorEnergyResist = 2;
			agapite.WeaponColdDamage = 30;
			agapite.WeaponEnergyDamage = 20;
			agapite.RunicMinAttributes = 4;
			agapite.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				agapite.RunicMinIntensity = 65;
				agapite.RunicMaxIntensity = 100;
			}
			else
			{
				agapite.RunicMinIntensity = 40;
				agapite.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo verite = Verite = new CraftAttributeInfo();

			verite.ArmorPhysicalResist = 3;
			verite.ArmorFireResist = 3;
			verite.ArmorColdResist = 2;
			verite.ArmorPoisonResist = 3;
			verite.ArmorEnergyResist = 1;
			verite.WeaponPoisonDamage = 40;
			verite.WeaponEnergyDamage = 20;
			verite.RunicMinAttributes = 4;
			verite.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				verite.RunicMinIntensity = 70;
				verite.RunicMaxIntensity = 100;
			}
			else
			{
				verite.RunicMinIntensity = 45;
				verite.RunicMaxIntensity = 90;
			}

			CraftAttributeInfo valorite = Valorite = new CraftAttributeInfo();

			valorite.ArmorPhysicalResist = 4;
			valorite.ArmorColdResist = 3;
			valorite.ArmorPoisonResist = 3;
			valorite.ArmorEnergyResist = 3;
			valorite.ArmorDurability = 50;
			valorite.WeaponFireDamage = 10;
			valorite.WeaponColdDamage = 20;
			valorite.WeaponPoisonDamage = 10;
			valorite.WeaponEnergyDamage = 20;
			valorite.RunicMinAttributes = 5;
			valorite.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				valorite.RunicMinIntensity = 85;
				valorite.RunicMaxIntensity = 100;
			}
			else
			{
				valorite.RunicMinIntensity = 50;
				valorite.RunicMaxIntensity = 100;
			}
			
			CraftAttributeInfo rusty  = Rusty  = new CraftAttributeInfo();

			rusty.ArmorPhysicalResist = 4;
			rusty.ArmorColdResist = 3;
			rusty.ArmorPoisonResist = 3;
			rusty.ArmorEnergyResist = 3;
			rusty.ArmorDurability = 50;
			rusty.WeaponFireDamage = 10;
			rusty.WeaponColdDamage = 20;
			rusty.WeaponPoisonDamage = 10;
			rusty.WeaponEnergyDamage = 20;
			rusty.RunicMinAttributes = 5;
			rusty.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                rusty.RunicMinIntensity = 50;
                rusty.RunicMaxIntensity = 100;
            }
            else
            {
                rusty.RunicMinIntensity = 50;
                rusty.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo silver = Silver = new CraftAttributeInfo();

			silver.ArmorPhysicalResist = 4;
			silver.ArmorColdResist = 3;
			silver.ArmorPoisonResist = 3;
			silver.ArmorEnergyResist = 3;
			silver.ArmorDurability = 50;
			silver.WeaponFireDamage = 10;
			silver.WeaponColdDamage = 20;
			silver.WeaponPoisonDamage = 10;
			silver.WeaponEnergyDamage = 20;
			silver.RunicMinAttributes = 5;
			silver.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                silver.RunicMinIntensity = 50;
                silver.RunicMaxIntensity = 100;
            }
            else
            {
                silver.RunicMinIntensity = 250;
                silver.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo pureCopper = PureCopper = new CraftAttributeInfo();

			pureCopper.ArmorPhysicalResist = 4;
			pureCopper.ArmorColdResist = 3;
			pureCopper.ArmorPoisonResist = 3;
			pureCopper.ArmorEnergyResist = 3;
			pureCopper.ArmorDurability = 50;
			pureCopper.WeaponFireDamage = 10;
			pureCopper.WeaponColdDamage = 20;
			pureCopper.WeaponPoisonDamage = 10;
			pureCopper.WeaponEnergyDamage = 20;
			pureCopper.RunicMinAttributes = 5;
			pureCopper.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                pureCopper.RunicMinIntensity = 50;
                pureCopper.RunicMaxIntensity = 100;
            }
            else
            {
                pureCopper.RunicMinIntensity = 50;
                pureCopper.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo bronzeAlloy = BronzeAlloy = new CraftAttributeInfo();

			bronzeAlloy.ArmorPhysicalResist = 4;
			bronzeAlloy.ArmorColdResist = 3;
			bronzeAlloy.ArmorPoisonResist = 3;
			bronzeAlloy.ArmorEnergyResist = 3;
			bronzeAlloy.ArmorDurability = 50;
			bronzeAlloy.WeaponFireDamage = 10;
			bronzeAlloy.WeaponColdDamage = 20;
			bronzeAlloy.WeaponPoisonDamage = 10;
			bronzeAlloy.WeaponEnergyDamage = 20;
			bronzeAlloy.RunicMinAttributes = 5;
			bronzeAlloy.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                bronzeAlloy.RunicMinIntensity = 50;
                bronzeAlloy.RunicMaxIntensity = 100;
            }
            else
            {
                bronzeAlloy.RunicMinIntensity = 50;
                bronzeAlloy.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo shadow = Shadow = new CraftAttributeInfo();

			shadow.ArmorPhysicalResist = 4;
			shadow.ArmorColdResist = 3;
			shadow.ArmorPoisonResist = 3;
			shadow.ArmorEnergyResist = 3;
			shadow.ArmorDurability = 50;
			shadow.WeaponFireDamage = 10;
			shadow.WeaponColdDamage = 20;
			shadow.WeaponPoisonDamage = 10;
			shadow.WeaponEnergyDamage = 20;
			shadow.RunicMinAttributes = 5;
			shadow.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                shadow.RunicMinIntensity = 50;
                shadow.RunicMaxIntensity = 100;
            }
            else
            {
                shadow.RunicMinIntensity = 50;
                shadow.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo rose = Rose = new CraftAttributeInfo();

			rose.ArmorPhysicalResist = 4;
			rose.ArmorColdResist = 3;
			rose.ArmorPoisonResist = 3;
			rose.ArmorEnergyResist = 3;
			rose.ArmorDurability = 50;
			rose.WeaponFireDamage = 10;
			rose.WeaponColdDamage = 20;
			rose.WeaponPoisonDamage = 10;
			rose.WeaponEnergyDamage = 20;
			rose.RunicMinAttributes = 5;
			rose.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                rose.RunicMinIntensity = 50;
                rose.RunicMaxIntensity = 100;
            }
            else
            {
                rose.RunicMinIntensity = 50;
                rose.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo lime = Lime = new CraftAttributeInfo();

			lime.ArmorPhysicalResist = 4;
			lime.ArmorColdResist = 3;
			lime.ArmorPoisonResist = 3;
			lime.ArmorEnergyResist = 3;
			lime.ArmorDurability = 50;
			lime.WeaponFireDamage = 10;
			lime.WeaponColdDamage = 20;
			lime.WeaponPoisonDamage = 10;
			lime.WeaponEnergyDamage = 20;
			lime.RunicMinAttributes = 5;
			lime.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                lime.RunicMinIntensity = 50;
                lime.RunicMaxIntensity = 100;
            }
            else
            {
                lime.RunicMinIntensity = 50;
                lime.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo fuscia = Fuscia = new CraftAttributeInfo();

			fuscia.ArmorPhysicalResist = 4;
			fuscia.ArmorColdResist = 3;
			fuscia.ArmorPoisonResist = 3;
			fuscia.ArmorEnergyResist = 3;
			fuscia.ArmorDurability = 50;
			fuscia.WeaponFireDamage = 10;
			fuscia.WeaponColdDamage = 20;
			fuscia.WeaponPoisonDamage = 10;
			fuscia.WeaponEnergyDamage = 20;
			fuscia.RunicMinAttributes = 5;
			fuscia.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                fuscia.RunicMinIntensity = 50;
                fuscia.RunicMaxIntensity = 100;
            }
            else
            {
                fuscia.RunicMinIntensity = 50;
                fuscia.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo bloodrock = Bloodrock = new CraftAttributeInfo();

			bloodrock.ArmorPhysicalResist = 4;
			bloodrock.ArmorColdResist = 3;
			bloodrock.ArmorPoisonResist = 3;
			bloodrock.ArmorEnergyResist = 3;
			bloodrock.ArmorDurability = 50;
			bloodrock.WeaponFireDamage = 10;
			bloodrock.WeaponColdDamage = 20;
			bloodrock.WeaponPoisonDamage = 10;
			bloodrock.WeaponEnergyDamage = 20;
			bloodrock.RunicMinAttributes = 5;
			bloodrock.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                bloodrock.RunicMinIntensity = 50;
                bloodrock.RunicMaxIntensity = 100;
            }
            else
            {
                bloodrock.RunicMinIntensity = 50;
                bloodrock.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo chromeBlue = ChromeBlue = new CraftAttributeInfo();

			chromeBlue.ArmorPhysicalResist = 4;
			chromeBlue.ArmorColdResist = 3;
			chromeBlue.ArmorPoisonResist = 3;
			chromeBlue.ArmorEnergyResist = 3;
			chromeBlue.ArmorDurability = 50;
			chromeBlue.WeaponFireDamage = 10;
			chromeBlue.WeaponColdDamage = 20;
			chromeBlue.WeaponPoisonDamage = 10;
			chromeBlue.WeaponEnergyDamage = 20;
			chromeBlue.RunicMinAttributes = 5;
			chromeBlue.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                chromeBlue.RunicMinIntensity = 50;
                chromeBlue.RunicMaxIntensity = 100;
            }
            else
            {
                chromeBlue.RunicMinIntensity = 50;
                chromeBlue.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo chromeCopper = ChromeCopper = new CraftAttributeInfo();

			ChromeCopper.ArmorPhysicalResist = 4;
			ChromeCopper.ArmorColdResist = 3;
			ChromeCopper.ArmorPoisonResist = 3;
			ChromeCopper.ArmorEnergyResist = 3;
			ChromeCopper.ArmorDurability = 50;
			ChromeCopper.WeaponFireDamage = 10;
			ChromeCopper.WeaponColdDamage = 20;
			ChromeCopper.WeaponPoisonDamage = 10;
			ChromeCopper.WeaponEnergyDamage = 20;
			ChromeCopper.RunicMinAttributes = 5;
			ChromeCopper.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                ChromeCopper.RunicMinIntensity = 50;
                ChromeCopper.RunicMaxIntensity = 100;
            }
            else
            {
                ChromeCopper.RunicMinIntensity = 50;
                ChromeCopper.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo pansy = Pansy = new CraftAttributeInfo();

			pansy.ArmorPhysicalResist = 4;
			pansy.ArmorColdResist = 3;
			pansy.ArmorPoisonResist = 3;
			pansy.ArmorEnergyResist = 3;
			pansy.ArmorDurability = 50;
			pansy.WeaponFireDamage = 10;
			pansy.WeaponColdDamage = 20;
			pansy.WeaponPoisonDamage = 10;
			pansy.WeaponEnergyDamage = 20;
			pansy.RunicMinAttributes = 5;
			pansy.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                pansy.RunicMinIntensity = 50;
                pansy.RunicMaxIntensity = 100;
            }
            else
            {
                pansy.RunicMinIntensity = 50;
                pansy.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo stinger = Stinger = new CraftAttributeInfo();

			stinger.ArmorPhysicalResist = 4;
			stinger.ArmorColdResist = 3;
			stinger.ArmorPoisonResist = 3;
			stinger.ArmorEnergyResist = 3;
			stinger.ArmorDurability = 50;
			stinger.WeaponFireDamage = 10;
			stinger.WeaponColdDamage = 20;
			stinger.WeaponPoisonDamage = 10;
			stinger.WeaponEnergyDamage = 20;
			stinger.RunicMinAttributes = 5;
			stinger.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                stinger.RunicMinIntensity = 50;
                stinger.RunicMaxIntensity = 100;
            }
            else
            {
                stinger.RunicMinIntensity = 50;
                stinger.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo royal = Royal = new CraftAttributeInfo();

			royal.ArmorPhysicalResist = 4;
			royal.ArmorColdResist = 3;
			royal.ArmorPoisonResist = 3;
			royal.ArmorEnergyResist = 3;
			royal.ArmorDurability = 50;
			royal.WeaponFireDamage = 10;
			royal.WeaponColdDamage = 20;
			royal.WeaponPoisonDamage = 10;
			royal.WeaponEnergyDamage = 20;
			royal.RunicMinAttributes = 5;
			royal.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                royal.RunicMinIntensity = 50;
                royal.RunicMaxIntensity = 100;
            }
            else
            {
                royal.RunicMinIntensity = 50;
                royal.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo blueSteel = BlueSteel = new CraftAttributeInfo();

			blueSteel.ArmorPhysicalResist = 4;
			blueSteel.ArmorColdResist = 3;
			blueSteel.ArmorPoisonResist = 3;
			blueSteel.ArmorEnergyResist = 3;
			blueSteel.ArmorDurability = 50;
			blueSteel.WeaponFireDamage = 10;
			blueSteel.WeaponColdDamage = 20;
			blueSteel.WeaponPoisonDamage = 10;
			blueSteel.WeaponEnergyDamage = 20;
			blueSteel.RunicMinAttributes = 5;
			blueSteel.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                blueSteel.RunicMinIntensity = 50;
                blueSteel.RunicMaxIntensity = 100;
            }
            else
            {
                blueSteel.RunicMinIntensity = 50;
                blueSteel.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo ice = Ice = new CraftAttributeInfo();

			ice.ArmorPhysicalResist = 4;
			ice.ArmorColdResist = 3;
			ice.ArmorPoisonResist = 3;
			ice.ArmorEnergyResist = 3;
			ice.ArmorDurability = 50;
			ice.WeaponFireDamage = 10;
			ice.WeaponColdDamage = 20;
			ice.WeaponPoisonDamage = 10;
			ice.WeaponEnergyDamage = 20;
			ice.RunicMinAttributes = 5;
			ice.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                ice.RunicMinIntensity = 50;
                ice.RunicMaxIntensity = 100;
            }
            else
            {
                ice.RunicMinIntensity = 50;
                ice.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo lemon = Lemon = new CraftAttributeInfo();

			lemon.ArmorPhysicalResist = 4;
			lemon.ArmorColdResist = 3;
			lemon.ArmorPoisonResist = 3;
			lemon.ArmorEnergyResist = 3;
			lemon.ArmorDurability = 50;
			lemon.WeaponFireDamage = 10;
			lemon.WeaponColdDamage = 20;
			lemon.WeaponPoisonDamage = 10;
			lemon.WeaponEnergyDamage = 20;
			lemon.RunicMinAttributes = 5;
			lemon.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                lemon.RunicMinIntensity = 50;
                lemon.RunicMaxIntensity = 100;
            }
            else
            {
                lemon.RunicMinIntensity = 50;
                lemon.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo blackrock = Blackrock = new CraftAttributeInfo();

			blackrock.ArmorPhysicalResist = 4;
			blackrock.ArmorColdResist = 3;
			blackrock.ArmorPoisonResist = 3;
			blackrock.ArmorEnergyResist = 3;
			blackrock.ArmorDurability = 50;
			blackrock.WeaponFireDamage = 10;
			blackrock.WeaponColdDamage = 20;
			blackrock.WeaponPoisonDamage = 10;
			blackrock.WeaponEnergyDamage = 20;
			blackrock.RunicMinAttributes = 5;
			blackrock.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                blackrock.RunicMinIntensity = 50;
                blackrock.RunicMaxIntensity = 100;
            }
            else
            {
                blackrock.RunicMinIntensity = 50;
                blackrock.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo roseQuartz = RoseQuartz = new CraftAttributeInfo();

			roseQuartz.ArmorPhysicalResist = 4;
			roseQuartz.ArmorColdResist = 3;
			roseQuartz.ArmorPoisonResist = 3;
			roseQuartz.ArmorEnergyResist = 3;
			roseQuartz.ArmorDurability = 50;
			roseQuartz.WeaponFireDamage = 10;
			roseQuartz.WeaponColdDamage = 20;
			roseQuartz.WeaponPoisonDamage = 10;
			roseQuartz.WeaponEnergyDamage = 20;
			roseQuartz.RunicMinAttributes = 5;
			roseQuartz.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                roseQuartz.RunicMinIntensity = 50;
                roseQuartz.RunicMaxIntensity = 100;
            }
            else
            {
                roseQuartz.RunicMinIntensity = 50;
                roseQuartz.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo mint = Mint = new CraftAttributeInfo();

			mint.ArmorPhysicalResist = 4;
			mint.ArmorColdResist = 3;
			mint.ArmorPoisonResist = 3;
			mint.ArmorEnergyResist = 3;
			mint.ArmorDurability = 50;
			mint.WeaponFireDamage = 10;
			mint.WeaponColdDamage = 20;
			mint.WeaponPoisonDamage = 10;
			mint.WeaponEnergyDamage = 20;
			mint.RunicMinAttributes = 5;
			mint.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                mint.RunicMinIntensity = 50;
                mint.RunicMaxIntensity = 100;
            }
            else
            {
                mint.RunicMinIntensity = 50;
                mint.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo aqua = Aqua = new CraftAttributeInfo();

			aqua.ArmorPhysicalResist = 4;
			aqua.ArmorColdResist = 3;
			aqua.ArmorPoisonResist = 3;
			aqua.ArmorEnergyResist = 3;
			aqua.ArmorDurability = 50;
			aqua.WeaponFireDamage = 10;
			aqua.WeaponColdDamage = 20;
			aqua.WeaponPoisonDamage = 10;
			aqua.WeaponEnergyDamage = 20;
			aqua.RunicMinAttributes = 5;
			aqua.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                aqua.RunicMinIntensity = 50;
                aqua.RunicMaxIntensity = 100;
            }
            else
            {
                aqua.RunicMinIntensity = 50;
                aqua.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo daemon = Daemon = new CraftAttributeInfo();

			daemon.ArmorPhysicalResist = 4;
			daemon.ArmorColdResist = 3;
			daemon.ArmorPoisonResist = 3;
			daemon.ArmorEnergyResist = 3;
			daemon.ArmorDurability = 50;
			daemon.WeaponFireDamage = 10;
			daemon.WeaponColdDamage = 20;
			daemon.WeaponPoisonDamage = 10;
			daemon.WeaponEnergyDamage = 20;
			daemon.RunicMinAttributes = 5;
			daemon.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                daemon.RunicMinIntensity = 50;
                daemon.RunicMaxIntensity = 100;
            }
            else
            {
                daemon.RunicMinIntensity = 50;
                daemon.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo mythril = Mythril = new CraftAttributeInfo();

			mythril.ArmorPhysicalResist = 4;
			mythril.ArmorColdResist = 3;
			mythril.ArmorPoisonResist = 3;
			mythril.ArmorEnergyResist = 3;
			mythril.ArmorDurability = 50;
			mythril.WeaponFireDamage = 10;
			mythril.WeaponColdDamage = 20;
			mythril.WeaponPoisonDamage = 10;
			mythril.WeaponEnergyDamage = 20;
			mythril.RunicMinAttributes = 5;
			mythril.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                mythril.RunicMinIntensity = 50;
                mythril.RunicMaxIntensity = 100;
            }
            else
            {
                mythril.RunicMinIntensity = 50;
                mythril.RunicMaxIntensity = 100;
            }

 
			CraftAttributeInfo titanium = Titanium = new CraftAttributeInfo();

			titanium.ArmorPhysicalResist = 4;
			titanium.ArmorColdResist = 3;
			titanium.ArmorPoisonResist = 3;
			titanium.ArmorEnergyResist = 3;
			titanium.ArmorDurability = 50;
			titanium.WeaponFireDamage = 10;
			titanium.WeaponColdDamage = 20;
			titanium.WeaponPoisonDamage = 10;
			titanium.WeaponEnergyDamage = 20;
			titanium.RunicMinAttributes = 5;
			titanium.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                titanium.RunicMinIntensity = 50;
                titanium.RunicMaxIntensity = 100;
            }
            else
            {
                titanium.RunicMinIntensity = 50;
                titanium.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo kryptonite = Kryptonite = new CraftAttributeInfo();

			kryptonite.ArmorPhysicalResist = 4;
			kryptonite.ArmorColdResist = 3;
			kryptonite.ArmorPoisonResist = 3;
			kryptonite.ArmorEnergyResist = 3;
			kryptonite.ArmorDurability = 50;
			kryptonite.WeaponFireDamage = 10;
			kryptonite.WeaponColdDamage = 20;
			kryptonite.WeaponPoisonDamage = 10;
			kryptonite.WeaponEnergyDamage = 20;
			kryptonite.RunicMinAttributes = 5;
			kryptonite.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                kryptonite.RunicMinIntensity = 50;
                kryptonite.RunicMaxIntensity = 100;
            }
            else
            {
                kryptonite.RunicMinIntensity = 50;
                kryptonite.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo diamond = Diamond = new CraftAttributeInfo();

			diamond.ArmorPhysicalResist = 4;
			diamond.ArmorColdResist = 3;
			diamond.ArmorPoisonResist = 3;
			diamond.ArmorEnergyResist = 3;
			diamond.ArmorDurability = 50;
			diamond.WeaponFireDamage = 10;
			diamond.WeaponColdDamage = 20;
			diamond.WeaponPoisonDamage = 10;
			diamond.WeaponEnergyDamage = 20;
			diamond.RunicMinAttributes = 5;
			diamond.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                diamond.RunicMinIntensity = 50;
                diamond.RunicMaxIntensity = 100;
            }
            else
            {
                diamond.RunicMinIntensity = 50;
                diamond.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo jolt = Jolt = new CraftAttributeInfo();

			jolt.ArmorPhysicalResist = 4;
			jolt.ArmorColdResist = 3;
			jolt.ArmorPoisonResist = 3;
			jolt.ArmorEnergyResist = 3;
			jolt.ArmorDurability = 50;
			jolt.WeaponFireDamage = 10;
			jolt.WeaponColdDamage = 20;
			jolt.WeaponPoisonDamage = 10;
			jolt.WeaponEnergyDamage = 20;
			jolt.RunicMinAttributes = 5;
			jolt.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                jolt.RunicMinIntensity = 50;
                jolt.RunicMaxIntensity = 100;
            }
            else
            {
                jolt.RunicMinIntensity = 50;
                jolt.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo uranium = Uranium = new CraftAttributeInfo();

			uranium.ArmorPhysicalResist = 4;
			uranium.ArmorColdResist = 3;
			uranium.ArmorPoisonResist = 3;
			uranium.ArmorEnergyResist = 3;
			uranium.ArmorDurability = 50;
			uranium.WeaponFireDamage = 10;
			uranium.WeaponColdDamage = 20;
			uranium.WeaponPoisonDamage = 10;
			uranium.WeaponEnergyDamage = 20;
			uranium.RunicMinAttributes = 5;
			uranium.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                uranium.RunicMinIntensity = 50;
                uranium.RunicMaxIntensity = 100;
            }
            else
            {
                uranium.RunicMinIntensity = 50;
                uranium.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo opiate = Opiate = new CraftAttributeInfo();

			opiate.ArmorPhysicalResist = 4;
			opiate.ArmorColdResist = 3;
			opiate.ArmorPoisonResist = 3;
			opiate.ArmorEnergyResist = 3;
			opiate.ArmorDurability = 50;
			opiate.WeaponFireDamage = 10;
			opiate.WeaponColdDamage = 20;
			opiate.WeaponPoisonDamage = 10;
			opiate.WeaponEnergyDamage = 20;
			opiate.RunicMinAttributes = 5;
			opiate.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                opiate.RunicMinIntensity = 50;
                opiate.RunicMaxIntensity = 100;
            }
            else
            {
                opiate.RunicMinIntensity = 50;
                opiate.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo negative = Negative = new CraftAttributeInfo();

			negative.ArmorPhysicalResist = 4;
			negative.ArmorColdResist = 3;
			negative.ArmorPoisonResist = 3;
			negative.ArmorEnergyResist = 3;
			negative.ArmorDurability = 50;
			negative.WeaponFireDamage = 10;
			negative.WeaponColdDamage = 20;
			negative.WeaponPoisonDamage = 10;
			negative.WeaponEnergyDamage = 20;
			negative.RunicMinAttributes = 5;
			negative.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                negative.RunicMinIntensity = 50;
                negative.RunicMaxIntensity = 100;
            }
            else
            {
                negative.RunicMinIntensity = 50;
                negative.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo deus = Deus = new CraftAttributeInfo();

			deus.ArmorPhysicalResist = 4;
			deus.ArmorColdResist = 3;
			deus.ArmorPoisonResist = 3;
			deus.ArmorEnergyResist = 3;
			deus.ArmorDurability = 50;
			deus.WeaponFireDamage = 10;
			deus.WeaponColdDamage = 20;
			deus.WeaponPoisonDamage = 10;
			deus.WeaponEnergyDamage = 20;
			deus.RunicMinAttributes = 5;
			deus.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                deus.RunicMinIntensity = 50;
                deus.RunicMaxIntensity = 100;
            }
            else
            {
                deus.RunicMinIntensity = 50;
                deus.RunicMaxIntensity = 100;
            }
 
			CraftAttributeInfo darkDeus = DarkDeus = new CraftAttributeInfo();

			darkDeus.ArmorPhysicalResist = 4;
			darkDeus.ArmorColdResist = 3;
			darkDeus.ArmorPoisonResist = 3;
			darkDeus.ArmorEnergyResist = 3;
			darkDeus.ArmorDurability = 50;
			darkDeus.WeaponFireDamage = 10;
			darkDeus.WeaponColdDamage = 20;
			darkDeus.WeaponPoisonDamage = 10;
			darkDeus.WeaponEnergyDamage = 20;
			darkDeus.RunicMinAttributes = 5;
			darkDeus.RunicMaxAttributes = 5;
			if ( Core.ML )
            {
                darkDeus.RunicMinIntensity = 50;
                darkDeus.RunicMaxIntensity = 100;
            }
            else
            {
                darkDeus.RunicMinIntensity = 50;
                darkDeus.RunicMaxIntensity = 100;
            }

			
			CraftAttributeInfo spined = Spined = new CraftAttributeInfo();

			spined.ArmorPhysicalResist = 5;
			spined.ArmorLuck = 40;
			spined.RunicMinAttributes = 1;
			spined.RunicMaxAttributes = 3;
			if ( Core.ML )
			{
				spined.RunicMinIntensity = 40;
				spined.RunicMaxIntensity = 100;
			}
			else
			{
				spined.RunicMinIntensity = 20;
				spined.RunicMaxIntensity = 40;
			}

			CraftAttributeInfo horned = Horned = new CraftAttributeInfo();

			horned.ArmorPhysicalResist = 2;
			horned.ArmorFireResist = 3;
			horned.ArmorColdResist = 2;
			horned.ArmorPoisonResist = 2;
			horned.ArmorEnergyResist = 2;
			horned.RunicMinAttributes = 3;
			horned.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				horned.RunicMinIntensity = 45;
				horned.RunicMaxIntensity = 100;
			}
			else
			{
				horned.RunicMinIntensity = 30;
				horned.RunicMaxIntensity = 70;
			}

			CraftAttributeInfo barbed = Barbed = new CraftAttributeInfo();

			barbed.ArmorPhysicalResist = 2;
			barbed.ArmorFireResist = 1;
			barbed.ArmorColdResist = 2;
			barbed.ArmorPoisonResist = 3;
			barbed.ArmorEnergyResist = 4;
			barbed.RunicMinAttributes = 4;
			barbed.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				barbed.RunicMinIntensity = 50;
				barbed.RunicMaxIntensity = 100;
			}
			else
			{
				barbed.RunicMinIntensity = 40;
				barbed.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo red = RedScales = new CraftAttributeInfo();

			red.ArmorFireResist = 10;
			red.ArmorColdResist = -3;

			CraftAttributeInfo yellow = YellowScales = new CraftAttributeInfo();

			yellow.ArmorPhysicalResist = -3;
			yellow.ArmorLuck = 20;

			CraftAttributeInfo black = BlackScales = new CraftAttributeInfo();

			black.ArmorPhysicalResist = 10;
			black.ArmorEnergyResist = -3;

			CraftAttributeInfo green = GreenScales = new CraftAttributeInfo();

			green.ArmorFireResist = -3;
			green.ArmorPoisonResist = 10;

			CraftAttributeInfo white = WhiteScales = new CraftAttributeInfo();

			white.ArmorPhysicalResist = -3;
			white.ArmorColdResist = 10;

			CraftAttributeInfo blue = BlueScales = new CraftAttributeInfo();

			blue.ArmorPoisonResist = -3;
			blue.ArmorEnergyResist = 10;

			//public static readonly CraftAttributeInfo OakWood, AshWood, YewWood, Heartwood, Bloodwood, Frostwood;

			CraftAttributeInfo oak = OakWood = new CraftAttributeInfo();

			CraftAttributeInfo ash = AshWood = new CraftAttributeInfo();

			CraftAttributeInfo yew = YewWood = new CraftAttributeInfo();

			CraftAttributeInfo heart = Heartwood = new CraftAttributeInfo();

			CraftAttributeInfo blood = Bloodwood = new CraftAttributeInfo();

			CraftAttributeInfo frost = Frostwood = new CraftAttributeInfo();
		}
	}

	public class CraftResourceInfo
	{
		private int m_Hue;
		private int m_Number;
		private string m_Name;
		private CraftAttributeInfo m_AttributeInfo;
		private CraftResource m_Resource;
		private Type[] m_ResourceTypes;

		public int Hue{ get{ return m_Hue; } }
		public int Number{ get{ return m_Number; } }
		public string Name{ get{ return m_Name; } }
		public CraftAttributeInfo AttributeInfo{ get{ return m_AttributeInfo; } }
		public CraftResource Resource{ get{ return m_Resource; } }
		public Type[] ResourceTypes{ get{ return m_ResourceTypes; } }

		public CraftResourceInfo( int hue, int number, string name, CraftAttributeInfo attributeInfo, CraftResource resource, params Type[] resourceTypes )
		{
			m_Hue = hue;
			m_Number = number;
			m_Name = name;
			m_AttributeInfo = attributeInfo;
			m_Resource = resource;
			m_ResourceTypes = resourceTypes;

			for ( int i = 0; i < resourceTypes.Length; ++i )
				CraftResources.RegisterType( resourceTypes[i], resource );
		}
	}

	public class CraftResources
	{
		private static CraftResourceInfo[] m_MetalInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1053109, "Iron",			CraftAttributeInfo.Blank,		CraftResource.Iron,				typeof( IronIngot ),		typeof( IronOre ),			typeof( Granite ) ),
				new CraftResourceInfo( 0x973, 1053108, "Dull Copper",	CraftAttributeInfo.DullCopper,	CraftResource.DullCopper,		typeof( DullCopperIngot ),	typeof( DullCopperOre ),	typeof( DullCopperGranite ) ),
				new CraftResourceInfo( 0x966, 1053107, "Shadow Iron",	CraftAttributeInfo.ShadowIron,	CraftResource.ShadowIron,		typeof( ShadowIronIngot ),	typeof( ShadowIronOre ),	typeof( ShadowIronGranite ) ),
				new CraftResourceInfo( 0x96D, 1053106, "Copper",		CraftAttributeInfo.Copper,		CraftResource.Copper,			typeof( CopperIngot ),		typeof( CopperOre ),		typeof( CopperGranite ) ),
				new CraftResourceInfo( 0x972, 1053105, "Bronze",		CraftAttributeInfo.Bronze,		CraftResource.Bronze,			typeof( BronzeIngot ),		typeof( BronzeOre ),		typeof( BronzeGranite ) ),
				new CraftResourceInfo( 0x8A5, 1053104, "Gold",			CraftAttributeInfo.Golden,		CraftResource.Gold,				typeof( GoldIngot ),		typeof( GoldOre ),			typeof( GoldGranite ) ),
				new CraftResourceInfo( 0x979, 1053103, "Agapite",		CraftAttributeInfo.Agapite,		CraftResource.Agapite,			typeof( AgapiteIngot ),		typeof( AgapiteOre ),		typeof( AgapiteGranite ) ),
				new CraftResourceInfo( 0x89F, 1053102, "Verite",		CraftAttributeInfo.Verite,		CraftResource.Verite,			typeof( VeriteIngot ),		typeof( VeriteOre ),		typeof( VeriteGranite ) ),
				new CraftResourceInfo( 0x8AB, 1053101, "Valorite",		CraftAttributeInfo.Valorite,	CraftResource.Valorite,			typeof( ValoriteIngot ),	typeof( ValoriteOre ),		typeof( ValoriteGranite ) ),
				//New Ores: "06/02/2013" - Giel
				new CraftResourceInfo( 0x8AB, 0,"Rusty",				CraftAttributeInfo.Rusty,		CraftResource.Rusty,			typeof( RustyIngot ),		typeof( RustyOre ),			typeof( RustyGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Silver",				CraftAttributeInfo.Silver,		CraftResource.Silver,			typeof( SilverIngot ),		typeof( SilverOre ),		typeof( SilverGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Pure Copper",			CraftAttributeInfo.PureCopper,	CraftResource.PureCopper,		typeof( PureCopperIngot ),	typeof( PureCopperOre ),	typeof( PureCopperGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Bronze Alloy",			CraftAttributeInfo.BronzeAlloy,	CraftResource.BronzeAlloy,		typeof( BronzeAlloyIngot ),	typeof( BronzeAlloyOre ),	typeof( BronzeAlloyGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Shadow",				CraftAttributeInfo.Shadow,		CraftResource.Shadow,			typeof( ShadowIngot ),		typeof( ShadowOre ),		typeof( ShadowGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Rose",					CraftAttributeInfo.Rose,		CraftResource.Rose,				typeof( RoseIngot ),		typeof( RoseOre ),			typeof( RoseGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Lime",					CraftAttributeInfo.Lime,		CraftResource.Lime,				typeof( LimeIngot ),		typeof( LimeOre ),			typeof( LimeGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Fuscia",				CraftAttributeInfo.Fuscia,		CraftResource.Fuscia,			typeof( FusciaIngot ),		typeof( FusciaOre ),		typeof( FusciaGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Bloodrock",			CraftAttributeInfo.Bloodrock,	CraftResource.Bloodrock,		typeof( BloodrockIngot ),	typeof( BloodrockOre ),		typeof( BloodrockGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Chrome Blue",			CraftAttributeInfo.ChromeBlue,	CraftResource.ChromeBlue,		typeof( ChromeBlueIngot ),	typeof( ChromeBlueOre ),	typeof( ChromeBlueGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Chrome Copper",		CraftAttributeInfo.ChromeCopper,CraftResource.ChromeCopper,		typeof( ChromeCopperIngot ),typeof( ChromeCopperOre ),	typeof( ChromeCopperGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Pansy",				CraftAttributeInfo.Pansy,		CraftResource.Pansy,			typeof( PansyIngot ),		typeof( PansyOre ),			typeof( PansyGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Stinger",				CraftAttributeInfo.Stinger,		CraftResource.Stinger,			typeof( StingerIngot ),		typeof( StingerOre ),		typeof( StingerGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Royal",				CraftAttributeInfo.Royal,		CraftResource.Royal,			typeof( RoyalIngot ),		typeof( RoyalOre ),			typeof( RoyalGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Blue Steel",			CraftAttributeInfo.BlueSteel,	CraftResource.BlueSteel,		typeof( BlueSteelIngot ),	typeof( BlueSteelOre ),		typeof( BlueSteelGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Ice",					CraftAttributeInfo.Ice,			CraftResource.Ice,				typeof( IceIngot ),			typeof( IceOre ),			typeof( IceGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Lemon",				CraftAttributeInfo.Lemon,		CraftResource.Lemon,			typeof( LemonIngot ),		typeof( LemonOre ),			typeof( LemonGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Blackrock",			CraftAttributeInfo.Blackrock,	CraftResource.Blackrock,		typeof( BlackrockIngot ),	typeof( BlackrockOre ),		typeof( BlackrockGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Rose Quartz",			CraftAttributeInfo.RoseQuartz,	CraftResource.RoseQuartz,		typeof( RoseQuartzIngot ),	typeof( RoseQuartzOre ),	typeof( RoseQuartzGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Mint",					CraftAttributeInfo.Mint,		CraftResource.Mint,				typeof( MintIngot ),		typeof( MintOre ),			typeof( MintGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Aqua",					CraftAttributeInfo.Aqua,		CraftResource.Aqua,				typeof( AquaIngot ),		typeof( AquaOre ),			typeof( AquaGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Daemon",				CraftAttributeInfo.Daemon,		CraftResource.Daemon,			typeof( DaemonIngot ),		typeof( DaemonOre ),		typeof( DaemonGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Mythril",				CraftAttributeInfo.Mythril,		CraftResource.Mythril,			typeof( MythrilIngot ),		typeof( MythrilOre ),		typeof( MythrilGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Titanium",				CraftAttributeInfo.Titanium,	CraftResource.Titanium,			typeof( TitaniumIngot ),	typeof( TitaniumOre ),		typeof( TitaniumGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Kryptonite",			CraftAttributeInfo.Kryptonite,	CraftResource.Kryptonite,		typeof( KryptoniteIngot ),	typeof( KryptoniteOre ),	typeof( KryptoniteGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Diamond",				CraftAttributeInfo.Diamond,		CraftResource.Diamond,			typeof( DiamondIngot ),		typeof( DiamondOre ),		typeof( DiamondGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Jolt",					CraftAttributeInfo.Jolt,		CraftResource.Jolt,				typeof( JoltIngot ),		typeof( JoltOre ),			typeof( JoltGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Uranium",				CraftAttributeInfo.Uranium,		CraftResource.Uranium,			typeof( UraniumIngot ),		typeof( UraniumOre ),		typeof( UraniumGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Opiate",				CraftAttributeInfo.Opiate,		CraftResource.Opiate,			typeof( OpiateIngot ),		typeof( OpiateOre ),		typeof( OpiateGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Negative",				CraftAttributeInfo.Negative,	CraftResource.Negative,			typeof( NegativeIngot ),	typeof( NegativeOre ),		typeof( NegativeGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Deus",					CraftAttributeInfo.Deus,		CraftResource.Deus,				typeof( DeusIngot ),		typeof( DeusOre ),			typeof( DeusGranite ) ),
				new CraftResourceInfo( 0x8AB, 0,"Dark Deus",			CraftAttributeInfo.DarkDeus,	CraftResource.DarkDeus,			typeof( DarkDeusIngot ),	typeof( DarkDeusOre ),		typeof( DarkDeusGranite ) ),

			};

		private static CraftResourceInfo[] m_ScaleInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x66D, 1053129, "Red Scales",	CraftAttributeInfo.RedScales,		CraftResource.RedScales,		typeof( RedScales ) ),
				new CraftResourceInfo( 0x8A8, 1053130, "Yellow Scales",	CraftAttributeInfo.YellowScales,	CraftResource.YellowScales,		typeof( YellowScales ) ),
				new CraftResourceInfo( 0x455, 1053131, "Black Scales",	CraftAttributeInfo.BlackScales,		CraftResource.BlackScales,		typeof( BlackScales ) ),
				new CraftResourceInfo( 0x851, 1053132, "Green Scales",	CraftAttributeInfo.GreenScales,		CraftResource.GreenScales,		typeof( GreenScales ) ),
				new CraftResourceInfo( 0x8FD, 1053133, "White Scales",	CraftAttributeInfo.WhiteScales,		CraftResource.WhiteScales,		typeof( WhiteScales ) ),
				new CraftResourceInfo( 0x8B0, 1053134, "Blue Scales",	CraftAttributeInfo.BlueScales,		CraftResource.BlueScales,		typeof( BlueScales ) )
			};

		private static CraftResourceInfo[] m_LeatherInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal",		CraftAttributeInfo.Blank,		CraftResource.RegularLeather,	typeof( Leather ),			typeof( Hides ) ),
				new CraftResourceInfo( 0x283, 1049354, "Spined",		CraftAttributeInfo.Spined,		CraftResource.SpinedLeather,	typeof( SpinedLeather ),	typeof( SpinedHides ) ),
				new CraftResourceInfo( 0x227, 1049355, "Horned",		CraftAttributeInfo.Horned,		CraftResource.HornedLeather,	typeof( HornedLeather ),	typeof( HornedHides ) ),
				new CraftResourceInfo( 0x1C1, 1049356, "Barbed",		CraftAttributeInfo.Barbed,		CraftResource.BarbedLeather,	typeof( BarbedLeather ),	typeof( BarbedHides ) )
			};

		private static CraftResourceInfo[] m_AOSLeatherInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal",		CraftAttributeInfo.Blank,		CraftResource.RegularLeather,	typeof( Leather ),			typeof( Hides ) ),
				new CraftResourceInfo( 0x8AC, 1049354, "Spined",		CraftAttributeInfo.Spined,		CraftResource.SpinedLeather,	typeof( SpinedLeather ),	typeof( SpinedHides ) ),
				new CraftResourceInfo( 0x845, 1049355, "Horned",		CraftAttributeInfo.Horned,		CraftResource.HornedLeather,	typeof( HornedLeather ),	typeof( HornedHides ) ),
				new CraftResourceInfo( 0x851, 1049356, "Barbed",		CraftAttributeInfo.Barbed,		CraftResource.BarbedLeather,	typeof( BarbedLeather ),	typeof( BarbedHides ) ),
			};

		private static CraftResourceInfo[] m_WoodInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1011542, "Normal",		CraftAttributeInfo.Blank,		CraftResource.RegularWood,	typeof( Log ),			typeof( Board ) ),
				new CraftResourceInfo( 0x7DA, 1072533, "Oak",			CraftAttributeInfo.OakWood,		CraftResource.OakWood,		typeof( OakLog ),		typeof( OakBoard ) ),
				new CraftResourceInfo( 0x4A7, 1072534, "Ash",			CraftAttributeInfo.AshWood,		CraftResource.AshWood,		typeof( AshLog ),		typeof( AshBoard ) ),
				new CraftResourceInfo( 0x4A8, 1072535, "Yew",			CraftAttributeInfo.YewWood,		CraftResource.YewWood,		typeof( YewLog ),		typeof( YewBoard ) ),
				new CraftResourceInfo( 0x4A9, 1072536, "Heartwood",		CraftAttributeInfo.Heartwood,	CraftResource.Heartwood,	typeof( HeartwoodLog ),	typeof( HeartwoodBoard ) ),
				new CraftResourceInfo( 0x4AA, 1072538, "Bloodwood",		CraftAttributeInfo.Bloodwood,	CraftResource.Bloodwood,	typeof( BloodwoodLog ),	typeof( BloodwoodBoard ) ),
				new CraftResourceInfo( 0x47F, 1072539, "Frostwood",		CraftAttributeInfo.Frostwood,	CraftResource.Frostwood,	typeof( FrostwoodLog ),	typeof( FrostwoodBoard ) )
			};

		/// <summary>
		/// Returns true if '<paramref name="resource"/>' is None, Iron, RegularLeather or RegularWood. False if otherwise.
		/// </summary>
		public static bool IsStandard( CraftResource resource )
		{
			return ( resource == CraftResource.None || resource == CraftResource.Iron || resource == CraftResource.RegularLeather || resource == CraftResource.RegularWood );
		}

		private static Hashtable m_TypeTable;

		/// <summary>
		/// Registers that '<paramref name="resourceType"/>' uses '<paramref name="resource"/>' so that it can later be queried by <see cref="CraftResources.GetFromType"/>
		/// </summary>
		public static void RegisterType( Type resourceType, CraftResource resource )
		{
			if ( m_TypeTable == null )
				m_TypeTable = new Hashtable();

			m_TypeTable[resourceType] = resource;
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value for which '<paramref name="resourceType"/>' uses -or- CraftResource.None if an unregistered type was specified.
		/// </summary>
		public static CraftResource GetFromType( Type resourceType )
		{
			if ( m_TypeTable == null )
				return CraftResource.None;

			object obj = m_TypeTable[resourceType];

			if ( !(obj is CraftResource) )
				return CraftResource.None;

			return (CraftResource)obj;
		}

		/// <summary>
		/// Returns a <see cref="CraftResourceInfo"/> instance describing '<paramref name="resource"/>' -or- null if an invalid resource was specified.
		/// </summary>
		public static CraftResourceInfo GetInfo( CraftResource resource )
		{
			CraftResourceInfo[] list = null;

			switch ( GetType( resource ) )
			{
				case CraftResourceType.Metal: list = m_MetalInfo; break;
				case CraftResourceType.Leather: list = Core.AOS ? m_AOSLeatherInfo : m_LeatherInfo; break;
				case CraftResourceType.Scales: list = m_ScaleInfo; break;
				case CraftResourceType.Wood: list = m_WoodInfo; break;
			}

			if ( list != null )
			{
				int index = GetIndex( resource );

				if ( index >= 0 && index < list.Length )
					return list[index];
			}

			return null;
		}

		/// <summary>
		/// Returns a <see cref="CraftResourceType"/> value indiciating the type of '<paramref name="resource"/>'.
		/// </summary>
		public static CraftResourceType GetType( CraftResource resource )
		{
			if ( resource >= CraftResource.Iron && resource <= CraftResource.DarkDeus  )
				return CraftResourceType.Metal;

			if ( resource >= CraftResource.RegularLeather && resource <= CraftResource.BarbedLeather )
				return CraftResourceType.Leather;

			if ( resource >= CraftResource.RedScales && resource <= CraftResource.BlueScales )
				return CraftResourceType.Scales;

			if ( resource >= CraftResource.RegularWood && resource <= CraftResource.Frostwood )
				return CraftResourceType.Wood;

			return CraftResourceType.None;
		}

		/// <summary>
		/// Returns the first <see cref="CraftResource"/> in the series of resources for which '<paramref name="resource"/>' belongs.
		/// </summary>
		public static CraftResource GetStart( CraftResource resource )
		{
			switch ( GetType( resource ) )
			{
				case CraftResourceType.Metal: return CraftResource.Iron;
				case CraftResourceType.Leather: return CraftResource.RegularLeather;
				case CraftResourceType.Scales: return CraftResource.RedScales;
				case CraftResourceType.Wood: return CraftResource.RegularWood;
			}

			return CraftResource.None;
		}

		/// <summary>
		/// Returns the index of '<paramref name="resource"/>' in the seriest of resources for which it belongs.
		/// </summary>
		public static int GetIndex( CraftResource resource )
		{
			CraftResource start = GetStart( resource );

			if ( start == CraftResource.None )
				return 0;

			return (int)(resource - start);
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Number"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
		/// </summary>
		public static int GetLocalizationNumber( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Number );
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Hue"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
		/// </summary>
		public static int GetHue( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Hue );
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Name"/> property of '<paramref name="resource"/>' -or- an empty string if the resource specified was invalid.
		/// </summary>
		public static string GetName( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? String.Empty : info.Name );
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>' -or- CraftResource.None if unable to convert.
		/// </summary>
		public static CraftResource GetFromOreInfo( OreInfo info )
		{
			if ( info.Name.IndexOf( "Spined" ) >= 0 )
				return CraftResource.SpinedLeather;
			else if ( info.Name.IndexOf( "Horned" ) >= 0 )
				return CraftResource.HornedLeather;
			else if ( info.Name.IndexOf( "Barbed" ) >= 0 )
				return CraftResource.BarbedLeather;
			else if ( info.Name.IndexOf( "Leather" ) >= 0 )
				return CraftResource.RegularLeather;

			if ( info.Level == 0 )
				return CraftResource.Iron;
			else if ( info.Level == 1 )
				return CraftResource.DullCopper;
			else if ( info.Level == 2 )
				return CraftResource.ShadowIron;
			else if ( info.Level == 3 )
				return CraftResource.Copper;
			else if ( info.Level == 4 )
				return CraftResource.Bronze;
			else if ( info.Level == 5 )
				return CraftResource.Gold;
			else if ( info.Level == 6 )
				return CraftResource.Agapite;
			else if ( info.Level == 7 )
				return CraftResource.Verite;
			else if ( info.Level == 8 )
				return CraftResource.Valorite;
			else if ( info.Level == 9)
				return CraftResource.Rusty;
			else if ( info.Level == 10)
				return CraftResource.Silver;
			else if ( info.Level == 11)
				return CraftResource.PureCopper;
			else if ( info.Level == 12)
				return CraftResource.BronzeAlloy;
			else if ( info.Level == 13)
				return CraftResource.Shadow;
			else if ( info.Level == 14)
				return CraftResource.Rose;
			else if ( info.Level == 15)
				return CraftResource.Lime;
			else if ( info.Level == 16)
				return CraftResource.Fuscia;
			else if ( info.Level == 17)
				return CraftResource.Bloodrock;
			else if ( info.Level == 18)
				return CraftResource.ChromeBlue;
			else if ( info.Level == 19)
				return CraftResource.ChromeCopper;
			else if ( info.Level == 20)
				return CraftResource.Pansy;
			else if ( info.Level == 21)
				return CraftResource.Stinger;
			else if ( info.Level == 22)
				return CraftResource.Royal;
			else if ( info.Level == 23)
				return CraftResource.BlueSteel;
			else if ( info.Level == 24)
				return CraftResource.Ice;
			else if ( info.Level == 25)
				return CraftResource.Lemon;
			else if ( info.Level == 26)
				return CraftResource.Blackrock;
			else if ( info.Level == 27)
				return CraftResource.RoseQuartz;
			else if ( info.Level == 28)
				return CraftResource.Mint;
			else if ( info.Level == 29)
				return CraftResource.Aqua;
			else if ( info.Level == 30)
				return CraftResource.Daemon;
			else if ( info.Level == 31)
				return CraftResource.Mythril;
			else if ( info.Level == 32)
				return CraftResource.Titanium;
			else if ( info.Level == 33)
				return CraftResource.Kryptonite;
			else if ( info.Level == 34)
				return CraftResource.Diamond;
			else if ( info.Level == 35)
				return CraftResource.Jolt;
			else if ( info.Level == 36)
				return CraftResource.Uranium;
			else if ( info.Level == 37)
				return CraftResource.Opiate;
			else if ( info.Level == 38)
				return CraftResource.Negative;
			else if ( info.Level == 39)
				return CraftResource.Deus;
			else if ( info.Level == 40)
				return CraftResource.DarkDeus;

			return CraftResource.None;
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>', using '<paramref name="material"/>' to help resolve leather OreInfo instances.
		/// </summary>
		public static CraftResource GetFromOreInfo( OreInfo info, ArmorMaterialType material )
		{
			if ( material == ArmorMaterialType.Studded || material == ArmorMaterialType.Leather || material == ArmorMaterialType.Spined ||
				material == ArmorMaterialType.Horned || material == ArmorMaterialType.Barbed )
			{
				if ( info.Level == 0 )
					return CraftResource.RegularLeather;
				else if ( info.Level == 1 )
					return CraftResource.SpinedLeather;
				else if ( info.Level == 2 )
					return CraftResource.HornedLeather;
				else if ( info.Level == 3 )
					return CraftResource.BarbedLeather;

				return CraftResource.None;
			}

			return GetFromOreInfo( info );
		}
	}

	// NOTE: This class is only for compatability with very old RunUO versions.
	// No changes to it should be required for custom resources.
	public class OreInfo
	{
		public static readonly OreInfo Iron			= new OreInfo( 0, 0x000, "Iron" );
		public static readonly OreInfo DullCopper	= new OreInfo( 1, 0x973, "Dull Copper" );
		public static readonly OreInfo ShadowIron	= new OreInfo( 2, 0x966, "Shadow Iron" );
		public static readonly OreInfo Copper		= new OreInfo( 3, 0x96D, "Copper" );
		public static readonly OreInfo Bronze		= new OreInfo( 4, 0x972, "Bronze" );
		public static readonly OreInfo Gold			= new OreInfo( 5, 0x8A5, "Gold" );
		public static readonly OreInfo Agapite		= new OreInfo( 6, 0x979, "Agapite" );
		public static readonly OreInfo Verite		= new OreInfo( 7, 0x89F, "Verite" );
		public static readonly OreInfo Valorite		= new OreInfo( 8, 0x8AB, "Valorite" );
		public static readonly OreInfo Rusty		= new OreInfo( 9, 0x8AB, "Rusty" );
		public static readonly OreInfo Silver		= new OreInfo( 10, 0x8AB, "Silver" );
		public static readonly OreInfo PureCopper	= new OreInfo( 11, 0x8AB, "PureCopper" );
		public static readonly OreInfo BronzeAlloy	= new OreInfo( 12, 0x8AB, "BronzeAlloy" );
		public static readonly OreInfo Shadow		= new OreInfo( 13, 0x8AB, "Shadow" );
		public static readonly OreInfo Rose			= new OreInfo( 14, 0x8AB, "Rose" );
		public static readonly OreInfo Lime			= new OreInfo( 15, 0x8AB, "Lime" );
		public static readonly OreInfo Fuscia		= new OreInfo( 16, 0x8AB, "Fuscia" );
		public static readonly OreInfo Bloodrock	= new OreInfo( 17, 0x8AB, "Bloodrock" );
		public static readonly OreInfo ChromeBlue	= new OreInfo( 18, 0x8AB, "ChromeBlue" );
		public static readonly OreInfo ChromeCopper	= new OreInfo( 19, 0x8AB, "ChromeCopper" );
		public static readonly OreInfo Pansy		= new OreInfo( 20, 0x8AB, "Pansy" );
		public static readonly OreInfo Stinger		= new OreInfo( 21, 0x8AB, "Stinger" );
		public static readonly OreInfo Royal		= new OreInfo( 22, 0x8AB, "Royal" );
		public static readonly OreInfo BlueSteel	= new OreInfo( 23, 0x8AB, "BlueSteel" );
		public static readonly OreInfo Ice			= new OreInfo( 24, 0x8AB, "Ice" );
		public static readonly OreInfo Lemon		= new OreInfo( 25, 0x8AB, "Lemon" );
		public static readonly OreInfo Blackrock	= new OreInfo( 26, 0x8AB, "Blackrock" );
		public static readonly OreInfo RoseQuartz	= new OreInfo( 27, 0x8AB, "RoseQuartz" );
		public static readonly OreInfo Mint			= new OreInfo( 28, 0x8AB, "Mint" );
		public static readonly OreInfo Aqua			= new OreInfo( 29, 0x8AB, "Aqua" );
		public static readonly OreInfo Daemon		= new OreInfo( 30, 0x8AB, "Daemon" );
		public static readonly OreInfo Mythril		= new OreInfo( 31, 0x8AB, "Mythril" );
		public static readonly OreInfo Titanium		= new OreInfo( 32, 0x8AB, "Titanium" );
		public static readonly OreInfo Kryptonite	= new OreInfo( 33, 0x8AB, "Kryptonite" );
		public static readonly OreInfo Diamond		= new OreInfo( 34, 0x8AB, "Diamond" );
		public static readonly OreInfo Jolt			= new OreInfo( 35, 0x8AB, "Jolt" );
		public static readonly OreInfo Uranium		= new OreInfo( 36, 0x8AB, "Uranium" );
		public static readonly OreInfo Opiate		= new OreInfo( 37, 0x8AB, "Opiate" );
		public static readonly OreInfo Negative		= new OreInfo( 38, 0x8AB, "Negative" );
		public static readonly OreInfo Deus			= new OreInfo( 39, 0x8AB, "Deus" );
		public static readonly OreInfo DarkDeus		= new OreInfo( 40, 0x8AB, "DarkDeus" );

		private int m_Level;
		private int m_Hue;
		private string m_Name;

		public OreInfo( int level, int hue, string name )
		{
			m_Level = level;
			m_Hue = hue;
			m_Name = name;
		}

		public int Level
		{
			get
			{
				return m_Level;
			}
		}

		public int Hue
		{
			get
			{
				return m_Hue;
			}
		}

		public string Name
		{
			get
			{
				return m_Name;
			}
		}
	}
}