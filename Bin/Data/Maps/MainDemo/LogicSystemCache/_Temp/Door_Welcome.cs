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
	public class Door_Welcome : Engine.EntitySystem.LogicSystem.LogicEntityObject
	{
		GameEntities.AutomaticOpenDoor __ownerEntity;
		
		public Door_Welcome( GameEntities.AutomaticOpenDoor ownerEntity )
			: base( ownerEntity )
		{
			this.__ownerEntity = ownerEntity;
			ownerEntity.PostCreated += delegate( Engine.EntitySystem.Entity __entity, System.Boolean loaded ) { if( Engine.EntitySystem.LogicSystemManager.Instance != null )PostCreated( loaded ); };
		}
		
		public GameEntities.AutomaticOpenDoor Owner
		{
			get { return __ownerEntity; }
		}
		
		
		public void PostCreated( System.Boolean loaded )
		{
			if(EntitySystemWorld.Instance.IsServer())
				Owner.NoAutomaticOpen = false;
		}

	}
}
