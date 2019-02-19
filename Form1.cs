using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace prjBestBlackJackKappa
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        WindowsMediaPlayer player2 = new WindowsMediaPlayer();
        Random r = new Random();
        int cardValuePlayer1 = 0;
        int cardValuePlayer2 = 0;
        int cardValuePlayer3 = 0;
        int cardValuePlayer4 = 0;
        int cardValuePlayer5 = 0;
        int cardValueDealer1 = 0;
        int cardValueDealer2 = 0;
        int cardValueDealer3 = 0;
        int cardValueDealer4 = 0;
        int cardValueDealer5 = 0;
        int cardDealer1 = 0;
        int cardDealer2 = 0;
        int cardDealer3 = 0;
        int cardDealer4 = 0;
        int cardDealer5 = 0;
        int cardPlayer1 = 0;
        int cardPlayer2 = 0;
        int cardPlayer3 = 0;
        int cardPlayer4 = 0;
        int cardPlayer5 = 0;
        String cardFile;
        int cardDealertotal;
        int bet;
        int money;
        int money2 = 100;
        int pot;
        int cash;
        public Form1()
        {
            InitializeComponent();
            
        } 

        private void btnDeal_Click(object sender, EventArgs e)

        {
            //sound occurs when button "Deal" is pressed
            player2.URL = "Deal em.mp3";
          
            //gives value a random number

            cardDealer1 = r.Next(1, 53);

            //If the Dealer picks an ace, a sound will occur
            if (cardDealer1 == 1 | cardDealer1 == 14 | cardDealer1 == 27 | cardDealer1 == 40)
           {
               player2.URL = "Just the luck of the draw.mp3";
           }
            //Assigns the correct picture to the cards
            cardFile = "Card Images/card" + cardDealer1 + ".JPG";
            picDealer1.Image = Image.FromFile(cardFile);

            

            //gives value a random number, and ensures that it will not have the same number as the other values
            cardPlayer1 = r.Next(1, 53);
            do
            {
                cardPlayer1 = r.Next(1, 53);
            } while (cardPlayer1 == cardDealer1 | cardPlayer1 == cardDealer2);

            //Assigns the correct picture to the cards
            cardFile = "Card Images/card" + cardPlayer1 + ".JPG";
            picPlayer1.Image = Image.FromFile(cardFile);


            //gives value a random number, and ensures that it will not have the same number as the other values
            cardPlayer2 = r.Next(1, 53);
            do
            {
                cardPlayer2 = r.Next(1, 53);
            } while (cardPlayer2 == cardDealer1 | cardPlayer2 == cardDealer2 || cardPlayer2 == cardPlayer1);

            //Assigns the correct picture to the cards
            cardFile = "Card Images/card" + cardPlayer2 + ".JPG";
            picPlayer2.Image = Image.FromFile(cardFile);


        
           

            


            //We then will mark every card with a value. Because the remainder of the card is the card value when divided by 13, we assign each picture with its face value
            cardValueDealer1 = cardDealer1 % 13;
           
            cardValuePlayer1 = cardPlayer1 % 13;
            cardValuePlayer2 = cardPlayer2 % 13;

            //Here, we give jacks, queens, and kings the value of 10 because those are the rules of Blackjack
            if (cardValueDealer1 == 11 || cardValueDealer1 == 12 || cardValueDealer1 == 0)
            {
                cardValueDealer1 = 10;
            }
           
            if (cardValuePlayer1 == 11 || cardValuePlayer1 == 12 || cardValuePlayer1 == 0)
            {
                cardValuePlayer1 = 10;
            }
            if (cardValuePlayer2 == 11 || cardValuePlayer2 == 12 || cardValuePlayer2 == 0)
            {
                cardValuePlayer2 = 10;
            }
            //We now assign the label to the total card values so the player can easily see the total values
            lblDealer.Text = Convert.ToString(cardValueDealer1);
            lblPlayer.Text = Convert.ToString(cardValuePlayer1 + cardValuePlayer2);
            btnHit.Enabled = true;
            btnDeal.Enabled = false;
            btnStay.Enabled = true;
            

        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            if (cardPlayer3 == 0)
            {
                //gives value a random number, and ensures that it will not have the same number as the other values
                cardPlayer3 = r.Next(1, 53);
                do
                {
                    cardPlayer3 = r.Next(1, 53);
                } while (cardPlayer3 == cardDealer1 | cardPlayer3 == cardDealer2 || cardPlayer3 == cardPlayer1 || cardPlayer3 == cardPlayer2);

                //Assigns the correct picture to the cards
                cardFile = "Card Images/card" + cardPlayer3 + ".JPG";
                picPlayer3.Image = Image.FromFile(cardFile);

                //Sets the Jack, Queen, and king to 10 points
                cardValuePlayer3 = cardPlayer3 % 13;

                if (cardValuePlayer3 == 11 || cardValuePlayer3 == 12 || cardValuePlayer3 == 0)
                {
                    cardValuePlayer3 = 10;
                }
                lblPlayer.Text = Convert.ToString(cardValuePlayer1 + cardValuePlayer2 + cardValuePlayer3);
            
            }

            // only triggers when card player 3 has a variable, meaning that it will trigger the second time the player clicks hit
            else if (cardPlayer3 >= 1 && cardPlayer4 == 0)
            {

                //gives value a random number, and ensures that it will not have the same number as the other values
                cardPlayer4 = r.Next(1, 53);
                do
                {
                    cardPlayer4 = r.Next(1, 53);
                } while (cardPlayer4 == cardDealer1 || cardPlayer4 == cardDealer2 || cardPlayer4 == cardPlayer1 || cardPlayer4 == cardPlayer2 || cardPlayer4 == cardPlayer3 || cardPlayer4 == cardDealer3 || cardPlayer4 == cardDealer4 || cardPlayer4 == cardDealer5);

                //Assigns the correct picture to the cards
                cardFile = "Card Images/card" + cardPlayer4 + ".JPG";
                picPlayer4.Image = Image.FromFile(cardFile);

                //Sets the Jack, Queen, and king to 10 points
                cardValuePlayer4 = cardPlayer4 % 13;
                 if (cardValuePlayer4 == 11 || cardValuePlayer4 == 12 || cardValuePlayer4 == 0)
                 {
                     cardValuePlayer4 = 10;
                 } 
                //updates the players total card value
                lblPlayer.Text = Convert.ToString(cardValuePlayer1 + cardValuePlayer2 + cardValuePlayer3 + cardValuePlayer4);
                player2.URL = "I got this.mp3";
            }

            // only triggers when card player 4 has a variable, meaning that it will trigger the third time the player clicks hit
            else if (cardPlayer4 >= 1 && cardPlayer5 == 0)
            {

                //gives value a random number, and ensures that it will not have the same number as the other values
                cardPlayer5 = r.Next(1, 53);
                do
                {
                    cardPlayer5 = r.Next(1, 53);
                } while (cardPlayer5 == cardDealer1 || cardPlayer5 == cardDealer2 || cardPlayer5 == cardPlayer1 || cardPlayer5 == cardPlayer2 || cardPlayer5 == cardPlayer3 || cardPlayer5 == cardDealer3 || cardPlayer5 == cardDealer4 || cardPlayer5 == cardDealer5 || cardPlayer5 == cardPlayer4);

                //Assigns the correct picture to the cards
                cardFile = "Card Images/card" + cardPlayer5 + ".JPG";
                picPlayer5.Image = Image.FromFile(cardFile);

                //Sets the Jack, Queen, and king to 10 points
                cardValuePlayer5 = cardPlayer5 % 13;
                if (cardValuePlayer5 == 11 || cardValuePlayer5 == 12 || cardValuePlayer5 == 0)
                {
                    cardValuePlayer5 = 10;
                }

                //updates the players card value
                lblPlayer.Text =Convert.ToString(cardValuePlayer1 + cardValuePlayer2 + cardValuePlayer3 + cardValuePlayer4 + cardValuePlayer5);
                player2.URL = "Hold it Partner";
            }

            // if the players total card value is over 21
            if (Convert.ToInt16(lblPlayer.Text) > 21)
            {
                lblMessage.Text = "You lost your money!!!";
                btnHit.Enabled = false;
                btnStay.Enabled = false;
                btnBet.Enabled = true;
                player2.URL ="Just the luck of the draw.mp3";
            }
            
            //if the dealers total card value is over 21
            if(Convert.ToInt16(lblDealer.Text) > 21)
            {
                lblMessage.Text = "You stole my money!!!";
                btnHit.Enabled = false;
                btnStay.Enabled = false;
                btnBet.Enabled = true;
                player2.URL = "Simmer down hotshot.mp3";
            }

            //If the player has no money after staying and not winning, he loses.
            if (Convert.ToInt16(lblMoney.Text) <= 0 && Convert.ToInt16(lblPlayer.Text) > 21)
            {
                btnBet.Enabled = false;
                btnHit.Enabled = false;
                btnStay.Enabled = false;
                player2.URL = "It aint luck its destiny.mp3";
                MessageBox.Show("Better 'Luck' next time");


              
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //This lets the player completely reset the game
            Form1 F = new Form1();
            F.Show();
            this.Dispose(false);
            player2.URL = "Laugh.mp3";
            player.URL = "";
            MessageBox.Show("So bad you had to restart?");
            
        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            int finalplayer;
            int finaldealer;
            int carddealerfiller;

            //gives value a random number, and ensures that it will not have the same number as the other values
            cardDealer2 = r.Next(1, 53);
            do
            {
                cardDealer2 = r.Next(1, 53);
            } while (cardDealer1 == cardDealer2);

            cardValueDealer2 = cardDealer2 % 13;
            if (cardValueDealer2 == 11 || cardValueDealer2 == 12 || cardValueDealer2 == 0)
            {
                cardValueDealer2 = 10;
            }
            cardDealertotal = cardValueDealer1 + cardValueDealer2;
            lblDealer.Text = Convert.ToString(cardValueDealer1 + cardValueDealer2);

            //Assigns the correct picture to the cards
            cardFile = "Card Images/card" + cardDealer2 + ".JPG";
            picDealer2.Image = Image.FromFile(cardFile);

            //if the total value is less that 16, the dealer will draw a card.
            if (cardDealertotal <= 16)
            {
             cardDealer3 = r.Next(1, 53);

             do
             {
                 cardDealer3 = r.Next(1, 53);
             } while (cardDealer3 == cardDealer1 || cardDealer3 == cardDealer2 || cardDealer3 == cardPlayer1 || cardDealer3 == cardPlayer2 || cardDealer3 == cardPlayer3);

             cardValueDealer3 = cardDealer3 % 13;
             if (cardValueDealer3 == 11 || cardValueDealer3 == 12 || cardValueDealer3 == 0)
             {
                 cardValueDealer3 = 10;
             }
             //assigns the dealers total value to a variable
             

             

                 cardFile = "Card Images/card" + cardDealer3 + ".JPG";
                 picDealer3.Image = Image.FromFile(cardFile);

                 lblDealer.Text = Convert.ToString(cardValueDealer1 + cardValueDealer2 + cardValueDealer3);

                 if (Convert.ToInt16(lblDealer.Text) > 21)
                 {
                     lblMessage.Text = "You stole my money!!!";
                     btnHit.Enabled = false;
                     btnStay.Enabled = false;
                     btnBet.Enabled = true;
                     player2.URL = "Simmer down hotshot.mp3";
                 }
             }
             
            // if the dealer  has less total points then the player, and the player is not over 21, he will assign card 4 a value.
             if ( cardValueDealer1 + cardValueDealer2 + cardValueDealer3 <= 16)
             {
                //gives value a random number, and ensures that it will not have the same number as the other values
                cardDealer4 = r.Next(1, 53);
                do
                {
                    cardDealer4 = r.Next(1, 53);
                } while (cardDealer4 == cardDealer1 || cardDealer4 == cardDealer2 || cardDealer4 == cardPlayer1 || cardDealer4 == cardPlayer2 || cardDealer4 == cardPlayer3 || cardDealer4 == cardDealer3 || cardDealer4 == cardPlayer4 || cardDealer4 == cardPlayer5);
                 
                 //Sets the Jack, Queen, and king to 10 points
                cardValueDealer4 = cardDealer4 % 13;
                if (cardValueDealer4 == 11 || cardValueDealer4 == 12 || cardValueDealer4 == 0)
                {
                    cardValueDealer4 = 10;
                }


              // show picture and adjust label total ( draw another card)
                    cardFile = "Card Images/card" + cardDealer4 + ".JPG";
                    picDealer4.Image = Image.FromFile(cardFile);
                    lblDealer.Text = Convert.ToString(cardValueDealer1 + cardValueDealer2 + cardValueDealer3 + cardValueDealer4);

                    //if the dealers total card value is over 21
                    if (Convert.ToInt16(lblDealer.Text) > 21)
                    {
                        lblMessage.Text = "You stole my money!!!";
                        btnHit.Enabled = false;
                        btnStay.Enabled = false;
                        btnBet.Enabled = true;
                        player2.URL = "Simmer down hotshot.mp3";
                    }
                
            }
            

        
            //if the dealer has less total points then the player, and the player is not over 21, he will draw another card.
             if (cardValueDealer1 + cardValueDealer2 + cardValueDealer3 + cardValueDealer4 <= 16)
             {
                 //gives value a random number, and ensures that it will not have the same number as the other values
                 cardDealer5 = r.Next(1, 53);
                 do
                 {
                     cardDealer5 = r.Next(1, 53);
                 } while (cardDealer5 == cardDealer1 || cardDealer5 == cardDealer2 || cardDealer5 == cardPlayer1 || cardDealer5 == cardPlayer2 || cardDealer5 == cardPlayer3 || cardDealer5 == cardDealer3 || cardDealer5 == cardDealer4 || cardDealer5 == cardPlayer4 || cardDealer5 == cardPlayer5);

                 //Sets the Jack, Queen, and king to 10 points
                 cardValueDealer5 = cardDealer5 % 13;
                 if (cardValueDealer5 == 11 || cardValueDealer5 == 12 || cardValueDealer5 == 0)
                 {
                     cardValueDealer5 = 10;
                 }
                 //Assigns the correct picture to the cards
                 cardFile = "Card Images/card" + cardDealer5 + ".JPG";
                 picDealer5.Image = Image.FromFile(cardFile);
                     lblDealer.Text = Convert.ToString(cardValueDealer1 + cardValueDealer2 + cardValueDealer3 + cardValueDealer4 + cardValueDealer5);

                     //if the dealers total card value is over 21
                     if (Convert.ToInt16(lblDealer.Text) > 21)
                     {
                         lblMessage.Text = "You stole my money!!!";
                         btnHit.Enabled = false;
                         btnStay.Enabled = false;
                         btnBet.Enabled = true;
                         player2.URL = "Simmer down hotshot.mp3";
                     }
                 

             }
             //if the dealers total card value is over 21
             if (Convert.ToInt16(lblDealer.Text) > 21)
             {
                 lblMessage.Text = "You stole my money!!!";
                 btnHit.Enabled = false;
                 btnStay.Enabled = false;
                 btnBet.Enabled = true;
                 player2.URL = "Simmer down hotshot.mp3";
             }

            {
                //assigning final variables
               finaldealer = Convert.ToInt16(lblDealer.Text);
             finalplayer = Convert.ToInt16(lblPlayer.Text);
                //different possible outcomes
                if (finalplayer > 21)
                {
                    lblMessage.Text = "You lost your money!!!";
                }
                else if (finaldealer > 21)
                {
                    lblMessage.Text = "You stole my money!!!";
                    player2.URL = "Simmer down hotshot.mp3";
                }
            
                else if (finalplayer > finaldealer)
                {
                    lblMessage.Text = "You stole my money!!!";
                }
                else if (finaldealer > finalplayer)
                {
                    lblMessage.Text = "You lost your money!!!";
                    player2.URL = "Just the luck of the draw.mp3";
                }
                else if (finaldealer == finalplayer)
                {
                    lblMessage.Text = "How Unfortunate...";
                }
                else if (finaldealer > 21 && finalplayer > 21)
                {
                    lblMessage.Text = "We Both Suck";
                }
                else if (finaldealer > 21 && finalplayer <= 21)
                {
                    lblMessage.Text = "You stole my money!!!";
                }
                else if (finaldealer <= 21 && finalplayer > 21)
                {
                    lblMessage.Text = "You lost your money!!!";
                }
                //if the user wins, he gains the money from the pot.
                if (lblMessage.Text == "You stole my money!!!")
                {
                   
                    pot = Convert.ToInt16(lblPot.Text);
                    cash = Convert.ToInt16(lblMoney.Text);
                    money2 =Convert.ToInt16 (pot + cash);
                    lblMoney.Text =Convert.ToString (money2);
                }

                //If the player has no money after staying and not winning, he loses.
                if (Convert.ToInt16(lblMoney.Text) <= 0)
                {
                    btnBet.Enabled = false;
                    btnHit.Enabled = false;
                    btnStay.Enabled = false;
                    player2.URL = "It aint luck its destiny.mp3";
                    MessageBox.Show("Better 'Luck' next time");
                }
                //removes hit and stay and allows a bet

                btnBet.Enabled = true;
                btnHit.Enabled = false;
                btnStay.Enabled = false;
                
            }
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.URL = "Saloon Music - Breaktime.mp3";
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt16(txtBet.Text) <= Convert.ToInt16(lblMoney.Text))
            {
            bet = Convert.ToInt16 (txtBet.Text) * 2;
            money = money2 - bet/2;
            lblPot.Text = Convert.ToString (bet);
            lblMoney.Text = Convert.ToString (money);
            money2 = Convert.ToInt16(lblMoney.Text);
            btnBet.Enabled = false;
            btnDeal.Enabled = true;
            if (money2 == 0)
            {
                player2.URL = "All or nothing.mp3";
            }
            else
            {
                player2.URL = "lets raise the stakes.mp3";
            }
            //reset all values
            cardDealer1 = 0;
            cardDealer2 = 0;
            cardDealer3 = 0;
            cardDealer4 = 0;
            cardDealer5 = 0;
            cardPlayer1 = 0;
            cardPlayer2 = 0;
            cardPlayer3 = 0;
            cardPlayer4 = 0;
            cardPlayer5 = 0;
            //reset all images
            picDealer1.Image = Image.FromFile("Card Images/CardBack.jpg");
            picDealer2.Image = Image.FromFile("Card Images/CardBack.jpg");
            picDealer3.Image = Image.FromFile("Card Images/CardBack.jpg");
            picDealer4.Image = Image.FromFile("Card Images/CardBack.jpg");
            picDealer5.Image = Image.FromFile("Card Images/CardBack.jpg");
            picPlayer1.Image = Image.FromFile("Card Images/CardBack.jpg");
            picPlayer2.Image = Image.FromFile("Card Images/CardBack.jpg");
            picPlayer3.Image = Image.FromFile("Card Images/CardBack.jpg");
            picPlayer4.Image = Image.FromFile("Card Images/CardBack.jpg");
            picPlayer5.Image = Image.FromFile("Card Images/CardBack.jpg");
            //reset all texts
            lblPlayer.Text = "";
            lblDealer.Text = "";
            lblMessage.Text = "";
            }
            else
            {
                player2.URL = "Hold it Partner.mp3";
                MessageBox.Show("You cant bet more then you own, idiot");
               
            }
        }

        private void lblMoney_Click(object sender, EventArgs e)
        {

        }

        private void picDealer1_Click(object sender, EventArgs e)
        {

        }
    }
}
