using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Scary_Time
{
    class CollisionCheck
    {
        public Rectangle erikaRect;
        public Rectangle claireRect;
        public int currentCharacter;
        public Rectangle boxRect;
        public Rectangle keyRect;
        public Rectangle deathRect;
        public int currentLevel;
        public bool boxHitBottom;
        public bool boxHitTop;
        public bool boxHitLeft;
        public bool boxHitRight;
        public bool keyCollision;
        public bool wallHitBottom;
        public bool wallHitTop;
        public bool wallHitLeft;
        public bool wallHitRight;
        public bool deathCollisionRight;
        public bool deathCollisionLeft;
        public bool deathCollisionTop;
        public bool deathCollisionBottom;

        public void PerformCollisionCheck()
        {
            boxHitBottom = false;
            boxHitTop = false;
            boxHitLeft = false;
            boxHitRight = false;
            wallHitBottom = false;
            wallHitTop = false;
            wallHitLeft = false;
            wallHitRight = false;
            keyCollision = false;
            deathCollisionRight = false;
            deathCollisionLeft = false;
            deathCollisionTop = false;
            deathCollisionBottom = false;

//FOR CHARACTER 1
            if (currentCharacter == 1)
            {
                // Bottom of object
                if ((erikaRect.Y + 25) <= (boxRect.Y + boxRect.Height) && (erikaRect.Y + 25) >= boxRect.Y && (erikaRect.X + (erikaRect.Width - 13)) >= boxRect.X && erikaRect.X <= (boxRect.X + (boxRect.Width - 6)))
                {
                    boxHitBottom = true;
                }

                // Top of object
                if ((erikaRect.Y + (erikaRect.Height + 2)) >= boxRect.Y && (erikaRect.Y + 28) <= (boxRect.Y + (boxRect.Height - 5)) && (erikaRect.X + (erikaRect.Width - 13)) >= boxRect.X && erikaRect.X <= (boxRect.X + (boxRect.Width - 6)))
                {
                    boxHitTop = true;
                }

                // Left of object
                if ((erikaRect.X + erikaRect.Width - 4) >= boxRect.X && erikaRect.X <= (boxRect.X + (boxRect.Width - 7)) && (erikaRect.Y + (erikaRect.Height - 5)) >= boxRect.Y && (erikaRect.Y + 26) <= (boxRect.Y + (boxRect.Height - 5)))
                {
                    boxHitLeft = true;
                }

                // Right of object
                if (erikaRect.X <= (boxRect.X + boxRect.Width) && erikaRect.X >= boxRect.X && (erikaRect.Y + (erikaRect.Height - 5)) >= boxRect.Y && (erikaRect.Y + 26) <= (boxRect.Y + (boxRect.Height - 5)))
                {
                    boxHitRight = true;
                }

                // Collision for the key
                if(erikaRect.Y >= (keyRect.Y - 40) && erikaRect.Y <= (keyRect.Y - 10) && erikaRect.X >= (keyRect.X - 40) && erikaRect.X <= (keyRect.X + 30))
                {
                    keyCollision = true;
                }

                // Temporary collision for the wall in level 1
                if (erikaRect.Y <= 220 && currentLevel == 1)
                {
                    wallHitBottom = true;
                }

                // Collision for Level 2

                // For the top wall
                if (erikaRect.Y <= 125 && currentLevel == 2)
                {
                    wallHitBottom = true;
                }

                // Left pillar
                if (erikaRect.X <= 75 && erikaRect.Y <= 150 && currentLevel == 2)
                {
                    wallHitRight = true;
                    wallHitBottom = true;
                }

                // Left wall
                if (erikaRect.X <= 50 && currentLevel == 2)
                {
                    wallHitRight = true;
                }

                // Right pillar
                if (erikaRect.X >= 690 && erikaRect.Y <= 150 && currentLevel == 2)
                {
                    wallHitBottom = true;
                    wallHitLeft = true;
                }

                // Right wall
                if (erikaRect.X >= 710 && currentLevel == 2)
                {
                    wallHitLeft = true;
                }

                // Bottom left wall going left
                if (erikaRect.X <= 350 && erikaRect.Y >= 315 && currentLevel == 2)
                {
                    wallHitRight = true;
                }

                // Bottom left wall going down
                if (erikaRect.X <= 345 && erikaRect.Y >= 310 && currentLevel == 2)
                {
                    wallHitTop = true;
                }

                // Bottom right wall going right
                if (erikaRect.X >= 370 && erikaRect.Y >= 315 && currentLevel == 2)
                {
                    wallHitLeft = true;
                }

                // Bottom right wall going down
                if (erikaRect.X >= 375 && erikaRect.Y >= 310 && currentLevel == 2)
                {
                    wallHitTop = true;
                }

                // Bottom right pillar
                if (erikaRect.X >= 690 && erikaRect.Y >= 290 && currentLevel == 2)
                {
                    wallHitTop = true;
                    wallHitLeft = true;
                }

                // Bottom left pillar
                if (erikaRect.X <= 75 && erikaRect.Y >= 290 && currentLevel == 2)
                {
                    wallHitRight = true;
                    wallHitTop = true;
                }

                // Right of death
                if (erikaRect.X <= (deathRect.X + deathRect.Width) && erikaRect.X >= deathRect.X && (erikaRect.Y + (erikaRect.Height - 5)) >= deathRect.Y && (erikaRect.Y + 26) <= (deathRect.Y + (deathRect.Height - 5)))
                {
                    deathCollisionRight = true;
                }

                // Left of death
                if ((erikaRect.X + erikaRect.Width - 4) >= deathRect.X && erikaRect.X <= (deathRect.X + (deathRect.Width - 7)) && (erikaRect.Y + (erikaRect.Height - 5)) >= deathRect.Y && (erikaRect.Y + 26) <= (deathRect.Y + (deathRect.Height - 5)))
                {
                    deathCollisionLeft = true;
                }

                // Top of death
                if ((erikaRect.Y + (erikaRect.Height + 2)) >= deathRect.Y && (erikaRect.Y + 28) <= (deathRect.Y + (deathRect.Height - 5)) && (erikaRect.X + (erikaRect.Width - 13)) >= deathRect.X && erikaRect.X <= (deathRect.X + (deathRect.Width - 6)))
                {
                    deathCollisionTop = true;
                }

                // Bottom of death
                if ((erikaRect.Y + 25) <= (deathRect.Y + deathRect.Height) && (erikaRect.Y + 25) >= deathRect.Y && (erikaRect.X + (erikaRect.Width - 13)) >= deathRect.X && erikaRect.X <= (deathRect.X + (deathRect.Width - 6)))
                {
                    deathCollisionBottom = true;
                }
            }

//FOR CLAIRE
            if (currentCharacter == 2)
            {
                // If player collision is detected at the bottom of object
                if ((claireRect.Y + 25) <= (boxRect.Y + boxRect.Height) && (claireRect.Y + 25) >= boxRect.Y && (claireRect.X + (claireRect.Width - 13)) >= boxRect.X && claireRect.X <= (boxRect.X + (boxRect.Width - 6)))
                {
                    boxHitBottom = true;
                }

                // Top of object
                if ((claireRect.Y + (claireRect.Height + 2)) >= boxRect.Y && (claireRect.Y + 28) <= (boxRect.Y + (boxRect.Height - 5)) && (claireRect.X + (claireRect.Width - 13)) >= boxRect.X && claireRect.X <= (boxRect.X + (boxRect.Width - 6)))
                {
                    boxHitTop = true;
                }

                // Left of object
                if ((claireRect.X + claireRect.Width - 4) >= boxRect.X && claireRect.X <= (boxRect.X + (boxRect.Width - 7)) && (claireRect.Y + (claireRect.Height - 5)) >= boxRect.Y && (claireRect.Y + 26) <= (boxRect.Y + (boxRect.Height - 5)))
                {
                    boxHitLeft = true;
                }

                // Right of object
                if (claireRect.X <= (boxRect.X + boxRect.Width) && claireRect.X >= boxRect.X && (claireRect.Y + (claireRect.Height - 5)) >= boxRect.Y && (claireRect.Y + 26) <= (boxRect.Y + (boxRect.Height - 5)))
                {
                    boxHitRight = true;
                }

                // Collision for the key
                if (claireRect.Y >= (keyRect.Y - 40) && claireRect.Y <= (keyRect.Y - 10) && claireRect.X >= (keyRect.X - 40) && claireRect.X <= (keyRect.X + 30))
                {
                    keyCollision = true;
                }

                // Temporary collision for the wall in level 1
                if (claireRect.Y <= 220 && currentLevel == 1)
                {
                    wallHitBottom = true;
                }

                // Collision for Level 2

                // For the top wall
                if (claireRect.Y <= 125 && currentLevel == 2)
                {
                    wallHitBottom = true;
                }

                // Left pillar
                if (claireRect.X <= 75 && claireRect.Y <= 150 && currentLevel == 2)
                {
                    wallHitRight = true;
                    wallHitBottom = true;
                }

                // Left wall
                if (claireRect.X <= 50 && currentLevel == 2)
                {
                    wallHitRight = true;
                }

                // Right pillar
                if (claireRect.X >= 690 && claireRect.Y <= 150 && currentLevel == 2)
                {
                    wallHitBottom = true;
                    wallHitLeft = true;
                }

                // Right wall
                if (claireRect.X >= 710 && currentLevel == 2)
                {
                    wallHitLeft = true;
                }

                // Bottom left wall going left
                if (claireRect.X <= 350 && claireRect.Y >= 315 && currentLevel == 2)
                {
                    wallHitRight = true;
                }

                // Bottom left wall going down
                if (claireRect.X <= 345 && claireRect.Y >= 310 && currentLevel == 2)
                {
                    wallHitTop = true;
                }

                // Bottom right wall going right
                if (claireRect.X >= 370 && claireRect.Y >= 315 && currentLevel == 2)
                {
                    wallHitLeft = true;
                }

                // Bottom right wall going down
                if (claireRect.X >= 375 && claireRect.Y >= 310 && currentLevel == 2)
                {
                    wallHitTop = true;
                }

                // Bottom right pillar
                if (claireRect.X >= 690 && claireRect.Y >= 290 && currentLevel == 2)
                {
                    wallHitTop = true;
                    wallHitLeft = true;
                }

                // Bottom left pillar
                if (claireRect.X <= 75 && claireRect.Y >= 290 && currentLevel == 2)
                {
                    wallHitRight = true;
                    wallHitTop = true;
                }

                // Right of death
                if (claireRect.X <= (deathRect.X + deathRect.Width) && claireRect.X >= deathRect.X && (claireRect.Y + (claireRect.Height - 5)) >= deathRect.Y && (claireRect.Y + 26) <= (deathRect.Y + (deathRect.Height - 5)))
                {
                    deathCollisionRight = true;
                }

                // Left of death
                if ((claireRect.X + claireRect.Width - 4) >= deathRect.X && claireRect.X <= (deathRect.X + (deathRect.Width - 7)) && (claireRect.Y + (claireRect.Height - 5)) >= deathRect.Y && (claireRect.Y + 26) <= (deathRect.Y + (deathRect.Height - 5)))
                {
                    deathCollisionLeft = true;
                }

                // Top of death
                if ((claireRect.Y + (claireRect.Height + 2)) >= deathRect.Y && (claireRect.Y + 28) <= (deathRect.Y + (deathRect.Height - 5)) && (claireRect.X + (claireRect.Width - 13)) >= deathRect.X && claireRect.X <= (deathRect.X + (deathRect.Width - 6)))
                {
                    deathCollisionTop = true;
                }

                // Bottom of death
                if ((claireRect.Y + 25) <= (deathRect.Y + deathRect.Height) && (claireRect.Y + 25) >= deathRect.Y && (claireRect.X + (claireRect.Width - 13)) >= deathRect.X && claireRect.X <= (deathRect.X + (deathRect.Width - 6)))
                {
                    deathCollisionBottom = true;
                }
            }
        }
    }
}
