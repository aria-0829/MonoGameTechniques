using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Windows.Forms;

namespace MonoGameTechniques
{
    internal class Models
    {
        public Model Mesh { get; set; }
        public Matrix Translation { get; set; }
        public Matrix Rotation { get; set; }
        public Matrix Scale { get; set; }
        public Effect Shader { get; set; }

        //Texturing
        public Texture Texture { get; set; }
        public Texture NormalMap { get; set; }

        //Lighting Variables
        public Vector3 DiffuseColor { get; set; }
        public Vector3 SpecularColor { get; set; }
        public float SpecularPower { get; set; }

        public Vector3 LightColor { get; set; }
        public Vector3 LightDirection { get; set; }

        public Models(Model _mesh, Vector3 _position, float _scale)
        {
            Mesh = _mesh;
            Translation = Matrix.CreateTranslation(_position);
            Rotation = Matrix.Identity;
            Scale = Matrix.CreateScale(_scale);
            DiffuseColor = new Vector3(1, 1, 1);
            SpecularColor = new Vector3(1, 1, 1); 
            SpecularPower = 4;
            LightDirection = new Vector3(-1, 0, 1);
            LightColor = new Vector3(1, 1, 1); //White
        }

        public void SetShader(Effect _effect)
        {
            Shader = _effect;

            foreach (ModelMesh mesh in Mesh.Meshes)
            {
                foreach (ModelMeshPart meshPart in mesh.MeshParts)
                {
                    meshPart.Effect = Shader;
                }
            }
        }

        public void SetTexture(Texture _tex, Texture _texNormal)
        {
            Texture = _tex;
            NormalMap = _texNormal;
        }

        public Matrix GetTransform()
        {
            return Scale * Rotation * Translation;
        }
        
        public void UpdatePhongParameters(Matrix _view, Matrix _projection, Vector3 _cameraPosition, bool _useDiffuse, bool _useSpecular, bool _useNormal)
        {
            Shader.Parameters["World"].SetValue(GetTransform());
            Shader.Parameters["WorldViewProjection"].SetValue(GetTransform() * _view * _projection);
            Shader.Parameters["CameraPosition"].SetValue(_cameraPosition);
            Shader.Parameters["DiffuseColor"].SetValue(DiffuseColor);
            Shader.Parameters["LightDirection"].SetValue(LightDirection);
            Shader.Parameters["LightColor"].SetValue(LightColor);
            Shader.Parameters["UseDiffuse"].SetValue(_useDiffuse);
            Shader.Parameters["UseSpecular"].SetValue(_useSpecular);
            Shader.Parameters["UseNormalMap"].SetValue(_useNormal);

            if (_useDiffuse)
            {
                Shader.Parameters["Texture"].SetValue(Texture);
            }
            if (_useSpecular)
            {
                Shader.Parameters["SpecularColor"].SetValue(SpecularColor);
                Shader.Parameters["SpecularPower"].SetValue(SpecularPower);
            }

            if (_useNormal)
            {
                Shader.Parameters["NormalMap"].SetValue(NormalMap);
            }
        }

        public void Render()
        {
            foreach (ModelMesh mesh in Mesh.Meshes)
            {
                mesh.Draw();
            }
        }
    }
}
