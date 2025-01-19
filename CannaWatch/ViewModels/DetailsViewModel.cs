using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CannaWatch.Data;
using CannaWatch.Models;
using CannaWatch.Services;
using Microsoft.EntityFrameworkCore;

namespace CannaWatch.ViewModels
{
    public class DetailsViewModel
    {
        private AppDbContext _context;
        private readonly ChatGptClient _chatGptClient;

        
        private readonly Plant SelectedPlant;
        private readonly Strain SelectedStrain;

        public DetailsViewModel(Plant plant, string apiKey)
        {
            _context = new AppDbContext();
            SelectedPlant = plant;
            _chatGptClient = new ChatGptClient(apiKey);
            SelectedStrain = FindPlantByName(plant.Strain);
            Console.WriteLine(plant.Strain);


        }

        // Expose properties of the Plant object
        public string? PlantInfo => SelectedStrain.Description;
        public string Strain => SelectedPlant.Strain;
        public string ImageUrl => SelectedPlant.ImageUrl;

        public string? type => SelectedStrain.Type;

        public string? thcLevel => SelectedStrain.ThcLevel;

        public string? relaxedValue => SelectedStrain.RelaxedValue;
        public string? happyValue => SelectedStrain.HappyValue;
        public string? euphoricValue => SelectedStrain.EuphoricValue;
        public string? upliftedValue => SelectedStrain.UpliftedValue;
        public string? sleepyValue => SelectedStrain.SleepyValue;
        public string? dryMouthValue => SelectedStrain.DryMouthValue;
        public string? dryEyeValue => SelectedStrain.DryEyeValue;
        public string? dizzyValue => SelectedStrain.DizzyValue;

        public string? paranoidValue => SelectedStrain.ParanoidValue;
        public string? anxiousValue => SelectedStrain.AnxiousValue;
        public string? stressValue => SelectedStrain.StressValue;
        public string? painValue => SelectedStrain.PainValue;
        public string? depressionValue => SelectedStrain.DepressionValue;
        public string? anxietyValue => SelectedStrain.AnxietyValue;
        public string? insomniaValue => SelectedStrain.InsomniaValue;
        public DateTime LastWatered => SelectedPlant.LastWatered;
        public DateTime LastFed => SelectedPlant.LastFed;

       /* public async Task LoadPlantInfoAsync()
        {
            if (SelectedPlant != null)
            {
                PlantInfo = await _chatGptClient.GetPlantInfoAsync(SelectedPlant.Strain);
            }
        }*/

        public Strain? FindPlantByName(string strainName)
        {
            return _context.Strains.FirstOrDefault(p => p.Name == strainName);
        }

    }
}
