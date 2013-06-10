using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseGranite : Item
	{
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
			set{ m_Resource = value; InvalidateProperties(); }
		}

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
				case 0:
				{
					m_Resource = (CraftResource)reader.ReadInt();
					break;
				}
			}

			if ( version < 1 )
				Stackable = Core.ML;
		}

		public override double DefaultWeight
		{
			get { return Core.ML ? 1.0 : 10.0; } // Pub 57
		}

		public BaseGranite( CraftResource resource ) : base( 0x1779 )
		{
			Hue = CraftResources.GetHue( resource );
			Stackable = Core.ML;

			m_Resource = resource;
		}

		public BaseGranite( Serial serial ) : base( serial )
		{
		}

		public override int LabelNumber{ get{ return 1044607; } } // high quality granite

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
	}

	public class Granite : BaseGranite
	{
		[Constructable]
		public Granite() : base( CraftResource.Iron )
		{
		}

		public Granite( Serial serial ) : base( serial )
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

	public class DullCopperGranite : BaseGranite
	{
		[Constructable]
		public DullCopperGranite() : base( CraftResource.DullCopper )
		{
		}

		public DullCopperGranite( Serial serial ) : base( serial )
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

	public class ShadowIronGranite : BaseGranite
	{
		[Constructable]
		public ShadowIronGranite() : base( CraftResource.ShadowIron )
		{
		}

		public ShadowIronGranite( Serial serial ) : base( serial )
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

	public class CopperGranite : BaseGranite
	{
		[Constructable]
		public CopperGranite() : base( CraftResource.Copper )
		{
		}

		public CopperGranite( Serial serial ) : base( serial )
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

	public class BronzeGranite : BaseGranite
	{
		[Constructable]
		public BronzeGranite() : base( CraftResource.Bronze )
		{
		}

		public BronzeGranite( Serial serial ) : base( serial )
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

	public class GoldGranite : BaseGranite
	{
		[Constructable]
		public GoldGranite() : base( CraftResource.Gold )
		{
		}

		public GoldGranite( Serial serial ) : base( serial )
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

	public class AgapiteGranite : BaseGranite
	{
		[Constructable]
		public AgapiteGranite() : base( CraftResource.Agapite )
		{
		}

		public AgapiteGranite( Serial serial ) : base( serial )
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

	public class VeriteGranite : BaseGranite
	{
		[Constructable]
		public VeriteGranite() : base( CraftResource.Verite )
		{
		}

		public VeriteGranite( Serial serial ) : base( serial )
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

	public class ValoriteGranite : BaseGranite
	{
		[Constructable]
		public ValoriteGranite() : base( CraftResource.Valorite )
		{
		}

		public ValoriteGranite( Serial serial ) : base( serial )
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

	public class RustyGranite : BaseGranite
	{

		[Constructable]
		public RustyGranite() : base( CraftResource.Rusty )
		{
		}

		public RustyGranite( Serial serial ) : base( serial )
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

	public class SilverGranite : BaseGranite
	{

		[Constructable]
		public SilverGranite() : base( CraftResource.Silver )
		{
		}

		public SilverGranite( Serial serial ) : base( serial )
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

	public class PureCopperGranite : BaseGranite
	{

		[Constructable]
		public PureCopperGranite() : base( CraftResource.PureCopper )
		{
		}

		public PureCopperGranite( Serial serial ) : base( serial )
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

	public class BronzeAlloyGranite : BaseGranite
	{

		[Constructable]
		public BronzeAlloyGranite() : base( CraftResource.BronzeAlloy )
		{
		}

		public BronzeAlloyGranite( Serial serial ) : base( serial )
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

	public class ShadowGranite : BaseGranite
	{

		[Constructable]
		public ShadowGranite() : base( CraftResource.Shadow )
		{
		}

		public ShadowGranite( Serial serial ) : base( serial )
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

	public class RoseGranite : BaseGranite
	{

		[Constructable]
		public RoseGranite() : base( CraftResource.Rose )
		{
		}

		public RoseGranite( Serial serial ) : base( serial )
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

	public class LimeGranite : BaseGranite
	{

		[Constructable]
		public LimeGranite() : base( CraftResource.Lime )
		{
		}

		public LimeGranite( Serial serial ) : base( serial )
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

	public class FusciaGranite : BaseGranite
	{

		[Constructable]
		public FusciaGranite() : base( CraftResource.Fuscia )
		{
		}

		public FusciaGranite( Serial serial ) : base( serial )
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

	public class BloodrockGranite : BaseGranite
	{

		[Constructable]
		public BloodrockGranite() : base( CraftResource.Bloodrock )
		{
		}

		public BloodrockGranite( Serial serial ) : base( serial )
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

	public class ChromeBlueGranite : BaseGranite
	{

		[Constructable]
		public ChromeBlueGranite() : base( CraftResource.ChromeBlue )
		{
		}

		public ChromeBlueGranite( Serial serial ) : base( serial )
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

	public class ChromeCopperGranite : BaseGranite
	{

		[Constructable]
		public ChromeCopperGranite() : base( CraftResource.ChromeCopper )
		{
		}

		public ChromeCopperGranite( Serial serial ) : base( serial )
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

	public class PansyGranite : BaseGranite
	{

		[Constructable]
		public PansyGranite() : base( CraftResource.Pansy )
		{
		}

		public PansyGranite( Serial serial ) : base( serial )
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

	public class StingerGranite : BaseGranite
	{

		[Constructable]
		public StingerGranite() : base( CraftResource.Stinger )
		{
		}

		public StingerGranite( Serial serial ) : base( serial )
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

	public class RoyalGranite : BaseGranite
	{

		[Constructable]
		public RoyalGranite() : base( CraftResource.Royal )
		{
		}

		public RoyalGranite( Serial serial ) : base( serial )
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

	public class BlueSteelGranite : BaseGranite
	{

		[Constructable]
		public BlueSteelGranite() : base( CraftResource.BlueSteel )
		{
		}

		public BlueSteelGranite( Serial serial ) : base( serial )
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

	public class IceGranite : BaseGranite
	{

		[Constructable]
		public IceGranite() : base( CraftResource.Ice )
		{
		}

		public IceGranite( Serial serial ) : base( serial )
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

	public class LemonGranite : BaseGranite
	{

		[Constructable]
		public LemonGranite() : base( CraftResource.Lemon )
		{
		}

		public LemonGranite( Serial serial ) : base( serial )
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

	public class BlackrockGranite : BaseGranite
	{

		[Constructable]
		public BlackrockGranite() : base( CraftResource.Blackrock )
		{
		}

		public BlackrockGranite( Serial serial ) : base( serial )
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

	public class RoseQuartzGranite : BaseGranite
	{

		[Constructable]
		public RoseQuartzGranite() : base( CraftResource.RoseQuartz )
		{
		}

		public RoseQuartzGranite( Serial serial ) : base( serial )
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

	public class MintGranite : BaseGranite
	{

		[Constructable]
		public MintGranite() : base( CraftResource.Mint )
		{
		}

		public MintGranite( Serial serial ) : base( serial )
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

	public class AquaGranite : BaseGranite
	{

		[Constructable]
		public AquaGranite() : base( CraftResource.Aqua )
		{
		}

		public AquaGranite( Serial serial ) : base( serial )
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

	public class DaemonGranite : BaseGranite
	{

		[Constructable]
		public DaemonGranite() : base( CraftResource.Daemon )
		{
		}

		public DaemonGranite( Serial serial ) : base( serial )
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

	public class MythrilGranite : BaseGranite
	{

		[Constructable]
		public MythrilGranite() : base( CraftResource.Mythril )
		{
		}

		public MythrilGranite( Serial serial ) : base( serial )
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

	public class TitaniumGranite : BaseGranite
	{

		[Constructable]
		public TitaniumGranite() : base( CraftResource.Titanium )
		{
		}

		public TitaniumGranite( Serial serial ) : base( serial )
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

	public class KryptoniteGranite : BaseGranite
	{

		[Constructable]
		public KryptoniteGranite() : base( CraftResource.Kryptonite )
		{
		}

		public KryptoniteGranite( Serial serial ) : base( serial )
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

	public class DiamondGranite : BaseGranite
	{

		[Constructable]
		public DiamondGranite() : base( CraftResource.Diamond )
		{
		}

		public DiamondGranite( Serial serial ) : base( serial )
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

	public class JoltGranite : BaseGranite
	{

		[Constructable]
		public JoltGranite() : base( CraftResource.Jolt )
		{
		}

		public JoltGranite( Serial serial ) : base( serial )
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

	public class UraniumGranite : BaseGranite
	{

		[Constructable]
		public UraniumGranite() : base( CraftResource.Uranium )
		{
		}

		public UraniumGranite( Serial serial ) : base( serial )
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

	public class OpiateGranite : BaseGranite
	{

		[Constructable]
		public OpiateGranite() : base( CraftResource.Opiate )
		{
		}

		public OpiateGranite( Serial serial ) : base( serial )
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

	public class NegativeGranite : BaseGranite
	{

		[Constructable]
		public NegativeGranite() : base( CraftResource.Negative )
		{
		}

		public NegativeGranite( Serial serial ) : base( serial )
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

	public class DeusGranite : BaseGranite
	{

		[Constructable]
		public DeusGranite() : base( CraftResource.Deus )
		{
		}

		public DeusGranite( Serial serial ) : base( serial )
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

	public class DarkDeusGranite : BaseGranite
	{

		[Constructable]
		public DarkDeusGranite() : base( CraftResource.DarkDeus )
		{
		}

		public DarkDeusGranite( Serial serial ) : base( serial )
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