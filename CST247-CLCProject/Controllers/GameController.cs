using CST247_CLCProject.Models;
using System;
using System.Drawing;
using System.Web.Mvc;

namespace CST247_CLCProject.Controllers
{
    public class GameController : Controller
    {
        static Game game = new Game();
        
        
        Random random = new Random();
        // GET: Button
        public ActionResult Index()
        {
            game.board.activeSomeCellswithBombs();
            game.board.calcualateNeighbors();
            
            return View("Game", game);
        }

        public ActionResult HandleButtonClick(string mine)
        {

            // mine example 13|9

            String[] rc = mine.Split('|');

            Point p = new Point(Int32.Parse(rc[0]), Int32.Parse(rc[1]));

            //int buttonNumber = int.Parse(mine);
            //buttons[buttonNumber].State = !buttons[buttonNumber].State;
            //return View("Button", buttons);

            game.board.theGrid[p.X, p.Y].isVisited = true;

            game.PlaceTurn(p.X, p.Y);
            
              
            return View("Game", game);
        }

        // winGame method returns to WinGame page when user win the game
        //public static ActionResult winGame()
        //{
            

        //    return View("WinGame");
        //}
        //public static ActionResult loseGame()
        //{


        //    return View("LoseGame");
        //}
    }
}