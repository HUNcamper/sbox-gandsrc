﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.ScreenShake
{
	internal class GoldSrcShake : CameraMode
	{
		float Length;
		float Speed;
		float Size;
		float RotationAmount;
		float NoiseZ;

		TimeSince lifeTime = 0;
		float pos = 0;

		public GoldSrcShake( float length = 0.1f, float speed = 1.0f, float size = 3.0f, float rotation = 0.6f )
		{
			Length = length;
			Speed = speed;
			Size = size;
			RotationAmount = rotation;
			NoiseZ = Rand.Float( -10000, 10000 );

			pos = Rand.Float( 0, 100000 );
		}

		/* public override bool Update( ref CameraSetup cam )
		{
			var delta = ((float)lifeTime).LerpInverse( 0, Length, true );
			delta = Easing.Linear( delta );
			
			var invdelta = 1 - delta;

			pos += Time.Delta * 10 * invdelta * Speed;

			//float x = Noise.Perlin( pos, 0, NoiseZ );
			//float y = Noise.Perlin( pos, 3.0f, NoiseZ );

			//cam.Position += (cam.Rotation.Right * x + cam.Rotation.Up * y) * invdelta * Size;
			//cam.Rotation *= Rotation.FromAxis( Vector3.Up, x * Size * invdelta * RotationAmount );
			cam.Rotation *= Rotation.FromAxis( Vector3.Right, Size * invdelta * RotationAmount );

			return lifeTime < Length;
		} */

		public override void Update()
		{
			var delta = ((float)lifeTime).LerpInverse( 0, Length, true );
			delta = Easing.Linear( delta );

			var invdelta = 1 - delta;

			pos += Time.Delta * 10 * invdelta * Speed;

			//float x = Noise.Perlin( pos, 0, NoiseZ );
			//float y = Noise.Perlin( pos, 3.0f, NoiseZ );

			//cam.Position += (cam.Rotation.Right * x + cam.Rotation.Up * y) * invdelta * Size;
			//cam.Rotation *= Rotation.FromAxis( Vector3.Up, x * Size * invdelta * RotationAmount );
			Rotation *= Rotation.FromAxis( Vector3.Right, Size * invdelta * RotationAmount );
		}
	}
}
