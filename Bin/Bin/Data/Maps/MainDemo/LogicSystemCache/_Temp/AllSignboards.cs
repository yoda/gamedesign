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
	public class AllSignboards : Engine.EntitySystem.LogicSystem.LogicEntityObject
	{
		GameEntities.GameGuiObject __ownerEntity;
		
		public AllSignboards( GameEntities.GameGuiObject ownerEntity )
			: base( ownerEntity )
		{
			this.__ownerEntity = ownerEntity;
			ownerEntity.PostCreated += delegate( Engine.EntitySystem.Entity __entity, System.Boolean loaded ) { if( Engine.EntitySystem.LogicSystemManager.Instance != null )PostCreated( loaded ); };
		}
		
		public GameEntities.GameGuiObject Owner
		{
			get { return __ownerEntity; }
		}
		
		
		public void PostCreated( System.Boolean loaded )
		{
			Engine.EntitySystem.LogicClass __class = Engine.EntitySystem.LogicSystemManager.Instance.MapClassManager.GetByName( "AllSignboards" );
			Engine.EntitySystem.LogicSystem.LogicDesignerMethod __method = (Engine.EntitySystem.LogicSystem.LogicDesignerMethod)__class.GetMethodByName( "PostCreated" );
			__method.Execute( this, new object[ 1 ]{ loaded } );
		}

	}
}
