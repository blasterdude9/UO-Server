using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseIngot : Item, ICommodity
	{
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
			set{ m_Resource = value; InvalidateProperties(); }
		}

		public override double DefaultWeight
		{
			get { return 0.1; }
		}
		
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

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

		public BaseIngot( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseIngot( CraftResource resource, int amount ) : base( 0x1BF2 )
		{
			Stackable = true;
			Amount = amount;
			Hue = CraftResources.GetHue( resource );

			m_Resource = resource;
		}

		public BaseIngot( Serial serial ) : base( serial )
		{
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			if ( Amount > 1 )
				list.Add( 1050039, "{0}\t#{1}", Amount, 1027154 ); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add( 1027154 ); // ingots
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
					return 1042684 + (int)(m_Resource - CraftResource.DullCopper);

				return 1042692;
			}
		}
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class IronIngot : BaseIngot
	{
		[Constructable]
		public IronIngot() : this( 1 )
		{
		}

		[Constructable]
		public IronIngot( int amount ) : base( CraftResource.Iron, amount )
		{
		}

		public IronIngot( Serial serial ) : base( serial )
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

		
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class DullCopperIngot : BaseIngot
	{
		[Constructable]
		public DullCopperIngot() : this( 1 )
		{
		}

		[Constructable]
		public DullCopperIngot( int amount ) : base( CraftResource.DullCopper, amount )
		{
		}

		public DullCopperIngot( Serial serial ) : base( serial )
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

		
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class ShadowIronIngot : BaseIngot
	{
		[Constructable]
		public ShadowIronIngot() : this( 1 )
		{
		}

		[Constructable]
		public ShadowIronIngot( int amount ) : base( CraftResource.ShadowIron, amount )
		{
		}

		public ShadowIronIngot( Serial serial ) : base( serial )
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

		
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class CopperIngot : BaseIngot
	{
		[Constructable]
		public CopperIngot() : this( 1 )
		{
		}

		[Constructable]
		public CopperIngot( int amount ) : base( CraftResource.Copper, amount )
		{
		}

		public CopperIngot( Serial serial ) : base( serial )
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

		
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class BronzeIngot : BaseIngot
	{
		[Constructable]
		public BronzeIngot() : this( 1 )
		{
		}

		[Constructable]
		public BronzeIngot( int amount ) : base( CraftResource.Bronze, amount )
		{
		}

		public BronzeIngot( Serial serial ) : base( serial )
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

		
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class GoldIngot : BaseIngot
	{
		[Constructable]
		public GoldIngot() : this( 1 )
		{
		}

		[Constructable]
		public GoldIngot( int amount ) : base( CraftResource.Gold, amount )
		{
		}

		public GoldIngot( Serial serial ) : base( serial )
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

		
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class AgapiteIngot : BaseIngot
	{
		[Constructable]
		public AgapiteIngot() : this( 1 )
		{
		}

		[Constructable]
		public AgapiteIngot( int amount ) : base( CraftResource.Agapite, amount )
		{
		}

		public AgapiteIngot( Serial serial ) : base( serial )
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

		
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class VeriteIngot : BaseIngot
	{
		[Constructable]
		public VeriteIngot() : this( 1 )
		{
		}

		[Constructable]
		public VeriteIngot( int amount ) : base( CraftResource.Verite, amount )
		{
		}

		public VeriteIngot( Serial serial ) : base( serial )
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

		
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class ValoriteIngot : BaseIngot
	{
		[Constructable]
		public ValoriteIngot() : this( 1 )
		{
		}

		[Constructable]
		public ValoriteIngot( int amount ) : base( CraftResource.Valorite, amount )
		{
		}

		public ValoriteIngot( Serial serial ) : base( serial )
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

		
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class RustyIngot : BaseIngot
	{

		[Constructable]
		public RustyIngot() : this( 1 )
		{
		}

		[Constructable]
		public RustyIngot( int amount ) : base( CraftResource.Rusty, amount )
		{
		}

		public RustyIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class SilverIngot : BaseIngot
	{

		[Constructable]
		public SilverIngot() : this( 1 )
		{
		}

		[Constructable]
		public SilverIngot( int amount ) : base( CraftResource.Silver, amount )
		{
		}

		public SilverIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class PureCopperIngot : BaseIngot
	{

		[Constructable]
		public PureCopperIngot() : this( 1 )
		{
		}

		[Constructable]
		public PureCopperIngot( int amount ) : base( CraftResource.PureCopper, amount )
		{
		}

		public PureCopperIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class BronzeAlloyIngot : BaseIngot
	{

		[Constructable]
		public BronzeAlloyIngot() : this( 1 )
		{
		}

		[Constructable]
		public BronzeAlloyIngot( int amount ) : base( CraftResource.BronzeAlloy, amount )
		{
		}

		public BronzeAlloyIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class ShadowIngot : BaseIngot
	{

		[Constructable]
		public ShadowIngot() : this( 1 )
		{
		}

		[Constructable]
		public ShadowIngot( int amount ) : base( CraftResource.Shadow, amount )
		{
		}

		public ShadowIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class RoseIngot : BaseIngot
	{

		[Constructable]
		public RoseIngot() : this( 1 )
		{
		}

		[Constructable]
		public RoseIngot( int amount ) : base( CraftResource.Rose, amount )
		{
		}

		public RoseIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class LimeIngot : BaseIngot
	{

		[Constructable]
		public LimeIngot() : this( 1 )
		{
		}

		[Constructable]
		public LimeIngot( int amount ) : base( CraftResource.Lime, amount )
		{
		}

		public LimeIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class FusciaIngot : BaseIngot
	{

		[Constructable]
		public FusciaIngot() : this( 1 )
		{
		}

		[Constructable]
		public FusciaIngot( int amount ) : base( CraftResource.Fuscia, amount )
		{
		}

		public FusciaIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class BloodrockIngot : BaseIngot
	{

		[Constructable]
		public BloodrockIngot() : this( 1 )
		{
		}

		[Constructable]
		public BloodrockIngot( int amount ) : base( CraftResource.Bloodrock, amount )
		{
		}

		public BloodrockIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class ChromeBlueIngot : BaseIngot
	{

		[Constructable]
		public ChromeBlueIngot() : this( 1 )
		{
		}

		[Constructable]
		public ChromeBlueIngot( int amount ) : base( CraftResource.ChromeBlue, amount )
		{
		}

		public ChromeBlueIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class ChromeCopperIngot : BaseIngot
	{

		[Constructable]
		public ChromeCopperIngot() : this( 1 )
		{
		}

		[Constructable]
		public ChromeCopperIngot( int amount ) : base( CraftResource.ChromeCopper, amount )
		{
		}

		public ChromeCopperIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class PansyIngot : BaseIngot
	{

		[Constructable]
		public PansyIngot() : this( 1 )
		{
		}

		[Constructable]
		public PansyIngot( int amount ) : base( CraftResource.Pansy, amount )
		{
		}

		public PansyIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class StingerIngot : BaseIngot
	{

		[Constructable]
		public StingerIngot() : this( 1 )
		{
		}

		[Constructable]
		public StingerIngot( int amount ) : base( CraftResource.Stinger, amount )
		{
		}

		public StingerIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class RoyalIngot : BaseIngot
	{

		[Constructable]
		public RoyalIngot() : this( 1 )
		{
		}

		[Constructable]
		public RoyalIngot( int amount ) : base( CraftResource.Royal, amount )
		{
		}

		public RoyalIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class BlueSteelIngot : BaseIngot
	{

		[Constructable]
		public BlueSteelIngot() : this( 1 )
		{
		}

		[Constructable]
		public BlueSteelIngot( int amount ) : base( CraftResource.BlueSteel, amount )
		{
		}

		public BlueSteelIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class IceIngot : BaseIngot
	{

		[Constructable]
		public IceIngot() : this( 1 )
		{
		}

		[Constructable]
		public IceIngot( int amount ) : base( CraftResource.Ice, amount )
		{
		}

		public IceIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class LemonIngot : BaseIngot
	{

		[Constructable]
		public LemonIngot() : this( 1 )
		{
		}

		[Constructable]
		public LemonIngot( int amount ) : base( CraftResource.Lemon, amount )
		{
		}

		public LemonIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class BlackrockIngot : BaseIngot
	{

		[Constructable]
		public BlackrockIngot() : this( 1 )
		{
		}

		[Constructable]
		public BlackrockIngot( int amount ) : base( CraftResource.Blackrock, amount )
		{
		}

		public BlackrockIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class RoseQuartzIngot : BaseIngot
	{

		[Constructable]
		public RoseQuartzIngot() : this( 1 )
		{
		}

		[Constructable]
		public RoseQuartzIngot( int amount ) : base( CraftResource.RoseQuartz, amount )
		{
		}

		public RoseQuartzIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class MintIngot : BaseIngot
	{

		[Constructable]
		public MintIngot() : this( 1 )
		{
		}

		[Constructable]
		public MintIngot( int amount ) : base( CraftResource.Mint, amount )
		{
		}

		public MintIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class AquaIngot : BaseIngot
	{

		[Constructable]
		public AquaIngot() : this( 1 )
		{
		}

		[Constructable]
		public AquaIngot( int amount ) : base( CraftResource.Aqua, amount )
		{
		}

		public AquaIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class DaemonIngot : BaseIngot
	{

		[Constructable]
		public DaemonIngot() : this( 1 )
		{
		}

		[Constructable]
		public DaemonIngot( int amount ) : base( CraftResource.Daemon, amount )
		{
		}

		public DaemonIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class MythrilIngot : BaseIngot
	{

		[Constructable]
		public MythrilIngot() : this( 1 )
		{
		}

		[Constructable]
		public MythrilIngot( int amount ) : base( CraftResource.Mythril, amount )
		{
		}

		public MythrilIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class TitaniumIngot : BaseIngot
	{

		[Constructable]
		public TitaniumIngot() : this( 1 )
		{
		}

		[Constructable]
		public TitaniumIngot( int amount ) : base( CraftResource.Titanium, amount )
		{
		}

		public TitaniumIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class KryptoniteIngot : BaseIngot
	{

		[Constructable]
		public KryptoniteIngot() : this( 1 )
		{
		}

		[Constructable]
		public KryptoniteIngot( int amount ) : base( CraftResource.Kryptonite, amount )
		{
		}

		public KryptoniteIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class DiamondIngot : BaseIngot
	{

		[Constructable]
		public DiamondIngot() : this( 1 )
		{
		}

		[Constructable]
		public DiamondIngot( int amount ) : base( CraftResource.Diamond, amount )
		{
		}

		public DiamondIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class JoltIngot : BaseIngot
	{

		[Constructable]
		public JoltIngot() : this( 1 )
		{
		}

		[Constructable]
		public JoltIngot( int amount ) : base( CraftResource.Jolt, amount )
		{
		}

		public JoltIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class UraniumIngot : BaseIngot
	{

		[Constructable]
		public UraniumIngot() : this( 1 )
		{
		}

		[Constructable]
		public UraniumIngot( int amount ) : base( CraftResource.Uranium, amount )
		{
		}

		public UraniumIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class OpiateIngot : BaseIngot
	{

		[Constructable]
		public OpiateIngot() : this( 1 )
		{
		}

		[Constructable]
		public OpiateIngot( int amount ) : base( CraftResource.Opiate, amount )
		{
		}

		public OpiateIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class NegativeIngot : BaseIngot
	{

		[Constructable]
		public NegativeIngot() : this( 1 )
		{
		}

		[Constructable]
		public NegativeIngot( int amount ) : base( CraftResource.Negative, amount )
		{
		}

		public NegativeIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class DeusIngot : BaseIngot
	{

		[Constructable]
		public DeusIngot() : this( 1 )
		{
		}

		[Constructable]
		public DeusIngot( int amount ) : base( CraftResource.Deus, amount )
		{
		}

		public DeusIngot( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class DarkDeusIngot : BaseIngot
	{

		[Constructable]
		public DarkDeusIngot() : this( 1 )
		{
		}

		[Constructable]
		public DarkDeusIngot( int amount ) : base( CraftResource.DarkDeus, amount )
		{
		}

		public DarkDeusIngot( Serial serial ) : base( serial )
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
	}
}