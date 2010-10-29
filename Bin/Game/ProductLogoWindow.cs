// Copyright (C) 2006-2010 NeoAxis Group Ltd.
using System;
using System.Collections.Generic;
using System.Text;
using Engine;
using Engine.UISystem;
using Engine.Renderer;
using Engine.MathEx;
using Engine.SoundSystem;

namespace Game
{
	/// <summary>
	/// Defines a your project logo window.
	/// </summary>
	public class ProductLogoWindow : EControl
	{
		const float lifeTime = 10;

		Texture productTexture;

		protected override void OnAttach()
		{
			base.OnAttach();

			productTexture = TextureManager.Instance.Load( "Gui\\Various\\Product.png" );

			EngineApp.Instance.MouseRelativeMode = true;

			SoundWorld.Instance.SetListener( new Vec3( 1000, 1000, 1000 ),
				Vec3.Zero, new Vec3( 1, 0, 0 ), new Vec3( 0, 0, 1 ) );

			ResetTime();
		}

		protected override void OnDetach()
		{
			EngineApp.Instance.MouseRelativeMode = false;
			EngineApp.Instance.MousePosition = new Vec2( .9f, .8f );

			base.OnDetach();
		}

		protected override bool OnKeyDown( KeyEvent e )
		{
			if( base.OnKeyDown( e ) )
				return true;
			if( e.Key == EKeys.Escape || e.Key == EKeys.Return || e.Key == EKeys.Space )
			{
				Destroy();
				return true;
			}
			return false;
		}

		protected override bool OnMouseDown( EMouseButtons button )
		{
			if( button == EMouseButtons.Left || button == EMouseButtons.Right )
			{
				Destroy();
				return true;
			}
			return base.OnMouseDown( button );
		}

		protected override void OnTick( float delta )
		{
			base.OnTick( delta );
			if( Time > lifeTime )
				Destroy();
		}

		void Destroy()
		{
			SetShouldDetach();

			//go to main menu
			GameEngineApp.Instance.ControlManager.Controls.Add( new MainMenuWindow() );
		}

		protected override void OnRenderUI( GuiRenderer renderer )
		{
		
		}

	}
}
