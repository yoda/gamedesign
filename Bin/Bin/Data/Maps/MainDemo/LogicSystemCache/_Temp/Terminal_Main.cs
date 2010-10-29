using System;
using System.Collections.Generic;
using Engine;
using Engine.EntitySystem;
using Engine.MapSystem;
using Engine.UISystem;
using Engine.FileSystem;
using Engine.PhysicsSystem;
using Engine.Renderer;
using Engine.SoundSystem;
using Engine.MathEx;
using Engine.Utils;
using GameCommon;
using GameEntities;

namespace Maps_MainDemo_LogicSystem_LogicSystemScripts
{
	public class Terminal_Main : Engine.EntitySystem.LogicSystem.LogicEntityObject
	{
		GameEntities.GameGuiObject __ownerEntity;
		
		public Terminal_Main( GameEntities.GameGuiObject ownerEntity )
			: base( ownerEntity )
		{
			this.__ownerEntity = ownerEntity;
			ownerEntity.PostCreated += delegate( Engine.EntitySystem.Entity __entity, System.Boolean loaded ) { if( Engine.EntitySystem.LogicSystemManager.Instance != null )PostCreated( loaded ); };
		}
		
		public GameEntities.GameGuiObject Owner
		{
			get { return __ownerEntity; }
		}
		
		public Engine.UISystem.ETabControl tabControl;
		public Engine.UISystem.EButton previousButton;
		public Engine.UISystem.EButton nextButton;
		public Engine.UISystem.ETextBox currentPageText;
		
		public void PostCreated( System.Boolean loaded )
		{
			Engine.EntitySystem.LogicClass __class = Engine.EntitySystem.LogicSystemManager.Instance.MapClassManager.GetByName( "Terminal_Main" );
			Engine.EntitySystem.LogicSystem.LogicDesignerMethod __method = (Engine.EntitySystem.LogicSystem.LogicDesignerMethod)__class.GetMethodByName( "PostCreated" );
			__method.Execute( this, new object[ 1 ]{ loaded } );
		}

		public void Next_Click( Engine.UISystem.EButton sender )
		{
			Engine.EntitySystem.LogicClass __class = Engine.EntitySystem.LogicSystemManager.Instance.MapClassManager.GetByName( "Terminal_Main" );
			Engine.EntitySystem.LogicSystem.LogicDesignerMethod __method = (Engine.EntitySystem.LogicSystem.LogicDesignerMethod)__class.GetMethodByName( "Next_Click" );
			__method.Execute( this, new object[ 1 ]{ sender } );
		}

		public void Previous_Click( Engine.UISystem.EButton sender )
		{
			Engine.EntitySystem.LogicClass __class = Engine.EntitySystem.LogicSystemManager.Instance.MapClassManager.GetByName( "Terminal_Main" );
			Engine.EntitySystem.LogicSystem.LogicDesignerMethod __method = (Engine.EntitySystem.LogicSystem.LogicDesignerMethod)__class.GetMethodByName( "Previous_Click" );
			__method.Execute( this, new object[ 1 ]{ sender } );
		}

		public void UpdatePageNavigation()
		{
			Engine.EntitySystem.LogicClass __class = Engine.EntitySystem.LogicSystemManager.Instance.MapClassManager.GetByName( "Terminal_Main" );
			Engine.EntitySystem.LogicSystem.LogicDesignerMethod __method = (Engine.EntitySystem.LogicSystem.LogicDesignerMethod)__class.GetMethodByName( "UpdatePageNavigation" );
			__method.Execute( this, new object[ 0 ]{  } );
		}

		public void Camera_Click( Engine.UISystem.EButton sender )
		{
			Engine.EntitySystem.LogicClass __class = Engine.EntitySystem.LogicSystemManager.Instance.MapClassManager.GetByName( "Terminal_Main" );
			Engine.EntitySystem.LogicSystem.LogicDesignerMethod __method = (Engine.EntitySystem.LogicSystem.LogicDesignerMethod)__class.GetMethodByName( "Camera_Click" );
			__method.Execute( this, new object[ 1 ]{ sender } );
		}

		public void CameraOptionsClose_Click( Engine.UISystem.EButton sender )
		{
			Engine.EntitySystem.LogicClass __class = Engine.EntitySystem.LogicSystemManager.Instance.MapClassManager.GetByName( "Terminal_Main" );
			Engine.EntitySystem.LogicSystem.LogicDesignerMethod __method = (Engine.EntitySystem.LogicSystem.LogicDesignerMethod)__class.GetMethodByName( "CameraOptionsClose_Click" );
			__method.Execute( this, new object[ 1 ]{ sender } );
		}

		public void UpdateSystemInformation()
		{
			string str = "";
			
			str += "Engine Version: " + EngineVersionInformation.Version + "\n";
			str += "\n";
			str += "Runtime Framework: " + RuntimeFramework.GetDisplayName() + "\n";
			str += "Renderer: " + RendererWorld.Instance.DriverName + "\n";
			str += "Active Render System: " + RenderSystem.Instance.Name + "\n";
			str += "Active Physics Library: " + PhysicsWorld.Instance.DriverName + "\n";
			str += "Active Sound Library: " + SoundWorld.Instance.DriverName + "\n";
			
			{
				string syntaxes = "";
				
				foreach(string syntax in GpuProgramManager.Instance.SupportedSyntaxes)
				{
					if(syntaxes != "")
						syntaxes += " ";
					syntaxes += syntax;
				}
				str += "Gpu syntaxes: " + syntaxes + "\n";
			}
			
			
			Owner.MainControl.Controls["TabControl/SystemInformation/Information"].Text = str;
		}

	}
}
