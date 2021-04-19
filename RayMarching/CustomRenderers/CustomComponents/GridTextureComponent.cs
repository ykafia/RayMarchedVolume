using Stride.Core;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Engine.Design;
using Stride.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayMarching
{
    [DataContract("GridTextureCompnent")]
    [Display("GridTextureCompnent", Expand = ExpandRule.Once)]
    [DefaultEntityComponentRenderer(typeof(GridTextureEntityProcessor))]
    [ComponentOrder(100)]
    public class GridTextureComponent : ActivableEntityComponent
    {
        [DataMember(10)]
        [Display("3D Grid")]
        public Texture GridTexture { get; set; }

        [DataMember(20)]
        [Display("Grid Dimensions")]
        public Int3 Dimensions { get; set; }
    }
}
