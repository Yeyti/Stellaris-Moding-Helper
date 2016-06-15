using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace SMH
{
    public sealed class ShaderProgram : IDisposable
    {
        private const int InvalidHandle = -1;

        public int Handle { get; private set; }

        public ShaderProgram()
        {
            AcquireHandle();
        }

        private void AcquireHandle()
        {
            Handle = GL.CreateProgram();
        }

        public void AttachShader(Shader shader)
        {
            GL.AttachShader(Handle, shader.Handle);
        }

        public void Link()
        {
            GL.LinkProgram(Handle);

            int linkStatus;
            GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out linkStatus);

            if (linkStatus == 0)
                Console.WriteLine(GL.GetProgramInfoLog(Handle));
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        private void ReleaseHandle()
        {
            if (Handle == InvalidHandle)
                return;

            GL.DeleteProgram(Handle);

            Handle = InvalidHandle;
        }

        public void Dispose()
        {
            ReleaseHandle();
            GC.SuppressFinalize(this);
        }

        ~ShaderProgram()
        {
            if (GraphicsContext.CurrentContext != null && !GraphicsContext.CurrentContext.IsDisposed)
                ReleaseHandle();
        }
    }
}
