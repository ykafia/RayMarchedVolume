using System;
using System.Linq;
using RayMarching.Effects;
using Stride.Core;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Input;

namespace RayMarching
{
    /// <summary>
    /// A script that allows to move and rotate an entity through keyboard, mouse and touch input to provide basic camera navigation.
    /// </summary>
    /// <remarks>
    /// The entity can be moved using W, A, S, D, Q and E, arrow keys, a gamepad's left stick or dragging/scaling using multi-touch.
    /// Rotation is achieved using the Numpad, the mouse while holding the right mouse button, a gamepad's right stick, or dragging using single-touch.
    /// </remarks>
    public class UpdateCameraPos : SyncScript
    {
        public Entity Camera;

        public override void Start()
        {
            
        }
        public override void Update()
        {
            Entity.Get<ModelComponent>().Materials[0].Passes.AsParallel().ForAll(x => x.Parameters.Set(RayMarchingSphereKeys.CameraPos, Camera.Transform.Position));
        }
    }
}
