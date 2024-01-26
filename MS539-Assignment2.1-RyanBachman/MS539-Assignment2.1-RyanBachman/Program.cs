using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

/*
 * Time Expectation to complete this assignment is 20 hours total.
 * 01/18/2024 - 1 hour used for planning out what the application does, what tools will be used for the GUI and what dependencies are needed.
 * 01/19/2024 - 5 hours spent. Used this time to set up the GUI elements.
 *              Created a card class to house all of the details I'm showing from the API call.
 *              Connected to the Scryfall API in code and linked search features. 
 *              Listbox filters and cleans up values from specific keys a user would want to see.
 *              Added enter key event for text box so the button doesn't have to be used.
 * 01/20/2024 - 4 hours spent.
 *              Spent some time reviewing and learning up on HttpClient and making sure I'm selecting the right keys.
 *              Added a way to check each of the keys and get only what I want.
 *              Added in ways to dig into further arrays to get specific attributes.
 *              Updated UI elements to get the data from the API and send it to the user.
 *              Set up the picture box to load the picture URL from the API.
 * 01/21/2024 - 1 hour spent, cleaning up the program a little more and recording the video for the assignment.
 * Spent hours total: 11 hours
 * 
 * Future Additions
 *      - Add a way to select a set specific card, since some cards can show up in multiple sets.
 *      - 
 */

namespace MS539_Assignment2._1_RyanBachman
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
