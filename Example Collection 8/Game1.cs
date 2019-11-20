using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scary_Time
{
    /// This is the main type for your game
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        KeyboardState oldKeyboardState, currentKeyboardState;
        SpriteBatch spriteBatch;
    //CLASSES
        CollisionCheck clsCollision;
    //ITEM VARIABLES
            //Box variables
        Texture2D box;
        Rectangle boxRect;
            //Key variables
        int hasKey = 1;
        Rectangle keyRect;
        Texture2D key;
            //Level variables
        int currentLevel = 1;
        Texture2D levelOne;
        Texture2D levelTwo;
        Texture2D gameOver;
            //Menu variables
        int menuOption = 0;
        Texture2D menuSprite;
        Rectangle menuRect;
        Texture2D menuOptionOneSprite;
        Rectangle menuOptionOneRect;
        Texture2D menuOptionTwoSprite;
        Rectangle menuOptionTwoRect;
        Texture2D menuOptionThreeSprite;
        Rectangle menuOptionThreeRect;
        Texture2D menuOptionOneSelectedSprite;
        Texture2D menuOptionTwoSelectedSprite;
        Texture2D menuOptionThreeSelectedSprite;
            //Health Bar variables
        Rectangle erikaHealthRect;
        Texture2D erikaHealthText;
        Texture2D erikaHealthBarText;
        Rectangle erikaHealthBarRect;
        int erikaHealth = 120;
        Rectangle claireHealthRect;
        Texture2D claireHealthText;
        Texture2D claireHealthBarText;
        Rectangle claireHealthBarRect;
        int claireHealth = 120;
            //Inventory variables
        bool inventoryOpen = false;
        Rectangle inventoryRect;
        Texture2D inventory;
            //Inventory Item variables
        Rectangle inventorykeyRect;
        Texture2D inventoryKey;
    //SOUND EFFECTS
        SoundEffect keySound;
        SoundEffect doorSound;
        SoundEffect ouchSound;
    //BACKGROUND MUSIC
        Song spookyMusic;
    //ENEMY VARIABLES
        float damageDelay = 500f;
        float damageElapsedTime;
    //CUT SCENE VARIABLES
        Texture2D talkingCharacter;
        Rectangle characterRect;
    //PLAYER CONTROLS VARIABLES
        int currentCharacter = 1;    
    //ANIMATION VARIABLES
            //Claire animation variables
        Texture2D claireRight, claireLeft, claireUp, claireDown, currentClaire;
        Rectangle sourceClaire;
        Rectangle claireRect;
        float claireDelay = 200f;
        int claireFrames = 0;
        float elapsed2;
            //Erika animation variables
        Texture2D erikaRight, erikaLeft, erikaUp, erikaDown, currentErika;
        Rectangle erikaRect;
        Rectangle sourceErika;
        float erikaElapsed;
        float erikaDelay = 200f;
        int erikaFrames = 0;
            //Mark animation variables
        Texture2D markRight, markLeft, markUp, markDown, currentMark;
        Rectangle markRect;
        Rectangle sourceMark;
        float markElasped;
        float markDelay = 200f;
        int markFrames = 0;
            //Kain animation variables
        Texture2D kainRight, kainLeft, kainUp, kainDown, currentKain;
        Rectangle kainRect;
        Rectangle sourceKain;
        float kainElapsed;
        float kainDelay = 200f;
        int kainFrames = 0;
            //Amy animation variables
        Texture2D amyRight, amyLeft, amyUp, amyDown, currentAmy;
        Rectangle amyRect;
        Rectangle sourceAmy;
        float amyElapsed;
        float amyDelay = 200f;
        int amyFrames = 0;
            //Enemy animation variables
        Texture2D deathRight, deathLeft, deathUp, deathDown, currentDeath;
        Rectangle deathRect;
        Rectangle sourceDeath;
        float deathElapsed;
        float deathDelay = 200f;
        int deathFrames = 0;
            //Dialog icon animation variables
        bool startIconAnimation = false;
        Texture2D dialogIcon, currentIcon;
        float iconElapsed;
        float iconDelay = 100f;
        Rectangle iconRect;
        Rectangle sourceIconRect;
        int iconFrames = 0;
            //Door animation variables
        bool doorOpen = false;
        float doorElapsed;
        float doorOpenElapsed;
        float doorDelay = 1500f;
        float doorAnimDelay1 = 500f;
        float doorAnimDelay2 = 1000f;
        Rectangle doorsourceRect = new Rectangle(32, 0, 32, 32);
        Rectangle doorRect;
        Texture2D doorAnim, currentDoorAnim;
            //Text animation variables
        int textinBox = 1;
        Rectangle textRect;
        SpriteFont font;
        String[] text = new String[2];
        String parsedText;
        String doorText;
        String typedText;
        double typedTextLength;
        int delayInMilliseconds;
        bool isDoneDrawing;
        bool showDialogBox = false;
            //Dialog Box
        Texture2D interacttextRect;
        Rectangle dialogRect;
        int interactBox = 1;



        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        protected override void Initialize()
        {
            currentKeyboardState = new KeyboardState();
            //Character Rectangles
            erikaRect = new Rectangle(500, 300, 34, 48);
            claireRect = new Rectangle(400, 300, 34, 48);
            markRect = new Rectangle(300, 300, 34, 48);
            amyRect = new Rectangle(200, 300, 34, 48);
            kainRect = new Rectangle(200, 250, 34, 48);
            //Item Rectangles
            keyRect = new Rectangle(400, 300, 15, 15);
            //Level Design Rectangles
            boxRect = new Rectangle(100, 300, 40, 40);
            doorRect = new Rectangle(300, 201, 40, 40);
            //Dialog Rectangles
            characterRect = new Rectangle(-100, 0, 384, 587);
            dialogRect = new Rectangle(140, 300, 600, 170);
            textRect = new Rectangle(145, 308, 600, 170);
            //Inventory Rectangles
            inventoryRect = new Rectangle(60, 0, 300, 300);
            inventorykeyRect = new Rectangle(85, 50, 40, 50);
            iconRect = new Rectangle(700, 448, 25, 25);
            //Menu Rectangles
            menuRect = new Rectangle(300, 80, 200, 50);
            menuOptionOneRect = new Rectangle(300, 150, 200, 50);
            menuOptionTwoRect = new Rectangle(300, 200, 200, 50);
            menuOptionThreeRect = new Rectangle(300, 250, 200, 50);
            //Health Bar Rectangles
            erikaHealthBarRect = new Rectangle(20, 20, 120, 20);
            erikaHealthRect = new Rectangle(33, 20, erikaHealth, 20);
            claireHealthBarRect = new Rectangle(20, 50, 120, 20);
            claireHealthRect = new Rectangle(33, 50, claireHealth, 20);
            //Enemy Rectangles
            deathRect = new Rectangle(300, 400, 40, 40);
            clsCollision = new CollisionCheck();

                base.Initialize();

        }

        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            levelOne = Content.Load<Texture2D>("Background");
            levelTwo = Content.Load<Texture2D>("Dungeon");
            gameOver = Content.Load<Texture2D>("GameOver");
            //Character Content
                //Erika
            erikaRight = Content.Load<Texture2D>("WalkingRight");
            erikaUp = Content.Load<Texture2D>("WalkingBack");
            erikaDown = Content.Load<Texture2D>("WalkingFront");
            erikaLeft = Content.Load<Texture2D>("WalkingLeft");
                //Claire
            claireUp = Content.Load<Texture2D>("ClaireBack");
            claireDown = Content.Load<Texture2D>("ClaireFront");
            claireRight = Content.Load<Texture2D>("ClaireRight");
            claireLeft = Content.Load<Texture2D>("ClaireLeft");
                //Amy
         /*   amyRight = Content.Load<Texture2D>("WalkingRight");
            amyUp = Content.Load<Texture2D>("WalkingUp");
            amyDown = Content.Load<Texture2D>("WalkingDown");
            amyLeft = Content.Load<Texture2D>("WalkingLeft"); 
                //Kain
            kainRight = Content.Load<Texture2D>("WalkingRight");
            kainUp = Content.Load<Texture2D>("WalkingUp");
            kainDown = Content.Load<Texture2D>("WalkingDown");
            kainLeft = Content.Load<Texture2D>("WalkingLeft");
                //Mark
            markRight = Content.Load<Texture2D>("WalkingRight");
            markUp = Content.Load<Texture2D>("WalkingUp");
            markDown = Content.Load<Texture2D>("WalkingDown");
            markLeft = Content.Load<Texture2D>("WalkingLeft"); */
                //Enemy
            deathRight = Content.Load<Texture2D>("DeathRight");
            deathLeft = Content.Load<Texture2D>("DeathLeft");
            deathDown = Content.Load<Texture2D>("DeathFront");
            deathUp = Content.Load<Texture2D>("DeathBack");
            //Door Content
            doorAnim = Content.Load<Texture2D>("Door");
            //Level Design Content
            box = Content.Load<Texture2D>("box");
            //Item Content
            key = Content.Load<Texture2D>("Key");
            //Inventory Content
            inventory = Content.Load<Texture2D>("inventoryBox");
            inventoryKey = Content.Load<Texture2D>("InventoryKey");
            //Menu Content
            menuSprite = Content.Load<Texture2D>("MenuImage");
            menuOptionOneSprite = Content.Load<Texture2D>("MenuOptionOne");
            menuOptionTwoSprite = Content.Load<Texture2D>("MenuOptionTwo");
            menuOptionThreeSprite = Content.Load<Texture2D>("MenuOptionThree");
            menuOptionOneSelectedSprite = Content.Load<Texture2D>("MenuOptionOneSelected");
            menuOptionTwoSelectedSprite = Content.Load<Texture2D>("MenuOptionTwoSelected");
            menuOptionThreeSelectedSprite = Content.Load<Texture2D>("MenuOptionThreeSelected");
            //Sound and Music Content
            doorSound = Content.Load<SoundEffect>("DoorOpen");
            keySound = Content.Load<SoundEffect>("KeySound");
            ouchSound = Content.Load<SoundEffect>("OuchSound");
            spookyMusic = Content.Load<Song>("Spooky");
            //Health Content
            erikaHealthBarText = Content.Load<Texture2D>("HealthBar");
            erikaHealthText = Content.Load<Texture2D>("ErikaHealth");
            claireHealthBarText = Content.Load<Texture2D>("HealthBar");
            claireHealthText = Content.Load<Texture2D>("ClaireHealth");
            //Dialog Content
            dialogIcon = Content.Load<Texture2D>("Crystal Heart");
            font = Content.Load<SpriteFont>("mySpriteFont");
            text[0] = "It's a box.";
            text[1] = "It's Locked.";
            
                
            
            
            talkingCharacter = Content.Load<Texture2D>("CharacterImage2");
            interacttextRect = Content.Load<Texture2D>("possible dialog box");


            parsedText = parseText(font, text[0]);
            doorText = parseText(font, text[1]);
            delayInMilliseconds = 50;
            isDoneDrawing = false;
            currentClaire = claireRight;
            currentErika = erikaRight;
            currentAmy = amyRight;
            currentKain = kainRight;
            currentMark = markRight;
            currentDeath = deathRight;
            currentDoorAnim = doorAnim;
            currentIcon = dialogIcon;
            MediaPlayer.Play(spookyMusic);
            MediaPlayer.IsRepeating = true;

        }

        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
//ANIMATION FOR ERIKA
        private void AnimateErika(GameTime gameTime)
        {
             erikaElapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

             if (erikaElapsed >= erikaDelay)
             {
                 if (erikaFrames >= 2)
                 {
                     erikaFrames = 0;
                 }
                 else
                 {
                     erikaFrames++;
                 }

                erikaElapsed = 0;
                sourceErika = new Rectangle(35 * erikaFrames, 0, 34, 48);
             }
        }
//ANIMATION FOR CLAIRE
        private void AnimateClaire(GameTime gameTime)
        {
            {
                elapsed2 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (elapsed2 >= claireDelay)
                {
                    if (claireFrames >= 3)
                    {
                        claireFrames = 0;
                    }
                    else
                    {
                        claireFrames++;
                    }

                    elapsed2 = 0;
                    sourceClaire = new Rectangle(46 * claireFrames, 0, 45, 70);
                }
            }
        }
//ANIMATION FOR MARK
        private void AnimateMark(GameTime gameTime)
        {
            {
                markElasped += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (markElasped >= markDelay)
                {
                    if (markFrames >= 3)
                    {
                        markFrames = 0;
                    }
                    else
                    {
                        markFrames++;
                    }

                    markElasped = 0;
                    sourceMark = new Rectangle(46 * markFrames, 0, 45, 70);
                }
            }
        }
//ANIMATION FOR AMY
        private void AnimateAmy(GameTime gameTime)
        {
            {
                amyElapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (amyElapsed >= amyDelay)
                {
                    if (amyFrames >= 3)
                    {
                        amyFrames = 0;
                    }
                    else
                    {
                        amyFrames++;
                    }

                    amyElapsed = 0;
                    sourceAmy = new Rectangle(46 * amyFrames, 0, 45, 70);
                }
            }
        }
//ANIMATION FOR KAIN
        private void AnimateKain(GameTime gameTime)
        {
            {
                kainElapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (kainElapsed >= kainDelay)
                {
                    if (kainFrames >= 3)
                    {
                        kainFrames = 0;
                    }
                    else
                    {
                        kainFrames++;
                    }

                    kainElapsed = 0;
                    sourceKain = new Rectangle(46 * kainFrames, 0, 45, 70);
                }
            }
        }
//ANIMATION FOR ENEMY
        private void AnimateDeath(GameTime gameTime)
        {
            {
                deathElapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (deathElapsed >= deathDelay)
                {
                    if (deathFrames >= 6)
                    {
                        deathFrames = 0;
                    }
                    else
                    {
                        deathFrames++;
                    }

                    deathElapsed = 0;
                    sourceDeath = new Rectangle(64 * deathFrames, 0, 64, 64);
                }
            }
        }
        //aniamtion for icon on corner of dialog box
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

        private void AnimateDoor(GameTime gameTime)
      {           
            doorOpenElapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if(doorOpenElapsed >= doorAnimDelay1 && doorOpenElapsed < doorAnimDelay2)
            {
               doorsourceRect = new Rectangle(64, 0, 32, 32);
            }

            if(doorOpenElapsed >= doorAnimDelay2)
            {
                doorsourceRect = new Rectangle(0, 0, 32, 32);
            }
       }
//code for text animation

        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            CollisionCheck clsCurrent;


            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            clsCurrent = clsCollision;

            clsCurrent.erikaRect = erikaRect;
            clsCurrent.claireRect = claireRect;
            clsCurrent.currentCharacter = currentCharacter;
            clsCurrent.currentLevel = currentLevel;
            clsCurrent.boxRect = boxRect;
            clsCurrent.keyRect = keyRect;
            clsCurrent.deathRect = deathRect;

            erikaHealthRect.Width = erikaHealth;
            claireHealthRect.Width = claireHealth;

            damageElapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


//Game menu options code
            if (currentKeyboardState.IsKeyUp(Keys.Escape) && oldKeyboardState.IsKeyDown(Keys.Escape) && menuOption == 0)
            {
                menuOption = 1;
            }
            else if (currentKeyboardState.IsKeyUp(Keys.Escape) && oldKeyboardState.IsKeyDown(Keys.Escape) && (menuOption == 1 || menuOption == 2 || menuOption == 3))
            {
                menuOption = 0;
            }

            if (menuOption == 1 && currentKeyboardState.IsKeyUp(Keys.Enter) && oldKeyboardState.IsKeyDown(Keys.Enter))
            {
                Exit();
            }

            if (menuOption == 2 && currentKeyboardState.IsKeyUp(Keys.Enter) && oldKeyboardState.IsKeyDown(Keys.Enter))
            {
                SaveGame();
                menuOption = 0;
            }

            if (menuOption == 3 && currentKeyboardState.IsKeyUp(Keys.Enter) && oldKeyboardState.IsKeyDown(Keys.Enter))
            {
                LoadGame();
                menuOption = 0;
            }

            if (menuOption == 1 && currentKeyboardState.IsKeyUp(Keys.Down) && oldKeyboardState.IsKeyDown(Keys.Down))
            {
                menuOption = 2;
            }
                else if (menuOption == 2 && currentKeyboardState.IsKeyUp(Keys.Down) && oldKeyboardState.IsKeyDown(Keys.Down))
                {
                    menuOption = 3;
                }
                    else if (menuOption == 3 && currentKeyboardState.IsKeyUp(Keys.Down) && oldKeyboardState.IsKeyDown(Keys.Down))
                    {
                        menuOption = 1;
                    }
                        else if (menuOption == 1 && currentKeyboardState.IsKeyUp(Keys.Up) && oldKeyboardState.IsKeyDown(Keys.Up))
                        {
                            menuOption = 3;
                        }
                            else if (menuOption == 3 && currentKeyboardState.IsKeyUp(Keys.Up) && oldKeyboardState.IsKeyDown(Keys.Up))
                            {
                                menuOption = 2;
                            }
                                else if (menuOption == 2 && currentKeyboardState.IsKeyUp(Keys.Up) && oldKeyboardState.IsKeyDown(Keys.Up))
                                {
                                    menuOption = 1;
                                }

                if (!isDoneDrawing)
                {
                    if (delayInMilliseconds == 0)
                    {
                        if(textinBox == 2)
                        {
                            typedText = parsedText;
                            
                        }
                        if(textinBox == 3)
                        {
                            typedText = doorText;
                            
                        }
                        isDoneDrawing = true;
                    }
                    else if (typedTextLength < parsedText.Length)
                    {
                        if (textinBox == 2)
                        {
                            Console.WriteLine("Box");
                            typedTextLength = typedTextLength + gameTime.ElapsedGameTime.TotalMilliseconds / delayInMilliseconds;

                            if (typedTextLength >= parsedText.Length)
                            {
                                typedTextLength = parsedText.Length;
                                isDoneDrawing = true;
                                startIconAnimation = true;
                                AnimateIcon(gameTime);
                            }
                            typedText = parsedText.Substring(0, (int)typedTextLength);
                        }
                        if (textinBox == 3)
                        {
                            Console.WriteLine("Door");
                            typedTextLength = typedTextLength + gameTime.ElapsedGameTime.TotalMilliseconds / delayInMilliseconds;

                            if (typedTextLength >= doorText.Length)
                            {
                                typedTextLength = doorText.Length;
                                isDoneDrawing = true;
                                startIconAnimation = true;
                                AnimateIcon(gameTime);
                            }

                            typedText = doorText.Substring(0, (int)typedTextLength); 
                        }
                        if(textinBox == 1)
                        {
                            typedText = parsedText.Substring(0, (int)typedTextLength);
                        } 
                    }
                }
            


            // Call collision class module
            clsCurrent.PerformCollisionCheck();
            // Move character up when W is pressed                

            if(Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                currentCharacter = 2;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                currentCharacter = 1;
            }
//first character is played by default
            if(currentCharacter == 1)
            {
                if ((Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)) && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
                {
                    currentErika = erikaUp;

                    if (erikaRect.Y > 0 && clsCurrent.boxHitBottom == false && clsCurrent.wallHitBottom == false)
                    {
                        erikaRect.Y -= 2;
                        AnimateErika(gameTime);
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    {
                        if(erikaRect.Y > 0 && clsCurrent.boxHitBottom == false && clsCurrent.wallHitBottom == false)
                        {
                            erikaRect.Y -= 4;
                        } 
                    }
                }

               // Move character right when A is pressed
                else if ((Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left)) && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
                {
                    currentErika = erikaLeft;

                    if (erikaRect.X > 0 && clsCurrent.boxHitRight == false && clsCurrent.wallHitRight == false)
                    {
                        erikaRect.X -= 2;
                        AnimateErika(gameTime);
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift)) 
                    {
                        if(erikaRect.X > 0 && clsCurrent.boxHitRight == false && clsCurrent.wallHitRight == false)
                        {
                            erikaRect.X -= 4;
                        } 
                    }
                }

                // Move character down when S is pressed
                else if ((Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)) && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
                {
                    currentErika = erikaDown;

                    if (erikaRect.Y < 440 && clsCurrent.boxHitTop == false && clsCurrent.wallHitTop == false)
                    {
                        erikaRect.Y += 2;
                        AnimateErika(gameTime);
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    {
                        if(erikaRect.Y < 440 && clsCurrent.boxHitTop == false && clsCurrent.wallHitTop == false)
                        {
                            erikaRect.Y += 4;
                        }
                    }
                }

                // Move character right when D is pressed
                else if ((Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right)) && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
                {
                    currentErika = erikaRight;

                    if (erikaRect.X < 775 && clsCurrent.boxHitLeft == false && clsCurrent.wallHitLeft == false)
                    {
                        erikaRect.X += 2;
                        AnimateErika(gameTime);
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift)) 
                    {
                        if(erikaRect.X < 775 && clsCurrent.boxHitLeft == false && clsCurrent.wallHitLeft == false)
                        {
                            erikaRect.X += 4;
                        }
                    }
                }
                else
                {
                    sourceErika = new Rectangle(34, 0, 34, 48);
                    sourceClaire = new Rectangle(0, 0, 45, 70);
                }

            }
//character two is played when left 2 is pressed
            if(currentCharacter == 2)
            {
                if ((Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)) && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
                {
                    currentClaire = claireUp;

                    if (claireRect.Y > 0 && clsCurrent.boxHitBottom == false && clsCurrent.wallHitBottom == false)
                    {
                        claireRect.Y -= 2;
                        AnimateClaire(gameTime);
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    {
                        if(claireRect.Y > 0 && clsCurrent.boxHitBottom == false && clsCurrent.wallHitBottom == false)
                        {
                            claireRect.Y -= 4;
                        }
                    }
                }

              // Move character left when A is pressed
                else if ((Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left)) && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
                {
                    currentClaire = claireLeft;

                    if (claireRect.X > 0 && clsCurrent.boxHitRight == false && clsCurrent.wallHitRight == false)
                    {
                        claireRect.X -= 2;
                        AnimateClaire(gameTime);
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    {
                        if(claireRect.X > 0 && clsCurrent.boxHitRight == false && clsCurrent.wallHitRight == false)
                        {
                            claireRect.X -= 4;
                        }
                    }
                }

                // Move character down when S is pressed
                else if ((Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)) && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
                {
                    currentClaire = claireDown;

                    if (claireRect.Y < 440 && clsCurrent.boxHitTop == false && clsCurrent.wallHitTop == false)
                    {
                        claireRect.Y += 2;
                        AnimateClaire(gameTime);
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    {
                        if(claireRect.Y < 440 && clsCurrent.boxHitTop == false && clsCurrent.wallHitTop == false)
                        {
                            claireRect.Y += 4;
                        }
                    }
                }

                // Move character right when D is pressed
                else if ((Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right)) && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
                {
                    currentClaire = claireRight;

                    if (claireRect.X < 775 && clsCurrent.boxHitLeft == false && clsCurrent.wallHitLeft == false)
                    {
                        claireRect.X += 2;
                        AnimateClaire(gameTime);
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift)) 
                    {
                        if(claireRect.X < 775 && clsCurrent.boxHitLeft == false && clsCurrent.wallHitLeft == false)
                        {
                            claireRect.X += 4;
                        }
                    }
                }
                else
                {
                    sourceClaire = new Rectangle(0, 0, 45, 70);
                }
            }
            

// Opens door when "Spacebar" is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && erikaRect.Y > doorRect.Y && erikaRect.Y < (doorRect.Y + 30) && erikaRect.X > (doorRect.X - 10) && erikaRect.X < (doorRect.X + 20) && currentCharacter == 1 && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false && currentLevel == 1 && hasKey == 2)
            {
                doorSound.Play();
                doorOpen = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && claireRect.Y > doorRect.Y && claireRect.Y < (doorRect.Y + 30) && claireRect.X > (doorRect.X - 10) && claireRect.X < (doorRect.X + 20) && currentCharacter == 2 && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false && currentLevel == 1 && hasKey == 2)
            {
                doorSound.Play();
                doorOpen = true;
            }

            if (currentKeyboardState.IsKeyUp(Keys.Space) && oldKeyboardState.IsKeyDown(Keys.Space) && showDialogBox == false && hasKey == 1 && erikaRect.Y > doorRect.Y && erikaRect.Y < (doorRect.Y + 30) && erikaRect.X > (doorRect.X - 10) && erikaRect.X < (doorRect.X + 20) && currentCharacter == 1 && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false && currentLevel == 1)
            {
                interactBox = 3;
                Console.WriteLine("Text in box");
            }
            else if (currentKeyboardState.IsKeyUp(Keys.Space) && oldKeyboardState.IsKeyDown(Keys.Space) && interactBox == 3 && currentCharacter == 1) 
            {
                interactBox = 1;
                typedTextLength = 0;
                isDoneDrawing = false;
            }

            if (currentKeyboardState.IsKeyUp(Keys.Space) && oldKeyboardState.IsKeyDown(Keys.Space) && showDialogBox == false && hasKey == 1 && claireRect.Y > doorRect.Y && claireRect.Y < (doorRect.Y + 30) && claireRect.X > (doorRect.X - 10) && claireRect.X < (doorRect.X + 20) && currentCharacter == 2 && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false && currentLevel == 1)
            {
                interactBox = 3;
                Console.WriteLine("Text in box");
            }
            else if (currentKeyboardState.IsKeyUp(Keys.Space) && oldKeyboardState.IsKeyDown(Keys.Space) && interactBox == 3 && currentCharacter == 2)
            {
                interactBox = 1;
                typedTextLength = 0;
                isDoneDrawing = false;
            }

            if (doorOpen == false)
            {
                doorsourceRect = new Rectangle(32, 0, 32, 32);
            }

            if (doorOpen == true)
            {
                doorElapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                currentDoorAnim = doorAnim;
                AnimateDoor(gameTime);
            }

            if (doorElapsed >= doorDelay)
            {
                doorOpenElapsed = 0;
                doorOpen = false;
                erikaRect = new Rectangle(360, 410, 34, 48);
                claireRect = new Rectangle(360, 410, 34, 48);
                boxRect = new Rectangle(300, 200, 40, 40);
                deathRect = new Rectangle(0, 0, 0, 0);
                currentLevel = 2;
                doorElapsed = 0;
            }

            if (currentLevel == 2 && (erikaRect.Y > 415 || claireRect.Y > 415))
            {
                currentLevel = 1;
                erikaRect = new Rectangle((doorRect.X + 5), (doorRect.Y + 20), 34, 48);
                claireRect = new Rectangle((doorRect.X + 5), (doorRect.Y + 20), 34, 48);
                boxRect = new Rectangle(100, 300, 40, 40);
                deathRect = new Rectangle(300, 400, 40, 40);
            }


            //interacting with boxes
            if(interactBox == 3)
            {
                showDialogBox = true;
                textinBox = 3;
            }

            if (interactBox == 2)
            {
                showDialogBox = true;
                //startIconAnimation = true;
                textinBox = 2;
            }
            if (interactBox == 1)
            {
                delayInMilliseconds = 50;
                startIconAnimation = false;
                showDialogBox = false;
                textinBox = 1;
            }


            if (currentKeyboardState.IsKeyUp(Keys.Space) && oldKeyboardState.IsKeyDown(Keys.Space) && interactBox == 1 && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
            {
                if (clsCurrent.boxHitBottom == true || clsCurrent.boxHitLeft == true || clsCurrent.boxHitTop == true || clsCurrent.boxHitRight == true)
                {
                    interactBox = 2;
                }
            }
            else if (currentKeyboardState.IsKeyUp(Keys.Space) && oldKeyboardState.IsKeyDown(Keys.Space) && interactBox == 2)
            {
                interactBox = 1;
                typedTextLength = 0;
                isDoneDrawing = false;
            }

//Follow code for character 1
            if (currentCharacter == 1 && claireHealth > 0)
            {
                if ((claireRect.X - 40) >= erikaRect.X)
                {
                    currentClaire = claireLeft;
                    AnimateClaire(gameTime);
                    claireRect.X -= 2;

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    {
                        claireRect.X -= 4;
                    }
                    if (erikaRect.Y > claireRect.Y)
                    {
                        claireRect.Y += 2;
                    }

                    if (erikaRect.Y < claireRect.Y)
                    {
                        claireRect.Y -= 2;
                    }
                }

                if ((claireRect.X + 40) <= erikaRect.X)
                {
                    currentClaire = claireRight;
                    AnimateClaire(gameTime);
                    claireRect.X += 2;

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    {
                        claireRect.X += 4;
                    }

                    if (erikaRect.Y > claireRect.Y)
                    {
                        claireRect.Y += 2;
                    }

                    if (erikaRect.Y < claireRect.Y)
                    {
                        claireRect.Y -= 2;
                    }
                }

                if ((claireRect.Y - 40) >= erikaRect.Y)
                {
                    currentClaire = claireUp;
                    AnimateClaire(gameTime);
                    claireRect.Y -= 2;

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    {
                        claireRect.Y -= 4;
                    }

                    if (erikaRect.X > claireRect.X)
                    {
                        claireRect.X += 2;
                    }

                    if (erikaRect.X < claireRect.X)
                    {
                        claireRect.X -= 2;
                    }
                }

                if ((claireRect.Y + 40) <= erikaRect.Y)
                {
                    currentClaire = claireDown;
                    AnimateClaire(gameTime);
                    claireRect.Y += 2;

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    {
                        claireRect.Y += 4;
                    }

                    if (erikaRect.X > claireRect.X)
                    {
                        claireRect.X += 2;
                    }

                    if (erikaRect.X < claireRect.X)
                    {
                        claireRect.X -= 2;
                    }
                }
            }

// Follow code for character 2
            if (currentCharacter == 2 && erikaHealth > 0)
            {
                if ((erikaRect.X - 40) >= claireRect.X)
                {
                    currentErika = erikaLeft;
                    AnimateErika(gameTime);
                    erikaRect.X -= 2;

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    {
                        erikaRect.X -= 4;
                    }
                    if (claireRect.Y > erikaRect.Y)
                    {
                        erikaRect.Y += 2;
                    }

                    if (claireRect.Y < erikaRect.Y)
                    {
                        erikaRect.Y -= 2;
                    }
                }

                if ((erikaRect.X + 40) <= claireRect.X)
                {
                    currentErika = erikaRight;
                    AnimateErika(gameTime);
                    erikaRect.X += 2;

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    {
                        erikaRect.X += 4;
                    }

                    if (claireRect.Y > erikaRect.Y)
                    {
                        erikaRect.Y += 2;
                    }

                    if (claireRect.Y < erikaRect.Y)
                    {
                        erikaRect.Y -= 2;
                    }
                }

                if ((erikaRect.Y - 40) >= claireRect.Y)
                {
                    currentErika = erikaUp;
                    AnimateErika(gameTime);
                    erikaRect.Y -= 2;

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    {
                        erikaRect.Y -= 4;
                    }

                    if (claireRect.X > erikaRect.X)
                    {
                        erikaRect.X += 2;
                    }

                    if (claireRect.X < erikaRect.X)
                    {
                        erikaRect.X -= 2;
                    }
                }

                if ((erikaRect.Y + 40) <= claireRect.Y)
                {
                    currentErika = erikaDown;
                    AnimateErika(gameTime);
                    erikaRect.Y += 2;

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    {
                        erikaRect.Y += 4;
                    }

                    if (claireRect.X > erikaRect.X)
                    {
                        erikaRect.X += 2;
                    }

                    if (claireRect.X < erikaRect.X)
                    {
                        erikaRect.X -= 2;
                    }
                }
            }

//Monster follow code for first character
            if(currentCharacter == 1 && currentLevel == 1)
            {
                if (doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
                {
                    if (deathRect.X > erikaRect.X)
                    {
                        currentDeath = deathLeft;
                        AnimateDeath(gameTime);
                        deathRect.X -= 1;
                        Console.WriteLine("Going Left");
                    }

                    if (deathRect.X < erikaRect.X)
                    {
                        currentDeath = deathRight;
                        AnimateDeath(gameTime);
                        deathRect.X += 1;
                        Console.WriteLine("Going Right");
                    }

                    if (deathRect.Y > erikaRect.Y)
                    {
                        currentDeath = deathUp;
                        AnimateDeath(gameTime);
                        deathRect.Y -= 1;
                        Console.WriteLine("Going Up");
                    }

                    if (deathRect.Y < erikaRect.Y)
                    {
                        currentDeath = deathDown;
                        AnimateDeath(gameTime);
                        deathRect.Y += 1;
                        Console.WriteLine("Going Down");
                    }
                }
            }

//Monster second character follow code
            if (currentCharacter == 2 && currentLevel == 1)
            {
                if (deathRect.X >= claireRect.X && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
                {
                    currentDeath = deathLeft;
                    AnimateDeath(gameTime);
                    deathRect.X -= 1;
                }

                if (deathRect.X <= claireRect.X && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
                {
                    currentDeath = deathRight;
                    AnimateDeath(gameTime);
                    deathRect.X += 1;
                }

                if (deathRect.Y >= claireRect.Y && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
                {
                    currentDeath = deathUp;
                    AnimateDeath(gameTime);
                    deathRect.Y -= 1;
                }

                if (deathRect.Y <= claireRect.Y && doorOpen == false && menuOption == 0 && inventoryOpen == false && showDialogBox == false)
                {
                    currentDeath = deathDown;
                    AnimateDeath(gameTime);
                    deathRect.Y += 1;
                }
            }

// Code for getting hurt by things that hurt
            if (currentCharacter == 1)
            {
                if (clsCurrent.deathCollisionRight == true && erikaHealth > 0 && damageElapsedTime >= damageDelay && inventoryOpen == false && doorOpen == false && menuOption == 0 && showDialogBox == false)
                {
                    erikaHealth -= 20;
                    ouchSound.Play();
                    damageElapsedTime = 0;

                    if (clsCurrent.boxHitBottom == false && clsCurrent.boxHitTop == false && clsCurrent.boxHitLeft == false && clsCurrent.boxHitRight == false && clsCurrent.wallHitBottom == false && clsCurrent.wallHitTop == false && clsCurrent.wallHitLeft == false && clsCurrent.wallHitRight == false)
                    {
                        int testPositionX = ((erikaRect.X + erikaRect.Width) + 30);

                        if (testPositionX > 800 && currentLevel == 1)
                        {
                            erikaRect.X = (800 - erikaRect.Width);
                        }
                        else
                        {
                            erikaRect.X += 30;
                        }
                    }
                }

                if (clsCurrent.deathCollisionLeft == true && erikaHealth > 0 && damageElapsedTime >= damageDelay && inventoryOpen == false && doorOpen == false && menuOption == 0 && showDialogBox == false)
                {
                    erikaHealth -= 20;
                    ouchSound.Play();
                    damageElapsedTime = 0;

                    if (clsCurrent.boxHitBottom == false && clsCurrent.boxHitTop == false && clsCurrent.boxHitLeft == false && clsCurrent.boxHitRight == false && clsCurrent.wallHitBottom == false && clsCurrent.wallHitTop == false && clsCurrent.wallHitLeft == false && clsCurrent.wallHitRight == false)
                    {
                        int testPositionX = (erikaRect.X - 30);

                        if (testPositionX < 1 && currentLevel == 1)
                        {
                            erikaRect.X = 1;
                        }
                        else
                        {
                            erikaRect.X -= 30;
                        }
                    }
                }

                if (clsCurrent.deathCollisionTop == true && erikaHealth > 0 && damageElapsedTime >= damageDelay && inventoryOpen == false && doorOpen == false && menuOption == 0 && showDialogBox == false)
                {
                    erikaHealth -= 20;
                    ouchSound.Play();
                    damageElapsedTime = 0;

                    if (clsCurrent.boxHitBottom == false && clsCurrent.boxHitTop == false && clsCurrent.boxHitLeft == false && clsCurrent.boxHitRight == false && clsCurrent.wallHitBottom == false && clsCurrent.wallHitTop == false && clsCurrent.wallHitLeft == false && clsCurrent.wallHitRight == false)
                    {
                        int testPositionY = (erikaRect.Y - 30);

                        if (testPositionY < 220 && currentLevel == 1)
                        {
                            erikaRect.Y = 220;
                        }
                        else
                        {
                            erikaRect.Y -= 30;
                        }
                    }
                }

                if (clsCurrent.deathCollisionBottom == true && erikaHealth > 0 && damageElapsedTime >= damageDelay && inventoryOpen == false && doorOpen == false && menuOption == 0 && showDialogBox == false)
                {
                    erikaHealth -= 20;
                    ouchSound.Play();
                    damageElapsedTime = 0;

                    if (clsCurrent.boxHitBottom == false && clsCurrent.boxHitTop == false && clsCurrent.boxHitLeft == false && clsCurrent.boxHitRight == false && clsCurrent.wallHitBottom == false && clsCurrent.wallHitTop == false && clsCurrent.wallHitLeft == false && clsCurrent.wallHitRight == false)
                    {
                        erikaRect.Y += 30;
                    }
                }
            }

            if (currentCharacter == 2)
            {
                if (clsCurrent.deathCollisionRight == true && claireHealth > 0 && damageElapsedTime >= damageDelay && inventoryOpen == false && doorOpen == false && menuOption == 0 && showDialogBox == false)
                {
                    claireHealth -= 20;
                    ouchSound.Play();
                    damageElapsedTime = 0;

                    if (clsCurrent.boxHitBottom == false && clsCurrent.boxHitTop == false && clsCurrent.boxHitLeft == false && clsCurrent.boxHitRight == false && clsCurrent.wallHitBottom == false && clsCurrent.wallHitTop == false && clsCurrent.wallHitLeft == false && clsCurrent.wallHitRight == false)
                    {
                        claireRect.X += 30;
                    }
                }

                if (clsCurrent.deathCollisionLeft == true && claireHealth > 0 && damageElapsedTime >= damageDelay && inventoryOpen == false && doorOpen == false && menuOption == 0 && showDialogBox == false)
                {
                    claireHealth -= 20;
                    ouchSound.Play();
                    damageElapsedTime = 0;

                    if (clsCurrent.boxHitBottom == false && clsCurrent.boxHitTop == false && clsCurrent.boxHitLeft == false && clsCurrent.boxHitRight == false && clsCurrent.wallHitBottom == false && clsCurrent.wallHitTop == false && clsCurrent.wallHitLeft == false && clsCurrent.wallHitRight == false)
                    {
                        claireRect.X -= 30;
                    }
                }

                if (clsCurrent.deathCollisionTop == true && erikaHealth > 0 && damageElapsedTime >= damageDelay && inventoryOpen == false && doorOpen == false && menuOption == 0 && showDialogBox == false)
                {
                    claireHealth -= 20;
                    ouchSound.Play();
                    damageElapsedTime = 0;

                    if (clsCurrent.boxHitBottom == false && clsCurrent.boxHitTop == false && clsCurrent.boxHitLeft == false && clsCurrent.boxHitRight == false && clsCurrent.wallHitBottom == false && clsCurrent.wallHitTop == false && clsCurrent.wallHitLeft == false && clsCurrent.wallHitRight == false)
                    {
                        claireRect.Y -= 30;
                    }
                }

                if (clsCurrent.deathCollisionBottom == true && erikaHealth > 0 && damageElapsedTime >= damageDelay && inventoryOpen == false && doorOpen == false && menuOption == 0 && showDialogBox == false)
                {
                    claireHealth -= 20;
                    ouchSound.Play();
                    damageElapsedTime = 0;

                    if (clsCurrent.boxHitBottom == false && clsCurrent.boxHitTop == false && clsCurrent.boxHitLeft == false && clsCurrent.boxHitRight == false && clsCurrent.wallHitBottom == false && clsCurrent.wallHitTop == false && clsCurrent.wallHitLeft == false && clsCurrent.wallHitRight == false)
                    {
                        claireRect.Y += 30;
                    }
                }
            }

            if (erikaHealth <= 0)
            {
                currentCharacter = 2;
            }

            if (claireHealth <= 0)
            {
                currentCharacter = 1;
            }

            if (erikaHealth <= 0 && claireHealth <= 0)
            {
                currentCharacter = 0;
            }

            /*if (clsCurrent.boxHitRight == true && erikaHealth < 120)
            {
                erikaHealth += 2;
                Console.WriteLine("Aw yeah");
            }*/

// Code for picking up the key
            if(Keyboard.GetState().IsKeyDown(Keys.Space) && clsCurrent.keyCollision == true && hasKey == 1)
            {
                hasKey = 2;
                keySound.Play();
            }

// Code for opening the inventory
            if (currentKeyboardState.IsKeyUp(Keys.I) && oldKeyboardState.IsKeyDown(Keys.I) && inventoryOpen == false && doorOpen == false && menuOption == 0 && showDialogBox == false)
            {
                inventoryOpen = true;
            }
            else if (currentKeyboardState.IsKeyUp(Keys.I) && oldKeyboardState.IsKeyDown(Keys.I) && inventoryOpen == true)
            {
                inventoryOpen = false;
            }

            base.Update(gameTime);
            }

        // Function for saving the game variables
        private void SaveGame()
        {
            string sPath = Environment.CurrentDirectory + @"\scarytime.txt";
            string[] sLines = new string[9];

            if (System.IO.File.Exists(sPath) == false)
            {
                System.IO.File.Create(sPath).Close();
            }
            sLines[0] = currentLevel.ToString();
            sLines[1] = claireRect.X.ToString() + "," + claireRect.Y;
            sLines[2] = erikaRect.X.ToString() + "," + erikaRect.Y;
            sLines[3] = hasKey.ToString();
            sLines[4] = erikaHealth.ToString();
            sLines[5] = claireHealth.ToString();
            sLines[6] = boxRect.X.ToString() + "," + boxRect.Y;
            sLines[7] = deathRect.X.ToString() + "," + deathRect.Y;
            sLines[8] = currentCharacter.ToString();

            System.IO.File.WriteAllLines(sPath, sLines);
        }

        // Function for loading the saved game variables
        private void LoadGame()
        {
            string sPath = Environment.CurrentDirectory + @"\scarytime.txt";
            char[] chrDelim = {','};
            string[] sLines = new string[6];
            string[] sCoor;

            if (System.IO.File.Exists(sPath) == false)
            {
                return;
            }

            sLines = System.IO.File.ReadAllLines(sPath);

            if (sLines.Length == 0)
            {
                return;
            }
            
            currentLevel = Convert.ToInt32(sLines[0]);

            sCoor = sLines[1].Split(chrDelim);
            claireRect.X = Convert.ToInt32(sCoor[0]);
            claireRect.Y = Convert.ToInt32(sCoor[1]);

            sCoor = sLines[2].Split(chrDelim);
            erikaRect.X = Convert.ToInt32(sCoor[0]);
            erikaRect.Y = Convert.ToInt32(sCoor[1]);

            sCoor = sLines[6].Split(chrDelim);
            boxRect.X = Convert.ToInt32(sCoor[0]);
            boxRect.Y = Convert.ToInt32(sCoor[1]);

            sCoor = sLines[7].Split(chrDelim);
            deathRect.X = Convert.ToInt32(sCoor[0]);
            deathRect.Y = Convert.ToInt32(sCoor[1]);

            hasKey = Convert.ToInt32(sLines[3]);
            erikaHealth = Convert.ToInt32(sLines[4]);
            claireHealth = Convert.ToInt32(sLines[5]);

            currentCharacter = Convert.ToInt32(sLines[8]);
        }

        /// This is called when the game should draw itself.
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code

            if(currentLevel == 0)
            {
                GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin();

                spriteBatch.End();
            }

            if (currentLevel == 1 && (currentCharacter == 1 || currentCharacter == 2))
            {
                GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin();
                spriteBatch.Draw(levelOne, GraphicsDevice.Viewport.Bounds, Color.White);
                spriteBatch.Draw(box, boxRect, Color.White);
                spriteBatch.Draw(currentDeath, deathRect, sourceDeath, Color.White);
                spriteBatch.Draw(currentDoorAnim, doorRect, doorsourceRect, Color.White);
                spriteBatch.Draw(erikaHealthBarText, erikaHealthBarRect, Color.White);
                spriteBatch.Draw(erikaHealthText, erikaHealthRect, Color.White);
                spriteBatch.Draw(claireHealthBarText, claireHealthBarRect, Color.White);
                spriteBatch.Draw(claireHealthText, claireHealthRect, Color.White);

                if (hasKey == 1)
                {
                    spriteBatch.Draw(key, keyRect, Color.White);
                }
                if (erikaRect.Y <= claireRect.Y)
                {
                    spriteBatch.Draw(currentErika, erikaRect, sourceErika, Color.White);
                    spriteBatch.Draw(currentClaire, claireRect, sourceClaire, Color.White);
                }
                if (erikaRect.Y > claireRect.Y)
                {
                    spriteBatch.Draw(currentClaire, claireRect, sourceClaire, Color.White);
                    spriteBatch.Draw(currentErika, erikaRect, sourceErika, Color.White);
                }

                if (showDialogBox == true)
                {
                    spriteBatch.Draw(interacttextRect, dialogRect, Color.White);
                }

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
                if (textinBox == 3)
                {
                    spriteBatch.DrawString(font, typedText, new Vector2(textRect.X, textRect.Y), Color.White);
                }

                // Code for the inventory
                if (inventoryOpen == true)
                {
                    spriteBatch.Draw(inventory, inventoryRect, Color.White);

                    if (hasKey == 2)
                    {
                        spriteBatch.Draw(inventoryKey, inventorykeyRect, Color.White);
                    }
                }

                if (menuOption == 1)
                {
                    spriteBatch.Draw(menuSprite, menuRect, Color.White);
                    spriteBatch.Draw(menuOptionOneSelectedSprite, menuOptionOneRect, Color.White);
                    spriteBatch.Draw(menuOptionTwoSprite, menuOptionTwoRect, Color.White);
                    spriteBatch.Draw(menuOptionThreeSprite, menuOptionThreeRect, Color.White);
                }

                if (menuOption == 2)
                {
                    spriteBatch.Draw(menuSprite, menuRect, Color.White);
                    spriteBatch.Draw(menuOptionOneSprite, menuOptionOneRect, Color.White);
                    spriteBatch.Draw(menuOptionTwoSelectedSprite, menuOptionTwoRect, Color.White);
                    spriteBatch.Draw(menuOptionThreeSprite, menuOptionThreeRect, Color.White);
                }

                if (menuOption == 3)
                {
                    spriteBatch.Draw(menuSprite, menuRect, Color.White);
                    spriteBatch.Draw(menuOptionOneSprite, menuOptionOneRect, Color.White);
                    spriteBatch.Draw(menuOptionTwoSprite, menuOptionTwoRect, Color.White);
                    spriteBatch.Draw(menuOptionThreeSelectedSprite, menuOptionThreeRect, Color.White);
                }

                //spriteBatch.Draw(talkingCharacter, characterRect, Color.White);
                spriteBatch.End();
            }

            if (currentLevel == 2 && (currentCharacter == 1 || currentCharacter == 2))
            {
                GraphicsDevice.Clear(Color.Black);

                spriteBatch.Begin();
                spriteBatch.Draw(levelTwo, GraphicsDevice.Viewport.Bounds, Color.White);
                spriteBatch.Draw(box, boxRect, Color.White);
                spriteBatch.Draw(erikaHealthBarText, erikaHealthBarRect, Color.White);
                spriteBatch.Draw(erikaHealthText, erikaHealthRect, Color.White);
                spriteBatch.Draw(claireHealthBarText, claireHealthBarRect, Color.White);
                spriteBatch.Draw(claireHealthText, claireHealthRect, Color.White);

                if (erikaRect.Y <= claireRect.Y)
                {
                    spriteBatch.Draw(currentErika, erikaRect, sourceErika, Color.White);
                    spriteBatch.Draw(currentClaire, claireRect, sourceClaire, Color.White);
                }
                if (erikaRect.Y > claireRect.Y)
                {
                    spriteBatch.Draw(currentClaire, claireRect, sourceClaire, Color.White);
                    spriteBatch.Draw(currentErika, erikaRect, sourceErika, Color.White);
                }
                if(showDialogBox == true)
                {
                    spriteBatch.Draw(interacttextRect, dialogRect, Color.White);
                }
                
                if (textinBox == 2 || textinBox == 3)
                {
                    spriteBatch.DrawString(font, typedText, new Vector2(textRect.X, textRect.Y), Color.White);
                }

                if(startIconAnimation == true)
                {
                    spriteBatch.Draw(dialogIcon, iconRect, sourceIconRect, Color.White);
                    currentIcon = dialogIcon;
                    AnimateIcon(gameTime);
                }

                // Code for the inventory
                if (inventoryOpen == true)
                {
                    spriteBatch.Draw(inventory, inventoryRect, Color.White);

                    if (hasKey == 2)
                    {
                        spriteBatch.Draw(inventoryKey, inventorykeyRect, Color.White);
                    }
                }

                if (menuOption == 1)
                {
                    spriteBatch.Draw(menuSprite, menuRect, Color.White);
                    spriteBatch.Draw(menuOptionOneSelectedSprite, menuOptionOneRect, Color.White);
                    spriteBatch.Draw(menuOptionTwoSprite, menuOptionTwoRect, Color.White);
                    spriteBatch.Draw(menuOptionThreeSprite, menuOptionThreeRect, Color.White);
                }

                if (menuOption == 2)
                {
                    spriteBatch.Draw(menuSprite, menuRect, Color.White);
                    spriteBatch.Draw(menuOptionOneSprite, menuOptionOneRect, Color.White);
                    spriteBatch.Draw(menuOptionTwoSelectedSprite, menuOptionTwoRect, Color.White);
                    spriteBatch.Draw(menuOptionThreeSprite, menuOptionThreeRect, Color.White);
                }

                if (menuOption == 3)
                {
                    spriteBatch.Draw(menuSprite, menuRect, Color.White);
                    spriteBatch.Draw(menuOptionOneSprite, menuOptionOneRect, Color.White);
                    spriteBatch.Draw(menuOptionTwoSprite, menuOptionTwoRect, Color.White);
                    spriteBatch.Draw(menuOptionThreeSelectedSprite, menuOptionThreeRect, Color.White);
                }

                spriteBatch.End();

                base.Draw(gameTime);
            }

            if (currentCharacter == 0)
            {
                GraphicsDevice.Clear(Color.Black);

                spriteBatch.Begin();
                spriteBatch.Draw(gameOver, GraphicsDevice.Viewport.Bounds, Color.White);
                spriteBatch.End();
            }
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
  
