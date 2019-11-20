using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Scary_Time
{
    class DialogText
    {
        SpriteBatch spriteBatch;
        SpriteFont font;
        String text;
        String parsedText;
        String typedText;
        double typedTextLength;
        int delayInMilliseconds;
        bool isDoneDrawing;
        Rectangle textRect;
        int textinBox = 1;
        Texture2D dialogIcon, currentIcon;
        Rectangle iconRect;
        int iconFrames = 0;
        Rectangle sourceIconRect;
        //bool showDialogBox = false;
        bool startIconAnimation = false;
        float iconElapsed;
        float iconDelay = 100f;

        public DialogText()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        //animation for icon on corner of dialog box
        private void AnimateIcon(GameTime gameTime)
        {
            iconElapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (iconElapsed >= iconDelay)
            {
                if (iconFrames >= 5)
                {
                    iconFrames = 0;
                }
                else
                {
                    iconFrames++;
                }

                iconElapsed = 0;
                sourceIconRect = new Rectangle(94 * iconFrames, 0, 94, 100);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (!isDoneDrawing)
            {
                if (delayInMilliseconds == 0)
                {
                    typedText = parsedText;
                    isDoneDrawing = true;
                }
                else if (typedTextLength < parsedText.Length)
                {
                    if (textinBox == 2)
                    {
                        typedTextLength = typedTextLength + gameTime.ElapsedGameTime.TotalMilliseconds / delayInMilliseconds;

                        if (typedTextLength >= parsedText.Length)
                        {
                            typedTextLength = parsedText.Length;
                            isDoneDrawing = true;
                            startIconAnimation = true;
                            AnimateIcon(gameTime);
                        }
                    }
                    typedText = parsedText.Substring(0, (int)typedTextLength);

                }
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            /*if (showDialogBox == true)
            {
                spriteBatch.Draw(interacttextRect, dialogRect, Color.White);
            }*/
            if (startIconAnimation == true)
            {
                spriteBatch.Draw(dialogIcon, iconRect, sourceIconRect, Color.White);
                currentIcon = dialogIcon;
                AnimateIcon(gameTime);
            }
            if (textinBox == 2)
            {
                spriteBatch.DrawString(font, typedText, new Vector2(textRect.X, textRect.Y), Color.White);
            }
            spriteBatch.End();
        }
        private String parseText(SpriteFont font, String text)
        {
            String line = String.Empty;
            String returnString = String.Empty;
            String[] wordArray = text.Split(' ');

            foreach (String word in wordArray)
            {
                if (font.MeasureString(line + word).Length() > textRect.Width)
                {
                    returnString = returnString + line + '\n';
                    line = String.Empty;
                }

                line = line + word + ' ';
            }

            return returnString + line;
        }
    }
}
