﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HatQuest
{
    class Room
    {
        //Fields
        private Enemy[] enemies;
        private int currentAttacker;
        private float timer;

        //Properties
        public Enemy this[int i]
        {
            get { return enemies[i]; }
        }

        public Room(Enemy en1, Enemy en2 = null, Enemy en3 = null, Enemy en4 = null, Enemy en5 = null)
        {
            enemies = new Enemy[5];
            enemies[0] = en1;
            enemies[1] = en2;
            enemies[2] = en3;
            enemies[3] = en4;
            enemies[4] = en5;

            //A currentAttacker of 5 indicates that all enemies have attacked
            currentAttacker = 0;
            timer = 0;
        }

        /// <summary>
        /// Used as an Update method for the Room class while the Play class is in the EnemyTurn state
        /// </summary>
        /// <param name="player">The current player for the enemies to target</param>
        public PlayState TakeEnemyTurn(Player player)
        {
            //Let the current attacker take their turn
            switch(currentAttacker)
            {
                case 0:
                    if (enemies[0] != null && enemies[0].IsActive)
                    {
                        enemies[0].AttackPlayer();
                        currentAttacker++;
                    }
                    else
                    {
                        currentAttacker++;
                    }
                    break;
                case 1:
                    if (enemies[1] != null && enemies[1].IsActive)
                    {
                        enemies[1].AttackPlayer();
                        currentAttacker++;
                    }
                    else
                    {
                        currentAttacker++;
                    }
                    break;
                case 2:
                    if (enemies[2] != null && enemies[2].IsActive)
                    {
                        enemies[2].AttackPlayer();
                        currentAttacker++;
                    }
                    else
                    {
                        currentAttacker++;
                    }
                    break;
                case 3:
                    if (enemies[3] != null && enemies[3].IsActive)
                    {
                        enemies[3].AttackPlayer();
                        currentAttacker++;
                    }
                    else
                    {
                        currentAttacker++;
                    }
                    break;
                case 4:
                    if (enemies[4] != null && enemies[4].IsActive)
                    {
                        enemies[4].AttackPlayer();
                        currentAttacker++;
                    }
                    else
                    {
                        currentAttacker++;
                    }
                    break;
                //Ends the enemy turn 
                default:
                    //Returns the player to their turn if there are still live e
                    foreach (Enemy enemy in enemies)
                    {
                        if(enemy != null && enemy.IsActive)
                        {
                            currentAttacker = 0;
                            return PlayState.PlayerInput;
                        }
                    }
                    //Sends the player to the safe room if all enemies are dead
                    currentAttacker = 0;
                    return PlayState.SafeRoom;
            }

            //Continues the enemies' turn if they haven't all finished
            return PlayState.EnemyTurn;
        }

        public void Draw(SpriteBatch batch)
        {
            foreach(Enemy en in enemies)
            {
                //The if statement may be redundant
                //IDK if the foreach loop will iterate through null values
                if(en != null)
                    en.Draw(batch);
            }
        }
    }
}
