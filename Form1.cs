using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dominic_Culminating
{
    public partial class Form1 : Form
    {

        Image imgChar = Properties.Resources.heroIdle;
        Image imgGoblin = Properties.Resources.goblinRun;
        Image imgSlime = Properties.Resources.slimeRun;
        Image imgBat = Properties.Resources.batFly;
        Image imgDoor = Properties.Resources.door_spritesheet;
        Image imgTorch = Properties.Resources.torch_spritesheet;
        Image imgFire = Properties.Resources.Fire_Spreadsheet;
        Image imgMenuChar = Properties.Resources.heroIdle4;

        // variables to keep track of which frame/sprite to display
        int count, row, col, totalRows, totalCols, charWidth, charHeight, charVel;
        int count2, row2, col2, totalRowsGoblin, totalColsGoblin, goblinWidth, goblinHeight;
        int count3, row3, col3, totalRowsSlime, totalColsSlime, slimeWidth, slimeHeight;
        int count4, row4, col4, totalRowsBat, totalColsBat, batWidth, batHeight;
        int count5, row5, col5, totalRowsDoor, totalColsDoor, doorWidth, doorHeight;
        int count6, row6, col6, totalRowsTorch, totalColsTorch, torchWidth, torchHeight;
        int count7, row7, col7, totalRowsMenuChar, totalColsMenuChar, menuCharWidth, menuCharHeight;
        int count8, row8, col8, totalRowsFire, totalColsFire, fireWidth, fireHeight;

        //spawn enemy / max
        int goblinMax = 0;
        int goblinMax2 = 0;
        int slimeMax = 0;
        int slimeMax2 = 0;
        int batMax = 0;

        Random rnd = new Random();
        List<Rectangle> rRect = new List<Rectangle>();
        List<int> goblinXVel = new List<int>();
        List<int> goblinYVel = new List<int>();

        List<Rectangle> sRect = new List<Rectangle>();
        List<int> slimeXVel = new List<int>();
        List<int> slimeYVel = new List<int>();

        List<Rectangle> bRect = new List<Rectangle>();
        List<int> batXVel = new List<int>();
        List<int> batYVel = new List<int>();

        Boolean goUp, goDown, goLeft, goRight, attack;
        Boolean faceLeft, faceRight;
        Rectangle rChar;
        Rectangle rDoor;
        Rectangle rTorch, rTorch2, rTorch3, rTorch4, rTorch5, rTorch6, rTorch7;
        Rectangle rMenuChar, rFire;

        Boolean gameOver = false;
        Boolean play = false;

        Rectangle rStart;
        int rStartWidth = 80;
        int rStartHeight = 40;

        Rectangle logo;
        int logoWidth = 300;
        int logoHeight = 50;

        Rectangle rPlayAgain;
        int rPlayAgainWidth = 160;
        int rPlayAgainHeight = 40;

        Rectangle rGameOver;
        int rGameOverWidth = 350;
        int rGameOverHeight = 50;

        Rectangle rWin;
        int rWinWidth = 350;
        int rWinHeight = 50;

        Rectangle key1, key2, key3, key4, key5;
        int keyWidth = 50;
        int keyHeight = 50;

        int keyTotal = 0;

        Boolean key1PickUp, key2PickUp, key3PickUp, key4PickUp, key5PickUp;

        Boolean room0, room1, room2, room3, room4, room5, room6;

        Rectangle[] rWall0 = new Rectangle[13];
        Rectangle[] rWall1 = new Rectangle[9];
        Rectangle[] rWall2 = new Rectangle[10];
        Rectangle[] rWall3 = new Rectangle[11];
        Rectangle[] rWall4 = new Rectangle[11];
        Rectangle[] rWall5 = new Rectangle[8];
        Rectangle[] rWall6 = new Rectangle[8];

        int health = 100;

        bool doorOpen = false, doorOpened = false;

        bool death = false, deathed = false;

        public Form1()
        {
            InitializeComponent();

            Image imgGoblin = Properties.Resources.goblinRun;
            //goblin

            //set number of rows and columns
            totalColsGoblin = 6;
            totalRowsGoblin = 2;

            // determine width and height of the individual sprites
            goblinWidth = imgGoblin.Width / totalColsGoblin;
            goblinHeight = imgGoblin.Height / totalRowsGoblin;

            List<Rectangle> rRect = new List<Rectangle>();
            List<int> goblinXVel = new List<int>();
            List<int> goblinYVel = new List<int>();

            Random rnd = new Random();

            Image imgSlime = Properties.Resources.slimeRun;
            //slime

            //set number of rows and columns
            totalColsSlime = 6;
            totalRowsSlime = 2;

            // determine width and height of the individual sprites
            slimeWidth = imgSlime.Width / totalColsSlime;
            slimeHeight = imgSlime.Height / totalRowsSlime;

            List<Rectangle> sRect = new List<Rectangle>();
            List<int> slimeXVel = new List<int>();
            List<int> slimeYVel = new List<int>();

            Image imgBat = Properties.Resources.batFly;
            // bat

            //set number of rows and columns
            totalColsBat = 4;
            totalRowsBat = 2;

            // determine width and height of the individual sprites
            batWidth = imgBat.Width / totalColsBat;
            batHeight = imgBat.Height / totalRowsBat;

            List<Rectangle> bRect = new List<Rectangle>();
            List<int> batXVel = new List<int>();
            List<int> batYVel = new List<int>();

            //door
            totalColsDoor = 14;
            totalRowsDoor = 1;

            doorWidth = imgDoor.Width / totalColsDoor;
            doorHeight = imgDoor.Height / totalRowsDoor;

            //torch
            totalColsTorch = 6;
            totalRowsTorch = 1;

            torchWidth = imgTorch.Width / totalColsTorch;
            torchHeight = imgTorch.Width / totalRowsTorch;

            //menu char
            totalColsMenuChar = 5;
            totalRowsMenuChar = 1;

            menuCharWidth = imgMenuChar.Width / totalColsMenuChar;
            menuCharHeight = imgMenuChar.Height / totalRowsMenuChar;

            //fire
            totalColsFire = 2;
            totalRowsFire = 2;

            fireWidth = imgFire.Width / totalColsFire;
            fireHeight = imgFire.Height / totalRowsFire;

            // char 
            totalCols = 5;
            totalRows = 2;

            charWidth = imgChar.Width / totalCols;
            charHeight = imgChar.Height / totalRows;

            rChar = new Rectangle(pbArena.Width / 2 - charWidth / 2 + 32, pbArena.Height / 2 - charHeight / 2, charWidth, charHeight);
            charVel = 7;

            //logo
            logo = new Rectangle(this.Width / 2 - logoWidth / 2, logoHeight + 160, logoWidth, logoHeight);

            if (room0 == true)

            {
                //walls
                rWall0[0] = new Rectangle(pbRoom00.Location, pbRoom00.Size);
                rWall0[1] = new Rectangle(pbRoom01.Location, pbRoom01.Size);
                rWall0[2] = new Rectangle(pbRoom02.Location, pbRoom02.Size);
                rWall0[3] = new Rectangle(pbRoom03.Location, pbRoom03.Size);
                rWall0[4] = new Rectangle(pbRoom04.Location, pbRoom04.Size);
                rWall0[5] = new Rectangle(pbRoom05.Location, pbRoom05.Size);
                rWall0[6] = new Rectangle(pbRoom06.Location, pbRoom06.Size);
                rWall0[7] = new Rectangle(pbRoom07.Location, pbRoom07.Size);
                rWall0[8] = new Rectangle(pbRoom08.Location, pbRoom08.Size);
                rWall0[9] = new Rectangle(pbRoom09.Location, pbRoom09.Size);
                rWall0[10] = new Rectangle(pbRoom010.Location, pbRoom010.Size);
                rWall0[11] = new Rectangle(pbRoom011.Location, pbRoom011.Size);
                rWall0[12] = new Rectangle(pbRoom012.Location, pbRoom012.Size);

                // now make the pictureboxes disappear
                pbRoom00.Visible = false;
                pbRoom01.Visible = false;
                pbRoom02.Visible = false;
                pbRoom03.Visible = false;
                pbRoom04.Visible = false;
                pbRoom05.Visible = false;
                pbRoom06.Visible = false;
                pbRoom07.Visible = false;
                pbRoom08.Visible = false;
                pbRoom09.Visible = false;
                pbRoom010.Visible = false;
                pbRoom011.Visible = false;
                pbRoom012.Visible = false;
            }


            // now make the pictureboxes disappear
            pbRoom00.Visible = false;
            pbRoom01.Visible = false;
            pbRoom02.Visible = false;
            pbRoom03.Visible = false;
            pbRoom04.Visible = false;
            pbRoom05.Visible = false;
            pbRoom06.Visible = false;
            pbRoom07.Visible = false;
            pbRoom08.Visible = false;
            pbRoom09.Visible = false;
            pbRoom010.Visible = false;
            pbRoom011.Visible = false;
            pbRoom012.Visible = false;

            // now make the pictureboxes disappear
            pbRoom10.Visible = false;
            pbRoom11.Visible = false;
            pbRoom12.Visible = false;
            pbRoom13.Visible = false;
            pbRoom14.Visible = false;
            pbRoom15.Visible = false;
            pbRoom17.Visible = false;
            pbRoom16.Visible = false;
    

            // now make the pictureboxes disappear
            pbRoom20.Visible = false;
            pbRoom21.Visible = false;
            pbRoom22.Visible = false;
            pbRoom23.Visible = false;
            pbRoom24.Visible = false;
            pbRoom25.Visible = false;
            pbRoom26.Visible = false;
            pbRoom27.Visible = false;
            pbRoom28.Visible = false;
            pbRoom29.Visible = false;
            // now make the pictureboxes disappear
            pbRoom30.Visible = false;
            pbRoom31.Visible = false;
            pbRoom32.Visible = false;
            pbRoom33.Visible = false;
            pbRoom34.Visible = false;
            pbRoom35.Visible = false;
            pbRoom36.Visible = false;
            pbRoom37.Visible = false;
            pbRoom38.Visible = false;
            pbRoom39.Visible = false;

            // now make the pictureboxes disappear
            pbRoom40.Visible = false;
            pbRoom41.Visible = false;
            pbRoom42.Visible = false;
            pbRoom43.Visible = false;
            pbRoom44.Visible = false;
            pbRoom45.Visible = false;
            pbRoom46.Visible = false;
            pbRoom47.Visible = false;
            pbRoom48.Visible = false;
            pbRoom49.Visible = false;
            pbRoom410.Visible = false;

            // now make the pictureboxes disappear
            pbRoom50.Visible = false;
            pbRoom51.Visible = false;
            pbRoom52.Visible = false;
            pbRoom53.Visible = false;
            pbRoom54.Visible = false;
            pbRoom55.Visible = false;
            pbRoom56.Visible = false;
            pbRoom57.Visible = false;

            // now make the pictureboxes disappear
            pbRoom60.Visible = false;
            pbRoom61.Visible = false;
            pbRoom62.Visible = false;
            pbRoom63.Visible = false;
            pbRoom64.Visible = false;
            pbRoom65.Visible = false;
            pbRoom66.Visible = false;
            pbRoom67.Visible = false;
        }


        //sound
        WMPLib.WindowsMediaPlayer snd1 = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer snd2 = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer snd3 = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer snd4 = new WMPLib.WindowsMediaPlayer();

                                           
        private void tmrChar_Tick(object sender, EventArgs e)
        {

            //menu char
            if (count7 >= (totalRowsMenuChar * totalColsMenuChar))
            {
                count7 = 0;
            }

            // do some math on "count" to give you row and column on the spritesheet
            // row = count \ totalCols     //row is chosen by key
            col7 = count7 % totalColsMenuChar;      //returns the remainder only (no integer)

            // increment the counter
            count7 += 1;


            //menu fire
            if (count8 >= (totalRowsFire * totalColsFire))
            {
                count8 = 0;
            }

            // do some math on "count" to give you row and column on the spritesheet
            row8 = count8 / totalColsFire;
            col8 = count8 % totalColsFire;      //returns the remainder only (no integer)

            // increment the counter
            count8 += 1;


            //death
            if (deathed == false)
            {

                if (health <= 0 && faceLeft == true)
                {
                    tmrChar.Interval = 1000;
                    imgChar = Properties.Resources.heroDeath;
                    totalCols = 7;
                    charWidth = imgChar.Width / totalCols;
                    charHeight = imgChar.Height / totalRows;
                    row = 0;
                    death = true;
                }


                while (death == true)
                {
                    if (count >= (totalRows * totalCols))
                    {
                        count = 6;
                        death = false;
                        deathed = true;

                        gameOver = true;
                    }

                    col = count % totalCols;  //returns the remainder only (no integer)
                    count += 1;

                }
            }


            if (deathed == false)
            {

                if (health <= 0 && faceRight == true)
                {
                    tmrChar.Interval = 1000;
                    imgChar = Properties.Resources.heroDeath;
                    totalCols = 7;
                    charWidth = imgChar.Width / totalCols;
                    charHeight = imgChar.Height / totalRows;
                    row = 1;

                    death = true;
                }


                while (death == true)
                {
                    if (count >= (totalRows * totalCols))
                    {
                        count = 6;
                        death = false;
                        deathed = true;

                        gameOver = true;
                    }

                    col = count % totalCols;  //returns the remainder only (no integer)
                    count += 1;

                    
                }
            }

            //wall code room 0
            if (room0 == true) 
            {

                //starts timer for room 0, changes bg image
                tmrRoom0.Start();
                pbArena.BackgroundImage = Properties.Resources.room_0;

                for (int x = 0; x <= 11; x++)
                {
                    //the character is normally able to move freely in any direction
                    //if the character collides with a rectangle ("wall"), then back it off in the opposite direction by one "move"

                    if (rChar.IntersectsWith(rWall0[x]))
                    {
                        if (goLeft == true && rChar.Left <= rWall0[x].Right && rChar.Left > rWall0[x].Left)
                        {
                            rChar.X += charVel;
                        }

                        if (goRight == true && rChar.Right >= rWall0[x].Left && rChar.Left < rWall0[x].Left)
                        {
                            rChar.X -= charVel;
                        }

                        if (goUp == true && rChar.Top <= rWall0[x].Bottom && rChar.Top > rWall0[x].Top)
                        {
                            rChar.Y += charVel;
                        }

                        if (goDown == true && rChar.Bottom >= rWall0[x].Top && rChar.Bottom < rWall0[x].Bottom)
                        {
                            rChar.Y -= charVel;
                        }

                    }
                }
            }

            //wall code room 1
            if (room1 == true)
            {

                //starts timer for room 1, changes bg image
                tmrRoom1.Start();
                pbArena.BackgroundImage = Properties.Resources.room_1;

                if (rChar.IntersectsWith(key1))
                {
                    key1PickUp = true;
                    tmrKeyPickUp.Start();
                }


                for (int x = 0; x <= 5; x++)
                {
                    //the character is normally able to move freely in any direction
                    //if the character collides with a rectangle ("wall"), then back it off in the opposite direction by one "move"

                    if (rChar.IntersectsWith(rWall1[x]))
                    {

                        if (goLeft == true && rChar.Left <= rWall1[x].Right && rChar.Left > rWall1[x].Left)
                        {
                            rChar.X += charVel;
                        }

                        if (goRight == true && rChar.Right >= rWall1[x].Left && rChar.Left < rWall1[x].Left)
                        {
                            rChar.X -= charVel;
                        }

                        if (goUp == true && rChar.Top <= rWall1[x].Bottom && rChar.Top > rWall1[x].Top)
                        {
                            rChar.Y += charVel;
                        }

                        if (goDown == true && rChar.Bottom >= rWall1[x].Top && rChar.Bottom < rWall1[x].Bottom)
                        {
                            rChar.Y -= charVel;
                        }

                    }
                }
            }

            //wall code room 2
            if (room2 == true)
            {

                //starts timer for room 2, changes bg image
                tmrRoom2.Start();
                pbArena.BackgroundImage = Properties.Resources.room_2;

                if (rChar.IntersectsWith(key2))
                {
                    key2PickUp = true;
                    tmrKeyPickUp.Start();
                }


                for (int x = 0; x <= 6; x++)
                {
                    //the character is normally able to move freely in any direction
                    //if the character collides with a rectangle ("wall"), then back it off in the opposite direction by one "move"

                    if (rChar.IntersectsWith(rWall2[x]))
                    {


                        if (goLeft == true && rChar.Left <= rWall2[x].Right && rChar.Left > rWall2[x].Left)
                        {
                            rChar.X += charVel;
                        }

                        if (goRight == true && rChar.Right >= rWall2[x].Left && rChar.Left < rWall2[x].Left)
                        {
                            rChar.X -= charVel;
                        }

                        if (goUp == true && rChar.Top <= rWall2[x].Bottom && rChar.Top > rWall2[x].Top)
                        {
                            rChar.Y += charVel;
                        }

                        if (goDown == true && rChar.Bottom >= rWall2[x].Top && rChar.Bottom < rWall2[x].Bottom)
                        {
                            rChar.Y -= charVel;
                        }

                    }

                }


            }

            //wall code room 3
            if (room3 == true)
            {

                //starts timer for room 3, changes bg image
                tmrRoom3.Start();
                pbArena.BackgroundImage = Properties.Resources.room_3;

                for (int x = 0; x <= 9; x++)
                {
                    //the character is normally able to move freely in any direction
                    //if the character collides with a rectangle ("wall"), then back it off in the opposite direction by one "move"

                    if (rChar.IntersectsWith(rWall3[x]))
                    {


                        if (goLeft == true && rChar.Left <= rWall3[x].Right && rChar.Left > rWall3[x].Left)
                        {
                            rChar.X += charVel;
                        }

                        if (goRight == true && rChar.Right >= rWall3[x].Left && rChar.Left < rWall3[x].Left)
                        {
                            rChar.X -= charVel;
                        }

                        if (goUp == true && rChar.Top <= rWall3
                            [x].Bottom && rChar.Top > rWall3[x].Top)
                        {
                            rChar.Y += charVel;
                        }

                        if (goDown == true && rChar.Bottom >= rWall3[x].Top && rChar.Bottom < rWall3[x].Bottom)
                        {
                            rChar.Y -= charVel;
                        }

                    }
                }
            }

            //wall code room 4
            if (room4 == true)
            {

                //starts timer for room 4, changes bg image
                tmrRoom4.Start();
                pbArena.BackgroundImage = Properties.Resources.room_4_copy;

                if (rChar.IntersectsWith(key3))
                {
                    key3PickUp = true;
                    tmrKeyPickUp.Start();
                }


                for (int x = 0; x <= 9; x++)
                {
                    //the character is normally able to move freely in any direction
                    //if the character collides with a rectangle ("wall"), then back it off in the opposite direction by one "move"

                    if (rChar.IntersectsWith(rWall4[x]))
                    {

                        if (goLeft == true && rChar.Left <= rWall4[x].Right && rChar.Left > rWall4[x].Left)
                        {
                            rChar.X += charVel;
                        }

                        if (goRight == true && rChar.Right >= rWall4[x].Left && rChar.Left < rWall4[x].Left)
                        {
                            rChar.X -= charVel;
                        }

                        if (goUp == true && rChar.Top <= rWall4[x].Bottom && rChar.Top > rWall4[x].Top)
                        {
                            rChar.Y += charVel;
                        }

                        if (goDown == true && rChar.Bottom >= rWall4[x].Top && rChar.Bottom < rWall4[x].Bottom)
                        {
                            rChar.Y -= charVel;
                        }

                    }
                }
            }

            //wall code room 5
            if (room5 == true)
            {

                //starts timer for room 5, changes bg image
                tmrRoom5.Start();
                pbArena.BackgroundImage = Properties.Resources.room_5;

                if (rChar.IntersectsWith(key4))
                {
                    key4PickUp = true;
                    tmrKeyPickUp.Start();
                }

                for (int x = 0; x <= 6; x++)
                {
                    //the character is normally able to move freely in any direction
                    //if the character collides with a rectangle ("wall"), then back it off in the opposite direction by one "move"

                    if (rChar.IntersectsWith(rWall5[x]))
                    {

                        if (goLeft == true && rChar.Left <= rWall5[x].Right && rChar.Left > rWall5[x].Left)
                        {
                            rChar.X += charVel;
                        }

                        if (goRight == true && rChar.Right >= rWall5[x].Left && rChar.Left < rWall5[x].Left)
                        {
                            rChar.X -= charVel;
                        }

                        if (goUp == true && rChar.Top <= rWall5[x].Bottom && rChar.Top > rWall5[x].Top)
                        {
                            rChar.Y += charVel;
                        }

                        if (goDown == true && rChar.Bottom >= rWall5[x].Top && rChar.Bottom < rWall5[x].Bottom)
                        {
                            rChar.Y -= charVel;
                        }

                    }
                }
            }


            //wall code room 6
            if (room6 == true)
            {

                //starts timer for room 6, changes bg image
                tmrRoom6.Start();
                pbArena.BackgroundImage = Properties.Resources.room_6;

                if (rChar.IntersectsWith(key5))
                {
                    key5PickUp = true;
                    tmrKeyPickUp.Start();
                }

                for (int x = 0; x <= 6; x++)
                {
                    //the character is normally able to move freely in any direction
                    //if the character collides with a rectangle ("wall"), then back it off in the opposite direction by one "move"

                    if (rChar.IntersectsWith(rWall6[x]))
                    {

                        if (goLeft == true && rChar.Left <= rWall6[x].Right && rChar.Left > rWall6[x].Left)
                        {
                            rChar.X += charVel;
                        }

                        if (goRight == true && rChar.Right >= rWall6[x].Left && rChar.Left < rWall6[x].Left)
                        {
                            rChar.X -= charVel;
                        }

                        if (goUp == true && rChar.Top <= rWall6[x].Bottom && rChar.Top > rWall6[x].Top)
                        {
                            rChar.Y += charVel;
                        }

                        if (goDown == true && rChar.Bottom >= rWall6[x].Top && rChar.Bottom < rWall6[x].Bottom)
                        {
                            rChar.Y -= charVel;
                        }

                    }
                }
            }


            if (room0 == true)
            {
                //walls
                rWall0[0] = new Rectangle(pbRoom00.Location, pbRoom00.Size);
                rWall0[1] = new Rectangle(pbRoom01.Location, pbRoom01.Size);
                rWall0[2] = new Rectangle(pbRoom02.Location, pbRoom02.Size);
                rWall0[3] = new Rectangle(pbRoom03.Location, pbRoom03.Size);
                rWall0[4] = new Rectangle(pbRoom04.Location, pbRoom04.Size);
                rWall0[5] = new Rectangle(pbRoom05.Location, pbRoom05.Size);
                rWall0[6] = new Rectangle(pbRoom06.Location, pbRoom06.Size);
                rWall0[7] = new Rectangle(pbRoom07.Location, pbRoom07.Size);
                rWall0[8] = new Rectangle(pbRoom08.Location, pbRoom08.Size);
                rWall0[9] = new Rectangle(pbRoom09.Location, pbRoom09.Size);
                rWall0[10] = new Rectangle(pbRoom010.Location, pbRoom010.Size);
                rWall0[11] = new Rectangle(pbRoom011.Location, pbRoom011.Size);
                rWall0[12] = new Rectangle(pbRoom012.Location, pbRoom012.Size);
            }

            if (goDown == true)
            {
                rChar.Y += charVel;
            }

            if (goUp == true)
            {
                rChar.Y -= charVel;
            }

            if (goLeft == true)
            {
               rChar.X -= charVel;
            }

            if (goRight == true)
            {
                rChar.X += charVel;

            }


            // char run animation code========================================
            // after the last row, start over
            if (count >= (totalRows * totalCols))
            {
                count = 0;

                if (attack == true)
                {

                    attack = false;

                }

            }

            // do some math on "count" to give you row and column on the spritesheet
            // row = count \ totalCols     //row is chosen by key
            col = count % totalCols;      //returns the remainder only (no integer)

            // increment the counter
            count += 1;


            //=======================================================================================================================================

            this.Refresh();

        }

        private void pbArena_Paint(object sender, PaintEventArgs e)
        {

            if (gameOver == true)
            {
                if (health <= 0)
                {
                    //game over
                    rGameOver = new Rectangle(this.Width / 2 - rGameOverWidth / 2, this.Height / 2 - rGameOverHeight - 50, rGameOverWidth, rGameOverHeight);
                    e.Graphics.DrawImage(Properties.Resources.gameOver, rGameOver);

                    //play again
                    rPlayAgain = new Rectangle(this.Width / 2 - rPlayAgainWidth / 2, this.Height / 2 - rPlayAgainHeight / 2, rPlayAgainWidth, rPlayAgainHeight);
                    e.Graphics.DrawImage(Properties.Resources.playAgain, rPlayAgain);

                    pbArena.BackgroundImage = Properties.Resources.bl;

                    rTorch = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch2 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch3 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch4 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch5 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch6 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch7 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                }

                if (health > 0 && doorOpened == true)

                { 
                    //win
                    rWin = new Rectangle(this.Width / 2 - rWinWidth / 2, this.Height / 2 - rWinHeight - 50, rWinWidth, rWinHeight);
                    e.Graphics.DrawImage(Properties.Resources.win, rWin);

                    //play again
                    rPlayAgain = new Rectangle(this.Width / 2 - rPlayAgainWidth / 2, this.Height / 2 - rPlayAgainHeight / 2, rPlayAgainWidth, rPlayAgainHeight);
                    e.Graphics.DrawImage(Properties.Resources.playAgain, rPlayAgain);

                    pbArena.BackgroundImage = Properties.Resources.bl;

                    rTorch = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch2 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch3 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch4 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch5 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch6 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch7 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    
                }
            }

            else if (play == false)
            {

                //menu graphics
                 pbArena.BackgroundImage = Properties.Resources.darkForest2;

                 //menu char
                 e.Graphics.DrawImage(imgMenuChar, rMenuChar, new RectangleF(col7 * menuCharWidth, row7 * menuCharHeight, menuCharWidth, menuCharHeight), GraphicsUnit.Pixel);
                 rMenuChar = new Rectangle(230, 305, menuCharWidth, menuCharHeight);

                //menu fire
                 e.Graphics.DrawImage(imgFire, rFire, new RectangleF(col8 * fireWidth, row8 * fireHeight, fireWidth, fireHeight), GraphicsUnit.Pixel);
                 rFire = new Rectangle(pbArena.Width / 2 - rFire.Width / 2 + 5, 315, fireWidth, fireHeight);
 
                //moves restart
                rPlayAgain = new Rectangle(2000, 2000, rPlayAgainWidth, rPlayAgainHeight);

                //start
                rStart = new Rectangle(this.Width / 2 - rStartWidth / 2, this.Height / 2 - rStartHeight / 2, rStartWidth, rStartHeight);
                e.Graphics.DrawImage(Properties.Resources.play, rStart);

                //logo
                logo = new Rectangle(this.Width / 2 - logoWidth / 2, this.Height / 2 - logoHeight - 50, logoWidth, logoHeight);
                e.Graphics.DrawImage(Properties.Resources.logo1, logo);

                //draws keys, initially all off screen
                key1= new Rectangle(2000, 2000, keyWidth, keyHeight);
                key2 = new Rectangle(2000, 2000, keyWidth, keyHeight);
                key3 = new Rectangle(2000, 2000, keyWidth, keyHeight);

            }


            else
            {

                //moves restart
                rPlayAgain = new Rectangle(2000, 2000, rPlayAgainWidth, rPlayAgainHeight);

                //moves start button
                rStart = new Rectangle(2000, 2000, rStartWidth, rStartHeight);

                if (room3 == true)
                //door 
                e.Graphics.DrawImage(imgDoor, rDoor, new RectangleF(col5 * doorWidth, row5 * doorHeight, doorWidth, doorHeight), GraphicsUnit.Pixel);
                
                //torch
                e.Graphics.DrawImage(imgTorch, rTorch, new RectangleF(col6 * torchWidth, row6 * torchHeight, torchWidth, torchHeight), GraphicsUnit.Pixel);
                e.Graphics.DrawImage(imgTorch, rTorch2, new RectangleF(col6 * torchWidth, row6 * torchHeight, torchWidth, torchHeight), GraphicsUnit.Pixel);
                e.Graphics.DrawImage(imgTorch, rTorch3, new RectangleF(col6 * torchWidth, row6 * torchHeight, torchWidth, torchHeight), GraphicsUnit.Pixel);
                e.Graphics.DrawImage(imgTorch, rTorch4, new RectangleF(col6 * torchWidth, row6 * torchHeight, torchWidth, torchHeight), GraphicsUnit.Pixel);
                e.Graphics.DrawImage(imgTorch, rTorch5, new RectangleF(col6 * torchWidth, row6 * torchHeight, torchWidth, torchHeight), GraphicsUnit.Pixel);
                e.Graphics.DrawImage(imgTorch, rTorch6, new RectangleF(col6 * torchWidth, row6 * torchHeight, torchWidth, torchHeight), GraphicsUnit.Pixel);
                e.Graphics.DrawImage(imgTorch, rTorch7, new RectangleF(col6 * torchWidth, row6 * torchHeight, torchWidth, torchHeight), GraphicsUnit.Pixel);

                //draw main character
                e.Graphics.DrawImage(imgChar, rChar, new RectangleF(col * charWidth, row * charHeight, charWidth, charHeight), GraphicsUnit.Pixel);

                //assigns key image
                e.Graphics.DrawImage(Properties.Resources.key, key1);
                e.Graphics.DrawImage(Properties.Resources.key, key2);
                e.Graphics.DrawImage(Properties.Resources.key, key3);
                e.Graphics.DrawImage(Properties.Resources.key, key4);
                e.Graphics.DrawImage(Properties.Resources.key, key5);

                //health
                e.Graphics.DrawString("Health:" + health.ToString(), new System.Drawing.Font("VCR OSD Mono", 24), Brushes.Red, 30, 370);

                //key totals
                e.Graphics.DrawString("Keys:" + keyTotal.ToString(), new System.Drawing.Font("VCR OSD Mono", 24), Brushes.Gold, pbArena.Width - 175, 370);

                //draws keys, initially all off screen
                key1 = new Rectangle(2000, 2000, keyWidth, keyHeight);
                key2 = new Rectangle(2000, 2000, keyWidth, keyHeight);
                key3 = new Rectangle(2000, 2000, keyWidth, keyHeight);
                key4 = new Rectangle(2000, 2000, keyWidth, keyHeight);
                key5 = new Rectangle(2000, 2000, keyWidth, keyHeight);

                //draws items in per room
                //room0
                if (room0 == true)
                {
                    rTorch = new Rectangle(143, 45, torchWidth, torchHeight);
                    rTorch2 = new Rectangle(527, 45, torchWidth, torchHeight);
                    rTorch3 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch4 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch5 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch6 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch7 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                }


                //room1
                if (room1 == true)
                {
                    {
                        key1 = new Rectangle(575, 280, keyWidth, keyHeight);
                        rTorch = new Rectangle(144, 190, torchWidth, torchHeight);
                        rTorch2 = new Rectangle(289, 190, torchWidth, torchHeight);
                        rTorch3 = new Rectangle(527, 45, torchWidth, torchHeight);
                        rTorch4 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                        rTorch5 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                        rTorch6 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                        rTorch7 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    }

                    if (key1PickUp == true)
                    {
                        key1 = new Rectangle(2000, 2000, keyWidth, keyHeight);
                    }
                }

                //room2 
                if (room2 == true)
                {
                    {
                        key2 = new Rectangle(458, 89, keyWidth, keyHeight);
                        rTorch = new Rectangle(287, 45, torchWidth, torchHeight);
                        rTorch2 = new Rectangle(432, 45, torchWidth, torchHeight);
                        rTorch3 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                        rTorch4 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                        rTorch5 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                        rTorch6 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                        rTorch7 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    }


                    if (key2PickUp == true)
                    {
                        key2 = new Rectangle(2000, 2000, keyWidth, keyHeight);
                    }

                }

                //room3
                if (room3 == true)
                {

                    rTorch = new Rectangle(240, 47, torchWidth, torchHeight);
                    rTorch2 = new Rectangle(480, 47, torchWidth, torchHeight);
                    rTorch3 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch4 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch5 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch6 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    rTorch7 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                
                }

                //room 4
                if (room4 == true)
                {
      
                    {
                        key3 = new Rectangle(610, 365, keyWidth, keyHeight);
                        rTorch = new Rectangle(108, 300, torchWidth, torchHeight);
                        rTorch2 = new Rectangle(275, 300, torchWidth, torchHeight);
                        rTorch3 = new Rectangle(333, 300, torchWidth, torchHeight);
                        rTorch4 = new Rectangle(107, 21, torchWidth, torchHeight);
                        rTorch5 = new Rectangle(442, 21, torchWidth, torchHeight);
                        rTorch6 = new Rectangle(555, 142, torchWidth, torchHeight);
                        rTorch7 = new Rectangle(500, 300, torchWidth, torchHeight);
                    }


                    if (key3PickUp == true)
                    {
                        key3 = new Rectangle(2000, 2000, keyWidth, keyHeight);
                    }

                }


                if (room5 == true)
                {

                    {
                        key4 = new Rectangle(50, 130, keyWidth, keyHeight);
                        rTorch = new Rectangle(95, 45, torchWidth, torchHeight);
                        rTorch2 = new Rectangle(287, 45, torchWidth, torchHeight);
                        rTorch3 = new Rectangle(95, 237, torchWidth, torchHeight);
                        rTorch4 = new Rectangle(287, 237, torchWidth, torchHeight);
                        rTorch5 = new Rectangle(479, 237, torchWidth, torchHeight);
                        rTorch6 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                        rTorch7 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    }

                    if (key4PickUp == true)
                    {
                        key4 = new Rectangle(2000, 2000, keyWidth, keyHeight);
                    }
                }

                if (room6 == true)
                {

                    {
                        key5 = new Rectangle(50, 80, keyWidth, keyHeight);
                        rTorch = new Rectangle(95, 45, torchWidth, torchHeight);
                        rTorch2 = new Rectangle(432, 45, torchWidth, torchHeight);
                        rTorch3 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                        rTorch4 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                        rTorch5 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                        rTorch6 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                        rTorch7 = new Rectangle(2000, 2000, torchWidth, torchHeight);
                    }

                    if (key5PickUp == true)
                    {
                        key5 = new Rectangle(2000, 2000, keyWidth, keyHeight);
                    }
                }


                foreach (Rectangle r in rRect.ToList())
                {
                    e.Graphics.DrawImage(imgGoblin, r, new RectangleF(col2 * goblinWidth, row2 * goblinHeight, goblinWidth, goblinHeight), GraphicsUnit.Pixel);
                }

                foreach (Rectangle s in sRect.ToList())
                {
                    e.Graphics.DrawImage(imgSlime, s, new RectangleF(col3 * slimeWidth, row3 * slimeHeight, slimeWidth, slimeHeight), GraphicsUnit.Pixel);
                }

                foreach (Rectangle b in bRect.ToList())
                {
                    e.Graphics.DrawImage(imgBat, b, new RectangleF(col4 * batWidth, row4 * batHeight, batWidth, batHeight), GraphicsUnit.Pixel);
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up && faceLeft == true)
            {
                goUp = true;
                imgChar = Properties.Resources.heroRun;
                totalCols = 8;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                row = 0;
            }

            if (e.KeyData == Keys.Up && faceRight == true)
            {
                goUp = true;
                imgChar = Properties.Resources.heroRun;
                totalCols = 8;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                row = 1;
            }

            if (e.KeyData == Keys.Down && faceLeft == true)
            {
                goDown = true;
                imgChar = Properties.Resources.heroRun;
                totalCols = 8;
           
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                row = 0;
            }

            if (e.KeyData == Keys.Down && faceRight == true)
            {
                goDown = true;
                imgChar = Properties.Resources.heroRun;
                totalCols = 8;
     
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                row = 1;
            }

            if (e.KeyData == Keys.Left)
            {
                goLeft = true;
                imgChar = Properties.Resources.heroRun;
                totalCols = 8;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                row = 0;
                faceLeft = true;
                faceRight = false;
            }

            if (e.KeyData == Keys.Right)
            {
                goRight = true;
                imgChar = Properties.Resources.heroRun;
                totalCols = 8;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                row = 1;
                faceRight = true;
                faceLeft = false;
            }

            if (e.KeyData == Keys.Space && faceRight == true)
            {
                imgChar = Properties.Resources.heroAttack;
                totalCols = 7;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                row = 1;
                attack = true;
                snd3.URL = @"swoosh.mp3";
            }

            if (e.KeyData == Keys.Space && faceLeft == true)
            {
                imgChar = Properties.Resources.heroAttack;
                totalCols = 7;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                row = 0;
                attack = true;
                snd3.URL = @"swoosh.mp3";
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up && faceRight == true)
            {
                goUp = false;
                imgChar = Properties.Resources.heroIdle;
                totalCols = 5;
                count = 0;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                row = 1;
            }

            if (e.KeyData == Keys.Up && faceLeft == true)
            {
                goUp = false;
                imgChar = Properties.Resources.heroIdle;
                totalCols = 5;
                count = 0;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                row = 0;
            }

            if (e.KeyData == Keys.Down && faceLeft == true)
            {
                goDown = false;
                imgChar = Properties.Resources.heroIdle;
                totalCols = 5;
                count = 0;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                row = 0;
            }

            if (e.KeyData == Keys.Down && faceRight == true)
            {
                goDown = false;
                imgChar = Properties.Resources.heroIdle;
                totalCols = 5;
                count = 0;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                row = 1;
            }


            if (e.KeyData == Keys.Left)
            {
                goLeft = false;
                imgChar = Properties.Resources.heroIdle;
                totalCols = 5;
                count = 0;
                row = 0;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
            }

            if (e.KeyData == Keys.Right)
            {
                goRight = false;
                imgChar = Properties.Resources.heroIdle;
                totalCols = 5;
                count = 0;
                row = 1;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
            }

            if (e.KeyData == Keys.Space && faceRight == true)
            {
                imgChar = Properties.Resources.heroIdle;
                totalCols = 5;
                count = 0;
                row = 1;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                attack = false;
            }

            if (e.KeyData == Keys.Space && faceLeft == true)
            {
                imgChar = Properties.Resources.heroIdle;
                totalCols = 5;
                count = 0;
                row = 0;
                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;
                attack = false;
            }
        }

        private void pbArena_MouseDown(object sender, MouseEventArgs e)
        {

            if (rStart.Contains(e.Location))
            {

                snd1.URL = @"bgMusicMp3.mp3";

                play = true;
                tmrChar.Enabled = true;
                tmrRoom0.Enabled = true;

                //room reset
                room0 = true;
                room1 = false;
                room2 = false;
                room3 = false;
                room4 = false;
                room5 = false;
                room6 = false;

                //key reset
                keyTotal = 0;
                key1PickUp = false;
                key2PickUp = false;
                key3PickUp = false;
                key4PickUp = false;
                key5PickUp = false;

                //door reset
                doorOpened = false;
                doorOpen = false;

                //death reset
                deathed = false;
                death = false;

                //char reset
                tmrChar.Interval = 40;
                health = 100;
                rChar = new Rectangle(pbArena.Width / 2 - charWidth / 2 + 32, pbArena.Height / 2 - charHeight / 2, charWidth, charHeight);

                // sprite reset
                imgChar = Properties.Resources.heroIdle;
                totalCols = 5;
                totalRows = 2;

                charWidth = imgChar.Width / totalCols;
                charHeight = imgChar.Height / totalRows;

                //enemy reset
                goblinMax = 2;
                goblinMax2 = 2;
                slimeMax = 2;
                slimeMax2 = 2;
                batMax = 2;

                //clears all
                //removes slimes

                foreach (Rectangle s in sRect.ToList())
                {
                    slimeXVel.RemoveAt(sRect.IndexOf(s));
                    slimeYVel.RemoveAt(sRect.IndexOf(s));
                    sRect.RemoveAt(sRect.IndexOf(s));
                }

                //removes goblins
                foreach (Rectangle r in rRect.ToList())
                {
                    goblinXVel.RemoveAt(rRect.IndexOf(r));
                    goblinYVel.RemoveAt(rRect.IndexOf(r));
                    rRect.RemoveAt(rRect.IndexOf(r));
                }

                //removes bats
                foreach (Rectangle b in bRect.ToList())
                {
                    batXVel.RemoveAt(bRect.IndexOf(b));
                    batYVel.RemoveAt(bRect.IndexOf(b));
                    bRect.RemoveAt(bRect.IndexOf(b));
                }

                pbArena.BackgroundImage = Properties.Resources.room_0;
                this.Refresh();

            }

            if (rPlayAgain.Contains(e.Location))
            {
                play = false;
                gameOver = false;
                tmrChar.Enabled = false;
                tmrRoom0.Enabled = false;
                tmrRoom1.Enabled = false;
                tmrRoom2.Enabled = false;
                tmrRoom3.Enabled = false;
                tmrRoom4.Enabled = false;
                tmrRoom5.Enabled = false;
                tmrRoom6.Enabled = false;

                //door reset
                doorOpened = false;
                doorOpen = false;
                count5 = 0;
                col5 = 0;

                snd1.URL = @"menuThemeMp3.mp3";

                this.Refresh();
            }



        }

        private void tmrRoom0_Tick(object sender, EventArgs e)
        {

            //removes goblins
            foreach (Rectangle r in rRect.ToList())
            {

                goblinXVel.RemoveAt(rRect.IndexOf(r));
                goblinYVel.RemoveAt(rRect.IndexOf(r));
                rRect.RemoveAt(rRect.IndexOf(r));

            }

            //removes bats
            foreach (Rectangle b in bRect.ToList())
            {

                batXVel.RemoveAt(bRect.IndexOf(b));
                batYVel.RemoveAt(bRect.IndexOf(b));
                bRect.RemoveAt(bRect.IndexOf(b));

            }

            //removes slimes
            foreach (Rectangle s in sRect.ToList())
            {

                slimeXVel.RemoveAt(sRect.IndexOf(s));
                slimeYVel.RemoveAt(sRect.IndexOf(s));
                sRect.RemoveAt(sRect.IndexOf(s));

            }

            //torches
            
              if (count6 >= (totalRowsTorch * totalColsTorch))
                    {
                        count6 = 0;
                    }

                    col6 = count6 % totalColsTorch;  //returns the remainder only (no integer)
                    count6 += 1;

                    this.Refresh();

            //enter room 1
            if (rChar.Bottom >= pbArena.Bottom && rChar.Right <= 170)

            {
                //draw main character
                rChar = new Rectangle(60, 40, charWidth, charHeight);

                room1 = true;
                room0 = false;
                room2 = false;
                tmrRoom1.Start();
                tmrRoom0.Stop();

                //walls room 1
                if (room1 == true)
                {
                    //walls
                    rWall1[0] = new Rectangle(pbRoom10.Location, pbRoom10.Size);
                    rWall1[1] = new Rectangle(pbRoom11.Location, pbRoom11.Size);
                    rWall1[2] = new Rectangle(pbRoom12.Location, pbRoom12.Size);
                    rWall1[3] = new Rectangle(pbRoom13.Location, pbRoom13.Size);
                    rWall1[4] = new Rectangle(pbRoom14.Location, pbRoom14.Size);
                    rWall1[5] = new Rectangle(pbRoom15.Location, pbRoom15.Size);
                    rWall1[6] = new Rectangle(pbRoom16.Location, pbRoom16.Size);
                    rWall1[7] = new Rectangle(pbRoom17.Location, pbRoom17.Size);

                    // now make the pictureboxes disappear
                    pbRoom10.Visible = false;
                    pbRoom11.Visible = false;
                    pbRoom12.Visible = false;
                    pbRoom13.Visible = false;
                    pbRoom14.Visible = false;
                    pbRoom15.Visible = false;
                    pbRoom16.Visible = false;
                    pbRoom17.Visible = false;

                }

                this.Refresh();

            }

        }

        private void tmrRoom1_Tick(object sender, EventArgs e)
        {
            {
                //torches

                if (count6 >= (totalRowsTorch * totalColsTorch))
                {
                    count6 = 0;
                }

                col6 = count6 % totalColsTorch;  //returns the remainder only (no integer)
                count6 += 1;

                this.Refresh();

                //goblin code
                int x = rnd.Next(-6, 6);
                int y = rnd.Next(-6, 6);
                goblinXVel.Add(x);   //X direction
                goblinYVel.Add(y);   //Y direction

                //spawn max
                if (rRect.Count <= goblinMax)
                {
                    rRect.Add(new Rectangle(rnd.Next(350, 500), rnd.Next(170, 250), goblinWidth * 2, goblinHeight * 2));
                }

                // after the last row, start over
                if (count2 >= (totalRowsGoblin * totalColsGoblin))
                    count2 = 0;

                // do some math on "count" to give you row and column on the spritesheet
                //row = count \ totalCols     //returns the integer only (no remainder) using backslash
                col2 = count2 % totalColsGoblin;  //returns the remainder only (no integer)

                // increment the counter
                count2 += 1;


                foreach (Rectangle r in rRect.ToList())
                {
                    if (r.IntersectsWith(rChar) && attack == true)
                    {
                        goblinXVel.RemoveAt(rRect.IndexOf(r));
                        goblinYVel.RemoveAt(rRect.IndexOf(r));
                        rRect.RemoveAt(rRect.IndexOf(r));
                        goblinMax -= 1;
                    }
                }

                for (int i = 0; i < rRect.Count; i++)
                {
                    // isolate each rectangle 'r' from the list 'rRect'
                    Rectangle r = rRect[i];
                    r.X += goblinXVel[i];
                    r.Y += goblinYVel[i];

                    for (int z = 0; z <= 7; z++)
                    {
                        //the character is normally able to move freely in any direction
                        //if the character collides with a rectangle ("wall"), then back it off in the opposite direction by one "move"

                        if (r.IntersectsWith(rWall1[z]))
                        {
                            //bounce off the walls
                            //if the ball hits the LEFT side of the Canvas, reverse the velocity value xVel
                            if (r.Left <= rWall1[z].Right && r.Left > rWall1[z].Left)
                                    r.X += 5;
                                    goblinXVel[i] = rnd.Next(4, 6);

                            //if the ball hits the RIGHT side...
                            if (r.Right >= rWall1[z].Left && r.Left < rWall1[z].Left)
                                    r.X -= 7;
                                    goblinXVel[i] = rnd.Next(-6, -4);

                            //if the ball hits the TOP...
                            if (r.Y <= rWall1[z].Bottom  && r.Y > rWall1[z].Top)
                                goblinYVel[i] = rnd.Next(4, 6);
                            do
                            {
                                goblinXVel[i] = rnd.Next(-4, 4);
                            }
                            while (goblinXVel[i] >= 2 && goblinXVel[i] <= 2);

                            //if the ball hits the BOTTOM...
                            if (r.Bottom >= rWall1[z].Top && r.Bottom < rWall1[z].Bottom)
                                goblinYVel[i] = rnd.Next(-6, -4);
                            do
                            {
                                goblinXVel[i] = rnd.Next(-4, 4);
                            }
                            while (goblinXVel[i] >= 2 && goblinXVel[i] <= 2);
                        }

                        // update the rectangle in the list
                        rRect[i] = r;
                    }
                }

                //enter room 0
                if (rChar.Top <= pbArena.Top && rChar.Right <= 170)
                {
                    rChar = new Rectangle(70, 350, charWidth, charHeight);
                    room0 = true;
                    room1 = false;
                    room2 = false;
                    tmrRoom1.Stop();
                    tmrRoom0.Start();
                }


                //enter room 2
                if (rChar.Bottom <= 220 && rChar.Right >= pbArena.Right)
                {
                    //draw main character
                    rChar = new Rectangle(35, 90, charWidth, charHeight);

                    room2 = true;
                    room1 = false;
                    room0 = false;
                    tmrRoom2.Start();
                    tmrRoom1.Stop();

                    this.Refresh();
                
                    //walls of room 2
                    if (room2 == true)
                    {
                        //walls
                        rWall2[0] = new Rectangle(pbRoom20.Location, pbRoom20.Size);
                        rWall2[1] = new Rectangle(pbRoom21.Location, pbRoom21.Size);
                        rWall2[2] = new Rectangle(pbRoom22.Location, pbRoom22.Size);
                        rWall2[3] = new Rectangle(pbRoom23.Location, pbRoom23.Size);
                        rWall2[4] = new Rectangle(pbRoom24.Location, pbRoom24.Size);
                        rWall2[5] = new Rectangle(pbRoom25.Location, pbRoom25.Size);
                        rWall2[6] = new Rectangle(pbRoom26.Location, pbRoom26.Size);
                        rWall2[7] = new Rectangle(pbRoom27.Location, pbRoom27.Size);
                        rWall2[8] = new Rectangle(pbRoom28.Location, pbRoom28.Size);
                        rWall2[9] = new Rectangle(pbRoom29.Location, pbRoom29.Size);

                        // now make the pictureboxes disappear
                        pbRoom20.Visible = false;
                        pbRoom21.Visible = false;
                        pbRoom22.Visible = false;
                        pbRoom23.Visible = false;
                        pbRoom24.Visible = false;
                        pbRoom25.Visible = false;
                        pbRoom26.Visible = false;
                        pbRoom27.Visible = false;
                        pbRoom28.Visible = false;
                        pbRoom29.Visible = false;

                    }


                    //removes slimes
                    foreach (Rectangle s in sRect.ToList())
                    {
                        slimeXVel.RemoveAt(sRect.IndexOf(s));
                        slimeYVel.RemoveAt(sRect.IndexOf(s));
                        sRect.RemoveAt(sRect.IndexOf(s));
                    }

                    //removes bats
                    foreach (Rectangle b in bRect.ToList())
                    {
                        batXVel.RemoveAt(bRect.IndexOf(b));
                        batYVel.RemoveAt(bRect.IndexOf(b));
                        bRect.RemoveAt(bRect.IndexOf(b));
                    }


                    this.Refresh();

                }

            }
        }

        private void tmrRoom2_Tick(object sender, EventArgs e)
        {

            {

                //torches

                if (count6 >= (totalRowsTorch * totalColsTorch))

                {
                    count6 = 0;
                }

                col6 = count6 % totalColsTorch;  //returns the remainder only (no integer)
                count6 += 1;

                this.Refresh();


            //slime code
            int x = rnd.Next(-3, 3);
            int y = rnd.Next(-3, 3);
            slimeXVel.Add(x);   //X direction
            slimeYVel.Add(y);   //Y direction

            //spawn max
            if (sRect.Count <= slimeMax)
            {
                sRect.Add(new Rectangle(rnd.Next(180, 450), 170, slimeWidth * 2, slimeHeight * 2));
            }

            // after the last row, start over
            if (count3 >= (totalRowsSlime * totalColsSlime))
                count3 = 0;

            // do some math on "count" to give you row and column on the spritesheet
            //row = count \ totalCols     //returns the integer only (no remainder) using backslash
            col3 = count3 % totalColsSlime;  //returns the remainder only (no integer)

            // increment the counter
            count3 += 1;

            foreach (Rectangle s in sRect.ToList())
            {
                if (s.IntersectsWith(rChar) && attack == true)
                {
                    slimeXVel.RemoveAt(sRect.IndexOf(s));
                    slimeYVel.RemoveAt(sRect.IndexOf(s));
                    sRect.RemoveAt(sRect.IndexOf(s));
                    slimeMax -= 1;
                }
            }

            for (int i = 0; i < sRect.Count; i++)
            {
                // isolate each rectangle 'r' from the list 'rRect'
                Rectangle s = sRect[i];
                s.X += slimeXVel[i];
                s.Y += slimeYVel[i];

                    for (int z = 0; z <= 9; z++)
                    {
                        //the character is normally able to move freely in any direction
                        //if the character collides with a rectangle ("wall"), then back it off in the opposite direction by one "move"

                        if (s.IntersectsWith(rWall2[z]))
                        {
                            //bounce off the walls
                            //if the ball hits the LEFT side of the Canvas, reverse the velocity value xVel
                            if (s.Left <= rWall2[z].Right && s.Left > rWall2[z].Left)
                                s.X += 5; 
                                slimeXVel[i] = rnd.Next(1, 3);

                            //if the ball hits the RIGHT side...
                            if (s.Right >= rWall2[z].Left && s.Left < rWall2[z].Left)
                                s.X -= 5;
                                slimeXVel[i] = rnd.Next(-3, -1);

                            //if the ball hits the TOP...
                            if (s.Y <= rWall2[z].Bottom + 200 && s.Y > rWall2[z].Top)
                                slimeYVel[i] = rnd.Next(1, 3);
                                slimeXVel[i] = rnd.Next(-3, 3);


                            //if the ball hits the BOTTOM...
                            if (s.Bottom >= rWall2[z].Top && s.Bottom < rWall2[z].Bottom)
                                slimeYVel[i] = rnd.Next(-3, -1);
                                slimeXVel[i] = rnd.Next(-3, 3);
                        }

                        // update the rectangle in the list
                        sRect[i] = s;
                    }
                }

                    //removes goblins
                    foreach (Rectangle r in rRect.ToList())

                    {
                        goblinXVel.RemoveAt(rRect.IndexOf(r));
                        goblinYVel.RemoveAt(rRect.IndexOf(r));
                        rRect.RemoveAt(rRect.IndexOf(r));
                    }

                    //removes bats
                    foreach (Rectangle b in bRect.ToList())
                    {
                        batXVel.RemoveAt(bRect.IndexOf(b));
                        batYVel.RemoveAt(bRect.IndexOf(b));
                        bRect.RemoveAt(bRect.IndexOf(b));
                    }

                    //enter room 1
                    if (rChar.Left <= pbArena.Left && rChar.Bottom <= 220)
                    {
                        rChar = new Rectangle(600, 100, charWidth, charHeight);
                        room1 = true;
                        room2 = false;
                        room0 = false;

                        tmrRoom1.Start();
                        tmrRoom2.Stop();

                        //removes slimes
                        foreach (Rectangle s in sRect.ToList())
                        {
                            slimeXVel.RemoveAt(sRect.IndexOf(s));
                            slimeYVel.RemoveAt(sRect.IndexOf(s));
                            sRect.RemoveAt(sRect.IndexOf(s));
                        }

                        this.Refresh();
                    }

                    //enter room 4
                    if (rChar.Top >= 255 && rChar.Right >= pbArena.Right)
                    {
                        rChar = new Rectangle(53, 340, charWidth, charHeight);
                        room4 = true;
                        room2 = false;
                        room1 = false;
                        room0 = false;
                        tmrRoom4.Start();
                        tmrRoom2.Stop();
                    }

                    {
                        //walls
                        rWall4[0] = new Rectangle(pbRoom40.Location, pbRoom40.Size);
                        rWall4[1] = new Rectangle(pbRoom41.Location, pbRoom41.Size);
                        rWall4[2] = new Rectangle(pbRoom42.Location, pbRoom42.Size);
                        rWall4[3] = new Rectangle(pbRoom43.Location, pbRoom43.Size);
                        rWall4[4] = new Rectangle(pbRoom44.Location, pbRoom44.Size);
                        rWall4[5] = new Rectangle(pbRoom45.Location, pbRoom45.Size);
                        rWall4[6] = new Rectangle(pbRoom46.Location, pbRoom46.Size);
                        rWall4[7] = new Rectangle(pbRoom47.Location, pbRoom47.Size);
                        rWall4[8] = new Rectangle(pbRoom48.Location, pbRoom48.Size);
                        rWall4[9] = new Rectangle(pbRoom49.Location, pbRoom49.Size);
                        rWall4[10] = new Rectangle(pbRoom410.Location, pbRoom410.Size);

                        // now make the pictureboxes disappear
                        pbRoom40.Visible = false;
                        pbRoom41.Visible = false;
                        pbRoom42.Visible = false;
                        pbRoom43.Visible = false;
                        pbRoom44.Visible = false;
                        pbRoom45.Visible = false;
                        pbRoom46.Visible = false;
                        pbRoom47.Visible = false;
                        pbRoom48.Visible = false;
                        pbRoom49.Visible = false;
                        pbRoom410.Visible = false;
                    }

                    //enter room 3
                    if (rChar.Top <= pbArena.Top && rChar.Left >= 301 && rChar.Right <= 450)
                    {
                        //draw main character
                        rChar = new Rectangle(350, 350, charWidth, charHeight);

                        room3 = true;
                        room2 = false;
                        room1 = false;
                        room0 = false;
                        tmrRoom3.Start();
                        tmrRoom2.Stop();

                        //walls of room 3
                        if (room3 == true)
                        {
                            //walls
                            rWall3[0] = new Rectangle(pbRoom30.Location, pbRoom30.Size);
                            rWall3[1] = new Rectangle(pbRoom31.Location, pbRoom31.Size);
                            rWall3[2] = new Rectangle(pbRoom32.Location, pbRoom32.Size);
                            rWall3[3] = new Rectangle(pbRoom33.Location, pbRoom33.Size);
                            rWall3[4] = new Rectangle(pbRoom34.Location, pbRoom34.Size);
                            rWall3[5] = new Rectangle(pbRoom35.Location, pbRoom35.Size);
                            rWall3[6] = new Rectangle(pbRoom36.Location, pbRoom36.Size);
                            rWall3[7] = new Rectangle(pbRoom37.Location, pbRoom37.Size);
                            rWall3[8] = new Rectangle(pbRoom38.Location, pbRoom38.Size);
                            rWall3[9] = new Rectangle(pbRoom39.Location, pbRoom39.Size);

                            // now make the pictureboxes disappear
                            pbRoom30.Visible = false;
                            pbRoom31.Visible = false;
                            pbRoom32.Visible = false;
                            pbRoom33.Visible = false;
                            pbRoom34.Visible = false;
                            pbRoom35.Visible = false;
                            pbRoom36.Visible = false;
                            pbRoom37.Visible = false;
                            pbRoom38.Visible = false;
                            pbRoom39.Visible = false;
                        }

                        this.Refresh();

                    }

                //enter room 5
                    if (rChar.Bottom >= pbArena.Bottom - 20 && rChar.Left >= 569 && rChar.Right <= pbArena.Right + charWidth)
                    {
                        //draw main character
                        rChar = new Rectangle(580, 20, charWidth, charHeight);

                        room5 = true;
                        room3 = false;
                        room2 = false;
                        room1 = false;
                        room0 = false;
                        tmrRoom5.Start();
                        tmrRoom2.Stop();

                        //walls of room 3
                        if (room5 == true)
                        {
                            //walls
                            rWall5[0] = new Rectangle(pbRoom50.Location, pbRoom50.Size);
                            rWall5[1] = new Rectangle(pbRoom51.Location, pbRoom51.Size);
                            rWall5[2] = new Rectangle(pbRoom52.Location, pbRoom52.Size);
                            rWall5[3] = new Rectangle(pbRoom53.Location, pbRoom53.Size);
                            rWall5[4] = new Rectangle(pbRoom54.Location, pbRoom54.Size);
                            rWall5[5] = new Rectangle(pbRoom55.Location, pbRoom55.Size);
                            rWall5[6] = new Rectangle(pbRoom56.Location, pbRoom56.Size);
                            rWall5[7] = new Rectangle(pbRoom57.Location, pbRoom57.Size);

                            // now make the pictureboxes disappear
                            pbRoom50.Visible = false;
                            pbRoom51.Visible = false;
                            pbRoom52.Visible = false;
                            pbRoom53.Visible = false;
                            pbRoom54.Visible = false;
                            pbRoom55.Visible = false;
                            pbRoom56.Visible = false;
                            pbRoom57.Visible = false;
                        }

                        this.Refresh();

                    }



            }
        }
        private void tmrRoom3_Tick(object sender, EventArgs e)
        {
            //torches

            if (count6 >= (totalRowsTorch * totalColsTorch))
            {
                count6 = 0;
            }

            col6 = count6 % totalColsTorch;  //returns the remainder only (no integer)
            count6 += 1;

            this.Refresh();


            rDoor = new Rectangle(526, 1, doorWidth, doorHeight);

            if (doorOpened == false)
            {

                if (rChar.IntersectsWith(rDoor) && keyTotal >= 5)
                {
                    doorOpen = true;
                    doorOpened = true;
                }


                while (doorOpen == true)
                {
                    if (count5 >= (totalRowsDoor * totalColsDoor))
                    {
                        count5 = 13;
                        doorOpen = false;
                    }

                    col5 = count5 % totalColsDoor;  //returns the remainder only (no integer)
                    count5 += 1;

                    this.Refresh();
                }
            }


            if (rChar.Top <= 50 && rChar.Left >= 520 && rChar.Right <= 635 && keyTotal >= 5)

            {

                gameOver = true;
            
            }

            //re enter room 2
            if (rChar.Bottom >= pbArena.Bottom && rChar.Left >= 301 && rChar.Right <= 442)
            {
                rChar = new Rectangle(355, 40, charWidth, charHeight);
                room2 = true;
                room3 = false;
                tmrRoom2.Start();
                tmrRoom3.Stop();
            }


            //enter room 6
            if (rChar.Bottom <= pbArena.Bottom && rChar.Top >= 185 && rChar.Left <= pbArena.Left)
            {
                //draw main character
                rChar = new Rectangle(580, 250, charWidth, charHeight);

                room6 = true;
                room3 = false;
                room2 = false;
                room1 = false;
                room0 = false;
                tmrRoom6.Start();
                tmrRoom3.Stop();

                //walls of room 6
                if (room6 == true)
                {
                    //walls
                    rWall6[0] = new Rectangle(pbRoom60.Location, pbRoom60.Size);
                    rWall6[1] = new Rectangle(pbRoom61.Location, pbRoom61.Size);
                    rWall6[2] = new Rectangle(pbRoom62.Location, pbRoom62.Size);
                    rWall6[3] = new Rectangle(pbRoom63.Location, pbRoom63.Size);
                    rWall6[4] = new Rectangle(pbRoom64.Location, pbRoom64.Size);
                    rWall6[5] = new Rectangle(pbRoom65.Location, pbRoom65.Size);
                    rWall6[6] = new Rectangle(pbRoom66.Location, pbRoom66.Size);
                    rWall6[7] = new Rectangle(pbRoom67.Location, pbRoom67.Size);

                    // now make the pictureboxes disappear
                    pbRoom60.Visible = false;
                    pbRoom61.Visible = false;
                    pbRoom62.Visible = false;
                    pbRoom63.Visible = false;
                    pbRoom64.Visible = false;
                    pbRoom65.Visible = false;
                    pbRoom66.Visible = false;
                    pbRoom67.Visible = false;
                }

                this.Refresh();

            }


            //removes slimes
            foreach (Rectangle s in sRect.ToList())
            {

                slimeXVel.RemoveAt(sRect.IndexOf(s));
                slimeYVel.RemoveAt(sRect.IndexOf(s));
                sRect.RemoveAt(sRect.IndexOf(s));

            }

            //removes goblins
            foreach (Rectangle r in rRect.ToList())
            {

                goblinXVel.RemoveAt(rRect.IndexOf(r));
                goblinYVel.RemoveAt(rRect.IndexOf(r));
                rRect.RemoveAt(rRect.IndexOf(r));

            }

            //removes bats
            foreach (Rectangle b in bRect.ToList())
            {

                batXVel.RemoveAt(bRect.IndexOf(b));
                batYVel.RemoveAt(bRect.IndexOf(b));
                bRect.RemoveAt(bRect.IndexOf(b));

            }

        }

        private void tmrRoom4_Tick(object sender, EventArgs e)
        {

            //torches

            if (count6 >= (totalRowsTorch * totalColsTorch))
            {
                count6 = 0;
            }

            col6 = count6 % totalColsTorch;  //returns the remainder only (no integer)
            count6 += 1;

            this.Refresh();


            //bat code
            int x = rnd.Next(-12, -8); 
            int y = rnd.Next(-12, -8);
            batXVel.Add(x);   //X direction
            batYVel.Add(y);   //Y direction

            //spawn max
            if (bRect.Count <= batMax)
            {
                bRect.Add(new Rectangle(pbArena.Width / 2, pbArena.Height / 2, batWidth * 2, batHeight * 2));
            }

            // after the last row, start over
            if (count4 >= (totalRowsBat * totalColsBat))
                count4 = 0;

            // do some math on "count" to give you row and column on the spritesheet
            //row = count \ totalCols     //returns the integer only (no remainder) using backslash
            col4 = count4 % totalColsBat;  //returns the remainder only (no integer)

            // increment the counter
            count4 += 1;

            foreach (Rectangle b in bRect.ToList())
            {
                if (b.IntersectsWith(rChar) && attack == true)
                {
                    batXVel.RemoveAt(bRect.IndexOf(b));
                    batYVel.RemoveAt(bRect.IndexOf(b));
                    bRect.RemoveAt(bRect.IndexOf(b));
                    batMax -= 1;
                }
            }

            for (int i = 0; i < bRect.Count; i++)
            {
                // isolate each rectangle 'r' from the list 'rRect'
                Rectangle b = bRect[i];
                b.X += batXVel[i];
                b.Y += batYVel[i];

                for (int z = 0; z <= 10; z++)
                    {
                        //the character is normally able to move freely in any direction
                        //if the character collides with a rectangle ("wall"), then back it off in the opposite direction by one "move"

                        if (b.IntersectsWith(rWall4[z]))
                        {
                            //bounce off the walls
                            //if the ball hits the LEFT side of the Canvas, reverse the velocity value xVel
                            if (b.Left <= rWall4[z].Right && b.Left > rWall4[z].Left)
                                b.X += 5;
                                batXVel[i] = rnd.Next(8, 12);

                            //if the ball hits the RIGHT side...
                            if (b.Right >= rWall4[z].Left && b.Left < rWall4[z].Left)
                                b.X -= 7;
                                batXVel[i] = rnd.Next(-12, -8);

                            //if the ball hits the TOP...
                            if (b.Y <= rWall4[z].Bottom + 200 && b.Y > rWall4[z].Top)
                                batYVel[i] = rnd.Next(8, 12);
                            do
                            {
                                batXVel[i] = rnd.Next(-10, 10);
                            }
                            while (batXVel[i] >= 6 && batXVel[i] <= 6);
        
                            //if the ball hits the BOTTOM...
                            if (b.Bottom >= rWall4[z].Top && b.Bottom < rWall4[z].Bottom)
                                batYVel[i] = rnd.Next(-12, -8);
                            do
                            {
                                batXVel[i] = rnd.Next(-10, 10);
                            }
                            while (batXVel[i] >= 6 && batXVel[i] <= 6);
                        }

                        // update the rectangle in the list
                        bRect[i] = b;
                    }
                }
        
            //re enter room 2
                if (rChar.Top >= 265 && rChar.Left <= pbArena.Left)
                {

                    rChar = new Rectangle(600, 310, charWidth, charHeight);
                    room2 = true;
                    room3 = false;
                    room4 = false;
                    room1 = false;
                    room0 = false;
                    tmrRoom2.Start();
                    tmrRoom4.Stop();

                }

            //die if you touch spikes
                if (rChar.Top >= 295 && rChar.Left >= 260 && rChar.Right <= 385)
                {

                    health -= health;
                    this.Refresh();

                }

                //removes slimes
                foreach (Rectangle s in sRect.ToList())
                {

                    slimeXVel.RemoveAt(sRect.IndexOf(s));
                    slimeYVel.RemoveAt(sRect.IndexOf(s));
                    sRect.RemoveAt(sRect.IndexOf(s));

                }

                //removes goblins
                foreach (Rectangle r in rRect.ToList())
                {

                    goblinXVel.RemoveAt(rRect.IndexOf(r));
                    goblinYVel.RemoveAt(rRect.IndexOf(r));
                    rRect.RemoveAt(rRect.IndexOf(r));

                }

                this.Refresh();

            
        }

        private void tmrEnemyAtk_Tick(object sender, EventArgs e)
        {
            foreach (Rectangle r in rRect.ToList())
            {
                if (r.IntersectsWith(rChar))
                {
                    health -= 25;
                    snd2.URL = @"dmg.mp3";
                }

            }

            foreach (Rectangle s in sRect.ToList())
            {
                if (s.IntersectsWith(rChar))
                {
                    health -= 50;
                    snd2.URL = @"dmg.mp3";
                }

            }


            foreach (Rectangle b in bRect.ToList())
            {
                if (b.IntersectsWith(rChar))
                {
                    health -= 10;
                    snd2.URL = @"dmg.mp3";
                }

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            snd1.URL = @"menuThemeMp3.mp3";

            tmrChar.Enabled = true;
            tmrChar.Start();

        }

        private void tmrKeyPickUp_Tick(object sender, EventArgs e)
        {

            keyTotal += 1;
            tmrKeyPickUp.Stop();

        }

        private void tmrRoom5_Tick(object sender, EventArgs e)
        {
       
            //torches

            if (count6 >= (totalRowsTorch * totalColsTorch))
            {
                count6 = 0;
            }

            col6 = count6 % totalColsTorch;  //returns the remainder only (no integer)
            count6 += 1;

            this.Refresh();


            //goblin code
            int x = rnd.Next(-6, 6);
            int y = rnd.Next(-6, 6);
            goblinXVel.Add(x);   //X direction
            goblinYVel.Add(y);   //Y direction

            //spawn max
            if (rRect.Count <= goblinMax2)
            {
                rRect.Add(new Rectangle(rnd.Next(120, 450), 280, goblinWidth * 2, goblinHeight * 2));
            }

            // after the last row, start over
            if (count2 >= (totalRowsGoblin * totalColsGoblin))
                count2 = 0;

            // do some math on "count" to give you row and column on the spritesheet
            //row = count \ totalCols     //returns the integer only (no remainder) using backslash
            col2 = count2 % totalColsGoblin;  //returns the remainder only (no integer)

            // increment the counter
            count2 += 1;

            foreach (Rectangle r in rRect.ToList())
            {
                if (r.IntersectsWith(rChar) && attack == true)
                {
                    goblinXVel.RemoveAt(rRect.IndexOf(r));
                    goblinYVel.RemoveAt(rRect.IndexOf(r));
                    rRect.RemoveAt(rRect.IndexOf(r));
                    goblinMax2 -= 1;
                }
            }

            for (int i = 0; i < rRect.Count; i++)
            {
                // isolate each rectangle 'r' from the list 'rRect'
                Rectangle r = rRect[i];
                r.X += goblinXVel[i];
                r.Y += goblinYVel[i];

                for (int z = 0; z <= 7; z++)
                {
                    //the character is normally able to move freely in any direction
                    //if the character collides with a rectangle ("wall"), then back it off in the opposite direction by one "move"

                    if (r.IntersectsWith(rWall5[z]))
                    {
                        //bounce off the walls
                        //if the ball hits the LEFT side of the Canvas, reverse the velocity value xVel
                        if (r.Left <= rWall5[z].Right && r.Left > rWall5[z].Left)
                            r.X += 5;
                            goblinXVel[i] = rnd.Next(4, 6);

                        //if the ball hits the RIGHT side...
                        if (r.Right >= rWall5[z].Left && r.Left < rWall5[z].Left)
                            r.X -= 7;
                            goblinXVel[i] = rnd.Next(-6, -4);

                        //if the ball hits the TOP...
                        if (r.Y <= rWall5[z].Bottom + 200 && r.Y > rWall5[z].Top)
                            goblinYVel[i] = rnd.Next(4, 6);
                        do
                        {
                            goblinXVel[i] = rnd.Next(-4, 4);
                        }
                        while (goblinXVel[i] >= 2 && goblinXVel[i] <= 2);
                        //if the ball hits the BOTTOM...
                        if (r.Bottom >= rWall5[z].Top && r.Bottom < rWall5[z].Bottom)
                            goblinYVel[i] = rnd.Next(-6, -4);
                        do
                        {
                            goblinXVel[i] = rnd.Next(-4, 4);
                        }
                        while (goblinXVel[i] >= 2 && goblinXVel[i] <= 2);
                    }

                    // update the rectangle in the list
                    rRect[i] = r;
                }
            }
                //removes slimes
                foreach (Rectangle s in sRect.ToList())
                {
                    slimeXVel.RemoveAt(sRect.IndexOf(s));
                    slimeYVel.RemoveAt(sRect.IndexOf(s));
                    sRect.RemoveAt(sRect.IndexOf(s));
                }

                //removes bats
                foreach (Rectangle b in bRect.ToList())
                {
                    batXVel.RemoveAt(bRect.IndexOf(b));
                    batYVel.RemoveAt(bRect.IndexOf(b));
                    bRect.RemoveAt(bRect.IndexOf(b));
                }

                //renter room 2
                if (rChar.Top <= pbArena.Top && rChar.Left >= 560)
                {

                    rChar = new Rectangle(550, 310, charWidth, charHeight);
                    room2 = true;
                    room3 = false;
                    room4 = false;
                    room5 = false;
                    room1 = false;
                    room0 = false;
                    tmrRoom2.Start();
                    tmrRoom5.Stop();

                    this.Refresh();

                }

                // redraw the image
                this.Refresh();

            

        }

        private void tmrRoom6_Tick(object sender, EventArgs e)
        {

            //torches

            if (count6 >= (totalRowsTorch * totalColsTorch))
            {
                count6 = 0;
            }

            col6 = count6 % totalColsTorch;  //returns the remainder only (no integer)
            count6 += 1;

            this.Refresh();

            //slime code
            int x = rnd.Next(-5, 5);
            int y = rnd.Next(-5, 5);
            slimeXVel.Add(x);   //X direction
            slimeYVel.Add(y);   //Y direction

            //spawn max
            if (sRect.Count <= slimeMax2)
            {
                sRect.Add(new Rectangle(rnd.Next(180, 550), 270, slimeWidth * 2, slimeHeight * 2));
            }

            // after the last row, start over
            if (count3 >= (totalRowsSlime * totalColsSlime))
                count3 = 0;

            // do some math on "count" to give you row and column on the spritesheet
            //row = count \ totalCols     //returns the integer only (no remainder) using backslash
            col3 = count3 % totalColsSlime;  //returns the remainder only (no integer)

            // increment the counter
            count3 += 1;

            foreach (Rectangle s in sRect.ToList())
            {
                if (s.IntersectsWith(rChar) && attack == true)
                {
                    slimeXVel.RemoveAt(sRect.IndexOf(s));
                    slimeYVel.RemoveAt(sRect.IndexOf(s));
                    sRect.RemoveAt(sRect.IndexOf(s));
                    slimeMax2 -= 1;
                }
            }

            for (int i = 0; i < sRect.Count; i++)
            {
                // isolate each rectangle 'r' from the list 'rRect'
                Rectangle s = sRect[i];
                s.X += slimeXVel[i];
                s.Y += slimeYVel[i];

              for (int z = 0; z <= 7; z++)
                    {
                        //the character is normally able to move freely in any direction
                        //if the character collides with a rectangle ("wall"), then back it off in the opposite direction by one "move"

                        if (s.IntersectsWith(rWall6[z]))
                        {
                            //bounce off the walls
                            //if the ball hits the LEFT side of the Canvas, reverse the velocity value xVel
                            if (s.Left <= rWall6[z].Right && s.Left > rWall6[z].Left)
                                s.X += 5;
                                slimeXVel[i] = rnd.Next(1, 3);

                            //if the ball hits the RIGHT side...
                            if (s.Right >= rWall6[z].Left && s.Left < rWall6[z].Left)
                                s.X -= 5;
                                slimeXVel[i] = rnd.Next(-3, -1);

                            //if the ball hits the TOP...
                            if (s.Y <= rWall6[z].Bottom + 200 && s.Y > rWall6[z].Top)
                                slimeYVel[i] = rnd.Next(1, 3);
                                slimeXVel[i] = rnd.Next(-3, 3);


                            //if the ball hits the BOTTOM...
                            if (s.Bottom >= rWall6[z].Top && s.Bottom < rWall6[z].Bottom)
                                slimeYVel[i] = rnd.Next(-3, -1);
                                slimeXVel[i] = rnd.Next(-3, 3);
                        }

                        // update the rectangle in the list
                        sRect[i] = s;
                    }
                }


             //enter room 3
            if (rChar.Bottom <= pbArena.Bottom && rChar.Top >= 185 && rChar.Right >= pbArena.Right)
            {
                //draw main character
                rChar = new Rectangle(50, 250, charWidth, charHeight);

                room3 = true;
                room6 = false;
                room2 = false;
                room1 = false;
                room0 = false;
                tmrRoom3.Start();
                tmrRoom6.Stop();

                this.Refresh();
            }


            //removes goblins
            foreach (Rectangle r in rRect.ToList())
            {
                goblinXVel.RemoveAt(rRect.IndexOf(r));
                goblinYVel.RemoveAt(rRect.IndexOf(r));
                rRect.RemoveAt(rRect.IndexOf(r));
            }

            //removes bats
            foreach (Rectangle b in bRect.ToList())
            {
                batXVel.RemoveAt(bRect.IndexOf(b));
                batYVel.RemoveAt(bRect.IndexOf(b));
                bRect.RemoveAt(bRect.IndexOf(b));
            }

        }

        private void tmrMenu_Tick(object sender, EventArgs e)
        {

            //// increment the counter
            //count7 += 1;

            //menu fire
            if (count8 >= (totalRowsFire * totalColsFire))
            {
                count8 = 0;
            }

            // do some math on "count" to give you row and column on the spritesheet
            row8 = count8 / totalColsFire;
            col8 = count8 % totalColsFire;      //returns the remainder only (no integer)

            // increment the counter
            count8 += 1;

            this.Refresh();

        }

        private void pbRoom64_Click(object sender, EventArgs e)
        {

        }

        private void pbRoom15_Click(object sender, EventArgs e)
        {

        }

    
    }
}

