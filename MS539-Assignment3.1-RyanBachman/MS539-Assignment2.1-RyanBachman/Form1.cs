using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Windows.Data.Json;
using Windows.Devices.Geolocation;
using Windows.System;
using Windows.UI.ViewManagement;

namespace MS539_Assignment3._1_RyanBachman
{
    public partial class MTGScout : Form
    {
        // Public variables to easily set the json key values to the CardInfo class, even in private functions.
        public string cardName;
        public string setName;
        public string cardImage;
        public string cardDetails;
        public string power;
        public string toughness;
        public string price;
        public string priceFoil;
        public string priceEtched;
        public string manaCost;
        public string flavorText;

        public MTGScout()
        {
            InitializeComponent();
        }

        // Create a card class for the Card being searched and house it's details using getters/setters.
        public class CardInfo
        {
            public string CardName { get; set; }
            public string SetName { get; set; }
            public string CardImage { get; set; }
            public string CardDetails { get; set; }
            public string Power { get; set; }
            public string Toughness { get; set; }
            public string Price { get; set; }
            public string PriceFoil { get; set; }
            public string PriceEtched { get; set; }
            public string ManaCost { get; set; }
            public string FlavorText { get; set; }

        }

        private async void GetSearchJson() // Search method to find the card and details you want in the Scryfall API.
        {
            using (var httpClient = new HttpClient()) // Set a new HttpClient connection
            {
                // Uses a try/catch to ensure that a valid card is being returned. If no card is returned, output a message to the user.
                try // Try to get the Json using the text search.
                {
                    string userInput = searchTB.Text.ToString(); ;

                    // Added a null/empty check for user input to let them
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        // 01/26/2024 - Updated the httpClient API call to check there's user input and not null and called the variable rather than the hard-coded text method.
                        var json = await httpClient.GetStringAsync("https://api.scryfall.com/cards/search?page=1&q=name%3A" + userInput); // Build a search on the Scryfall API using the text box value.

                        // Create a new card object to house received info from JSON.
                        CardInfo card = new CardInfo();

                        // Set new JObjects from the overall code to house data from nested objects like data.name or image_uris.large.
                        var data = JObject.Parse(json)["data"][0];
                        var imageData = JObject.Parse(json)["data"][0]["image_uris"];
                        var priceData = JObject.Parse(json)["data"][0]["prices"];

                        // Start setting card object attributes to what's received from API.
                        card.CardName = data["name"].ToString();
                        card.SetName = data["set_name"].ToString();

                        // If no image attribute is found, set a default image from resources.
                        if (JObject.Parse(json)["image_uris"] != null)
                        {
                            card.CardImage = imageData["large"].ToString();
                            searchPB.Visible = true;
                            searchPB.Load(card.CardImage);
                        }
                        else
                        {
                            searchPB.Visible = true;
                            searchPB.Image = Properties.Resources.NoImage;
                        }
                        card.CardImage = imageData["large"].ToString();

                        // If no oracle text attribute is found, default to N/A.
                        if (JObject.Parse(json)["data"][0]["oracle_text"] != null)
                        {
                            card.CardDetails = data["oracle_text"].ToString();
                        }
                        else
                        {
                            card.CardDetails = "N/A";
                        }

                        // Not all cards have Power. Error handling for cards that dont come with Power. N/A if no Power key is found.
                        if (JObject.Parse(json)["data"][0]["power"] != null)
                        {
                            card.Power = data["power"].ToString();
                        }
                        else
                        {
                            card.Power = "N/A";
                        }

                        // Not all cards have Toughness. Error handling for cards that dont come with Toughness. N/A if no Toughness key is found.
                        if (JObject.Parse(json)["data"][0]["toughness"] != null)
                        {
                            card.Toughness = data["toughness"].ToString();
                        }
                        else
                        {
                            card.Toughness = "N/A";
                        }

                        card.Price = priceData["usd"].ToString();
                        card.PriceFoil = priceData["usd_foil"].ToString();
                        card.PriceEtched = priceData["usd_etched"].ToString();

                        // Not all cards have Mana Costs. Error handling for cards that dont come with Mana Costs. N/A if no Mana Cost key is found.
                        if (JObject.Parse(json)["data"][0]["mana_cost"] != null)
                        {
                            card.ManaCost = data["mana_cost"].ToString();
                        }
                        else
                        {
                            card.ManaCost = "N/A";
                        }

                        // Not all cards have Flavor Text. Error handling for cards that dont come with Flavor Text. N/A if no Flavor Text key is found.
                        if (JObject.Parse(json)["data"][0]["flavor_text"] != null)
                        {
                            card.FlavorText = data["flavor_text"].ToString();
                        }
                        else
                        {
                            card.FlavorText = "N/A";
                        }

                        // Clear the listbox for a fresh pull each time a search is conducted.
                        CardDetailLB.Items.Clear();
                        CardDetailLB.Items.Add("Name: " + card.CardName);
                        CardDetailLB.Items.Add("Set: " + card.SetName);
                        // Set the picture box to load the image url found in the API pull.
                        searchPB.Load(card.CardImage);
                        CardDetailLB.Items.Add("Details: " + card.CardDetails);
                        CardDetailLB.Items.Add("Power: " + card.Power);
                        CardDetailLB.Items.Add("Toughness: " + card.Toughness);
                        CardDetailLB.Items.Add("Price (USD): " + card.Price);
                        CardDetailLB.Items.Add("Foil Price (USD): " + card.PriceFoil);
                        CardDetailLB.Items.Add("Etched Price (USD): " + card.PriceEtched);
                        CardDetailLB.Items.Add("Mana Cost: " + card.ManaCost);
                        CardDetailLB.Items.Add("Flavor Text: " + card.FlavorText);
                    }
                    else
                    {
                        MessageBox.Show("The search box is empty. Please type in a valid card name in the search box.", "Search Error");
                    }
                }
                catch
                {
                    MessageBox.Show("This card was not found, try searching for a valid card.", "Search Error");
                }
            }
        }

        private async void GetRandomCard() // Random method to get a random card with your selected variables like mana color or mana cost.
        {
            using (var httpClient = new HttpClient()) // Set a new HttpClient connection
            {
                // Uses a try/catch to ensure that a valid card is being returned. If no card is returned, output a message to the user.
                try // Try to get the Json using the text search.
                {
                    string randomQueryBuilder = null;
                    string searchText = null;
                    string manaSymbol = null;

                    if (RandomLB.CheckedItems.Count > 0) // Check if a listbox item is selected to generate the search query.
                    {
                        string[] manaList = RandomLB.CheckedItems.OfType<string>().ToArray();

                        foreach (string listItem in manaList)
                        {
                            switch (listItem)
                            {
                                case "Black":
                                    manaSymbol = "B";
                                    break;
                                case "White":
                                    manaSymbol = "W";
                                    break;
                                case "Green":
                                    manaSymbol = "G";
                                    break;
                                case "Blue":
                                    manaSymbol = "U";
                                    break;
                                case "Red":
                                    manaSymbol = "R";
                                    break;
                            }

                            searchText += manaSymbol + ",";
                        }

                        // string searchList = selected.Select(p => p.Value).ToArray().Aggregate((current, next) => current + "," + next);
                        randomQueryBuilder = "colors%3A" + searchText;
                    }
                    else // If nothing selected, fully random search the API.
                    {
                        randomQueryBuilder = null;
                    }

                    // 01/26/2024 - Updated the httpClient API call to check there's user input and not null and called the variable rather than the hard-coded text method.
                    var json = await httpClient.GetStringAsync("https://api.scryfall.com/cards/random?page=1&q=" + randomQueryBuilder); // Build a search on the Scryfall API using the text box value.

                    // Create a new card object to house received info from JSON.
                    CardInfo card = new CardInfo();

                    // Set new JObjects from the overall code to house data from nested objects like data.name or image_uris.large.
                    var data = JObject.Parse(json);
                    var imageData = JObject.Parse(json)["image_uris"];
                    var priceData = JObject.Parse(json)["prices"];

                    // Start setting card object attributes to what's received from API.
                    card.CardName = data["name"].ToString();
                    card.SetName = data["set_name"].ToString();

                    // If no image attribute is found, set a default image from resources.
                    if (JObject.Parse(json)["image_uris"] != null)
                    {
                        card.CardImage = imageData["large"].ToString();
                        randomPB.Visible = true;
                        randomPB.Load(card.CardImage);
                    }
                    else
                    {
                        randomPB.Visible = true;
                        randomPB.Image = Properties.Resources.NoImage;
                    }

                    // If no oracle text attribute is found, default to N/A.
                    if (JObject.Parse(json)["oracle_text"] != null)
                    {
                        card.CardDetails = data["oracle_text"].ToString();
                    }
                    else
                    {
                        card.CardDetails = "N/A";
                    }

                    // Not all cards have Power. Error handling for cards that dont come with Power. N/A if no Power key is found.
                    if (JObject.Parse(json)["power"] != null)
                    {
                        card.Power = data["power"].ToString();
                    }
                    else
                    {
                        card.Power = "N/A";
                    }

                    // Not all cards have Toughness. Error handling for cards that dont come with Toughness. N/A if no Toughness key is found.
                    if (JObject.Parse(json)["toughness"] != null)
                    {
                        card.Toughness = data["toughness"].ToString();
                    }
                    else
                    {
                        card.Toughness = "N/A";
                    }

                    card.Price = priceData["usd"].ToString();
                    card.PriceFoil = priceData["usd_foil"].ToString();
                    card.PriceEtched = priceData["usd_etched"].ToString();

                    // Not all cards have Mana Costs. Error handling for cards that dont come with Mana Costs. N/A if no Mana Cost key is found.
                    if (JObject.Parse(json)["mana_cost"] != null)
                    {
                        card.ManaCost = data["mana_cost"].ToString();
                    }
                    else
                    {
                        card.ManaCost = "N/A";
                    }

                    // Not all cards have Flavor Text. Error handling for cards that dont come with Flavor Text. N/A if no Flavor Text key is found.
                    if (JObject.Parse(json)["flavor_text"] != null)
                    {
                        card.FlavorText = data["flavor_text"].ToString();
                    }
                    else
                    {
                        card.FlavorText = "N/A";
                    }

                    // Clear the listbox for a fresh pull each time a search is conducted.
                    CardDetailLB.Items.Clear();
                    CardDetailLB.Items.Add("Name: " + card.CardName);
                    CardDetailLB.Items.Add("Set: " + card.SetName);
                    // Set the picture box to load the image url found in the API pull.
                    CardDetailLB.Items.Add("Details: " + card.CardDetails);
                    CardDetailLB.Items.Add("Power: " + card.Power);
                    CardDetailLB.Items.Add("Toughness: " + card.Toughness);
                    CardDetailLB.Items.Add("Price (USD): " + card.Price);
                    CardDetailLB.Items.Add("Foil Price (USD): " + card.PriceFoil);
                    CardDetailLB.Items.Add("Etched Price (USD): " + card.PriceEtched);
                    CardDetailLB.Items.Add("Mana Cost: " + card.ManaCost);
                    CardDetailLB.Items.Add("Flavor Text: " + card.FlavorText);
                }
                catch
                {
                    MessageBox.Show("Could not find a card. Something went wrong.", "Random Card Error");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Clicking this button will do the random search and set the image in the picture box and generate the card details from the JSON.
        private void randomBtn_Click(object sender, EventArgs e)
        {
            // Clear the listbox for a fresh pull each time a search is conducted.
            CardDetailLB.Items.Clear();
            searchPB.Image = null;
            searchPB.Visible = false;

            GetRandomCard();
        }

        // Clicking this button will search for whatever card the user is searching for in the searchTB GUI tool.
        private void searchBtn_Click(object sender, EventArgs e)
        {
            // Clear the listbox for a fresh pull each time a search is conducted.
            CardDetailLB.Items.Clear();
            randomPB.Image = null;
            randomPB.Visible = false;

            GetSearchJson();
        }

        private void searchTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Clear the listbox for a fresh pull each time a search is conducted.
                CardDetailLB.Items.Clear();
                randomPB.Image = null;
                randomPB.Visible = false;

                GetSearchJson();
                e.Handled = true;
            }
        }

        // Handles when the user wants to exit the application through the menu strip.
        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Future Addition: Add a new window to search top 10 selling cards per set.
        private void top10PricesSetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}