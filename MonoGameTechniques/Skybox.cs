using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace MonoGameTechniques
{
    internal class Skybox
    {
        private Model skyBox;
        private TextureCube skyBoxTexture;
        private Effect skyBoxEffect;
        private float size = 500;

        public Skybox(string _skyBoxTexture, ContentManager _content)
        {
            skyBox = _content.Load<Model>("Cube");
            skyBoxTexture = _content.Load<TextureCube>(_skyBoxTexture);
            skyBoxEffect = _content.Load<Effect>("CubeMap");
        }

        public void Draw(Matrix _view, Matrix _projection, Vector3 _cameraPosition)
        {
            

            foreach (ModelMesh mesh in skyBox.Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    part.Effect = skyBoxEffect;
                    Matrix world = Matrix.CreateScale(size) * Matrix.CreateTranslation(_cameraPosition);

                    part.Effect.Parameters["World"].SetValue(world);
                    part.Effect.Parameters["WorldViewProjection"].SetValue(world * _view * _projection);
                    part.Effect.Parameters["SkyBoxTexture"].SetValue(skyBoxTexture);
                    part.Effect.Parameters["CameraPosition"].SetValue(_cameraPosition);

                }

                mesh.Draw();
            }
        }
    }
}