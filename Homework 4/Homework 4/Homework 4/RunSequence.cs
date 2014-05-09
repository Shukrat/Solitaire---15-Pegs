using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_4
{
    class RunSequence
    {
        #region Attributes - Holes
        public HoleMake holeZero;
        public HoleMake holeOne;
        public HoleMake holeTwo;
        public HoleMake holeThree;
        public HoleMake holeFour;
        public HoleMake holeFive;
        public HoleMake holeSix;
        public HoleMake holeSeven;
        public HoleMake holeEight;
        public HoleMake holeNine;
        public HoleMake holeTen;
        public HoleMake holeEleven;
        public HoleMake holeTwelve;
        public HoleMake holeThirteen;
        public HoleMake holeFourteen;
        #endregion

        #region Attributes - bools
        public bool tf_holeZero;
        public bool tf_holeOne;
        public bool tf_holeTwo;
        public bool tf_holeThree;
        public bool tf_holeFour;
        public bool tf_holeFive;
        public bool tf_holeSix;
        public bool tf_holeSeven;
        public bool tf_holeEight;
        public bool tf_holeNine;
        public bool tf_holeTen;
        public bool tf_holeEleven;
        public bool tf_holeTwelve;
        public bool tf_holeThirteen;
        public bool tf_holeFourteen;
        #endregion

        #region Attributes - Stuff
        public Random rand = new Random();
        public int randInt;
        public bool solved = false;
        public bool noMovesLeft = false;
        public int pegsLeft;
        public int count = 0;
        public Form1 form1;
        public string correctMoves = "";
        public List<HoleMake> holeList;
        #endregion

        public bool Solved
        {
            get { return solved; }
            set { solved = value; }
        }

        // Intializes new board
        public RunSequence(Form1 form1)
        {
            this.form1 = form1;
            holeZero = new HoleMake(0);
            holeOne = new HoleMake(1);
            holeTwo = new HoleMake(2);
            holeThree = new HoleMake(3);
            holeFour = new HoleMake(4);
            holeFive = new HoleMake(5);
            holeSix = new HoleMake(6);
            holeSeven = new HoleMake(7);
            holeEight = new HoleMake(8);
            holeNine = new HoleMake(9);
            holeTen = new HoleMake(10);
            holeEleven = new HoleMake(11);
            holeTwelve = new HoleMake(12);
            holeThirteen = new HoleMake(13);
            holeFourteen = new HoleMake(14);

            #region Hole Connectivity Assignment
            //Hole Zero
            holeZero.sw = holeOne;
            holeZero.se = holeTwo;

            // Hole One
            holeOne.ne = holeZero;
            holeOne.e = holeTwo;
            holeOne.se = holeFour;
            holeOne.sw = holeThree;

            // Hole Two
            holeTwo.nw = holeZero;
            holeTwo.w = holeOne;
            holeTwo.se = holeFive;
            holeTwo.sw = holeFour;

            // Hole Three
            holeThree.ne = holeOne;
            holeThree.e = holeFour;
            holeThree.se = holeSeven;
            holeThree.sw = holeSix;

            // Hole Four
            holeFour.ne = holeTwo;
            holeFour.e = holeFive;
            holeFour.se = holeEight;
            holeFour.sw = holeSeven;
            holeFour.w = holeThree;
            holeFour.nw = holeOne;

            // Hole Five
            holeFive.nw = holeTwo;
            holeFive.w = holeFour;
            holeFive.se = holeNine;
            holeFive.sw = holeEight;

            // Hole Six
            holeSix.ne = holeThree;
            holeSix.e = holeSeven;
            holeSix.se = holeEleven;
            holeSix.sw = holeTen;

            // Hole Seven
            holeSeven.ne = holeFour;
            holeSeven.e = holeEight;
            holeSeven.se = holeTwelve;
            holeSeven.sw = holeEleven;
            holeSeven.w = holeSix;
            holeSeven.nw = holeThree;

            // Hole Eight
            holeEight.ne = holeFive;
            holeEight.e = holeNine;
            holeEight.se = holeThirteen;
            holeEight.sw = holeTwelve;
            holeEight.w = holeSeven;
            holeEight.nw = holeFour;

            // Hole Nine
            holeNine.nw = holeFive;
            holeNine.w = holeEight;
            holeNine.se = holeFourteen;
            holeNine.sw = holeThirteen;

            // Hole Ten
            holeTen.ne = holeSix;
            holeTen.e = holeEleven;

            // Hole Eleven
            holeEleven.ne = holeSeven;
            holeEleven.e = holeTwelve;
            holeEleven.w = holeTen;
            holeEleven.nw = holeSix;

            // Hole Twelve
            holeTwelve.ne = holeEight;
            holeTwelve.e = holeThirteen;
            holeTwelve.w = holeEleven;
            holeTwelve.nw = holeSeven;

            // Hole Thirteen
            holeThirteen.ne = holeNine;
            holeThirteen.e = holeFourteen;
            holeThirteen.w = holeTwelve;
            holeThirteen.nw = holeEight;

            // Hole Fourteen
            holeFourteen.w = holeThirteen;
            holeFourteen.nw = holeNine;
            #endregion

            #region List Fill
            holeList = new List<HoleMake>();
            holeList.Add(holeZero);
            holeList.Add(holeOne);
            holeList.Add(holeTwo);
            holeList.Add(holeThree);
            holeList.Add(holeFour);
            holeList.Add(holeFive);
            holeList.Add(holeSix);
            holeList.Add(holeSeven);
            holeList.Add(holeEight);
            holeList.Add(holeNine);
            holeList.Add(holeTen);
            holeList.Add(holeEleven);
            holeList.Add(holeTwelve);
            holeList.Add(holeThirteen);
            holeList.Add(holeFourteen);
            #endregion

            TextBoxWrite = "============================================================";
        }

        // Method to write to text box on Form1
        public string TextBoxWrite
        {
            set { form1.WriteToText(value); }
        }

        // Runs puzzle solving code
        public void RunPuzzleZero(int i)
        {
            // Write which peg is empty
            correctMoves += "Empty Hole: " + i;

            // Cycle at the start of each new for loop
            // Set holes to filled
            foreach (HoleMake hole in holeList)
            {
                hole.Filled = true;
            }

            // After holes are filled, take out peg at
            // hole i from for loop
            holeList[i].Filled = false;

            // Set while loop variable back to false
            noMovesLeft = false;

            #region Set bools for if a move occured to true
            // These bools represent if a move occured, start each one as true
            tf_holeZero = true;
            tf_holeOne = true;
            tf_holeTwo = true;
            tf_holeThree = true;
            tf_holeFour = true;
            tf_holeFive = true;
            tf_holeSix = true;
            tf_holeSeven = true;
            tf_holeEight = true;
            tf_holeNine = true;
            tf_holeTen = true;
            tf_holeEleven = true;
            tf_holeTwelve = true;
            tf_holeThirteen = true;
            tf_holeFourteen = true;
            #endregion

            // Set # of pegs in board to 14
            pegsLeft = 14;

            // Loop to find solution
            while (!noMovesLeft)
            {
                randInt = rand.Next(0, 15);
                switch (randInt)
                {
                    case 0:
                        #region Hole Zero Check
                        // Start at hole zero and check if jump can be made
                        if (holeZero.Filled == true)
                        {
                            if (holeZero.sw.Filled == true && holeZero.sw.sw.Filled == false)
                            {
                                holeZero.Filled = false;
                                holeZero.sw.Filled = false;
                                holeZero.sw.sw.Filled = true;
                                correctMoves += Environment.NewLine + "From: " + holeZero.holeNo + " to " + holeZero.sw.sw.holeNo;
                                pegsLeft--;
                                continue;
                            }
                            if (holeZero.se.Filled == true && holeZero.se.se.Filled == false)
                            {
                                holeZero.Filled = false;
                                holeZero.se.Filled = false;
                                holeZero.se.se.Filled = true;
                                correctMoves += Environment.NewLine + "From: " + holeZero.holeNo + " to " + holeZero.se.se.holeNo;
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeZero = false;
                        #endregion
                        break;
                    case 1:
                        #region Hole One Check
                        // Check hole one, see if jumps can be made
                        if (holeOne.Filled == true)
                        {
                            if (holeOne.sw.Filled == true && holeOne.sw.sw.Filled == false)
                            {
                                holeOne.Filled = false;
                                holeOne.sw.Filled = false;
                                holeOne.sw.sw.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeOne.holeNo + " to " + holeOne.sw.sw.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeOne.se.Filled == true && holeOne.se.se.Filled == false)
                            {
                                holeOne.Filled = false;
                                holeOne.se.Filled = false;
                                holeOne.se.se.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeOne.holeNo + " to " + holeOne.se.se.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeOne = false;
                        #endregion
                        break;
                    case 2:
                        #region Hole Two Check
                        // Check hole two, see if jumps can be made
                        if (holeTwo.Filled == true)
                        {
                            if (holeTwo.sw.Filled == true && holeTwo.sw.sw.Filled == false)
                            {
                                holeTwo.Filled = false;
                                holeTwo.sw.Filled = false;
                                holeTwo.sw.sw.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeTwo.holeNo + " to " + holeTwo.sw.sw.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeTwo.se.Filled == true && holeTwo.se.se.Filled == false)
                            {
                                holeTwo.Filled = false;
                                holeTwo.se.Filled = false;
                                holeTwo.se.se.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeTwo.holeNo + " to " + holeTwo.se.se.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeTwo = false;
                        #endregion
                        break;
                    case 3:
                        #region Hole Three Check
                        // Check hole three, see if jumps can be made
                        if (holeThree.Filled == true)
                        {
                            if (holeThree.sw.Filled == true && holeThree.sw.sw.Filled == false)
                            {
                                holeThree.Filled = false;
                                holeThree.sw.Filled = false;
                                holeThree.sw.sw.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeThree.holeNo + " to " + holeThree.sw.sw.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeThree.se.Filled == true && holeThree.se.se.Filled == false)
                            {
                                holeThree.Filled = false;
                                holeThree.se.Filled = false;
                                holeThree.se.se.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeThree.holeNo + " to " + holeThree.se.se.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeThree.ne.Filled == true && holeThree.ne.ne.Filled == false)
                            {
                                holeThree.Filled = false;
                                holeThree.ne.Filled = false;
                                holeThree.ne.ne.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeThree.holeNo + " to " + holeThree.ne.ne.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeThree.e.Filled == true && holeThree.e.e.Filled == false)
                            {
                                holeThree.Filled = false;
                                holeThree.e.Filled = false;
                                holeThree.e.e.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeThree.holeNo + " to " + holeThree.e.e.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeThree = false;
                        #endregion
                        break;
                    case 4:
                        #region Hole Four Check
                        // Check hole four, see if jumps can be made
                        if (holeFour.Filled == true)
                        {
                            if (holeFour.sw.Filled == true && holeFour.sw.sw.Filled == false)
                            {
                                holeFour.Filled = false;
                                holeFour.sw.Filled = false;
                                holeFour.sw.sw.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeFour.holeNo + " to " + holeFour.sw.sw.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeFour.se.Filled == true && holeFour.se.se.Filled == false)
                            {
                                holeFour.Filled = false;
                                holeFour.se.Filled = false;
                                holeFour.se.se.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeFour.holeNo + " to " + holeFour.se.se.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeFour = false;
                        #endregion
                        break;
                    case 5:
                        #region Hole Five Check
                        // Check hole Five, see if jumps can be made
                        if (holeFive.Filled == true)
                        {
                            if (holeFive.sw.Filled == true && holeFive.sw.sw.Filled == false)
                            {
                                holeFive.Filled = false;
                                holeFive.sw.Filled = false;
                                holeFive.sw.sw.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeFive.holeNo + " to " + holeFive.sw.sw.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeFive.se.Filled == true && holeFive.se.se.Filled == false)
                            {
                                holeFive.Filled = false;
                                holeFive.se.Filled = false;
                                holeFive.se.se.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeFive.holeNo + " to " + holeFive.se.se.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeFive.nw.Filled == true && holeFive.nw.nw.Filled == false)
                            {
                                holeFive.Filled = false;
                                holeFive.nw.Filled = false;
                                holeFive.nw.nw.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeFive.holeNo + " to " + holeFive.nw.nw.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeFive.w.Filled == true && holeFive.w.w.Filled == false)
                            {
                                holeFive.Filled = false;
                                holeFive.w.Filled = false;
                                holeFive.w.w.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeFive.holeNo + " to " + holeFive.w.w.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeFive = false;
                        #endregion
                        break;
                    case 6:
                        #region Hole Six Check
                        // Check hole one, see if jumps can be made
                        if (holeSix.Filled == true)
                        {
                            if (holeSix.ne.Filled == true && holeSix.ne.ne.Filled == false)
                            {
                                holeSix.Filled = false;
                                holeSix.ne.Filled = false;
                                holeSix.ne.ne.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeSix.holeNo + " to " + holeSix.ne.ne.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeSix.e.Filled == true && holeSix.e.e.Filled == false)
                            {
                                holeSix.Filled = false;
                                holeSix.e.Filled = false;
                                holeSix.e.e.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeSix.holeNo + " to " + holeSix.e.e.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeSix = false;
                        #endregion
                        break;
                    case 7:
                        #region Hole Seven Check
                        // Check hole seven, see if jumps can be made
                        if (holeSeven.Filled == true)
                        {
                            if (holeSeven.e.Filled == true && holeSeven.e.e.Filled == false)
                            {
                                holeSeven.Filled = false;
                                holeSeven.e.Filled = false;
                                holeSeven.e.e.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeSeven.holeNo + " to " + holeSeven.e.e.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeSeven.ne.Filled == true && holeSeven.ne.ne.Filled == false)
                            {
                                holeSeven.Filled = false;
                                holeSeven.ne.Filled = false;
                                holeSeven.ne.ne.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeSeven.holeNo + " to " + holeSeven.ne.ne.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeSeven = false;
                        #endregion
                        break;
                    case 8:
                        #region Hole Eight Check
                        // Check hole eight, see if jumps can be made
                        if (holeEight.Filled == true)
                        {
                            if (holeEight.w.Filled == true && holeEight.w.w.Filled == false)
                            {
                                holeEight.Filled = false;
                                holeEight.w.Filled = false;
                                holeEight.w.w.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeEight.holeNo + " to " + holeEight.w.w.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeEight.nw.Filled == true && holeEight.nw.nw.Filled == false)
                            {
                                holeEight.Filled = false;
                                holeEight.nw.Filled = false;
                                holeEight.nw.nw.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeEight.holeNo + " to " + holeEight.nw.nw.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeEight = false;
                        #endregion
                        break;
                    case 9:
                        #region Hole Nine Check
                        // Check hole nine, see if jumps can be made
                        if (holeNine.Filled == true)
                        {
                            if (holeNine.w.Filled == true && holeNine.w.w.Filled == false)
                            {
                                holeNine.Filled = false;
                                holeNine.w.Filled = false;
                                holeNine.w.w.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeNine.holeNo + " to " + holeNine.w.w.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeNine.nw.Filled == true && holeNine.nw.nw.Filled == false)
                            {
                                holeNine.Filled = false;
                                holeNine.nw.Filled = false;
                                holeNine.nw.nw.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeNine.holeNo + " to " + holeNine.nw.nw.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeNine = false;
                        #endregion
                        break;
                    case 10:
                        #region Hole Ten Check
                        // Check hole ten, see if jumps can be made
                        if (holeTen.Filled == true)
                        {
                            if (holeTen.e.Filled == true && holeTen.e.e.Filled == false)
                            {
                                holeTen.Filled = false;
                                holeTen.e.Filled = false;
                                holeTen.e.e.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeTen.holeNo + " to " + holeTen.e.e.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeTen.ne.Filled == true && holeTen.ne.ne.Filled == false)
                            {
                                holeTen.Filled = false;
                                holeTen.ne.Filled = false;
                                holeTen.ne.ne.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeTen.holeNo + " to " + holeTen.ne.ne.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeTen = false;
                        #endregion
                        break;
                    case 11:
                        #region Hole Eleven Check
                        // Check hole eleven, see if jumps can be made
                        if (holeEleven.Filled == true)
                        {
                            if (holeEleven.e.Filled == true && holeEleven.e.e.Filled == false)
                            {
                                holeEleven.Filled = false;
                                holeEleven.e.Filled = false;
                                holeEleven.e.e.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeEleven.holeNo + " to " + holeEleven.e.e.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeEleven.ne.Filled == true && holeEleven.ne.ne.Filled == false)
                            {
                                holeEleven.Filled = false;
                                holeEleven.ne.Filled = false;
                                holeEleven.ne.ne.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeEleven.holeNo + " to " + holeEleven.ne.ne.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeEleven = false;
                        #endregion
                        break;
                    case 12:
                        #region Hole Twelve Check
                        // Check hole twelve, see if jumps can be made
                        if (holeTwelve.Filled == true)
                        {
                            if (holeTwelve.nw.Filled == true && holeTwelve.nw.nw.Filled == false)
                            {
                                holeTwelve.Filled = false;
                                holeTwelve.nw.Filled = false;
                                holeTwelve.nw.nw.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeTwelve.holeNo + " to " + holeTwelve.nw.nw.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeTwelve.ne.Filled == true && holeTwelve.ne.ne.Filled == false)
                            {
                                holeTwelve.Filled = false;
                                holeTwelve.ne.Filled = false;
                                holeTwelve.ne.ne.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeTwelve.holeNo + " to " + holeTwelve.ne.ne.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeTwelve = false;
                        #endregion
                        break;
                    case 13:
                        #region Hole Thirteen Check
                        // Check hole thirteen, see if jumps can be made
                        if (holeThirteen.Filled == true)
                        {
                            if (holeThirteen.nw.Filled == true && holeThirteen.nw.nw.Filled == false)
                            {
                                holeThirteen.Filled = false;
                                holeThirteen.nw.Filled = false;
                                holeThirteen.nw.nw.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeThirteen.holeNo + " to " + holeThirteen.nw.nw.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeThirteen.w.Filled == true && holeThirteen.w.w.Filled == false)
                            {
                                holeThirteen.Filled = false;
                                holeThirteen.w.Filled = false;
                                holeThirteen.w.w.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeThirteen.holeNo + " to " + holeThirteen.w.w.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeThirteen = false;
                        #endregion
                        break;
                    case 14:
                        #region Hole Fourteen Check
                        // Check hole fourteen, see if jumps can be made
                        if (holeFourteen.Filled == true)
                        {
                            if (holeFourteen.nw.Filled == true && holeFourteen.nw.nw.Filled == false)
                            {
                                holeFourteen.Filled = false;
                                holeFourteen.nw.Filled = false;
                                holeFourteen.nw.nw.filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeFourteen.holeNo + " to " + holeFourteen.nw.nw.holeNo);
                                pegsLeft--;
                                continue;
                            }
                            if (holeFourteen.w.Filled == true && holeFourteen.w.w.Filled == false)
                            {
                                holeFourteen.Filled = false;
                                holeFourteen.w.Filled = false;
                                holeFourteen.w.w.Filled = true;
                                correctMoves += Environment.NewLine + ("From: " + holeFourteen.holeNo + " to " + holeFourteen.w.w.holeNo);
                                pegsLeft--;
                                continue;
                            }
                        }
                        tf_holeFourteen = false;
                        #endregion
                        break;
                    default: break;
                }

                if (tf_holeZero == false && tf_holeOne == false && tf_holeTwo == false &&
                    tf_holeThree == false && tf_holeFour == false && tf_holeFive == false &&
                    tf_holeSix == false && tf_holeSeven == false && tf_holeEight == false &&
                    tf_holeNine == false && tf_holeTen == false && tf_holeEleven == false &&
                    tf_holeTwelve == false && tf_holeThirteen == false && tf_holeFourteen == false)
                {
                    if (pegsLeft == 1)
                    {
                        solved = true;
                        for (int x = 0; x < 15; x++)
                        {
                            if (holeList[x].Filled == true)
                            {
                                correctMoves += Environment.NewLine + "Position complete: " + x;
                            }
                        }
                        correctMoves += Environment.NewLine + "Pegs Left: " + pegsLeft;
                        correctMoves += Environment.NewLine + "============================================================";
                        TextBoxWrite = correctMoves;
                        break;
                    }
                    else
                    {
                        correctMoves = "";
                        noMovesLeft = true;
                    }
                }
            }

        }
    }
}
