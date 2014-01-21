using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gamedemo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private Texture2D _spriteTexture;
        private List<DrawnCard> cardTextureList;
        private Dictionary<string, DrawnCard> cardTextureMap;
        private int x = 0;
        private int y = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            cardTextureList = new List<DrawnCard>();
            cardTextureMap = new Dictionary<string, DrawnCard>();
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

            _spriteTexture = Content.Load<Texture2D>("Mouse");

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

            foreach(string cardPrefix in cardType)
            {
                for (int i = 2; i < 11; i++)
                {
                    string cardName = cardPrefix + "_" + i.ToString();
                    DrawnCard reference = new DrawnCard(Content.Load<Texture2D>(cardName));
                    cardTextureList.Add(reference);
                    cardTextureMap.Add(cardName, reference);
                }

                foreach (string specialCardValue in specialCardValues)
                {
                    string cardName = cardPrefix + "_" + specialCardValue;
                    DrawnCard reference = new DrawnCard(Content.Load<Texture2D>(cardName));
                    cardTextureList.Add(reference);
                    cardTextureMap.Add(cardName, reference);
                }
            }


            Random r = new Random();
            foreach (DrawnCard card in cardTextureList)
            {
                card.IsVisible = true;
                card.move(r.Next(480), r.Next(800));
            }
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
            x++;
            y++;

            if (x > 500) x = 0;
            if (y > 500) y = 0;

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
                _spriteBatch.Draw(card.Reference, new Vector2(card.X, card.Y), Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
