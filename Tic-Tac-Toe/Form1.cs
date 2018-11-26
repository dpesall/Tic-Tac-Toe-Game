using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class TicTacToe : Form
    {
        bool freezeBoard = false;
        Random rnd = new Random();
        char[] gameBoard = {'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e'};
        public TicTacToe()
        {
            InitializeComponent();
        }

        private void newGame(object sender, EventArgs e) {
            // Prevents further moves from being played
            freezeBoard = false;
            // Initialized gameBoard array to all empty slots
            for (int i = 0; i < gameBoard.Length; i++)
            {
                gameBoard[i] = 'e';
            }
            // Resets screen to empty board
            square1.Image = square2.Image = square3.Image = square4.Image = square5.Image = square6.Image = square7.Image = square8.Image = square9.Image = System.Drawing.Image.FromFile("empty.png");
            
        }

        private void scoreUp(object sender, EventArgs e, int winner) {
            if (winner == 0)
            {
                int currentScore = 0;
                Int32.TryParse(playerScore.Text, out currentScore);
                currentScore++;
                playerScore.Text = currentScore.ToString();
            }
            if (winner == 1){
                int currentScore = 0;
                Int32.TryParse(computerScore.Text, out currentScore);
                currentScore++;
                computerScore.Text = currentScore.ToString();
            }
        }
        
        // This function executes after each move to check and see if there is a winner.
        private bool checkVictory(object sender, EventArgs e, int recentMove) {
            if (gameBoard[recentMove] == 'x') {
                if (gameBoard[0] == 'x'){
                    if (gameBoard[1] == 'x' && gameBoard[2] == 'x') {
                        scoreUp(sender, e, 0);
                        return true;
                        // x victory
                    }
                    if (gameBoard[4] == 'x' && gameBoard[8] == 'x')
                    {
                        scoreUp(sender, e, 0);
                        return true;
                        // x victory
                    }
                    if (gameBoard[3] == 'x' && gameBoard[6] == 'x')
                    {
                        scoreUp(sender, e, 0);
                        return true;
                        // x victory
                    }
                }
                if (gameBoard[1] == 'x')
                {
                    if (gameBoard[4] == 'x' && gameBoard[7] == 'x')
                    {
                        scoreUp(sender, e, 0);
                        return true;
                        // x victory
                    }
                }
                if (gameBoard[2] == 'x')
                {
                    if (gameBoard[5] == 'x' && gameBoard[8] == 'x')
                    {
                        scoreUp(sender, e, 0);
                        return true;
                        // x victory
                    }
                }
                if (gameBoard[3] == 'x')
                {
                    if (gameBoard[4] == 'x' && gameBoard[5] == 'x')
                    {
                        scoreUp(sender, e, 0);
                        return true;
                        // x victory
                    }
                }
                if (gameBoard[4] == 'x')
                {
                    if (gameBoard[2] == 'x' && gameBoard[6] == 'x')
                    {
                        scoreUp(sender, e, 0);
                        return true;
                        // x victory
                    }
                }
                if (gameBoard[6] == 'x')
                {
                    if (gameBoard[7] == 'x' && gameBoard[8] == 'x')
                    {
                        scoreUp(sender, e, 0);
                        return true;
                        // x victory
                    }
                }
            }
            else
            {
                if (gameBoard[0] == 'o')
                {
                    if (gameBoard[1] == 'o' && gameBoard[2] == 'o')
                    {
                        scoreUp(sender, e, 1);
                        return true;
                        // o victory
                    }
                    if (gameBoard[4] == 'o' && gameBoard[8] == 'o')
                    {
                        scoreUp(sender, e, 1);
                        return true;
                        // o victory
                    }
                    if (gameBoard[3] == 'o' && gameBoard[6] == 'o')
                    {
                        scoreUp(sender, e, 1);
                        return true;
                        // o victory
                    }
                }
                if (gameBoard[1] == 'o')
                {
                    if (gameBoard[4] == 'o' && gameBoard[7] == 'o')
                    {
                        scoreUp(sender, e, 1);
                        return true;
                        // o victory
                    }
                }
                if (gameBoard[2] == 'o')
                {
                    if (gameBoard[5] == 'o' && gameBoard[8] == 'o')
                    {
                        scoreUp(sender, e, 1);
                        return true;
                        // o victory
                    }
                }
                if (gameBoard[3] == 'o')
                {
                    if (gameBoard[4] == 'o' && gameBoard[5] == 'o')
                    {
                        scoreUp(sender, e, 1);
                        return true;
                        // o victory
                    }
                }
                if (gameBoard[4] == 'o')
                {
                    if (gameBoard[2] == 'o' && gameBoard[6] == 'o')
                    {
                        scoreUp(sender, e, 1);
                        return true;
                        // o victory
                    }
                }
                if (gameBoard[6] == 'o')
                {
                    if (gameBoard[7] == 'o' && gameBoard[8] == 'o')
                    {
                        scoreUp(sender, e, 1);
                        return true;
                        // o victory
                    }
                }
            }
            return false;
        }

        private void nextMove(object sender, EventArgs e, int finalMovePosition) {
            freezeBoard = checkVictory(sender, e, finalMovePosition);

            // If a game has ended, the player won't be able to keep placing X's
            if (freezeBoard) {
                return;
            }
            bool validMove = false;
            int finalMove = -1;
            for (int i = 0; i < gameBoard.Length; i++) {
                if (gameBoard[i] == 'e') {
                    finalMove++;
                }
            }
            if (finalMove == -1) {
                validMove = true;
                checkVictory(sender, e, finalMovePosition);
            }
            int computerMove = -1;
            while (!validMove) {
                computerMove = rnd.Next(0, 8);
                if (gameBoard[computerMove] == 'e') {
                    validMove = true;
                    gameBoard[computerMove] = 'o';
                }
            }
            
            switch (computerMove)
            {
                case 0:
                    square1.Image = System.Drawing.Image.FromFile("o.png");
                    gameBoard[0] = 'o';
                    finalMovePosition = 0;
                    break;
                case 1:
                    square2.Image = System.Drawing.Image.FromFile("o.png");
                    gameBoard[1] = 'o';
                    finalMovePosition = 1;
                    break;
                case 2:
                    square3.Image = System.Drawing.Image.FromFile("o.png");
                    gameBoard[2] = 'o';
                    finalMovePosition = 2;
                    break;
                case 3:
                    square4.Image = System.Drawing.Image.FromFile("o.png");
                    gameBoard[3] = 'o';
                    finalMovePosition = 3;
                    break;
                case 4:
                    square5.Image = System.Drawing.Image.FromFile("o.png");
                    gameBoard[4] = 'o';
                    finalMovePosition = 4;
                    break;
                case 5:
                    square6.Image = System.Drawing.Image.FromFile("o.png");
                    gameBoard[5] = 'o';
                    finalMovePosition = 5;
                    break;
                case 6:
                    square7.Image = System.Drawing.Image.FromFile("o.png");
                    gameBoard[6] = 'o';
                    finalMovePosition = 6;
                    break;
                case 7:
                    square8.Image = System.Drawing.Image.FromFile("o.png");
                    gameBoard[7] = 'o';
                    finalMovePosition = 7;
                    break;
                case 8:
                    square9.Image = System.Drawing.Image.FromFile("o.png");
                    gameBoard[8] = 'o';
                    finalMovePosition = 8;
                    break;
                default:
                    break;
            }
            
            freezeBoard = checkVictory(sender, e, finalMovePosition);
            if (freezeBoard)
            {
                return;
            }

        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            newGame(sender, e);
        }

        private void buttonEasy_Click(object sender, EventArgs e)
        {

        }

        private void buttonHard_Click(object sender, EventArgs e)
        {

        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {

        }

        private void square1_Click(object sender, EventArgs e)
        {
            if (gameBoard[0] == 'e' && !freezeBoard) {
                square1.Image = System.Drawing.Image.FromFile("x.png");
                gameBoard[0] = 'x';
                nextMove(sender, e, 0);
            }
        }

        private void square2_Click(object sender, EventArgs e)
        {
            if (gameBoard[1] == 'e' && !freezeBoard)
            {
                square2.Image = System.Drawing.Image.FromFile("x.png");
                gameBoard[1] = 'x';
                nextMove(sender, e, 1);
            }
        }

        private void square3_Click(object sender, EventArgs e)
        {
            if (gameBoard[2] == 'e' && !freezeBoard)
            {
                square3.Image = System.Drawing.Image.FromFile("x.png");
                gameBoard[2] = 'x';
                nextMove(sender, e, 2);
            }
        }

        private void square4_Click(object sender, EventArgs e)
        {
            if (gameBoard[3] == 'e' && !freezeBoard)
            {
                square4.Image = System.Drawing.Image.FromFile("x.png");
                gameBoard[3] = 'x';
                nextMove(sender, e, 3);
            }
        }

        private void square5_Click(object sender, EventArgs e)
        {
            if (gameBoard[4] == 'e' && !freezeBoard)
            {
                square5.Image = System.Drawing.Image.FromFile("x.png");
                gameBoard[4] = 'x';
                nextMove(sender, e, 4);
            }
        }

        private void square6_Click(object sender, EventArgs e)
        {
            if (gameBoard[5] == 'e' && !freezeBoard)
            {
                square6.Image = System.Drawing.Image.FromFile("x.png");
                gameBoard[5] = 'x';
                nextMove(sender, e, 5);
            }
        }

        private void square7_Click(object sender, EventArgs e)
        {
            if (gameBoard[6] == 'e' && !freezeBoard)
            {
                square7.Image = System.Drawing.Image.FromFile("x.png");
                gameBoard[6] = 'x';
                nextMove(sender, e, 6);
            }
        }

        private void square8_Click(object sender, EventArgs e)
        {
            if (gameBoard[7] == 'e' && !freezeBoard)
            {
                square8.Image = System.Drawing.Image.FromFile("x.png");
                gameBoard[7] = 'x';
                nextMove(sender, e, 7);
            }
        }

        private void square9_Click(object sender, EventArgs e)
        {
            if (gameBoard[8] == 'e' && !freezeBoard)
            {
                square9.Image = System.Drawing.Image.FromFile("x.png");
                gameBoard[8] = 'x';
                nextMove(sender, e, 8);
            }
        }
    }
}
