﻿using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL4;

namespace Basics.Physics.Test.UI
{
    public class MipMapGeneratedRenderObject : ARenderable
    {
        private int _minMipmapLevel = 0;
        private int _maxMipmapLevel;
        private int _texture;
        public MipMapGeneratedRenderObject(TexturedVertex[] vertices, int program, string filename, int maxMipmapLevel)
            : base(program, vertices.Length)
        {
            _maxMipmapLevel = maxMipmapLevel;
            // create first buffer: vertex
            GL.NamedBufferStorage(
                Buffer,
                TexturedVertex.Size * vertices.Length,        // the size needed by this buffer
                vertices,                           // data to initialize with
                BufferStorageFlags.MapWriteBit);    // at this point we will only write to the buffer

            GL.VertexArrayAttribBinding(VertexArray, 0, 0);
            GL.EnableVertexArrayAttrib(VertexArray, 0);
            GL.VertexArrayAttribFormat(
                VertexArray,
                0,                      // attribute index, from the shader location = 0
                4,                      // size of attribute, vec4
                VertexAttribType.Float, // contains floats
                false,                  // does not need to be normalized as it is already, floats ignore this flag anyway
                0);                     // relative offset, first item

            GL.VertexArrayAttribBinding(VertexArray, 1, 0);
            GL.EnableVertexArrayAttrib(VertexArray, 1);
            GL.VertexArrayAttribFormat(
                VertexArray,
                1,                      // attribute index, from the shader location = 1
                2,                      // size of attribute, vec2
                VertexAttribType.Float, // contains floats
                false,                  // does not need to be normalized as it is already, floats ignore this flag anyway
                16);                     // relative offset after a vec4

            // link the vertex array and buffer and provide the stride as size of Vertex
            GL.VertexArrayVertexBuffer(VertexArray, 0, Buffer, IntPtr.Zero, TexturedVertex.Size);

            InitTextures(filename);
        }

        private void InitTextures(string filename)
        {
            int width, height;
            var data = LoadTexture(filename, out width, out height);
            GL.CreateTextures(TextureTarget.Texture2D, 1, out _texture);
            GL.TextureStorage2D(
                _texture,
                _maxMipmapLevel,             // levels of mipmapping
                SizedInternalFormat.Rgba32f, // format of texture
                width,
                height);

            GL.BindTexture(TextureTarget.Texture2D, _texture);
            GL.TextureSubImage2D(_texture,
                0,                  // this is level 0
                0,                  // x offset
                0,                  // y offset
                width,
                height,
                PixelFormat.Rgba,
                PixelType.Float,
                data);

            GL.GenerateTextureMipmap(_texture);
            GL.TextureParameterI(_texture, TextureParameterName.TextureBaseLevel, ref _minMipmapLevel);
            GL.TextureParameterI(_texture, TextureParameterName.TextureMaxLevel, ref _maxMipmapLevel);
            var textureMinFilter = (int)TextureMinFilter.LinearMipmapLinear;
            GL.TextureParameterI(_texture, TextureParameterName.TextureMinFilter, ref textureMinFilter);
            var textureMagFilter = (int)TextureMinFilter.Linear;
            GL.TextureParameterI(_texture, TextureParameterName.TextureMagFilter, ref textureMagFilter);
            // data not needed from here on, OpenGL has the data
        }

        private float[] LoadTexture(string filename, out int width, out int height)
        {
            float[] r;
            using (var bmp = (Bitmap)Image.FromFile(filename))
            {
                width = bmp.Width;
                height = bmp.Height;
                r = new float[width * height * 4];
                int index = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        var pixel = bmp.GetPixel(x, y);
                        r[index++] = pixel.R / 255f;
                        r[index++] = pixel.G / 255f;
                        r[index++] = pixel.B / 255f;
                        r[index++] = pixel.A / 255f;
                    }
                }
            }
            return r;
        }

        public override void Bind()
        {
            base.Bind();
            GL.BindTexture(TextureTarget.Texture2D, _texture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GL.DeleteTexture(_texture);
            }
            base.Dispose(disposing);
        }
    }
}