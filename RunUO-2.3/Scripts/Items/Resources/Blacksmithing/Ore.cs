using System;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Engines.Craft;
using Server.Mobiles;
// 313 melt value for new ores must be set
namespace Server.Items
{
	public abstract class BaseOre : Item
	{
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
			set{ m_Resource = value; InvalidateProperties(); }
		}

		public abstract BaseIngot GetIngot();

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (int) m_Resource );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					m_Resource = (CraftResource)reader.ReadInt();
					break;
				}
				case 0:
				{
					OreInfo info;

					switch ( reader.ReadInt() )
					{
						case 0: info = OreInfo.Iron; break;
						case 1: info = OreInfo.DullCopper; break;
						case 2: info = OreInfo.ShadowIron; break;
						case 3: info = OreInfo.Copper; break;
						case 4: info = OreInfo.Bronze; break;
						case 5: info = OreInfo.Gold; break;
						case 6: info = OreInfo.Agapite; break;
						case 7: info = OreInfo.Verite; break;
						case 8: info = OreInfo.Valorite; break;
						case 9: info = OreInfo.Rusty; break;
						case 10: info = OreInfo.Silver; break;
						case 11: info = OreInfo.PureCopper; break;
						case 12: info = OreInfo.BronzeAlloy; break;
						case 13: info = OreInfo.Shadow; break;
						case 14: info = OreInfo.Rose; break;
						case 15: info = OreInfo.Lime; break;
						case 16: info = OreInfo.Fuscia; break;
						case 17: info = OreInfo.Bloodrock; break;
						case 18: info = OreInfo.ChromeBlue; break;
						case 19: info = OreInfo.ChromeCopper; break;
						case 20: info = OreInfo.Pansy; break;
						case 21: info = OreInfo.Stinger; break;
						case 22: info = OreInfo.Royal; break;
						case 23: info = OreInfo.BlueSteel; break;
						case 24: info = OreInfo.Ice; break;
						case 25: info = OreInfo.Lemon; break;
						case 26: info = OreInfo.Blackrock; break;
						case 27: info = OreInfo.RoseQuartz; break;
						case 28: info = OreInfo.Mint; break;
						case 29: info = OreInfo.Aqua; break;
						case 30: info = OreInfo.Daemon; break;
						case 31: info = OreInfo.Mythril; break;
						case 32: info = OreInfo.Titanium; break;
						case 33: info = OreInfo.Kryptonite; break;
						case 34: info = OreInfo.Diamond; break;
						case 35: info = OreInfo.Jolt; break;
						case 36: info = OreInfo.Uranium; break;
						case 37: info = OreInfo.Opiate; break;
						case 38: info = OreInfo.Negative; break;
						case 39: info = OreInfo.Deus; break;
						case 40: info = OreInfo.DarkDeus; break;
						default: info = null; break;
					}

					m_Resource = CraftResources.GetFromOreInfo( info );
					break;
				}
			}
		}

		private static int RandomSize()
		{
			double rand = Utility.RandomDouble();

			if ( rand < 0.12 )
				return 0x19B7;
			else if ( rand < 0.18 )
				return 0x19B8;
			else if ( rand < 0.25 )
				return 0x19BA;
			else
				return 0x19B9;
		}

		public BaseOre( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseOre( CraftResource resource, int amount ) : base( RandomSize() )
		{
			Stackable = true;
			Amount = amount;
			Hue = CraftResources.GetHue( resource );

			m_Resource = resource;
		}

		public BaseOre( Serial serial ) : base( serial )
		{
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			if ( Amount > 1 )
				list.Add( 1050039, "{0}\t#{1}", Amount, 1026583 ); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add( 1026583 ); // ore
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( !CraftResources.IsStandard( m_Resource ) )
			{
				int num = CraftResources.GetLocalizationNumber( m_Resource );

				if ( num > 0 )
					list.Add( num );
				else
					list.Add( CraftResources.GetName( m_Resource ) );
			}
		}

		public override int LabelNumber
		{
			get
			{
				if ( m_Resource >= CraftResource.DullCopper && m_Resource <= CraftResource.DarkDeus )
					return 1042845 + (int)(m_Resource - CraftResource.DullCopper);

				return 1042853; // iron ore;
			}
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !Movable )
				return;

			if ( RootParent is BaseCreature )
			{
				from.SendLocalizedMessage( 500447 ); // That is not accessible
			}
			else if ( from.InRange( this.GetWorldLocation(), 2 ) )
			{
				from.SendLocalizedMessage( 501971 ); // Select the forge on which to smelt the ore, or another pile of ore with which to combine it.
				from.Target = new InternalTarget( this );
			}
			else
			{
				from.SendLocalizedMessage( 501976 ); // The ore is too far away.
			}
		}

		private class InternalTarget : Target
		{
			private BaseOre m_Ore;

			public InternalTarget( BaseOre ore ) :  base ( 2, false, TargetFlags.None )
			{
				m_Ore = ore;
			}

			private bool IsForge( object obj )
			{
				if ( Core.ML && obj is Mobile && ((Mobile)obj).IsDeadBondedPet )
					return false;

				if ( obj.GetType().IsDefined( typeof( ForgeAttribute ), false ) )
					return true;

				int itemID = 0;

				if ( obj is Item )
					itemID = ((Item)obj).ItemID;
				else if ( obj is StaticTarget )
					itemID = ((StaticTarget)obj).ItemID;

				return ( itemID == 4017 || (itemID >= 6522 && itemID <= 6569) );
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Ore.Deleted )
					return;

				if ( !from.InRange( m_Ore.GetWorldLocation(), 2 ) )
				{
					from.SendLocalizedMessage( 501976 ); // The ore is too far away.
					return;
				}

				#region Combine Ore
				if ( targeted is BaseOre )
				{
					BaseOre ore = (BaseOre)targeted;

					if ( !ore.Movable )
					{
						return;
					}
					else if ( m_Ore == ore )
					{
						from.SendLocalizedMessage( 501972 ); // Select another pile or ore with which to combine this.
						from.Target = new InternalTarget( ore );
						return;
					}
					else if ( ore.Resource != m_Ore.Resource )
					{
						from.SendLocalizedMessage( 501979 ); // You cannot combine ores of different metals.
						return;
					}

					int worth = ore.Amount;

					if ( ore.ItemID == 0x19B9 )
						worth *= 8;
					else if ( ore.ItemID == 0x19B7 )
						worth *= 2;
					else
						worth *= 4;

					int sourceWorth = m_Ore.Amount;

					if ( m_Ore.ItemID == 0x19B9 )
						sourceWorth *= 8;
					else if ( m_Ore.ItemID == 0x19B7 )
						sourceWorth *= 2;
					else
						sourceWorth *= 4;

					worth += sourceWorth;

					int plusWeight = 0;
					int newID = ore.ItemID;

					if ( ore.DefaultWeight != m_Ore.DefaultWeight )
					{
						if ( ore.ItemID == 0x19B7 || m_Ore.ItemID == 0x19B7 )
						{
							newID = 0x19B7;
						}
						else if ( ore.ItemID == 0x19B9 )
						{
							newID = m_Ore.ItemID;
							plusWeight = ore.Amount * 2;
						}
						else
						{
							plusWeight = m_Ore.Amount * 2;
						}
					}

					if ( ( ore.ItemID == 0x19B9 && worth > 120000 ) || ( ( ore.ItemID == 0x19B8 || ore.ItemID == 0x19BA ) && worth > 60000 ) || ( ore.ItemID == 0x19B7 && worth > 30000 ) )
					{
						from.SendLocalizedMessage( 1062844 ); // There is too much ore to combine.
						return;
					}
					else if ( ore.RootParent is Mobile && ( plusWeight + ((Mobile)ore.RootParent).Backpack.TotalWeight ) > ((Mobile)ore.RootParent).Backpack.MaxWeight )
					{
						from.SendLocalizedMessage( 501978 ); // The weight is too great to combine in a container.
						return;
					}

					ore.ItemID = newID;

					if ( ore.ItemID == 0x19B9 )
						ore.Amount = worth / 8;
					else if ( ore.ItemID == 0x19B7 )
						ore.Amount = worth / 2;
					else
						ore.Amount = worth / 4;

					m_Ore.Delete();
					return;
				}
				#endregion

				if ( IsForge( targeted ) )
				{
					double difficulty;

					switch ( m_Ore.Resource )
					{
						default: difficulty = 50.0; break;
						case CraftResource.DullCopper: difficulty = 65.0; break;
						case CraftResource.ShadowIron: difficulty = 70.0; break;
						case CraftResource.Copper: difficulty = 75.0; break;
						case CraftResource.Bronze: difficulty = 80.0; break;
						case CraftResource.Gold: difficulty = 85.0; break;
						case CraftResource.Agapite: difficulty = 90.0; break;
						case CraftResource.Verite: difficulty = 95.0; break;
						case CraftResource.Valorite: difficulty = 99.0; break;
						case CraftResource.Rusty: difficulty = 99.0; break;
						case CraftResource.Silver: difficulty = 99.0; break;
						case CraftResource.PureCopper: difficulty = 99.0; break;
						case CraftResource.BronzeAlloy: difficulty = 99.0; break;
						case CraftResource.Shadow: difficulty = 99.0; break;
						case CraftResource.Rose: difficulty = 99.0; break;
						case CraftResource.Lime: difficulty = 99.0; break;
						case CraftResource.Fuscia: difficulty = 99.0; break;
						case CraftResource.Bloodrock: difficulty = 99.0; break;
						case CraftResource.ChromeBlue: difficulty = 99.0; break;
						case CraftResource.ChromeCopper: difficulty = 99.0; break;
						case CraftResource.Pansy: difficulty = 99.0; break;
						case CraftResource.Stinger: difficulty = 99.0; break;
						case CraftResource.Royal: difficulty = 99.0; break;
						case CraftResource.BlueSteel: difficulty = 99.0; break;
						case CraftResource.Ice: difficulty = 99.0; break;
						case CraftResource.Lemon: difficulty = 99.0; break;
						case CraftResource.Blackrock: difficulty = 99.0; break;
						case CraftResource.RoseQuartz: difficulty = 99.0; break;
						case CraftResource.Mint: difficulty = 99.0; break;
						case CraftResource.Aqua: difficulty = 99.0; break;
						case CraftResource.Daemon: difficulty = 99.0; break;
						case CraftResource.Mythril: difficulty = 99.0; break;
						case CraftResource.Titanium: difficulty = 99.0; break;
						case CraftResource.Kryptonite: difficulty = 99.0; break;
						case CraftResource.Diamond: difficulty = 99.0; break;
						case CraftResource.Jolt: difficulty = 99.0; break;
						case CraftResource.Uranium: difficulty = 99.0; break;
						case CraftResource.Opiate: difficulty = 99.0; break;
						case CraftResource.Negative: difficulty = 99.0; break;
						case CraftResource.Deus: difficulty = 99.0; break;
						case CraftResource.DarkDeus: difficulty = 99.0; break;
					}

					double minSkill = difficulty - 25.0;
					double maxSkill = difficulty + 25.0;

					if ( difficulty > 50.0 && difficulty > from.Skills[SkillName.Mining].Value )
					{
						from.SendLocalizedMessage( 501986 ); // You have no idea how to smelt this strange ore!
						return;
					}

					if ( m_Ore.ItemID == 0x19B7 && m_Ore.Amount < 2 )
					{
						from.SendLocalizedMessage( 501987 ); // There is not enough metal-bearing ore in this pile to make an ingot.
						return;
					}

					if ( from.CheckTargetSkill( SkillName.Mining, targeted, minSkill, maxSkill ) )
					{
						int toConsume = m_Ore.Amount;

						if ( toConsume <= 0 )
						{
							from.SendLocalizedMessage( 501987 ); // There is not enough metal-bearing ore in this pile to make an ingot.
						}
						else
						{
							if ( toConsume > 30000 )
								toConsume = 30000;

							int ingotAmount;

							if ( m_Ore.ItemID == 0x19B7 )
							{
								ingotAmount = toConsume / 2;

								if ( toConsume % 2 != 0 )
									--toConsume;
							}
							else if ( m_Ore.ItemID == 0x19B9 )
							{
								ingotAmount = toConsume * 2;
							}
							else
							{
								ingotAmount = toConsume;
							}

							BaseIngot ingot = m_Ore.GetIngot();
							ingot.Amount = ingotAmount;

							m_Ore.Consume( toConsume );
							from.AddToBackpack( ingot );
							//from.PlaySound( 0x57 );

							from.SendLocalizedMessage( 501988 ); // You smelt the ore removing the impurities and put the metal in your backpack.
						}
					}
					else
					{
						if ( m_Ore.Amount < 2 )
						{
							if ( m_Ore.ItemID == 0x19B9 )
								m_Ore.ItemID = 0x19B8;
							else
								m_Ore.ItemID = 0x19B7;
						}
						else
						{
							m_Ore.Amount /= 2;
						}

						from.SendLocalizedMessage( 501990 ); // You burn away the impurities but are left with less useable metal.
					}
				}
			}
		}
	}

	public class IronOre : BaseOre
	{
		[Constructable]
		public IronOre() : this( 1 )
		{
		}

		[Constructable]
		public IronOre( int amount ) : base( CraftResource.Iron, amount )
		{
		}

		public IronOre( bool fixedSize ) : this( 1 )
		{
			if ( fixedSize )
				ItemID = 0x19B8;
		}

		public IronOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new IronIngot();
		}
	}

	public class DullCopperOre : BaseOre
	{
		[Constructable]
		public DullCopperOre() : this( 1 )
		{
		}

		[Constructable]
		public DullCopperOre( int amount ) : base( CraftResource.DullCopper, amount )
		{
		}

		public DullCopperOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new DullCopperIngot();
		}
	}

	public class ShadowIronOre : BaseOre
	{
		[Constructable]
		public ShadowIronOre() : this( 1 )
		{
		}

		[Constructable]
		public ShadowIronOre( int amount ) : base( CraftResource.ShadowIron, amount )
		{
		}

		public ShadowIronOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new ShadowIronIngot();
		}
	}

	public class CopperOre : BaseOre
	{
		[Constructable]
		public CopperOre() : this( 1 )
		{
		}

		[Constructable]
		public CopperOre( int amount ) : base( CraftResource.Copper, amount )
		{
		}

		public CopperOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new CopperIngot();
		}
	}

	public class BronzeOre : BaseOre
	{
		[Constructable]
		public BronzeOre() : this( 1 )
		{
		}

		[Constructable]
		public BronzeOre( int amount ) : base( CraftResource.Bronze, amount )
		{
		}

		public BronzeOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new BronzeIngot();
		}
	}

	public class GoldOre : BaseOre
	{
		[Constructable]
		public GoldOre() : this( 1 )
		{
		}

		[Constructable]
		public GoldOre( int amount ) : base( CraftResource.Gold, amount )
		{
		}

		public GoldOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new GoldIngot();
		}
	}

	public class AgapiteOre : BaseOre
	{
		[Constructable]
		public AgapiteOre() : this( 1 )
		{
		}

		[Constructable]
		public AgapiteOre( int amount ) : base( CraftResource.Agapite, amount )
		{
		}

		public AgapiteOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new AgapiteIngot();
		}
	}

	public class VeriteOre : BaseOre
	{
		[Constructable]
		public VeriteOre() : this( 1 )
		{
		}

		[Constructable]
		public VeriteOre( int amount ) : base( CraftResource.Verite, amount )
		{
		}

		public VeriteOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new VeriteIngot();
		}
	}

	public class ValoriteOre : BaseOre
	{
		[Constructable]
		public ValoriteOre() : this( 1 )
		{
		}

		[Constructable]
		public ValoriteOre( int amount ) : base( CraftResource.Valorite, amount )
		{
		}

		public ValoriteOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}	

		public override BaseIngot GetIngot()
		{
			return new ValoriteIngot();
		}
	}
	
	public class RustyOre : BaseOre
	{

		[Constructable]
		public RustyOre() : this( 1 )
		{
		}

		[Constructable]
		public RustyOre( int amount ) : base( CraftResource.Rusty, amount )
		{
		}

		public RustyOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new RustyIngot();
		}
	}

	public class SilverOre : BaseOre
	{

		[Constructable]
		public SilverOre() : this( 1 )
		{
		}

		[Constructable]
		public SilverOre( int amount ) : base( CraftResource.Silver, amount )
		{
		}

		public SilverOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new SilverIngot();
		}
	}

	public class PureCopperOre : BaseOre
	{

		[Constructable]
		public PureCopperOre() : this( 1 )
		{
		}

		[Constructable]
		public PureCopperOre( int amount ) : base( CraftResource.PureCopper, amount )
		{
		}

		public PureCopperOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new PureCopperIngot();
		}
	}

	public class BronzeAlloyOre : BaseOre
	{

		[Constructable]
		public BronzeAlloyOre() : this( 1 )
		{
		}

		[Constructable]
		public BronzeAlloyOre( int amount ) : base( CraftResource.BronzeAlloy, amount )
		{
		}

		public BronzeAlloyOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new BronzeAlloyIngot();
		}
	}

	public class ShadowOre : BaseOre
	{

		[Constructable]
		public ShadowOre() : this( 1 )
		{
		}

		[Constructable]
		public ShadowOre( int amount ) : base( CraftResource.Shadow, amount )
		{
		}

		public ShadowOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new ShadowIngot();
		}
	}

	public class RoseOre : BaseOre
	{

		[Constructable]
		public RoseOre() : this( 1 )
		{
		}

		[Constructable]
		public RoseOre( int amount ) : base( CraftResource.Rose, amount )
		{
		}

		public RoseOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new RoseIngot();
		}
	}

	public class LimeOre : BaseOre
	{

		[Constructable]
		public LimeOre() : this( 1 )
		{
		}

		[Constructable]
		public LimeOre( int amount ) : base( CraftResource.Lime, amount )
		{
		}

		public LimeOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new LimeIngot();
		}
	}

	public class FusciaOre : BaseOre
	{

		[Constructable]
		public FusciaOre() : this( 1 )
		{
		}

		[Constructable]
		public FusciaOre( int amount ) : base( CraftResource.Fuscia, amount )
		{
		}

		public FusciaOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new FusciaIngot();
		}
	}

	public class BloodrockOre : BaseOre
	{

		[Constructable]
		public BloodrockOre() : this( 1 )
		{
		}

		[Constructable]
		public BloodrockOre( int amount ) : base( CraftResource.Bloodrock, amount )
		{
		}

		public BloodrockOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new BloodrockIngot();
		}
	}

	public class ChromeBlueOre : BaseOre
	{

		[Constructable]
		public ChromeBlueOre() : this( 1 )
		{
		}

		[Constructable]
		public ChromeBlueOre( int amount ) : base( CraftResource.ChromeBlue, amount )
		{
		}

		public ChromeBlueOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new ChromeBlueIngot();
		}
	}

	public class ChromeCopperOre : BaseOre
	{

		[Constructable]
		public ChromeCopperOre() : this( 1 )
		{
		}

		[Constructable]
		public ChromeCopperOre( int amount ) : base( CraftResource.ChromeCopper, amount )
		{
		}

		public ChromeCopperOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new ChromeCopperIngot();
		}
	}

	public class PansyOre : BaseOre
	{

		[Constructable]
		public PansyOre() : this( 1 )
		{
		}

		[Constructable]
		public PansyOre( int amount ) : base( CraftResource.Pansy, amount )
		{
		}

		public PansyOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new PansyIngot();
		}
	}

	public class StingerOre : BaseOre
	{

		[Constructable]
		public StingerOre() : this( 1 )
		{
		}

		[Constructable]
		public StingerOre( int amount ) : base( CraftResource.Stinger, amount )
		{
		}

		public StingerOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new StingerIngot();
		}
	}

	public class RoyalOre : BaseOre
	{

		[Constructable]
		public RoyalOre() : this( 1 )
		{
		}

		[Constructable]
		public RoyalOre( int amount ) : base( CraftResource.Royal, amount )
		{
		}

		public RoyalOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new RoyalIngot();
		}
	}

	public class BlueSteelOre : BaseOre
	{

		[Constructable]
		public BlueSteelOre() : this( 1 )
		{
		}

		[Constructable]
		public BlueSteelOre( int amount ) : base( CraftResource.BlueSteel, amount )
		{
		}

		public BlueSteelOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new BlueSteelIngot();
		}
	}

	public class IceOre : BaseOre
	{

		[Constructable]
		public IceOre() : this( 1 )
		{
		}

		[Constructable]
		public IceOre( int amount ) : base( CraftResource.Ice, amount )
		{
		}

		public IceOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new IceIngot();
		}
	}

	public class LemonOre : BaseOre
	{

		[Constructable]
		public LemonOre() : this( 1 )
		{
		}

		[Constructable]
		public LemonOre( int amount ) : base( CraftResource.Lemon, amount )
		{
		}

		public LemonOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new LemonIngot();
		}
	}

	public class BlackrockOre : BaseOre
	{

		[Constructable]
		public BlackrockOre() : this( 1 )
		{
		}

		[Constructable]
		public BlackrockOre( int amount ) : base( CraftResource.Blackrock, amount )
		{
		}

		public BlackrockOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new BlackrockIngot();
		}
	}

	public class RoseQuartzOre : BaseOre
	{

		[Constructable]
		public RoseQuartzOre() : this( 1 )
		{
		}

		[Constructable]
		public RoseQuartzOre( int amount ) : base( CraftResource.RoseQuartz, amount )
		{
		}

		public RoseQuartzOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new RoseQuartzIngot();
		}
	}

	public class MintOre : BaseOre
	{

		[Constructable]
		public MintOre() : this( 1 )
		{
		}

		[Constructable]
		public MintOre( int amount ) : base( CraftResource.Mint, amount )
		{
		}

		public MintOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new MintIngot();
		}
	}

	public class AquaOre : BaseOre
	{

		[Constructable]
		public AquaOre() : this( 1 )
		{
		}

		[Constructable]
		public AquaOre( int amount ) : base( CraftResource.Aqua, amount )
		{
		}

		public AquaOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new AquaIngot();
		}
	}

	public class DaemonOre : BaseOre
	{

		[Constructable]
		public DaemonOre() : this( 1 )
		{
		}

		[Constructable]
		public DaemonOre( int amount ) : base( CraftResource.Daemon, amount )
		{
		}

		public DaemonOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new DaemonIngot();
		}
	}

	public class MythrilOre : BaseOre
	{

		[Constructable]
		public MythrilOre() : this( 1 )
		{
		}

		[Constructable]
		public MythrilOre( int amount ) : base( CraftResource.Mythril, amount )
		{
		}

		public MythrilOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new MythrilIngot();
		}
	}

	public class TitaniumOre : BaseOre
	{

		[Constructable]
		public TitaniumOre() : this( 1 )
		{
		}

		[Constructable]
		public TitaniumOre( int amount ) : base( CraftResource.Titanium, amount )
		{
		}

		public TitaniumOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new TitaniumIngot();
		}
	}

	public class KryptoniteOre : BaseOre
	{

		[Constructable]
		public KryptoniteOre() : this( 1 )
		{
		}

		[Constructable]
		public KryptoniteOre( int amount ) : base( CraftResource.Kryptonite, amount )
		{
		}

		public KryptoniteOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new KryptoniteIngot();
		}
	}

	public class DiamondOre : BaseOre
	{

		[Constructable]
		public DiamondOre() : this( 1 )
		{
		}

		[Constructable]
		public DiamondOre( int amount ) : base( CraftResource.Diamond, amount )
		{
		}

		public DiamondOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new DiamondIngot();
		}
	}

	public class JoltOre : BaseOre
	{

		[Constructable]
		public JoltOre() : this( 1 )
		{
		}

		[Constructable]
		public JoltOre( int amount ) : base( CraftResource.Jolt, amount )
		{
		}

		public JoltOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new JoltIngot();
		}
	}

	public class UraniumOre : BaseOre
	{

		[Constructable]
		public UraniumOre() : this( 1 )
		{
		}

		[Constructable]
		public UraniumOre( int amount ) : base( CraftResource.Uranium, amount )
		{
		}

		public UraniumOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new UraniumIngot();
		}
	}

	public class OpiateOre : BaseOre
	{

		[Constructable]
		public OpiateOre() : this( 1 )
		{
		}

		[Constructable]
		public OpiateOre( int amount ) : base( CraftResource.Opiate, amount )
		{
		}

		public OpiateOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new OpiateIngot();
		}
	}

	public class NegativeOre : BaseOre
	{

		[Constructable]
		public NegativeOre() : this( 1 )
		{
		}

		[Constructable]
		public NegativeOre( int amount ) : base( CraftResource.Negative, amount )
		{
		}

		public NegativeOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new NegativeIngot();
		}
	}

	public class DeusOre : BaseOre
	{

		[Constructable]
		public DeusOre() : this( 1 )
		{
		}

		[Constructable]
		public DeusOre( int amount ) : base( CraftResource.Deus, amount )
		{
		}

		public DeusOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new DeusIngot();
		}
	}

	public class DarkDeusOre : BaseOre
	{

		[Constructable]
		public DarkDeusOre() : this( 1 )
		{
		}

		[Constructable]
		public DarkDeusOre( int amount ) : base( CraftResource.DarkDeus, amount )
		{
		}

		public DarkDeusOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override BaseIngot GetIngot()
		{
			return new DarkDeusIngot();
		}
	}
	
	
}