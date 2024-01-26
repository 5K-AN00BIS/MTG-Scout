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

namespace MS539_Assignment2._1_RyanBachman
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

        /*
        private static async Task<CardInfo> NewtonsoftJsonStream(string uri, HttpClient httpClient)
        {
            using var httpResponse = await httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

            httpResponse.EnsureSuccessStatusCode(); // Will throw an error if no 200 response is received.

            if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
            {
                var jsonStream = await httpResponse.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(jsonStream);
                using var jsonReader = new JsonTextReader(streamReader);

                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    MessageBox.Show("Valid JSON received.", "HTTP Response", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return serializer.Deserialize<CardInfo>(jsonReader);
                }
                catch(JsonReaderException)
                {
                    MessageBox.Show("Invalid JSON format received.", "HTTP Response", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The HTTP response was not valid. Deserialization of JSON cannot be completed.", "HTTP Response", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }*/

        private async void GetSearchJson()
        {
            using (var httpClient = new HttpClient()) // Set a new HttpClient connection
            {
                try // Try to get the Json using the text search.
                {
                    var json = await httpClient.GetStringAsync("https://api.scryfall.com/cards/search?page=1&q=name%3A" + searchTB.Text.ToString()); // Build a search on the Scryfall API using the text box value.

                    // Create a new card object to house received info from JSON.
                    CardInfo card = new CardInfo();

                    // Set new JObjects from the overall code to house data from nested objects like data.name or image_uris.large.
                    var data = JObject.Parse(json)["data"][0];
                    var imageData = JObject.Parse(json)["data"][0]["image_uris"];
                    var priceData = JObject.Parse(json)["data"][0]["prices"];

                    // Start setting card object attributes to what's received from API.
                    card.CardName = data["name"].ToString();
                    card.SetName = data["set_name"].ToString();
                    card.CardImage = imageData["large"].ToString();
                    card.CardDetails = data["oracle_text"].ToString();

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
                    card.ManaCost = data["mana_cost"].ToString();

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
                catch
                {
                    MessageBox.Show("This card was not found, try searching for a valid card.");
                }
            }
        }

        private async void GetRandomCard()
        {
            using (var httpClient = new HttpClient()) // Set a new HttpClient connection
            {
                try // Try to get the Json using the text search.
                {
                    var json = await httpClient.GetStringAsync("https://api.scryfall.com/cards/search?page=1&q=" + searchTB.Text.ToString()); // Build a search on the Scryfall API using the text box value.
                }
                catch
                {
                    MessageBox.Show("Could not find a card. Something went wrong.");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // This list box will be used to select different values to search random cards within the selected parameters.
        private void RandomLB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Clicking this button will do the random search and set the image in the picture box and generate the card details from the JSON.
        private void randomBtn_Click(object sender, EventArgs e)
        {
            // Clear the listbox for a fresh pull each time a search is conducted.
            CardDetailLB.Items.Clear();
            searchPB.Image = null;

            GetRandomCard();
        }

        // Clicking this button will search for whatever card the user is searching for in the searchTB GUI tool.
        private void searchBtn_Click(object sender, EventArgs e)
        {
            GetSearchJson();
        }

        private void searchTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetSearchJson();
                e.Handled = true;
            }
        }
    }
}