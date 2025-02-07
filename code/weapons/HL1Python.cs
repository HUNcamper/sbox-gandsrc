﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
	[Library( "weapon_357", Title = "Colt Python" )]
	partial class HL1Python : Weapon
	{
		public override string ViewModelPath => "models/gandsrc/hl1/v_357.vmdl";
		public override float PrimaryRate => 1.25f;
		public override float SecondaryRate => 5.0f;
		public override float ReloadTime => 4.0f;
		public override int MagSize { get; set; } = 6;

		public TimeSince TimeSinceDischarge { get; set; }

		public override void Spawn()
		{
			base.Spawn();

			SetModel( "weapons/rust_pistol/rust_pistol.vmdl" );
		}

		public override bool CanPrimaryAttack()
		{
			return base.CanPrimaryAttack() && Input.Down( InputButton.PrimaryAttack );
		}

		public override void AttackPrimary()
		{
			base.AttackPrimary();

			TimeSincePrimaryAttack = 0;
			TimeSinceSecondaryAttack = 0;

			(Owner as AnimatedEntity)?.SetAnimParameter( "b_attack", true );

			Particles.Create( "particles/muzzleflash.vpcf", EffectEntity, "muzzle" );
			ShootEffects( shakeVertRot: 15.0f, shakeLength: 0.8 );
			PlaySound( "hl1-weapons-357-fire" );
			ShootBullet( 0.05f, 1.5f, 9.0f, 3.0f );
		}

		public override void SimulateAnimator( PawnAnimator anim )
		{
			anim.SetAnimParameter( "holdtype", 1 );
			anim.SetAnimParameter( "aimat_weight", 1.0f );
			anim.SetAnimParameter( "holdtype_handedness", 0 );
		}
	}

}
