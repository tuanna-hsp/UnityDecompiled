using System;
using UnityEngine;

namespace UnityEditorInternal
{
	internal struct FrameDebuggerEventData
	{
		public int frameEventIndex;

		public int vertexCount;

		public int indexCount;

		public int instanceCount;

		public int drawCallCount;

		public string shaderName;

		public string passName;

		public string passLightMode;

		public int shaderInstanceID;

		public int subShaderIndex;

		public int shaderPassIndex;

		public string shaderKeywords;

		public int rendererInstanceID;

		public Mesh mesh;

		public int meshInstanceID;

		public int meshSubset;

		public int csInstanceID;

		public string csName;

		public string csKernel;

		public int csThreadGroupsX;

		public int csThreadGroupsY;

		public int csThreadGroupsZ;

		public string rtName;

		public int rtWidth;

		public int rtHeight;

		public int rtFormat;

		public int rtDim;

		public int rtFace;

		public short rtCount;

		public short rtHasDepthTexture;

		public FrameDebuggerBlendState blendState;

		public FrameDebuggerRasterState rasterState;

		public FrameDebuggerDepthState depthState;

		public FrameDebuggerStencilState stencilState;

		public int stencilRef;

		public int batchBreakCause;

		public ShaderProperties shaderProperties;
	}
}
