using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

/*
 * Ryan Bachman
 * 01/26/2024
 * MTG Scout - Search the Scryfall database for cards with useful details!
 * MS539 - Assignment 3.1: Basic GUI and Exception Handling
 * Spring 2024, Grad 1
 * 
 * Time Expectation to complete this assignment is 8 hours total.
 * 01/26/2024 - Added 3 more GUI elements and added some error checking. More details below
 *              Added error checking for cards without images and ensured that a default image is displayed in these cases.
 *              Added null checker for the text box to ensure the user enters a search term when pressing enter or clicking the search button.
 *              Added method to pull a random card with filters for what color cards you want to search for.
 *              Updated random card query to differ from search card query.
 *              Cleaned up the list box to use attributes that can be queried (mana color).
 *              Updated picture boxes to not be visible until an image is displayed.
 *              Added CheckOnClick property for the listbox to remove the need to double click.
 *              Add tooltips to the buttons to show the user what is happening.
 *              Added a menu bar for future additions. For now, added a way to exit application through the menu.
 *              Total time today for coding this project: 4 hours
 */

namespace MS539_Assignment3._1_RyanBachman
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MTGScout());
        }
    }
}
