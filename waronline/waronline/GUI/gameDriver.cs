using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using waronline.GUI;

namespace waronline
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class gameDriver : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private List<DrawnCard> cardTextureList;
        private Dictionary<string, DrawnCard> cardTextureMap;
        private int x = 0;
        private int y = 0;
        private bool _firstUpdate = true;

        private GameTemplate game;


        public gameDriver()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = @"Assets\Cards";
            cardTextureList = new List<DrawnCard>();
            cardTextureMap = new Dictionary<string, DrawnCard>();

            TouchPanel.EnabledGestures = GestureType.Tap;

            game = new MainGameLogic(cardTextureList);
        }



        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            string[] cardType =
            {
                "Club",
                "Diamond",
                "Heart",
                "Spade"
            };

            string[] specialCardValues =
            {
                "jack",
                "queen",
                "king",
                "ace"
            };

            Texture2D backCardTexture2D = Content.Load<Texture2D>("card_background");

            foreach(string cardPrefix in cardType)
            {
                for (int i = 2; i < 11; i++)
                {
                    string cardName = cardPrefix + "_" + i.ToString();
                    DrawnCard reference = new DrawnCard(Content.Load<Texture2D>(cardName), backCardTexture2D, cardName);
                    cardTextureList.Add(reference);
                    cardTextureMap.Add(cardName, reference);
                }

                foreach (string specialCardValue in specialCardValues)
                {
                    string cardName = cardPrefix + "_" + specialCardValue;
                    DrawnCard reference = new DrawnCard(Content.Load<Texture2D>(cardName), backCardTexture2D, cardName);
                    cardTextureList.Add(reference);
                    cardTextureMap.Add(cardName, reference);
                }
            }

            game.initCards();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (_firstUpdate)
            {
                // Temp hack to fix gestures
                typeof(Microsoft.Xna.Framework.Input.Touch.TouchPanel)
                    .GetField("_touchScale", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                    .SetValue(null, Vector2.One);

                _firstUpdate = false;
            }

            game.updateState();

            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                switch (gesture.GestureType)
                {
                    case GestureType.Tap:
                        game.applyOnTouch(gesture.Position);
                        break;
                    default:
                        break;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.ForestGreen);

            Vector2 position = new Vector2(x, y);

            _spriteBatch.Begin();

            //_spriteBatch.Draw(_spriteTexture, position, Color.White);

            foreach (DrawnCard card in cardTextureList)
            {
                if (card.IsVisible)
                {
                    _spriteBatch.Draw(card.Reference, new Vector2(card.X, card.Y), null, Color.White, 0, Vector2.Zero, Constants.scale, SpriteEffects.None, 0.0f);                    
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
