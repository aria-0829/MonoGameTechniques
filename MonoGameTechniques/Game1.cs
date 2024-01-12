using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MonoGameTechniques
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _sprite;
        private SpriteFont _font;
        private RenderTarget2D _renderTarget;

        private Models fighter;
        private List<Models> fighters = new List<Models>();
        private Models fish;

        private Effect phong;
        private Effect blackWhite;
        private Effect wave;
        private float time = 0;

        private Skybox skybox;
        private float angle = 0;
        private float distance = 20;

        private Texture texFighterDiffuse;
        private Texture texFighterNormal;
        private Texture texFishDiffuse;
        private Texture texFishNormal;

        private Vector3 cameraPosition;
        private Matrix world = Matrix.Identity;
        private Matrix view = Matrix.Identity;
        private Matrix projection = Matrix.Identity;

        private Toolbar toolbar;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            toolbar = new Toolbar();
            toolbar.Show();
            toolbar.TopMost = true;

            cameraPosition = new Vector3(0, 40, 40);
            world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
            view = Matrix.CreateLookAt(new Vector3(0, 0, 600), new Vector3(0, 0, 0), Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), _graphics.GraphicsDevice.Viewport.AspectRatio, 0.1f, 10000f);

            _sprite = new SpriteBatch(GraphicsDevice);

            _renderTarget = new RenderTarget2D(GraphicsDevice, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight, 
                                               false, _graphics.PreferredBackBufferFormat, DepthFormat.Depth24);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _font = Content.Load<SpriteFont>("Arial14");

            // Load Shader
            phong = Content.Load<Effect>("Phong");
            blackWhite = Content.Load<Effect>("BlackAndWhite");
            wave = Content.Load<Effect>("Wave");

            // Load Space Fighter
            texFighterDiffuse = Content.Load<Texture>("FighterDiffuse");
            texFighterNormal = Content.Load<Texture>("FighterNormal");
            
            fighter = new Models(Content.Load<Model>("Fighter"), new Vector3(0, 0, 0), 0.2f);
            fighter.SetShader(phong);
            fighter.SetTexture(texFighterDiffuse, texFighterNormal);

            // Load Skybox
            skybox = new Skybox("Skybox/Skybox", Content);

            // Load Fish
            texFishDiffuse = Content.Load<Texture>("FishDiffuse");
            texFishNormal = Content.Load<Texture>("FishNormal");
            fish = new Models(Content.Load<Model>("Fish"), new Vector3(0, 0, 0), 5f);
            fish.SetShader(phong);
            fish.SetTexture(texFishDiffuse, texFishNormal);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (toolbar.SFM)
            {
                SpaceFighterMaps();
            }
            else if (toolbar.SS)
            {
                SpaceScene();
            }
            else if (toolbar.PP)
            {
                PostProcessing();
            }

            base.Update(gameTime);
        }

        private void SpaceFighterMaps()
        {
            view = Matrix.CreateLookAt(new Vector3(0, 0, 600), new Vector3(0, 0, 0), Vector3.Up);
        }

        private void SpaceScene()
        {
            angle += 0.01f;
            cameraPosition = distance * new Vector3((float)Math.Sin(angle), 0, (float)Math.Cos(angle));
            view = Matrix.CreateLookAt(cameraPosition, new Vector3(0, 0, 0), Vector3.UnitY);

            if (toolbar.AddSF)
            {
                Vector3 fighterPosition = 100f * Matrix.Invert(view).Forward + cameraPosition;

                Models newfighter = new Models(Content.Load<Model>("Fighter"), fighterPosition, 0.02f);
                newfighter.SetShader(phong);
                newfighter.SetTexture(texFighterDiffuse, texFighterNormal);
                newfighter.Rotation = Matrix.CreateRotationX(MathHelper.ToRadians(-45));
                fighters.Add(newfighter);

                toolbar.AddSF = false;
            }
        }

        private void PostProcessing()
        {
            view = Matrix.CreateLookAt(new Vector3(0, 0, 600), new Vector3(0, 0, 0), Vector3.Up);
        }

        private Vector3 QuaternionToEuler(Quaternion quat)
        {
            float pitch = MathHelper.ToDegrees((float)Math.Atan2(2f * (quat.X * quat.W - quat.Y * quat.Z), 1f - 2f * (quat.X * quat.X + quat.Z * quat.Z)));
            float yaw = MathHelper.ToDegrees((float)Math.Asin(2f * (quat.X * quat.Z + quat.Y * quat.W)));
            float roll = MathHelper.ToDegrees((float)Math.Atan2(2f * (quat.Z * quat.W - quat.X * quat.Y), 1f - 2f * (quat.Y * quat.Y + quat.Z * quat.Z)));

            // Ensure positive values for pitch, yaw, and roll
            if (pitch < 0)
                pitch += 360;
            if (yaw < 0)
                yaw += 360;
            if (roll < 0)
                roll += 360;

            return new Vector3(pitch, yaw, roll);
        }

        private void RenderInfo(Models model, Color color)
        {
            string outputP = "Position: " + model.Translation.Translation.ToString();
            _sprite.DrawString(_font, outputP, new Vector2(10, 40), color);

            Quaternion rotationQuaternion = Quaternion.CreateFromRotationMatrix(model.Rotation);
            Vector3 rotation = QuaternionToEuler(rotationQuaternion);
            string outputR = "Rotation: " + rotation.ToString();
            _sprite.DrawString(_font, outputR, new Vector2(10, 70), color);

            Vector3 scale = new Vector3(model.Scale.M11, model.Scale.M22, model.Scale.M33);
            string outputS = "Scale: " + scale.ToString();
            _sprite.DrawString(_font, outputS, new Vector2(10, 100), color);
        }

        protected void DrawSceneToTexture(RenderTarget2D _renderTarget)
        {
            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(Color.Black);

            fish.UpdatePhongParameters(view, projection, cameraPosition, true, true, true);
            fish.Render();

            GraphicsDevice.SetRenderTarget(null);
        }

        protected override void Draw(GameTime gameTime)
        {
            #region ConfiguareDevice
            GraphicsDevice.Clear(Color.Black);
            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            if (toolbar.SFM && toolbar.Wireframe)
            {
                rasterizerState.FillMode = FillMode.WireFrame;
            }
            GraphicsDevice.RasterizerState = rasterizerState;
            #endregion ConfiguareDevice

            #region States
            if (toolbar.PP)
            {
                if (toolbar.BlankWhite) // Black and White
                {
                    DrawSceneToTexture(_renderTarget);
                    GraphicsDevice.Clear(Color.Black);
                    _sprite.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, 
                                  SamplerState.LinearClamp, DepthStencilState.Default, 
                                  RasterizerState.CullNone, blackWhite);
                    _sprite.Draw(_renderTarget,Vector2.Zero, Color.White);
                }
                else if (toolbar.UnderWater) // Under Water
                {
                    DrawSceneToTexture(_renderTarget);

                    wave.Parameters["TintBlue"].SetValue(toolbar.Tint);
                    wave.Parameters["Amplitude"].SetValue(toolbar.Amplitude);
                    wave.Parameters["Frequency"].SetValue(toolbar.Frequency);

                    time += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                    time += deltaTime;
                    wave.Parameters["Time"].SetValue(time);

                    GraphicsDevice.Clear(Color.Black);
                    _sprite.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,
                                  SamplerState.LinearClamp, DepthStencilState.Default,
                                  RasterizerState.CullNone, wave);
                    _sprite.Draw(_renderTarget, Vector2.Zero, Color.White);
                }

                _sprite.DrawString(_font, "Fish", new Vector2(10, 10), Color.White);
                RenderInfo(fish, Color.White); // Render Info
                string outputCP = "Camera Position: " + cameraPosition.ToString();
                _sprite.DrawString(_font, outputCP, new Vector2(10, 130), Color.White);
            }
            else
            {
                _sprite.Begin();

                fighter.SetShader(phong);
                fighter.SetTexture(texFighterDiffuse, texFighterNormal);

                _sprite.DrawString(_font, "Space Fighter", new Vector2(10, 10), Color.Yellow);

                if (toolbar.SFM) // Space Fighter Maps
                {
                    fighter.UpdatePhongParameters(view, projection, cameraPosition, toolbar.Diffuse, toolbar.Specular, toolbar.Normal);
                    
                    fighter.Rotation *= Matrix.CreateRotationX(0.4f * (float)gameTime.ElapsedGameTime.TotalSeconds);
                    fighter.Render();

                    RenderInfo(fighter, Color.GreenYellow); // Render Info

                    string outputCP = "Camera Position: " + cameraPosition.ToString();
                    _sprite.DrawString(_font, outputCP, new Vector2(10, 130), Color.Yellow);
                }
                else if (toolbar.SS) // Space Scene
                {
                    foreach (Models fighter in fighters)
                    {
                        fighter.UpdatePhongParameters(view, projection, cameraPosition, true, true, true);
                        fighter.Render();
                    }

                    if (fighters.Count > 0)
                    {
                        Models lastFighter = fighters[fighters.Count - 1];

                        RenderInfo(lastFighter, Color.GreenYellow); // Render Info
                    }
                    else
                    {
                        RenderInfo(fighter, Color.GreenYellow); // Render Info
                    }

                    string outputC = "Fighter Count: " + fighters.Count.ToString();
                    _sprite.DrawString(_font, outputC, new Vector2(10, 130), Color.Yellow);

                    string outputCP = "Camera Position: " + cameraPosition.ToString();
                    _sprite.DrawString(_font, outputCP, new Vector2(10, 160), Color.Yellow);

                    skybox.Draw(view, projection, cameraPosition);
                }
            }
            #endregion States

            _sprite.End();

            //GraphicsDevice.DepthStencilState = DepthStencilState.None;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;

            base.Draw(gameTime);
        }
        
    }
}