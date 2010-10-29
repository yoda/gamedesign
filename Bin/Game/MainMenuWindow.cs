// Copyright (C) 2006-2010 NeoAxis Group Ltd.
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Engine;
using Engine.UISystem;
using Engine.EntitySystem;
using Engine.MapSystem;
using Engine.MathEx;
using Engine.Renderer;
using Engine.SoundSystem;
using GameCommon;
using GameEntities;

namespace Game
{
	/// <summary>
	/// Defines a main menu.
	/// </summary>
	public class MainMenuWindow : EControl
	{
		EControl window;
		ETextBox versionTextBox;

		Map mapInstance;

		///////////////////////////////////////////

		/// <summary>
		/// Creates a window of the main menu and creates the background world.
		/// </summary>
		protected override void OnAttach()
		{
			base.OnAttach();

			//create main menu window
			window = ControlDeclarationManager.Instance.CreateControl( "Gui\\MainMenuWindow.gui" );

			window.ColorMultiplier = new ColorValue( 1, 1, 1, 0 );
			Controls.Add( window );

			//no shader model 2 warning
			if( window.Controls[ "NoShaderModel2" ] != null )
				window.Controls[ "NoShaderModel2" ].Visible = !RenderSystem.Instance.HasShaderModel2();

			//button handlers
			( (EButton)window.Controls[ "Multiplayer" ] ).Click += Multiplayer_Click;


			//play background music
			GameMusic.MusicPlay( "Sounds\\Music\\MainMenu.ogg", true );

			//update sound listener
			SoundWorld.Instance.SetListener( new Vec3( 1000, 1000, 1000 ),
				Vec3.Zero, new Vec3( 1, 0, 0 ), new Vec3( 0, 0, 1 ) );

			ResetTime();
		}

		void Run_Click( EButton sender )
		{
			GameEngineApp.Instance.SetNeedMapLoad( "Maps\\MainDemo\\Map.map" );
		}

		void Multiplayer_Click( EButton sender )
		{
			if( EngineApp.Instance.WebPlayerMode )
			{
				Log.Warning( "Networking is not supported for web player at this time." );
				return;
			}

			Controls.Add( new MultiplayerLoginWindow() );
		}

		/// <summary>
		/// Destroys the background world at closing the main menu.
		/// </summary>
		protected override void OnDetach()
		{
			//destroy the background world
			DestroyMap();

			base.OnDetach();
		}

		protected override bool OnKeyDown( KeyEvent e )
		{
			if( base.OnKeyDown( e ) )
				return true;

			if( e.Key == EKeys.Escape )
			{
				Controls.Add( new MenuWindow() );
				return true;
			}

			return false;
		}

		protected override void OnTick( float delta )
		{
			base.OnTick( delta );

			//Change window transparency
			{
				float alpha = 0;

				if( Time > 2 && Time <= 4 )
					alpha = ( Time - 2 ) / 2;
				else if( Time > 4 )
					alpha = 1;

				window.ColorMultiplier = new ColorValue( 1, 1, 1, alpha );
			}

			//update sound listener
			SoundWorld.Instance.SetListener( new Vec3( 1000, 1000, 1000 ),
				Vec3.Zero, new Vec3( 1, 0, 0 ), new Vec3( 0, 0, 1 ) );

		}

		protected override void OnRender()
		{
			base.OnRender();

			//Update camera orientation
			if( Map.Instance != null )
			{
				float dir = Time / 10.0f;

				Vec3 from = new Vec3(
					MathFunctions.Cos( dir ) * 29.0f / 1.5f,
					MathFunctions.Sin( dir * 1.50f ) * 10.0f / 1.5f,
					( MathFunctions.Cos( dir * 1.2f ) + 1.4f ) * 17.0f / 1.5f );
				Vec3 to = Vec3.Zero;
				float fov = 80;

				Camera camera = RendererWorld.Instance.DefaultCamera;
				camera.NearClipDistance = Map.Instance.NearFarClipDistance.Minimum;
				camera.FarClipDistance = Map.Instance.NearFarClipDistance.Maximum;
				camera.FixedUp = Vec3.ZAxis;
				camera.Fov = fov;
				camera.Position = from;
				camera.LookAt( to );
			}
		}

		/// <summary>
		/// Creates the background world.
		/// </summary>
		void CreateMap()
		{
			WorldType worldType = EntityTypes.Instance.GetByName( "SimpleWorld" ) as WorldType;
			if( worldType == null )
				Log.Fatal( "MainMenuWindow: CreateMap: \"SimpleWorld\" type is not exists." );


		}

		/// <summary>
		/// Destroys the background world.
		/// </summary>
		void DestroyMap()
		{
			if( mapInstance == Map.Instance )
			{
				MapSystemWorld.MapDestroy();
				EntitySystemWorld.Instance.WorldDestroy();
			}
		}
	}
}
