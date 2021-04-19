using Stride.Engine;
using Stride.Graphics;
using Stride.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayMarching
{
    public class GridTextureEntityProcessor : EntityProcessor<GridTextureComponent, GridTextureObject>, IEntityComponentRenderProcessor
    {
        public VisibilityGroup VisibilityGroup { get; set; }

        /// <summary>
        /// Gets the active render object.
        /// </summary>
        /// <value>The active render object.</value>
        public GridTextureObject MyRenderObject { get; private set; }

        /// <inheritdoc />
        protected override void OnSystemRemove()
        {
            if (MyRenderObject != null)
            {
                VisibilityGroup.RenderObjects.Remove(MyRenderObject);
                MyRenderObject = null;
            }

            base.OnSystemRemove();
        }

        /// <inheritdoc />
        protected override GridTextureObject GenerateComponentData(Entity entity, GridTextureComponent component)
        {
            return new GridTextureObject() 
            {
                GridTexture = component.GridTexture,
                Dimensions = component.Dimensions
            };
        }

        

        /// <inheritdoc />
        public override void Draw(RenderContext context)
        {
            var previousRenderObject = MyRenderObject;
            MyRenderObject = null;

            // Go thru components of this entity
            foreach (var entityKeyPair in ComponentDatas)
            {
                var myEntityComponent = entityKeyPair.Key;
                var myRenderObject = entityKeyPair.Value;
                if (myEntityComponent.Enabled)
                {
                    // Select the first enabled component and assign data from UI

                    myEntityComponent.GridTexture = myRenderObject.GridTexture;
                    MyRenderObject = myRenderObject;
                    break;
                }
            }

            if (MyRenderObject != previousRenderObject)
            {
                if (previousRenderObject != null)
                    VisibilityGroup.RenderObjects.Remove(previousRenderObject);
                if (MyRenderObject != null)
                    VisibilityGroup.RenderObjects.Add(MyRenderObject);
            }
        }
    }
}
